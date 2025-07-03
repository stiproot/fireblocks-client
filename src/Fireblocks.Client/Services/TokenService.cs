using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Fireblocks.Client.Extensions;
using Fireblocks.Client.Abstractions;
using Microsoft.IdentityModel.Tokens;

namespace Fireblocks.Client.Services;

public class TokenService : ITokenService
{
	private readonly IFireblocksApiConfig _fireblocksApiConfig;
	private readonly IJwtConfig _jwtConfig;

	public TokenService(IFireblocksApiConfig fireblocksApiConfig, IJwtConfig jwtConfig)
	{
		_fireblocksApiConfig = fireblocksApiConfig ?? throw new ArgumentNullException(nameof(fireblocksApiConfig));
		_jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));
	}

	public string BuildToken(HttpRequestMessage requestMessage)
	{
		ArgumentNullException.ThrowIfNull(_fireblocksApiConfig.SecretKey, nameof(_fireblocksApiConfig.SecretKey));
		ArgumentNullException.ThrowIfNull(requestMessage, nameof(requestMessage));

		using RSA rsa = RSA.Create();

		rsa.ImportPkcs8PrivateKey(_fireblocksApiConfig.SecretKey.ToByteArray(), out _);

		var jwtSecurityToken = new JwtSecurityToken(
			claims: BuildClaims(requestMessage),
			signingCredentials: new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
			{
				CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
			}
		);

		return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
	}

	IEnumerable<Claim> BuildClaims(HttpRequestMessage requestMessage)
	{
		ArgumentNullException.ThrowIfNull(_fireblocksApiConfig.ApiKey, nameof(_fireblocksApiConfig.ApiKey));
		ArgumentNullException.ThrowIfNull(requestMessage.RequestUri, nameof(requestMessage.RequestUri));

		return new List<Claim>
		{
			new("uri", requestMessage.RequestUri.AbsolutePath.ToString()),
			new("nonce",_jwtConfig.Nonce),
			new(JwtRegisteredClaimNames.Iat, _jwtConfig.IssueAt.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
			new(JwtRegisteredClaimNames.Exp, _jwtConfig.IssueAt.AddSeconds(_jwtConfig.ExpiredInSeconds).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
			new(JwtRegisteredClaimNames.Sub, _fireblocksApiConfig.ApiKey),
			new("bodyHash", GetRequestBodyHash(requestMessage))
		};
	}

	static string GetRequestBodyHash(HttpRequestMessage requestMessage)
	{
		ArgumentNullException.ThrowIfNull(requestMessage, nameof(requestMessage));

		if (requestMessage.Content == null) return GetHash(null);

		var stream = requestMessage.Content.ReadAsStreamAsync().Result;
		var reader = new StreamReader(stream);
		var body = reader.ReadToEnd();
		stream.Seek(0, SeekOrigin.Begin);

		return GetHash(!string.IsNullOrEmpty(body) ? body : null);
	}

	static string GetHash(string? data)
	{
		using var sha256 = SHA256.Create();
		var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data ?? "\"\""));

		return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
	}
}

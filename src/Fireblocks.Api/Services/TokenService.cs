using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Fireblocks.Api.Extensions;
using Fireblocks.Api.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Fireblocks.Api.Services;

public class TokenService : ITokenService
{
	private readonly IFireblocksApiConfig _fireblocksApiConfig;
	private readonly IJwtConfig _jwtConfig;

	public TokenService(IFireblocksApiConfig fireblocksApiConfig, IJwtConfig jwtConfig)
	{
		_fireblocksApiConfig = fireblocksApiConfig ?? throw new ArgumentNullException(nameof(fireblocksApiConfig));
		_jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));
	}

	public string BuildToken(HttpRequestMessage request)
	{
		ArgumentNullException.ThrowIfNull(_fireblocksApiConfig.SecretKey, nameof(_fireblocksApiConfig.SecretKey));
		ArgumentNullException.ThrowIfNull(request, nameof(request));

		using RSA rsa = RSA.Create();
		rsa.ImportPkcs8PrivateKey(_fireblocksApiConfig.SecretKey.ToByteArray(), out _);

		var jwtSecurityToken = new JwtSecurityToken(
			claims: BuildClaims(request),
			signingCredentials: new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
			{
				CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
			}
		);

		return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
	}

	IEnumerable<Claim> BuildClaims(HttpRequestMessage request)
	{
		ArgumentNullException.ThrowIfNull(_fireblocksApiConfig.ApiKey, nameof(_fireblocksApiConfig.ApiKey));
		ArgumentNullException.ThrowIfNull(request.RequestUri, nameof(request.RequestUri));

		return new List<Claim>
		{
			new Claim("uri", request.RequestUri.AbsolutePath.ToString()),
			new Claim("nonce",_jwtConfig.Nonce),
			new Claim(
				JwtRegisteredClaimNames.Iat,
				_jwtConfig.IssueAt.ToUnixEpochDate().ToString(),
				ClaimValueTypes.Integer64),
			new Claim(
				JwtRegisteredClaimNames.Exp,
				_jwtConfig.IssueAt.AddSeconds(_jwtConfig.ExpiredInSeconds).ToUnixEpochDate().ToString(),
				ClaimValueTypes.Integer64),
			new Claim(JwtRegisteredClaimNames.Sub, _fireblocksApiConfig.ApiKey),
			new Claim("bodyHash", GetRequestBodyHash(request))
		};
	}

	static string GetRequestBodyHash(HttpRequestMessage request)
	{
		ArgumentNullException.ThrowIfNull(request, nameof(request));

		if (request.Content == null)
			return string.Empty;

		var stream = request.Content.ReadAsStreamAsync().Result;
		using var reader = new StreamReader(stream);
		var body = reader.ReadToEnd();
		stream.Seek(0, SeekOrigin.Begin);

		return GetHash(body);
	}

	static string GetHash(string data)
	{
		ArgumentNullException.ThrowIfNull(data, nameof(data));

		using var sha256 = SHA256.Create();
		var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));

		return Convert.ToHexString(bytes);
	}
}

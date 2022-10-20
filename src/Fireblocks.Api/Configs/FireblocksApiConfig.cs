namespace Fireblocks.Api.Configs;

/// <summary>
/// Fireblocks Api configuration
/// </summary>
public class FireblocksApiConfig
{
	/// <summary>
	/// Api base url
	/// </summary>
	public string BaseUrl { get; set; } = "https://api.fireblocks.io";

	/// <summary>
	/// The API Key to be provided to you by Fireblocks
	/// </summary>
	public string? ApiKey { get; set; }

	/// <summary>
	/// RSA 4096 private key (stored in fireblocks_secret.key)<br/>
	/// https://docs.fireblocks.com/api/#issuing-api-credentials
	/// </summary>
	public string? SecretKey { get; set; }
}

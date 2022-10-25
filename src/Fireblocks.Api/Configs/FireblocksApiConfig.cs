using Fireblocks.Api.Interfaces;

namespace Fireblocks.Api.Configs;

public class FireblocksApiConfig : IFireblocksApiConfig
{
	public string BaseUrl { get; set; } = "https://api.fireblocks.io";
	public string? ApiKey { get; set; }
	public string? SecretKey { get; set; }
}

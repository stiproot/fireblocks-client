using Fireblocks.Client.Abstractions;

namespace Fireblocks.Client.Configs;

public class FireblocksApiConfig : IFireblocksApiConfig
{
	public string BaseUrl { get; set; } = "https://api.fireblocks.io";
	public string Version { get; set; } = "v1";
	public required string ApiKey { get; set; }
	public required string SecretKey { get; set; }
}

using Fireblocks.Api.Interfaces;
using Unified;

namespace Fireblocks.Api.Configs;

public class JwtConfig : IJwtConfig
{
	public string Nonce { get; set; } = UnifiedId.NewId();
	public DateTime IssueAt { get; set; } = DateTime.UtcNow;
	public int ExpiredInSeconds { get; set; } = 25;
}

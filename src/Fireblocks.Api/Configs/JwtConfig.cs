using Fireblocks.Api.Interfaces;
using Unified;

namespace Fireblocks.Api.Configs;

public class JwtConfig : IJwtConfig
{
	public string Nonce { get; set; } = UnifiedId.NewId();
	public DateTimeOffset IssueAt { get; set; } = DateTimeOffset.UtcNow;
	public int ExpiredInSeconds { get; set; } = 25;
}

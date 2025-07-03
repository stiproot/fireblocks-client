using Fireblocks.Client.Abstractions;
using Unified;

namespace Fireblocks.Client.Configs;

public class JwtConfig : IJwtConfig
{
	public string Nonce { get; set; } = UnifiedId.NewId();
	public DateTimeOffset IssueAt { get; set; } = DateTimeOffset.UtcNow;
	public int ExpiredInSeconds { get; set; } = 25;
}

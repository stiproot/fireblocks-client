namespace Fireblocks.Api.Interfaces;

public interface IJwtConfig
{
	string Nonce { get; set; }
	DateTime IssueAt { get; set; }
	int ExpiredInSeconds { get; set; }
}

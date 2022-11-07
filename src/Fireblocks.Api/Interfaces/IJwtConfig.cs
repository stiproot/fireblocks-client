namespace Fireblocks.Api.Interfaces;

/// <summary>
/// Fireblocks Jwt configuration
/// </summary>
public interface IJwtConfig
{
	/// <summary>
	/// Unique number or string. Each API request needs to have a different nonce
	/// </summary>
	string Nonce { get; set; }

	/// <summary>
	/// The time at which the JWT was issued, in seconds since Epoch
	/// </summary>
	DateTimeOffset IssueAt { get; set; }

	/// <summary>
	/// The expiration time on and after which the JWT must not be accepted for processing, in seconds since Epoch<br/>
	/// Must be less than iat+30sec.
	/// </summary>
	int ExpiredInSeconds { get; set; }
}

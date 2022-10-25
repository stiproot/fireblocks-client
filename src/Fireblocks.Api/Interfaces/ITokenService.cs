namespace Fireblocks.Api.Interfaces;

/// <summary>
/// Authentication token service
/// </summary>
public interface ITokenService
{
	/// <summary>
	/// Build new token
	/// </summary>
	string BuildToken(HttpRequestMessage requestMessage);
}

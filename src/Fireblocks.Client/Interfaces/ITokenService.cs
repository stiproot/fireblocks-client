namespace Fireblocks.Client.Abstractions;

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

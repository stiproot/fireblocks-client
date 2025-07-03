using Refit;

namespace Fireblocks.Client.Abstractions;

[Headers("User-Agent: Fireblocks.Client", "Accept: application/json", "Content-Type: application/json")]
public interface IFireblocksApi
{
}

using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

public interface INetworkApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<NetworkConnectionModel>>> GetNetworkConnectionsAsync();

	[Get("/{connectionId}")]
	Task<ApiResponse<NetworkConnectionModel>> GetNetworkConnectionAsync(string connectionId);
}

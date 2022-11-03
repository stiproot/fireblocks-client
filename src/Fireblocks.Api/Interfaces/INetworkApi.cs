using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface INetworkApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<NetworkConnectionModel>>> GetNetworkConnectionsAsync();

	[Get("/{connectionId}")]
	Task<ApiResponse<NetworkConnectionModel>> GetNetworkConnectionAsync(string connectionId);
}

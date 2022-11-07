using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Services;

public class NetworkService : INetworkService
{
	private readonly INetworkApi _networkApi;

	public NetworkService(INetworkApi networkApi) =>
		_networkApi = networkApi;

	public async Task<ApiResponse<NetworkConnectionModel>> GetNetworkConnectionAsync(string connectionId) =>
		await _networkApi.GetNetworkConnectionAsync(connectionId);

	public async Task<ApiResponse<IEnumerable<NetworkConnectionModel>>> GetNetworkConnectionsAsync() =>
		await _networkApi.GetNetworkConnectionsAsync();
}

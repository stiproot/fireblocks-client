using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface INetworkService
{
	/// <summary>
	/// List Network Connections<br/>
	/// Retrieves all Fireblocks network connections<br/>
	/// https://docs.fireblocks.com/api/?#list-network-connections
	/// </summary>
	Task<ApiResponse<IEnumerable<NetworkConnectionModel>>> GetNetworkConnectionsAsync();

	/// <summary>
	/// Retrieve a Network Connection<br/>
	/// Retrieves a network connection matching the requested connectionId<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-a-network-connection
	/// </summary>
	Task<ApiResponse<NetworkConnectionModel>> GetNetworkConnectionAsync(string connectionId);
}

using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

/// <summary>
/// Asset services
/// </summary>
public interface IAssetService
{
	/// <summary>
	/// Retrieve all Assets Supported by Fireblocks<br/>
	/// https://docs.fireblocks.com/api/?#supported-assets
	/// </summary>
	Task<ApiResponse<IEnumerable<AssetTypeModel>>> GetSupportedAssetsAsync();
}

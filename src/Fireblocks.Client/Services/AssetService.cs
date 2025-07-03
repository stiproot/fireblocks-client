using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Services;

public class AssetService : IAssetService
{
	private readonly IAssetApi _assetApi;

	public AssetService(IAssetApi assetApi) => _assetApi = assetApi;

	public async Task<ApiResponse<IEnumerable<AssetTypeModel>>> GetSupportedAssetsAsync() =>
		await _assetApi.GetSupportedAssetsAsync();
}

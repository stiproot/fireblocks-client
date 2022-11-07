using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Services;

public class AssetService : IAssetService
{
	private readonly IAssetApi _assetApi;

	public AssetService(IAssetApi assetApi) =>
		_assetApi = assetApi;

	public async Task<ApiResponse<IEnumerable<AssetTypeModel>>> GetSupportedAssetsAsync() =>
		await _assetApi.GetSupportedAssetsAsync();
}

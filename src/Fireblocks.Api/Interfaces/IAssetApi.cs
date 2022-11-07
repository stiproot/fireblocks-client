using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IAssetApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<AssetTypeModel>>> GetSupportedAssetsAsync();
}

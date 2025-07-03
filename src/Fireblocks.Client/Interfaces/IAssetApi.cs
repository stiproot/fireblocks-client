using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

public interface IAssetApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<AssetTypeModel>>> GetSupportedAssetsAsync();
}

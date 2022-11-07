using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IExternalWalletApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<ExternalWalletModel>>> GetExternalWalletsAsync();

	[Post("")]
	Task<ApiResponse<ExternalWalletModel>> CreateExternalWalletAsync([Body] CreateExternalWalletModel payload);

	[Get("/{walletId}")]
	Task<ApiResponse<ExternalWalletModel>> GetExternalWalletAsync(string walletId);

	[Delete("/{walletId}")]
	Task<ApiResponse<string>> DeleteExternalWalletAsync(string walletId);

	[Get("/{walletId}/{assetId}")]
	Task<ApiResponse<ExternalWalletAssetModel>> GetExternalWalletAssetAsync(string walletId, string assetId);

	[Post("/{walletId}/{assetId}")]
	Task<ApiResponse<ExternalWalletAssetModel>> CreateExternalWalletAssetAsync(
		string walletId,
		string assetId,
		[Body] CreateExternalWalletAssetModel payload);

	[Delete("/{walletId}/{assetId}")]
	Task<ApiResponse<string>> DeleteExternalWalletAssetAsync(string walletId, string assetId);

	[Post("/{walletId}/set_customer_ref_id")]
	Task<ApiResponse<string>> SetCustomerRefIdForExternalWalletAsync(
		string walletId,
		[Body] SetCustomerRefIdForExternalWalletModel payload);
}

using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

public interface IInternalWalletApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<UnmanagedWalletModel>>> GetInternalWalletsAsync();

	[Post("")]
	Task<ApiResponse<UnmanagedWalletModel>> CreateInternalWalletAsync([Body] CreateInternalWalletModel payload);

	[Get("/{walletId}")]
	Task<ApiResponse<UnmanagedWalletModel>> GetInternalWalletAsync(string walletId);

	[Delete("/{walletId}")]
	Task<ApiResponse<string>> DeleteInternalWalletAsync(string walletId);

	[Get("/{walletId}/{assetId}")]
	Task<ApiResponse<WalletAssetModel>> GetInternalWalletAssetAsync(string walletId, string assetId);

	[Post("/{walletId}/{assetId}")]
	Task<ApiResponse<WalletAssetModel>> CreateInternalWalletAssetAsync(
		string walletId,
		string assetId,
		[Body] CreateInternalWalletAssetModel payload);

	[Delete("/{walletId}/{assetId}")]
	Task<ApiResponse<string>> DeleteInternalWalletAssetAsync(string walletId, string assetId);

	[Post("/{walletId}/set_customer_ref_id")]
	Task<ApiResponse<string>> SetCustomerRefIdForInternalWalletAsync(
		string walletId,
		[Body] SetCustomerRefIdForInternalWalletModel payload);
}

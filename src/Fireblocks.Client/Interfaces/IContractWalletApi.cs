using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

public interface IContractWalletApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<UnmanagedContractModel>>> GetContractWalletsAsync();

	[Post("")]
	Task<ApiResponse<UnmanagedContractModel>> CreateContractWalletAsync([Body] CreateContractWalletModel payload);

	[Get("/{walletId}")]
	Task<ApiResponse<UnmanagedContractModel>> GetContractWalletAsync(string walletId);

	[Delete("/{walletId}")]
	Task<ApiResponse<string>> DeleteContractWalletAsync(string walletId);

	[Get("/{walletId}/{assetId}")]
	Task<ApiResponse<ContractAssetModel>> GetContractWalletAssetAsync(string walletId, string assetId);

	[Post("/{walletId}/{assetId}")]
	Task<ApiResponse<ContractAssetModel>> CreateContractWalletAssetAsync(
		string walletId,
		string assetId,
		[Body] CreateContractWalletAssetModel payload);

	[Delete("/{walletId}/{assetId}")]
	Task<ApiResponse<string>> DeleteContractWalletAssetAsync(string walletId, string assetId);
}

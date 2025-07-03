using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

/// <summary>
/// Contract wallet services
/// </summary>
public interface IContractWalletService
{
	/// <summary>
	/// List Contract Wallets<br/>
	/// Lists contract wallets in your workspace<br/>
	/// https://docs.fireblocks.com/api/#list-contract-wallets
	/// </summary>
	Task<ApiResponse<IEnumerable<UnmanagedContractModel>>> GetContractWalletsAsync();

	/// <summary>
	/// Create a Contract Wallet<br/>
	/// Creates a new contract wallet<br/>
	/// https://docs.fireblocks.com/api/#create-a-contract-wallet
	/// </summary>
	Task<ApiResponse<UnmanagedContractModel>> CreateContractWalletAsync(CreateContractWalletModel payload);

	/// <summary>
	/// Get a Contract Wallet<br/>
	/// Finds a specific contract wallet by ID<br/>
	/// https://docs.fireblocks.com/api/#get-a-contract-wallet
	/// </summary>
	Task<ApiResponse<UnmanagedContractModel>> GetContractWalletAsync(string walletId);

	/// <summary>
	/// Delete a Contract Wallet<br/>
	/// Deletes a contract wallet by ID<br/>
	/// https://docs.fireblocks.com/api/#delete-a-contract-wallet
	/// </summary>
	Task<ApiResponse<string>> DeleteContractWalletAsync(string walletId);

	/// <summary>
	/// Get an Asset from a Contract Wallet<br/>
	/// Returns a contract wallet asset by ID<br/>
	/// https://docs.fireblocks.com/api/#get-an-asset-from-a-contract-wallet
	/// </summary>
	Task<ApiResponse<ContractAssetModel>> GetContractWalletAssetAsync(string walletId, string assetId);

	/// <summary>
	/// Add an Asset to a Contract Wallet<br/>
	/// Adds an asset to an existing contract wallet<br/>
	/// https://docs.fireblocks.com/api/#add-an-asset-to-a-contract-wallet
	/// </summary>
	Task<ApiResponse<ContractAssetModel>> CreateContractWalletAssetAsync(
		string walletId,
		string assetId,
		CreateContractWalletAssetModel payload);

	/// <summary>
	/// Delete an Asset from a Contract Wallet<br/>
	/// Deletes a contract wallet asset by ID<br/>
	/// https://docs.fireblocks.com/api/#delete-an-asset-from-a-contract-wallet
	/// </summary>
	Task<ApiResponse<string>> DeleteContractWalletAssetAsync(string walletId, string assetId);
}

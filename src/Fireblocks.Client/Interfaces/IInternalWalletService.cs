using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

/// <summary>
/// Internal wallet services
/// </summary>
public interface IInternalWalletService
{
	/// <summary>
	/// List Internal Wallets<br/>
	/// Retrieves all Internal Wallets in your workspace<br/>
	/// https://docs.fireblocks.com/api/#list-internal-wallets
	/// </summary>
	Task<ApiResponse<IEnumerable<UnmanagedWalletModel>>> GetInternalWalletsAsync();

	/// <summary>
	/// Create a New Internal Wallet<br/>
	/// Creates a new Internal Wallet container<br/>
	/// https://docs.fireblocks.com/api/#create-a-new-internal-wallet
	/// </summary>
	Task<ApiResponse<UnmanagedWalletModel>> CreateInternalWalletAsync(CreateInternalWalletModel payload);

	/// <summary>
	/// Retrieve an Internal Wallet<br/>
	/// Retrieves all assets under the Internal Wallet<br/>
	/// https://docs.fireblocks.com/api/#retrieve-an-internal-wallet
	/// </summary>
	Task<ApiResponse<UnmanagedWalletModel>> GetInternalWalletAsync(string walletId);

	/// <summary>
	/// Delete an Internal Wallet<br/>
	/// Deletes an Internal Wallet container<br/>
	/// https://docs.fireblocks.com/api/#delete-an-internal-wallet
	/// </summary>
	Task<ApiResponse<string>> DeleteInternalWalletAsync(string walletId);

	/// <summary>
	/// Retrieve an Asset from an Internal Wallet<br/>
	/// Retrieves the information on a specific asset within an Internal Wallet<br/>
	/// https://docs.fireblocks.com/api/#retrieve-an-asset-from-an-internal-wallet
	/// </summary>
	Task<ApiResponse<WalletAssetModel>> GetInternalWalletAssetAsync(string walletId, string assetId);

	/// <summary>
	/// Add an Asset to an Internal Wallet<br/>
	/// Adds an address to an existing Internal Wallet container<br/>
	/// https://docs.fireblocks.com/api/#add-an-asset-to-an-internal-wallet
	/// </summary>
	Task<ApiResponse<WalletAssetModel>> CreateInternalWalletAssetAsync(
		string walletId,
		string assetId,
		CreateInternalWalletAssetModel payload);

	/// <summary>
	/// Delete a Whitelisted Address from an Internal Wallet<br/>
	/// Deletes a whitelisted address (for an asset) from an Internal Wallet<br/>
	/// https://docs.fireblocks.com/api/#delete-a-whitelisted-address-from-an-internal-wallet
	/// </summary>
	Task<ApiResponse<string>> DeleteInternalWalletAssetAsync(string walletId, string assetId);

	/// <summary>
	/// Set an AML Customer Reference ID for an Internal Wallet<br/>
	/// Sets an AML/KYT customer reference ID for the specific internal wallet<br/>
	/// https://docs.fireblocks.com/api/#set-an-aml-customer-reference-id-for-an-internal-wallet
	/// </summary>
	Task<ApiResponse<string>> SetCustomerRefIdForInternalWalletAsync(
		string walletId,
		SetCustomerRefIdForInternalWalletModel payload);
}

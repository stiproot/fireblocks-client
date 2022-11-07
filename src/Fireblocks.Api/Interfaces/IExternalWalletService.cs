using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

/// <summary>
/// External wallet services
/// </summary>
public interface IExternalWalletService
{
	/// <summary>
	/// List External Wallets<br/>
	/// Retrieves all External Wallets in your workspace<br/>
	/// https://docs.fireblocks.com/api/#list-external-wallets
	/// </summary>
	Task<ApiResponse<IEnumerable<ExternalWalletModel>>> GetExternalWalletsAsync();

	/// <summary>
	/// Create a New External Wallet<br/>
	/// https://docs.fireblocks.com/api/#create-a-new-external-wallet
	/// </summary>
	Task<ApiResponse<ExternalWalletModel>> CreateExternalWalletAsync(CreateExternalWalletModel payload);

	/// <summary>
	/// Retrieve an External Wallet<br/>
	/// Retrieves the External Wallet for the request wallet ID<br/>
	/// https://docs.fireblocks.com/api/#retrieve-an-external-wallet
	/// </summary>
	Task<ApiResponse<ExternalWalletModel>> GetExternalWalletAsync(string walletId);

	/// <summary>
	/// Delete an External Wallet<br/>
	/// https://docs.fireblocks.com/api/#delete-an-external-wallet
	/// </summary>
	Task<ApiResponse<string>> DeleteExternalWalletAsync(string walletId);

	/// <summary>
	/// Retrieve an Asset from an External Wallet<br/>
	/// Retrieves the External Wallet of the requested wallet ID and asset<br/>
	/// https://docs.fireblocks.com/api/#retrieve-an-asset-from-an-external-wallet
	/// </summary>
	Task<ApiResponse<ExternalWalletAssetModel>> GetExternalWalletAssetAsync(string walletId, string assetId);

	/// <summary>
	/// Add an Asset to an External Wallet<br/>
	/// Adds an address to an existing External Wallet<br/>
	/// https://docs.fireblocks.com/api/#add-an-asset-to-an-external-wallet
	/// </summary>
	Task<ApiResponse<ExternalWalletAssetModel>> CreateExternalWalletAssetAsync(
		string walletId,
		string assetId,
		CreateExternalWalletAssetModel payload);

	/// <summary>
	/// Delete an Asset from an External Wallet<br/>
	/// https://docs.fireblocks.com/api/#delete-an-asset-from-an-external-wallet
	/// </summary>
	Task<ApiResponse<string>> DeleteExternalWalletAssetAsync(string walletId, string assetId);

	/// <summary>
	/// Set an AML Customer Reference ID for an External Wallet<br/>
	/// Sets an AML/KYT customer reference ID for the specific external wallet<br/>
	/// https://docs.fireblocks.com/api/#set-an-aml-customer-reference-id-for-an-external-wallet
	/// </summary>
	Task<ApiResponse<string>> SetCustomerRefIdForExternalWalletAsync(
		string walletId,
		SetCustomerRefIdForExternalWalletModel payload);
}

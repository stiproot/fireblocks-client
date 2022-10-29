using Fireblocks.Api.Models.Requests.Params;
using Fireblocks.Api.Models.Responses;
using Refit;
using Request = Fireblocks.Api.Models.Requests;

namespace Fireblocks.Api.Interfaces;

/// <summary>
/// Vault services
/// </summary>
public interface IVaultService
{
	/// <summary>
	/// List Vault Accounts (Paged)<br/>
	/// Retrieves all vault accounts in your workspace<br/>
	/// This endpoint returns a limited amount of results and quick response time<br/>
	/// https://docs.fireblocks.com/api/#list-vault-accounts-paged
	/// </summary>
	Task<ApiResponse<VaultAccountsPagedModel>> GetVaultAccountsWithPageInfoAsync(
		GetVaultAccountsWithPageInfoParams queryParams);

	/// <summary>
	/// List Vault Accounts<br/>
	/// Retrieves all Vault Accounts in your workspace<br/>
	/// https://docs.fireblocks.com/api/#list-vault-accounts
	/// </summary>
	Task<ApiResponse<IEnumerable<VaultAccountModel>>> GetVaultAccountsAsync(GetVaultAccountsParams queryParams);

	/// <summary>
	/// Retrieve a Vault Account<br/>
	/// Returns the requested Vault Account<br/>
	/// https://docs.fireblocks.com/api/#retrieve-a-vault-account
	/// </summary>
	Task<ApiResponse<VaultAccountModel>> GetVaultAccountAsync(string vaultAccountId);

	/// <summary>
	/// Create a New Vault Account<br/>
	/// Creates a new Vault Account with the requested name<br/>
	/// https://docs.fireblocks.com/api/#create-a-new-vault-account
	/// </summary>
	Task<ApiResponse<VaultAccountModel>> CreateVaultAccountAsync(Request.CreateVaultAccountModel payload);

	/// <summary>
	/// Rename a Vault Account<br/>
	/// Renames the requested vault account<br/>
	/// https://docs.fireblocks.com/api/#rename-a-vault-account
	/// </summary>
	Task<ApiResponse<VaultAccountModel>> UpdateVaultAccountAsync(
		string vaultAccountId,
		Request.UpdateVaultAccountModel payload);

	/// <summary>
	/// Retrieve the Balance of an Asset in a Vault Account<br/>
	/// Retrieves a wallet of a specific asset under a Fireblocks Vault Account<br/>
	/// https://docs.fireblocks.com/api/#retrieve-the-balance-of-an-asset-in-a-vault-account
	/// </summary>
	Task<ApiResponse<VaultAssetModel>> GetVaultAccountAssetAsync(string vaultAccountId, string assetId);

	/// <summary>
	/// Create a New Wallet under the Vault Account<br/>
	/// Creates a new wallet of a specific asset under a Fireblocks Vault Account<br/>
	/// https://docs.fireblocks.com/api/#create-a-new-wallet-under-the-vault-account
	/// </summary>
	Task<ApiResponse<VaultAssetModel>> CreateVaultAssetAsync(
		string vaultAccountId,
		string assetId,
		Request.CreateVaultAssetModel payload);

	/// <summary>
	/// Refresh the Balance of an Asset<br/>
	/// Updates the balance of a specific asset in a Vault Account<br/>
	/// https://docs.fireblocks.com/api/#refresh-the-balance-of-an-asset
	/// </summary>
	Task<ApiResponse<VaultAssetModel>> RefreshVaultAssetBalanceAsync(string vaultAccountId, string assetId);

	/// <summary>
	/// Hide the Vault Account from the Web Console View<br/>
	/// https://docs.fireblocks.com/api/#hide-the-vault-account-from-the-web-console-view
	/// </summary>
	/// <returns>HTTP 200, no content</returns>
	Task<ApiResponse<string>> HideVaultAccountAsync(string vaultAccountId);

	/// <summary>
	/// Return the Vault Account to be visible in the Web Console<br/>
	/// https://docs.fireblocks.com/api/#return-the-vault-account-to-be-visible-in-the-web-console
	/// </summary>
	/// <returns>HTTP 200, no content</returns>
	Task<ApiResponse<string>> UnhideVaultAccountAsync(string vaultAccountId);

	/// <summary>
	/// Retrieve the Addresses of an Asset in a Vault Account<br/>
	/// Retrieves all addresses of a specific asset inside a Fireblocks Vault Account<br/>
	/// https://docs.fireblocks.com/api/#retrieve-the-addresses-of-an-asset-in-a-vault-account
	/// </summary>
	Task<ApiResponse<IEnumerable<VaultAccountAssetAddressModel>>> GetDepositAddressesAsync(
		string vaultAccountId,
		string assetId,
		Request.GetDepositAddressesModel payload);

	/// <summary>
	/// Create a New Deposit Address of an Asset in a Vault Account<br/>
	/// Generates a new deposit address for the requested asset under the specific vault account<br/>
	/// https://docs.fireblocks.com/api/#create-a-new-deposit-address-of-an-asset-in-a-vault-account
	/// </summary>
	Task<ApiResponse<CreateAddressModel>> GenerateNewAddressAsync(
		string vaultAccountId,
		string assetId,
		Request.GenerateNewAddressModel payload);

	/// <summary>
	/// Rename an Address<br/>
	/// Updates the description of an existing address of an asset within a Fireblocks Vault Account<br/>
	/// https://docs.fireblocks.com/api/#rename-an-address
	/// </summary>
	Task<ApiResponse<SetAddressDescriptionModel>> SetAddressDescriptionAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		Request.SetAddressDescriptionModel payload);

	/// <summary>
	/// Retrieve the Maximum Spendable Amount<br/>
	/// https://docs.fireblocks.com/api/#retrieve-the-maximum-spendable-amount
	/// </summary>
	Task<ApiResponse<MaxSpendableAmountModel>> GetMaxSpendableAmountAsync(
		string vaultAccountId,
		string assetId);

	/// <summary>
	/// Set an AML Customer Reference ID for Vault Account<br/>
	/// https://docs.fireblocks.com/api/#set-an-aml-customer-reference-id-for-vault-account
	/// </summary>
	/// <returns>HTTP 200, no content</returns>
	Task<ApiResponse<string>> SetVaultAccountCustomerRefIdAsync(
		string vaultAccountId,
		Request.SetVaultAccountCustomerRefIdModel payload);

	/// <summary>
	/// Set an AML Customer Reference ID for an Address<br/>
	/// https://docs.fireblocks.com/api/#set-an-aml-customer-reference-id-for-an-address
	/// </summary>
	/// <returns>HTTP 200, no content</returns>
	Task<ApiResponse<string>> SetCustomerRefIdForAddressAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		Request.SetVaultAccountCustomerRefIdModel payload);

	/// <summary>
	/// Retrieve Unspent Inputs<br/>
	/// Returns unspent inputs of the requested asset in the Vault Account<br/>
	/// https://docs.fireblocks.com/api/#retrieve-unspent-inputs
	/// </summary>
	Task<ApiResponse<IEnumerable<UnspentInputsDataModel>>> GetUnspentInputsAsync(
		string vaultAccountId,
		string assetId);

	/// <summary>
	/// Retrieve Public Key by Derivation Path<br/>
	/// Retrieves the public key of your Fireblocks' Vault<br/>
	/// https://docs.fireblocks.com/api/#retrieve-public-key-by-derivation-path
	/// </summary>
	Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoAsync(GetPublicKeyInfoParams queryParams);

	/// <summary>
	/// Retrieve the Public Key of Fireblocks' Address<br/>
	/// Retrieves the public key of your Fireblocks' Vault<br/>
	/// https://docs.fireblocks.com/api/#retrieve-the-public-key-of-fireblocks-39-address
	/// </summary>
	Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoForVaultAccountAsync(
		string vaultAccountId,
		string assetId,
		string change,
		int addressIndex,
		GetPublicKeyInfoForVaultAccountParams queryParams);

	/// <summary>
	/// Set Auto Fuel Properties of the Vault Account<br/>
	/// This endpoint is relevant only if the Gas Station is enabled on your workspace!<br/>
	/// Enable / Disable auto fueling of the Vault Account's Ethereum address<br/>
	/// https://docs.fireblocks.com/api/#set-auto-fuel-properties-of-the-vault-account
	/// </summary>
	Task<ApiResponse<string>> SetAutoFuelAsync(string vaultAccountId, Request.SetAutoFuelModel payload);

	/// <summary>
	/// Retrieve Vault Balance by Assets<br/>
	/// Returns the aggregated balance of your assets accross all Vault Accounts<br/>
	/// https://docs.fireblocks.com/api/#retrieve-vault-balance-by-assets
	/// </summary>
	Task<ApiResponse<IEnumerable<VaultAssetModel>>> GetVaultAssetsBalanceAsync(
		GetVaultAssetsBalanceParams queryParams);

	/// <summary>
	/// Retrieve Asset's Vault Balance<br/>
	/// Returns the balance of the requested asset<br/>
	/// https://docs.fireblocks.com/api/#retrieve-asset-39-s-vault-balance
	/// </summary>
	Task<ApiResponse<VaultAssetModel>> GetVaultBalanceByAssetAsync(string assetId);
}

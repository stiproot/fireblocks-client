using Fireblocks.Client.Models.Requests.Params;
using Fireblocks.Client.Models.Responses;
using Refit;
using Request = Fireblocks.Client.Models.Requests;

namespace Fireblocks.Client.Abstractions;

public interface IVaultApi : IFireblocksApi
{
	[Get("/accounts_paged")]
	Task<ApiResponse<VaultAccountsPagedModel>> GetVaultAccountsWithPageInfoAsync(
		[Query] GetVaultAccountsWithPageInfoParams queryParams);

	[Get("/accounts")]
	Task<ApiResponse<IEnumerable<VaultAccountModel>>> GetVaultAccountsAsync([Query] GetVaultAccountsParams queryParams);

	[Get("/accounts/{vaultAccountId}")]
	Task<ApiResponse<VaultAccountModel>> GetVaultAccountAsync(string vaultAccountId);

	[Post("/accounts")]
	Task<ApiResponse<VaultAccountModel>> CreateVaultAccountAsync([Body] Request.CreateVaultAccountModel payload);

	[Put("/accounts/{vaultAccountId}")]
	Task<ApiResponse<VaultAccountModel>> UpdateVaultAccountAsync(
		string vaultAccountId,
		[Body] Request.UpdateVaultAccountModel payload);

	[Get("/accounts/{vaultAccountId}/{assetId}")]
	Task<ApiResponse<VaultAssetModel>> GetVaultAccountAssetAsync(string vaultAccountId, string assetId);

	[Post("/accounts/{vaultAccountId}/{assetId}")]
	Task<ApiResponse<VaultAssetModel>> CreateVaultAssetAsync(
		string vaultAccountId,
		string assetId,
		[Body] Request.CreateVaultAssetModel payload);

	[Post("/accounts/{vaultAccountId}/{assetId}/balance")]
	Task<ApiResponse<VaultAssetModel>> RefreshVaultAssetBalanceAsync(string vaultAccountId, string assetId);

	[Post("/accounts/{vaultAccountId}/hide")]
	Task<ApiResponse<string>> HideVaultAccountAsync(string vaultAccountId);

	[Post("/accounts/{vaultAccountId}/unhide")]
	Task<ApiResponse<string>> UnhideVaultAccountAsync(string vaultAccountId);

	[Get("/accounts/{vaultAccountId}/{assetId}/addresses")]
	Task<ApiResponse<IEnumerable<VaultAccountAssetAddressModel>>> GetDepositAddressesAsync(
		string vaultAccountId,
		string assetId,
		[Body] Request.GetDepositAddressesModel payload);

	[Post("/accounts/{vaultAccountId}/{assetId}/addresses")]
	Task<ApiResponse<CreateAddressModel>> GenerateNewAddressAsync(
		string vaultAccountId,
		string assetId,
		[Body] Request.GenerateNewAddressModel payload);

	[Put("/accounts/{vaultAccountId}/{assetId}/addresses/{addressId}")]
	Task<ApiResponse<SetAddressDescriptionModel>> SetAddressDescriptionAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		[Body] Request.SetAddressDescriptionModel payload);

	[Get("/accounts/{vaultAccountId}/{assetId}/max_spendable_amount")]
	Task<ApiResponse<MaxSpendableAmountModel>> GetMaxSpendableAmountAsync(
		string vaultAccountId,
		string assetId);

	[Post("/accounts/{vaultAccountId}/set_customer_ref_id")]
	Task<ApiResponse<string>> SetVaultAccountCustomerRefIdAsync(
		string vaultAccountId,
		[Body] Request.SetVaultAccountCustomerRefIdModel payload);

	[Post("/accounts/{vaultAccountId}/{assetId}/addresses/{addressId}/set_customer_ref_id")]
	Task<ApiResponse<string>> SetCustomerRefIdForAddressAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		[Body] Request.SetVaultAccountCustomerRefIdModel payload);

	[Get("/accounts/{vaultAccountId}/{assetId}/unspent_inputs")]
	Task<ApiResponse<IEnumerable<UnspentInputsDataModel>>> GetUnspentInputsAsync(
		string vaultAccountId,
		string assetId);

	[Get("/public_key_info")]
	Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoAsync([Query] GetPublicKeyInfoParams queryParams);

	[Get("/accounts/{vaultAccountId}/{assetId}/{change}/{addressIndex}/public_key_info")]
	Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoForVaultAccountAsync(
		string vaultAccountId,
		string assetId,
		string change,
		int addressIndex,
		[Query] GetPublicKeyInfoForVaultAccountParams queryParams);

	[Post("/accounts/{vaultAccountId}/set_auto_fuel")]
	Task<ApiResponse<string>> SetAutoFuelAsync(string vaultAccountId, [Body] Request.SetAutoFuelModel payload);

	[Get("/assets")]
	Task<ApiResponse<IEnumerable<VaultAssetModel>>> GetVaultAssetsBalanceAsync(
		[Query] GetVaultAssetsBalanceParams queryParams);

	[Get("/assets/{assetId}")]
	Task<ApiResponse<VaultAssetModel>> GetVaultBalanceByAssetAsync(string assetId);
}

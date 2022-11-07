using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Requests.Params;
using Fireblocks.Api.Models.Responses;
using Refit;
using Request = Fireblocks.Api.Models.Requests;

namespace Fireblocks.Api.Services;

public class VaultService : IVaultService
{
	private readonly IVaultApi _vaultApi;

	public VaultService(IVaultApi vaultApi) =>
		_vaultApi = vaultApi;

	public async Task<ApiResponse<VaultAccountModel>> CreateVaultAccountAsync(Request.CreateVaultAccountModel payload) =>
		await _vaultApi.CreateVaultAccountAsync(payload);

	public async Task<ApiResponse<VaultAssetModel>> CreateVaultAssetAsync(
		string vaultAccountId,
		string assetId,
		Request.CreateVaultAssetModel payload) =>
			await _vaultApi.CreateVaultAssetAsync(vaultAccountId, assetId, payload);

	public async Task<ApiResponse<CreateAddressModel>> GenerateNewAddressAsync(
		string vaultAccountId,
		string assetId,
		Request.GenerateNewAddressModel payload) =>
			await _vaultApi.GenerateNewAddressAsync(vaultAccountId, assetId, payload);

	public async Task<ApiResponse<IEnumerable<VaultAccountAssetAddressModel>>> GetDepositAddressesAsync(
		string vaultAccountId,
		string assetId,
		Request.GetDepositAddressesModel payload) =>
			await _vaultApi.GetDepositAddressesAsync(vaultAccountId, assetId, payload);

	public async Task<ApiResponse<MaxSpendableAmountModel>> GetMaxSpendableAmountAsync(
		string vaultAccountId,
		string assetId) =>
			await _vaultApi.GetMaxSpendableAmountAsync(vaultAccountId, assetId);

	public async Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoAsync(GetPublicKeyInfoParams queryParams) =>
		await _vaultApi.GetPublicKeyInfoAsync(queryParams);

	public async Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoForVaultAccountAsync(
		string vaultAccountId,
		string assetId,
		string change,
		int addressIndex,
		GetPublicKeyInfoForVaultAccountParams queryParams) =>
			await _vaultApi.GetPublicKeyInfoForVaultAccountAsync(
				vaultAccountId,
				assetId,
				change,
				addressIndex,
				queryParams);

	public async Task<ApiResponse<IEnumerable<UnspentInputsDataModel>>> GetUnspentInputsAsync(
		string vaultAccountId,
		string assetId) =>
			await _vaultApi.GetUnspentInputsAsync(vaultAccountId, assetId);

	public async Task<ApiResponse<VaultAssetModel>> GetVaultAccountAssetAsync(string vaultAccountId, string assetId) =>
		await _vaultApi.GetVaultAccountAssetAsync(vaultAccountId, assetId);

	public async Task<ApiResponse<VaultAccountModel>> GetVaultAccountAsync(string vaultAccountId) =>
		await _vaultApi.GetVaultAccountAsync(vaultAccountId);

	public async Task<ApiResponse<IEnumerable<VaultAccountModel>>> GetVaultAccountsAsync(GetVaultAccountsParams queryParams) =>
		await _vaultApi.GetVaultAccountsAsync(queryParams);

	public async Task<ApiResponse<VaultAccountsPagedModel>> GetVaultAccountsWithPageInfoAsync(
		GetVaultAccountsWithPageInfoParams queryParams) =>
			await _vaultApi.GetVaultAccountsWithPageInfoAsync(queryParams);

	public async Task<ApiResponse<IEnumerable<VaultAssetModel>>> GetVaultAssetsBalanceAsync(
		GetVaultAssetsBalanceParams queryParams) =>
			await _vaultApi.GetVaultAssetsBalanceAsync(queryParams);

	public async Task<ApiResponse<VaultAssetModel>> GetVaultBalanceByAssetAsync(string assetId) =>
		await _vaultApi.GetVaultBalanceByAssetAsync(assetId);

	public async Task<ApiResponse<string>> HideVaultAccountAsync(string vaultAccountId) =>
		await _vaultApi.HideVaultAccountAsync(vaultAccountId);

	public async Task<ApiResponse<VaultAssetModel>> RefreshVaultAssetBalanceAsync(string vaultAccountId, string assetId) =>
		await _vaultApi.RefreshVaultAssetBalanceAsync(vaultAccountId, assetId);

	public async Task<ApiResponse<SetAddressDescriptionModel>> SetAddressDescriptionAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		Request.SetAddressDescriptionModel payload) =>
			await _vaultApi.SetAddressDescriptionAsync(vaultAccountId, assetId, addressId, payload);

	public async Task<ApiResponse<string>> SetAutoFuelAsync(string vaultAccountId, Request.SetAutoFuelModel payload) =>
		await _vaultApi.SetAutoFuelAsync(vaultAccountId, payload);

	public async Task<ApiResponse<string>> SetCustomerRefIdForAddressAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		Request.SetVaultAccountCustomerRefIdModel payload) =>
			await _vaultApi.SetCustomerRefIdForAddressAsync(vaultAccountId, assetId, addressId, payload);

	public async Task<ApiResponse<string>> SetVaultAccountCustomerRefIdAsync(
		string vaultAccountId,
		Request.SetVaultAccountCustomerRefIdModel payload) =>
			await _vaultApi.SetVaultAccountCustomerRefIdAsync(vaultAccountId, payload);

	public async Task<ApiResponse<string>> UnhideVaultAccountAsync(string vaultAccountId) =>
		await _vaultApi.UnhideVaultAccountAsync(vaultAccountId);

	public async Task<ApiResponse<VaultAccountModel>> UpdateVaultAccountAsync(
		string vaultAccountId,
		Request.UpdateVaultAccountModel payload) =>
			await _vaultApi.UpdateVaultAccountAsync(vaultAccountId, payload);
}

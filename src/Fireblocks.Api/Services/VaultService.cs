using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Requests.Params;
using Fireblocks.Api.Models.Responses;
using Microsoft.Extensions.Logging;
using Refit;
using Request = Fireblocks.Api.Models.Requests;

namespace Fireblocks.Api.Services;

public class VaultService : IVaultService
{
	private readonly ILogger<VaultService> _logger;
	private readonly IVaultApi _vaultApi;

	public VaultService(ILogger<VaultService> logger, IVaultApi vaultApi)
	{
		_logger = logger;
		_vaultApi = vaultApi;
	}

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

	public Task<ApiResponse<IEnumerable<VaultAccountAssetAddressModel>>> GetDepositAddressesAsync(
		string vaultAccountId,
		string assetId,
		Request.GetDepositAddressesModel payload)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<MaxSpendableAmountModel>> GetMaxSpendableAmountAsync(string vaultAccountId, string assetId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoAsync(GetPublicKeyInfoParams queryParams)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<PublicKeyModel>> GetPublicKeyInfoForVaultAccountAsync(
		string vaultAccountId,
		string assetId,
		string change,
		int addressIndex,
		GetPublicKeyInfoForVaultAccountParams queryParams)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<IEnumerable<UnspentInputsDataModel>>> GetUnspentInputsAsync(
		string vaultAccountId,
		string assetId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<VaultAssetModel>> GetVaultAccountAssetAsync(string vaultAccountId, string assetId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<VaultAccountModel>> GetVaultAccountAsync(string vaultAccountId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<IEnumerable<VaultAccountModel>>> GetVaultAccountsAsync(GetVaultAccountsParams queryParams)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<VaultAccountsPagedModel>> GetVaultAccountsWithPageInfo(
		GetVaultAccountsWithPageInfoParams queryParams)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<IEnumerable<VaultAssetModel>>> GetVaultAssetsBalanceAsync(
		GetVaultAssetsBalanceParams queryParams)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<VaultAssetModel>> GetVaultBalanceByAssetAsync(string assetId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<string>> HideVaultAccountAsync(string vaultAccountId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<VaultAssetModel>> RefreshVaultAssetBalanceAsync(string vaultAccountId, string assetId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<SetAddressDescriptionModel>> SetAddressDescriptionAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		Request.SetAddressDescriptionModel payload)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<string>> SetAutoFuelAsync(string vaultAccountId, Request.SetAutoFuelModel payload)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<string>> SetCustomerRefIdForAddressAsync(
		string vaultAccountId,
		string assetId,
		string addressId,
		Request.SetVaultAccountCustomerRefIdModel payload)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<string>> SetVaultAccountCustomerRefIdAsync(
		string vaultAccountId,
		Request.SetVaultAccountCustomerRefIdModel payload)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<string>> UnhideVaultAccountAsync(string vaultAccountId)
	{
		throw new NotImplementedException();
	}

	public Task<ApiResponse<VaultAccountModel>> UpdateVaultAccountAsync(
		string vaultAccountId,
		Request.UpdateVaultAccountModel payload)
	{
		throw new NotImplementedException();
	}
}

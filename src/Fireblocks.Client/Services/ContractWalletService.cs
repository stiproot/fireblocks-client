using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Services;

public class ContractWalletService : IContractWalletService
{
	private readonly IContractWalletApi _contractWalletApi;

	public ContractWalletService(IContractWalletApi contractWalletApi) =>
		_contractWalletApi = contractWalletApi;

	public async Task<ApiResponse<ContractAssetModel>> CreateContractWalletAssetAsync(
		string walletId,
		string assetId,
		CreateContractWalletAssetModel payload) =>
			await _contractWalletApi.CreateContractWalletAssetAsync(walletId, assetId, payload);

	public async Task<ApiResponse<UnmanagedContractModel>> CreateContractWalletAsync(
		CreateContractWalletModel payload) =>
			await _contractWalletApi.CreateContractWalletAsync(payload);

	public async Task<ApiResponse<string>> DeleteContractWalletAssetAsync(string walletId, string assetId) =>
		await _contractWalletApi.DeleteContractWalletAssetAsync(walletId, assetId);

	public async Task<ApiResponse<string>> DeleteContractWalletAsync(string walletId) =>
		await _contractWalletApi.DeleteContractWalletAsync(walletId);

	public async Task<ApiResponse<ContractAssetModel>> GetContractWalletAssetAsync(string walletId, string assetId) =>
		await _contractWalletApi.GetContractWalletAssetAsync(walletId, assetId);

	public async Task<ApiResponse<UnmanagedContractModel>> GetContractWalletAsync(string walletId) =>
		await _contractWalletApi.GetContractWalletAsync(walletId);

	public async Task<ApiResponse<IEnumerable<UnmanagedContractModel>>> GetContractWalletsAsync() =>
		await _contractWalletApi.GetContractWalletsAsync();
}

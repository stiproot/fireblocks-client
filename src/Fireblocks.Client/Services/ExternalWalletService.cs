using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Services;

public class ExternalWalletService : IExternalWalletService
{
	private readonly IExternalWalletApi _externalWalletApi;

	public ExternalWalletService(IExternalWalletApi externalWalletApi) =>
		_externalWalletApi = externalWalletApi;

	public async Task<ApiResponse<ExternalWalletAssetModel>> CreateExternalWalletAssetAsync(
		string walletId,
		string assetId,
		CreateExternalWalletAssetModel payload) =>
			await _externalWalletApi.CreateExternalWalletAssetAsync(walletId, assetId, payload);

	public async Task<ApiResponse<ExternalWalletModel>> CreateExternalWalletAsync(CreateExternalWalletModel payload) =>
		await _externalWalletApi.CreateExternalWalletAsync(payload);

	public async Task<ApiResponse<string>> DeleteExternalWalletAssetAsync(string walletId, string assetId) =>
		await _externalWalletApi.DeleteExternalWalletAssetAsync(walletId, assetId);

	public async Task<ApiResponse<string>> DeleteExternalWalletAsync(string walletId) =>
		await _externalWalletApi.DeleteExternalWalletAsync(walletId);

	public async Task<ApiResponse<ExternalWalletAssetModel>> GetExternalWalletAssetAsync(
		string walletId,
		string assetId) =>
			await _externalWalletApi.GetExternalWalletAssetAsync(walletId, assetId);

	public async Task<ApiResponse<ExternalWalletModel>> GetExternalWalletAsync(string walletId) =>
		await _externalWalletApi.GetExternalWalletAsync(walletId);

	public async Task<ApiResponse<IEnumerable<ExternalWalletModel>>> GetExternalWalletsAsync() =>
		await _externalWalletApi.GetExternalWalletsAsync();

	public async Task<ApiResponse<string>> SetCustomerRefIdForExternalWalletAsync(
		string walletId,
		SetCustomerRefIdForExternalWalletModel payload) =>
			await _externalWalletApi.SetCustomerRefIdForExternalWalletAsync(walletId, payload);
}

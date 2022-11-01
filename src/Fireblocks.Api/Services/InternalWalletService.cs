using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Services;

public class InternalWalletService : IInternalWalletService
{
	private readonly IInternalWalletApi _internalWalletApi;

	public InternalWalletService(IInternalWalletApi internalWalletApi) =>
		_internalWalletApi = internalWalletApi;

	public async Task<ApiResponse<WalletAssetModel>> CreateInternalWalletAssetAsync(
		string walletId,
		string assetId,
		CreateInternalWalletAssetModel payload) =>
			await _internalWalletApi.CreateInternalWalletAssetAsync(walletId, assetId, payload);

	public async Task<ApiResponse<UnmanagedWalletModel>> CreateInternalWalletAsync(CreateInternalWalletModel payload) =>
		await _internalWalletApi.CreateInternalWalletAsync(payload);

	public async Task<ApiResponse<string>> DeleteInternalWalletAssetAsync(string walletId, string assetId) =>
		await _internalWalletApi.DeleteInternalWalletAssetAsync(walletId, assetId);

	public async Task<ApiResponse<string>> DeleteInternalWalletAsync(string walletId) =>
		await _internalWalletApi.DeleteInternalWalletAsync(walletId);

	public async Task<ApiResponse<WalletAssetModel>> GetInternalWalletAssetAsync(string walletId, string assetId) =>
		await _internalWalletApi.GetInternalWalletAssetAsync(walletId, assetId);

	public async Task<ApiResponse<UnmanagedWalletModel>> GetInternalWalletAsync(string walletId) =>
		await _internalWalletApi.GetInternalWalletAsync(walletId);

	public async Task<ApiResponse<IEnumerable<UnmanagedWalletModel>>> GetInternalWalletsAsync() =>
		await _internalWalletApi.GetInternalWalletsAsync();

	public async Task<ApiResponse<string>> SetCustomerRefIdForInternalWalletAsync(
		string walletId,
		SetCustomerRefIdForInternalWalletModel payload) =>
			await _internalWalletApi.SetCustomerRefIdForInternalWalletAsync(walletId, payload);
}

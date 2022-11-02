using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Services;

public class ExchangeService : IExchangeService
{
	private readonly IExchangeApi _exchangeApi;

	public ExchangeService(IExchangeApi exchangeApi) =>
		_exchangeApi = exchangeApi;

	public async Task<ApiResponse<string>> ConvertAsync(
		string exchangeAccountId,
		ConvertExchangeAccountFundModel payload) =>
			await _exchangeApi.ConvertAsync(exchangeAccountId, payload);

	public async Task<ApiResponse<ExchangeAssetModel>> GetExchangeAccountAssetAsync(
		string exchangeAccountId,
		string assetId) =>
			await _exchangeApi.GetExchangeAccountAssetAsync(exchangeAccountId, assetId);

	public async Task<ApiResponse<ExchangeAccountModel>> GetExchangeAccountAsync(string exchangeAccountId) =>
		await _exchangeApi.GetExchangeAccountAsync(exchangeAccountId);

	public async Task<ApiResponse<IEnumerable<ExchangeAccountModel>>> GetExchangeAccountsAsync() =>
		await _exchangeApi.GetExchangeAccountsAsync();

	public async Task<ApiResponse<string>> InternalTransferAsync(
		string exchangeAccountId,
		ExchangeInternalTransferModel payload) =>
			await _exchangeApi.InternalTransferAsync(exchangeAccountId, payload);
}

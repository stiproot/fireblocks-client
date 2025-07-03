using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Services;

public class FiatService : IFiatService
{
	private readonly IFiatApi _fiatApi;

	public FiatService(IFiatApi fiatApi) =>
		_fiatApi = fiatApi;

	public async Task<ApiResponse<string>> DepositFromLinkedDdaAsync(string accountId, DepositFundModel payload) =>
		await _fiatApi.DepositFromLinkedDdaAsync(accountId, payload);

	public async Task<ApiResponse<FiatAccountModel>> GetFiatAccountAsync(string accountId) =>
		await _fiatApi.GetFiatAccountAsync(accountId);

	public async Task<ApiResponse<IEnumerable<FiatAccountModel>>> GetFiatAccountsAsync() =>
		await _fiatApi.GetFiatAccountsAsync();

	public async Task<ApiResponse<string>> RedeemToLinkedDdaAsync(string accountId, RedeemFundModel payload) =>
		await _fiatApi.RedeemToLinkedDdaAsync(accountId, payload);
}

using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IFiatApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<FiatAccountModel>>> GetFiatAccountsAsync();

	[Get("/{fiatAccountId}")]
	Task<ApiResponse<FiatAccountModel>> GetFiatAccountAsync(string accountId);

	[Post("/{accountId}/redeem_to_linked_dda")]
	Task<ApiResponse<string>> RedeemToLinkedDdaAsync(
		string accountId,
		[Body] RedeemFundModel payload);

	[Post("/{accountId}/deposit_from_linked_dda")]
	Task<ApiResponse<string>> DepositFromLinkedDdaAsync(
		string accountId,
		[Body] DepositFundModel payload);
}

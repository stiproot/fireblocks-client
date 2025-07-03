using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

/// <summary>
/// Fiat services
/// </summary>
public interface IFiatService
{
	/// <summary>
	/// List Fiat Accounts<br/>
	/// Retrieves all the FIAT accounts linked to your workspace<br/>
	/// https://docs.fireblocks.com/api/?#list-fiat-accounts
	/// </summary>
	/// <returns></returns>
	Task<ApiResponse<IEnumerable<FiatAccountModel>>> GetFiatAccountsAsync();

	/// <summary>
	/// Retrieve a Specific Fiat Accounts<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-a-specific-fiat-accounts
	/// </summary>
	Task<ApiResponse<FiatAccountModel>> GetFiatAccountAsync(string accountId);

	/// <summary>
	/// Redeem Funds to Linked DDA<br/>
	/// https://docs.fireblocks.com/api/?#redeem-funds-to-linked-dda
	/// </summary>
	Task<ApiResponse<string>> RedeemToLinkedDdaAsync(string accountId, RedeemFundModel payload);

	/// <summary>
	/// Deposit Funds from Linked DDA<br/>
	/// https://docs.fireblocks.com/api/?#deposit-funds-from-linked-dda
	/// </summary>
	Task<ApiResponse<string>> DepositFromLinkedDdaAsync(string accountId, DepositFundModel payload);
}

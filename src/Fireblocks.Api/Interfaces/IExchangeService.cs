using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IExchangeService
{
	/// <summary>
	/// List Exchange Accounts<br/>
	/// Fetches all the exchange accounts<br/>
	/// https://docs.fireblocks.com/api/#list-exchange-accounts
	/// </summary>
	Task<ApiResponse<IEnumerable<ExchangeAccountModel>>> GetExchangeAccountsAsync();

	/// <summary>
	/// Retrieve a Specific Exchange Account<br/>
	/// Retrieves the Exchange Account associated with the requested exchange account ID<br/>
	/// https://docs.fireblocks.com/api/#retrieve-a-specific-exchange-account
	/// </summary>
	Task<ApiResponse<ExchangeAccountModel>> GetExchangeAccountAsync(string exchangeAccountId);

	/// <summary>
	/// Retrieve a Specific Asset Within an Exchange Account<br/>
	/// https://docs.fireblocks.com/api/#retrieve-a-specific-asset-within-an-exchange-account
	/// </summary>
	Task<ApiResponse<ExchangeAssetModel>> GetExchangeAccountAssetAsync(string exchangeAccountId, string assetId);

	/// <summary>
	/// Exchange's Internal Transfer<br/>
	/// Transfers funds between trading accounts under the same exchange account<br/>
	/// https://docs.fireblocks.com/api/#exchange-39-s-internal-transfer
	/// </summary>
	Task<ApiResponse<string>> InternalTransferAsync(string exchangeAccountId, ExchangeInternalTransferModel payload);

	/// <summary>
	/// Convert exchange account funds<br/>
	/// Convert exchange account funds from the source asset to the destination asset<br/>
	/// https://docs.fireblocks.com/api/#convert-exchange-account-funds
	/// </summary>
	Task<ApiResponse<string>> ConvertAsync(string exchangeAccountId, ConvertExchangeAccountFundModel payload);
}

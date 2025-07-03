using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

public interface IExchangeApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<ExchangeAccountModel>>> GetExchangeAccountsAsync();

	[Get("/{exchangeAccountId}")]
	Task<ApiResponse<ExchangeAccountModel>> GetExchangeAccountAsync(string exchangeAccountId);

	[Get("/{exchangeAccountId}/{assetId}")]
	Task<ApiResponse<ExchangeAssetModel>> GetExchangeAccountAssetAsync(string exchangeAccountId, string assetId);

	[Post("/{exchangeAccountId}/internal_transfer")]
	Task<ApiResponse<string>> InternalTransferAsync(
		string exchangeAccountId,
		[Body] ExchangeInternalTransferModel payload);

	[Post("/{exchangeAccountId}/convert")]
	Task<ApiResponse<string>> ConvertAsync(
		string exchangeAccountId,
		[Body] ConvertExchangeAccountFundModel payload);
}

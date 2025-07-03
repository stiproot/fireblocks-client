using Fireblocks.Client.Enums;

namespace Fireblocks.Client.Models.Responses;

public class TradingAccountModel : BaseResponseModel
{
	/// <summary>
	/// The specific trading account under the exchange account
	/// </summary>
	public TradingAccountType? Type { get; set; }

	/// <summary>
	/// Assets in the trading account
	/// </summary>
	public IEnumerable<ExchangeAssetModel>? Assets { get; set; }
}

using Fireblocks.Client.Enums;

namespace Fireblocks.Client.Models.Requests;

public class DropTransactionModel : BaseRequestModel
{
	/// <summary>
	/// [optional] The requested fee level of the dropping transaction (LOW / MEDIUM / HIGH)
	/// </summary>
	public FeeLevelType? FeeLevel { get; set; }
}

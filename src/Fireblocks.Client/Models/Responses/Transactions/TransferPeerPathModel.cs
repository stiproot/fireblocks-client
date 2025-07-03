using Fireblocks.Client.Enums;

namespace Fireblocks.Client.Models.Responses;

public class TransferPeerPathModel : BaseResponseModel
{
	/// <summary>
	/// The ID of the peer
	/// </summary>
	public string? Id { get; set; }

	public TransferPeerPathType? Type { get; set; }
}

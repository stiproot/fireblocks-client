namespace Fireblocks.Client.Models.Requests;

public class CreateVaultAssetModel : BaseRequestModel
{
	/// <summary>
	/// [optional] EOS account address
	/// </summary>
	public string? EosAccountName { get; set; }
}

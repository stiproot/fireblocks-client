namespace Fireblocks.Client.Models.Responses;

public class CreateVaultAssetModel : BaseAddressModel
{
	/// <summary>
	/// The ID of the Vault Account
	/// </summary>
	public string? Id { get; set; }

	/// <summary>
	/// Returned for EOS, the account name
	/// </summary>
	public string? EosAccountName { get; set; }
}

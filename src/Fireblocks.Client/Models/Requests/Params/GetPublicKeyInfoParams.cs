using Fireblocks.Client.Enums;

namespace Fireblocks.Client.Models.Requests.Params;

public class GetPublicKeyInfoParams : GetPublicKeyInfoForVaultAccountParams
{
	/// <summary>
	/// String, one of the supported SigningAlgorithms
	/// </summary>
	public SigningAlgorithm? algorithm { get; set; }

	/// <summary>
	/// List of integers
	/// </summary>
	public IEnumerable<int>? derivationPath { get; set; }
}

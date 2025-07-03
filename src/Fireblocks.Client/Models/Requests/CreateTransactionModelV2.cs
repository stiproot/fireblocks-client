
using System.Text.Json.Serialization;

namespace Fireblocks.Client.Models;

/// <summary>
/// Represents the root payload for a Fireblocks transaction request.
/// </summary>
public class CreateTransactionModelV2
{
  [JsonPropertyName("operation")]
  public string Operation { get; set; } = "TRANSFER"; // Default to TRANSFER as per example

  [JsonPropertyName("assetId")]
  public string AssetId { get; set; }

  [JsonPropertyName("amount")]
  public string Amount { get; set; } // Use string to handle decimal values precisely as Fireblocks expects

  [JsonPropertyName("source")]
  public TransactionSource Source { get; set; }

  [JsonPropertyName("destination")]
  public TransactionDestination Destination { get; set; }

  [JsonPropertyName("externalTxId")]
  public string ExternalTxId { get; set; }

  [JsonPropertyName("note")]
  public string Note { get; set; }
}

/// <summary>
/// Represents the source of the transaction (e.g., a vault account).
/// </summary>
public class TransactionSource
{
  [JsonPropertyName("type")]
  public string Type { get; set; } = "VAULT_ACCOUNT"; // Default to VAULT_ACCOUNT as per example

  [JsonPropertyName("id")]
  public string Id { get; set; } // Vault account ID
}

/// <summary>
/// Represents the destination of the transaction (e.g., a one-time address).
/// </summary>
public class TransactionDestination
{
  [JsonPropertyName("type")]
  public string Type { get; set; } = "ONE_TIME_ADDRESS"; // Default to ONE_TIME_ADDRESS as per example

  [JsonPropertyName("oneTimeAddress")]
  public OneTimeAddress OneTimeAddress { get; set; }
}

/// <summary>
/// Represents a one-time blockchain address for the destination.
/// </summary>
public class OneTimeAddress
{
  [JsonPropertyName("address")]
  public string Address { get; set; }
}
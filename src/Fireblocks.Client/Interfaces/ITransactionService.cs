using Fireblocks.Client.Models;
using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Requests.Params;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

/// <summary>
/// Transaction services
/// </summary>
public interface ITransactionService
{
	/// <summary>
	/// List Transactions<br/>
	/// Lists the transaction history for your workspace<br/>
	/// https://docs.fireblocks.com/api/?#list-transactions
	/// </summary>
	Task<ApiResponse<IEnumerable<TransactionDetailsModel>>> GetTransactionsAsync(
		ListTransactionsParams queryParams);

	/// <summary>
	/// Create a New Transaction<br/>
	/// Submits a new transaction on the Fireblocks platform<br/>
	/// https://docs.fireblocks.com/api/?#create-a-new-transaction
	/// </summary>
	Task<ApiResponse<CreateTransactionResponseModel>> CreateTransactionAsync(CreateTransactionModel payload);

	Task<ApiResponse<CreateTransactionResponseModel>> CreateTransactionAsyncV2(CreateTransactionModelV2 payload);

	/// <summary>
	/// Retrieve a Specific Transaction<br/>
	/// Retrieves a specific transaction for the requested transaction ID<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-a-specific-transaction
	/// </summary>
	Task<ApiResponse<TransactionDetailsModel>> GetTransactionByIdAsync(string txId);

	/// <summary>
	/// Retrieve a Specific Transaction By External ID<br/>
	/// Retrieves a specific transaction for the requested external transaction ID<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-a-specific-transaction-by-external-id
	/// </summary>
	Task<ApiResponse<TransactionDetailsModel>> GetTransactionByExternalTxIdAsync(string externalTxId);

	/// <summary>
	/// Cancel Transaction<br/>
	/// Cancel the requested transaction<br/>
	/// https://docs.fireblocks.com/api/?#cancel-transaction
	/// </summary>
	Task<ApiResponse<string>> CancelTransactionByIdAsync(string txId);

	/// <summary>
	/// Drop Transaction<br/>
	/// Replaces Ethereum transactions that are stuck with 0 confirmation<br/>
	/// This request creates a new transaction that can replace the stalled transaction, with the same source as the original one, with 0 ETH sent to itself<br/>
	/// By using the same nonce as the original one, it will drop the original transaction once the new transaction will be mined.<br/>
	/// A stuck transaction can be replaced by a different transaction using the create transaction endpoint and the "replaceTxByHash" field<br/>
	/// https://docs.fireblocks.com/api/?#drop-transaction
	/// </summary>
	Task<ApiResponse<string>> DropTransactionAsync(string txId, DropTransactionModel payload);

	/// <summary>
	/// Freeze Transaction<br/>
	/// Freezes transaction so that it will not be available for spending<br/>
	/// https://docs.fireblocks.com/api/?#freeze-transaction
	/// </summary>
	Task<ApiResponse<string>> FreezeTransactionAsync(string txId);

	/// <summary>
	/// Unfreeze Transaction<br/>
	/// Makes the transaction avaialble after it was frozen<br/>
	/// https://docs.fireblocks.com/api/?#unfreeze-transaction
	/// </summary>
	Task<ApiResponse<string>> UnfreezeTransactionAsync(string txId);

	/// <summary>
	/// Validate Destination Address<br/>
	/// This endpoint validates the destination address exists or is activate with the necessary activation per blockchain<br/>
	/// Supported for the following assets: XRP, DOT, XLM, EOS<br/>
	/// https://docs.fireblocks.com/api/?#validate-destination-address
	/// </summary>
	Task<ApiResponse<AddressStatusModel>> ValidateDestinationAddressAsync(string assetId, string address);

	/// <summary>
	/// Estimate Transaction Fee<br/>
	/// Estimates the transaction fee for a given transaction request<br/>
	/// For UTXO based assets, the response will contain the suggested fee per byte<br/>
	/// For ETH/ETC based assets, the suggested gas price (calculated by adding the baseFee + actualPriority, based on the latest 12 block)<br/>
	/// For XRP/XLM, the transaction fee<br/>
	/// https://docs.fireblocks.com/api/?#estimate-transaction-fee
	/// </summary>
	Task<ApiResponse<EstimatedTransactionFeeResponseModel>> EstimateFeeForTransactionAsync(
		EstimateTransactionFeeModel payload);

	/// <summary>
	/// Set Confirmation Threshold by TXID<br/>
	/// Overrides the required number of confirmations for a transaction completion by its transaction ID<br/>
	/// Note: Confirmation thresholds cannot be adjusted after a transaction has reached a COMPLETED status<br/>
	/// https://docs.fireblocks.com/api/?#set-confirmation-threshold-by-tx-id
	/// </summary>
	Task<ApiResponse<SetConfirmationsThresholdResponseModel>> SetConfirmationThresholdForTxIdAsync(
		string txId,
		SetConfirmationThresholdByTxHashModel payload);

	/// <summary>
	/// Set Confirmation Threshold by TX Hash<br/>
	/// Overrides the required number of confirmations for a transaction completion by its transactions hash<br/>
	/// Note: Confirmation thresholds cannot be adjusted after a transaction has reached a COMPLETED status<br/>
	/// https://docs.fireblocks.com/api/?#set-confirmation-threshold-by-tx-hash
	/// </summary>
	Task<ApiResponse<SetConfirmationsThresholdResponseModel>> SetConfirmationThresholdForTxHashAsync(
		string txHash,
		SetConfirmationThresholdByTxHashModel payload);
}

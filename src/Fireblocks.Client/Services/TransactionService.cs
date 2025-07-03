using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models;
using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Requests.Params;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Services;

public class TransactionService : ITransactionService
{
	private readonly ITransactionApi _transactionApi;

	public TransactionService(ITransactionApi transactionApi) =>
		_transactionApi = transactionApi;

	public async Task<ApiResponse<string>> CancelTransactionByIdAsync(string txId) =>
		await _transactionApi.CancelTransactionByIdAsync(txId);

	public async Task<ApiResponse<CreateTransactionResponseModel>> CreateTransactionAsync(
		CreateTransactionModel payload) =>
			await _transactionApi.CreateTransactionAsync(payload);

	public async Task<ApiResponse<CreateTransactionResponseModel>> CreateTransactionAsyncV2(
		CreateTransactionModelV2 payload) =>
			await _transactionApi.CreateTransactionAsyncV2(payload);

	public async Task<ApiResponse<string>> DropTransactionAsync(string txId, DropTransactionModel payload) =>
		await _transactionApi.DropTransactionAsync(txId, payload);

	public async Task<ApiResponse<EstimatedTransactionFeeResponseModel>> EstimateFeeForTransactionAsync(
		EstimateTransactionFeeModel payload) =>
			await _transactionApi.EstimateFeeForTransactionAsync(payload);

	public async Task<ApiResponse<string>> FreezeTransactionAsync(string txId) =>
		await _transactionApi.FreezeTransactionAsync(txId);

	public async Task<ApiResponse<TransactionDetailsModel>> GetTransactionByExternalTxIdAsync(string externalTxId) =>
		await _transactionApi.GetTransactionByExternalTxIdAsync(externalTxId);

	public async Task<ApiResponse<TransactionDetailsModel>> GetTransactionByIdAsync(string txId) =>
		await _transactionApi.GetTransactionByIdAsync(txId);

	public async Task<ApiResponse<IEnumerable<TransactionDetailsModel>>> GetTransactionsAsync(
		ListTransactionsParams queryParams) =>
			await _transactionApi.GetTransactionsAsync(queryParams);

	public async Task<ApiResponse<SetConfirmationsThresholdResponseModel>> SetConfirmationThresholdForTxHashAsync(
		string txHash,
		SetConfirmationThresholdByTxHashModel payload) =>
			await _transactionApi.SetConfirmationThresholdForTxHashAsync(txHash, payload);

	public async Task<ApiResponse<SetConfirmationsThresholdResponseModel>> SetConfirmationThresholdForTxIdAsync(
		string txId,
		SetConfirmationThresholdByTxHashModel payload) =>
			await _transactionApi.SetConfirmationThresholdForTxIdAsync(txId, payload);

	public async Task<ApiResponse<string>> UnfreezeTransactionAsync(string txId) =>
		await _transactionApi.UnfreezeTransactionAsync(txId);

	public async Task<ApiResponse<AddressStatusModel>> ValidateDestinationAddressAsync(string assetId, string address) =>
		await _transactionApi.ValidateDestinationAddressAsync(assetId, address);
}

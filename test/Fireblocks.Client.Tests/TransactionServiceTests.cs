namespace Fireblocks.Client.Tests;

public class TransactionServiceTests : BaseServiceTests
{
	private readonly Mock<ITransactionApi> _transactionApiMock;
	private readonly ITransactionService _transactionService;

	public TransactionServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_transactionApiMock = new Mock<ITransactionApi>();
		_transactionService = new TransactionService(_transactionApiMock.Object);
	}

	[Fact]
	public async Task CancelTransactionByIdAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.CancelTransactionByIdAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _transactionService.CancelTransactionByIdAsync("transactionId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CreateTransactionAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.CreateTransactionAsync(It.IsAny<Request.CreateTransactionModel>()))
			.Returns(CreateResponse<CreateTransactionResponseModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.CreateTransactionAsync(new Request.CreateTransactionModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task DropTransactionAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.DropTransactionAsync(It.IsAny<string>(), It.IsAny<Request.DropTransactionModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _transactionService.DropTransactionAsync("transactionId", new Request.DropTransactionModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task EstimateFeeForTransactionAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.EstimateFeeForTransactionAsync(It.IsAny<Request.EstimateTransactionFeeModel>()))
			.Returns(CreateResponse<EstimatedTransactionFeeResponseModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.EstimateFeeForTransactionAsync(new Request.EstimateTransactionFeeModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task FreezeTransactionAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.FreezeTransactionAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _transactionService.FreezeTransactionAsync("transactionId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetTransactionByExternalTxIdAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.GetTransactionByExternalTxIdAsync(It.IsAny<string>()))
			.Returns(CreateResponse<TransactionDetailsModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.GetTransactionByExternalTxIdAsync("externalTxId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetTransactionByIdAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.GetTransactionByIdAsync(It.IsAny<string>()))
			.Returns(CreateResponse<TransactionDetailsModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.GetTransactionByIdAsync("transactionId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetTransactionsAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.GetTransactionsAsync(It.IsAny<ListTransactionsParams>()))
			.Returns(CreateIEnumerableResponse<TransactionDetailsModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.GetTransactionsAsync(new ListTransactionsParams());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetConfirmationThresholdForTxHashAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.SetConfirmationThresholdForTxHashAsync(
				It.IsAny<string>(),
				It.IsAny<Request.SetConfirmationThresholdByTxHashModel>()))
			.Returns(CreateResponse<SetConfirmationsThresholdResponseModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.SetConfirmationThresholdForTxHashAsync(
			"txHash",
			new Request.SetConfirmationThresholdByTxHashModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetConfirmationThresholdForTxIdAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.SetConfirmationThresholdForTxIdAsync(
				It.IsAny<string>(),
				It.IsAny<Request.SetConfirmationThresholdByTxHashModel>()))
			.Returns(CreateResponse<SetConfirmationsThresholdResponseModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.SetConfirmationThresholdForTxIdAsync(
			"txId",
			new Request.SetConfirmationThresholdByTxHashModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task UnfreezeTransactionAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.UnfreezeTransactionAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _transactionService.UnfreezeTransactionAsync("transactionId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task ValidateDestinationAddressAsync_ShouldSucceed()
	{
		// Given
		_ = _transactionApiMock
			.Setup(x => x.ValidateDestinationAddressAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<AddressStatusModel>(HttpStatusCode.OK));

		// When
		var result = await _transactionService.ValidateDestinationAddressAsync("address", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

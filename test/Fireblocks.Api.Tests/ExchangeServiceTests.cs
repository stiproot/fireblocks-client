namespace Fireblocks.Api.Tests;

public class ExchangeServiceTests : BaseServiceTests
{
	private readonly Mock<IExchangeApi> _exchangeApiMock;
	private readonly IExchangeService _exchangeService;

	public ExchangeServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_exchangeApiMock = new Mock<IExchangeApi>();
		_exchangeService = new ExchangeService(_exchangeApiMock.Object);
	}

	[Fact]
	public async Task ConvertAsync_ShouldSucceed()
	{
		// Given
		_exchangeApiMock
			.Setup(x => x.ConvertAsync(It.IsAny<string>(), It.IsAny<Request.ConvertExchangeAccountFundModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _exchangeService.ConvertAsync(
			"exchangeAccountId",
			new Request.ConvertExchangeAccountFundModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetExchangeAccountAssetAsync_ShouldSucceed()
	{
		// Given
		_exchangeApiMock
			.Setup(x => x.GetExchangeAccountAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<ExchangeAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _exchangeApiMock.Object.GetExchangeAccountAssetAsync("exchangeAccountId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetExchangeAccountAsync_ShouldSucceed()
	{
		// Given
		_exchangeApiMock
			.Setup(x => x.GetExchangeAccountAsync(It.IsAny<string>()))
			.Returns(CreateResponse<ExchangeAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _exchangeApiMock.Object.GetExchangeAccountAsync("exchangeAccountId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetExchangeAccountsAsync_ShouldSucceed()
	{
		// Given
		_exchangeApiMock
			.Setup(x => x.GetExchangeAccountsAsync())
			.Returns(CreateIEnumerableResponse<ExchangeAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _exchangeApiMock.Object.GetExchangeAccountsAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task InternalTransferAsync_ShouldSucceed()
	{
		// Given
		_exchangeApiMock
			.Setup(x => x.InternalTransferAsync(It.IsAny<string>(), It.IsAny<Request.ExchangeInternalTransferModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _exchangeService.InternalTransferAsync(
			"exchangeAccountId",
			new Request.ExchangeInternalTransferModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

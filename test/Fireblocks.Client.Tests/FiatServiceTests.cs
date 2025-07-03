namespace Fireblocks.Client.Tests;

public class FiatServiceTests : BaseServiceTests
{
	private readonly Mock<IFiatApi> _fiatApiMock;
	private readonly IFiatService _fiatService;

	public FiatServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_fiatApiMock = new Mock<IFiatApi>();
		_fiatService = new FiatService(_fiatApiMock.Object);
	}

	[Fact]
	public async Task DepositFromLinkedDdaAsync_ShouldSucceed()
	{
		// Given
		_ = _fiatApiMock
			.Setup(x => x.DepositFromLinkedDdaAsync(It.IsAny<string>(), It.IsAny<Request.DepositFundModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _fiatService.DepositFromLinkedDdaAsync(
			"accountId",
			new Request.DepositFundModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetFiatAccountAsync_ShouldSucceed()
	{
		// Given
		_ = _fiatApiMock
			.Setup(x => x.GetFiatAccountAsync(It.IsAny<string>()))
			.Returns(CreateResponse<FiatAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _fiatService.GetFiatAccountAsync("accountId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetFiatAccountsAsync_ShouldSucceed()
	{
		// Given
		_ = _fiatApiMock
			.Setup(x => x.GetFiatAccountsAsync())
			.Returns(CreateIEnumerableResponse<FiatAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _fiatService.GetFiatAccountsAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task RedeemToLinkedDdaAsync_ShouldSucceed()
	{
		// Given
		_ = _fiatApiMock
			.Setup(x => x.RedeemToLinkedDdaAsync(It.IsAny<string>(), It.IsAny<Request.RedeemFundModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _fiatService.RedeemToLinkedDdaAsync(
			"accountId",
			new Request.RedeemFundModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

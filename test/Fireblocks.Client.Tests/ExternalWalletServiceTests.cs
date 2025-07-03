namespace Fireblocks.Client.Tests;

public class ExternalWalletServiceTests : BaseServiceTests
{
	private readonly Mock<IExternalWalletApi> _externalWalletApiMock;
	private readonly IExternalWalletService _externalWalletService;

	public ExternalWalletServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_externalWalletApiMock = new Mock<IExternalWalletApi>();
		_externalWalletService = new ExternalWalletService(_externalWalletApiMock.Object);
	}

	[Fact]
	public async Task CreateExternalWalletAssetAsync_ShouldSucceedAsync()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.CreateExternalWalletAssetAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.CreateExternalWalletAssetModel>()))
			.Returns(CreateResponse<ExternalWalletAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _externalWalletService.CreateExternalWalletAssetAsync(
			"walletId",
			"assetId",
			new Request.CreateExternalWalletAssetModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CreateExternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.CreateExternalWalletAsync(It.IsAny<Request.CreateExternalWalletModel>()))
			.Returns(CreateResponse<ExternalWalletModel>(HttpStatusCode.OK));

		// When
		var result = await _externalWalletService.CreateExternalWalletAsync(new Request.CreateExternalWalletModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task DeleteExternalWalletAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.DeleteExternalWalletAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _externalWalletService.DeleteExternalWalletAssetAsync("walletId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task DeleteExternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.DeleteExternalWalletAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _externalWalletService.DeleteExternalWalletAsync("walletId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetExternalWalletAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.GetExternalWalletAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<ExternalWalletAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _externalWalletService.GetExternalWalletAssetAsync("walletId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetExternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.GetExternalWalletAsync(It.IsAny<string>()))
			.Returns(CreateResponse<ExternalWalletModel>(HttpStatusCode.OK));

		// When
		var result = await _externalWalletService.GetExternalWalletAsync("walletId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetExternalWalletsAsync_ShouldSucceed()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.GetExternalWalletsAsync())
			.Returns(CreateIEnumerableResponse<ExternalWalletModel>(HttpStatusCode.OK));

		// When
		var result = await _externalWalletService.GetExternalWalletsAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetCustomerRefIdForExternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _externalWalletApiMock
			.Setup(x => x.SetCustomerRefIdForExternalWalletAsync(
				It.IsAny<string>(),
				It.IsAny<Request.SetCustomerRefIdForExternalWalletModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _externalWalletService.SetCustomerRefIdForExternalWalletAsync(
			"walletId",
			new Request.SetCustomerRefIdForExternalWalletModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

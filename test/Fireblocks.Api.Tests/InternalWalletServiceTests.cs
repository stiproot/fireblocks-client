namespace Fireblocks.Api.Tests;

public class InternalWalletServiceTests : BaseServiceTests
{
	private readonly Mock<IInternalWalletApi> _internalWalletApiMock;
	private readonly IInternalWalletService _internalWalletService;

	public InternalWalletServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_internalWalletApiMock = new Mock<IInternalWalletApi>();
		_internalWalletService = new InternalWalletService(_internalWalletApiMock.Object);
	}

	[Fact]
	public async Task CreateInternalWalletAssetAsync_ShouldSucceedAsync()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.CreateInternalWalletAssetAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.CreateInternalWalletAssetModel>()))
			.Returns(CreateResponse<WalletAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _internalWalletService.CreateInternalWalletAssetAsync(
			"walletId",
			"assetId",
			new Request.CreateInternalWalletAssetModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CreateInternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.CreateInternalWalletAsync(It.IsAny<Request.CreateInternalWalletModel>()))
			.Returns(CreateResponse<UnmanagedWalletModel>(HttpStatusCode.OK));

		// When
		var result = await _internalWalletService.CreateInternalWalletAsync(new Request.CreateInternalWalletModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task DeleteInternalWalletAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.DeleteInternalWalletAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _internalWalletService.DeleteInternalWalletAssetAsync("walletId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task DeleteInternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.DeleteInternalWalletAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _internalWalletService.DeleteInternalWalletAsync("walletId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetInternalWalletAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.GetInternalWalletAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<WalletAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _internalWalletService.GetInternalWalletAssetAsync("walletId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetInternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.GetInternalWalletAsync(It.IsAny<string>()))
			.Returns(CreateResponse<UnmanagedWalletModel>(HttpStatusCode.OK));

		// When
		var result = await _internalWalletService.GetInternalWalletAsync("walletId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetInternalWalletsAsync_ShouldSucceed()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.GetInternalWalletsAsync())
			.Returns(CreateIEnumerableResponse<UnmanagedWalletModel>(HttpStatusCode.OK));

		// When
		var result = await _internalWalletService.GetInternalWalletsAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetCustomerRefIdForInternalWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _internalWalletApiMock
			.Setup(x => x.SetCustomerRefIdForInternalWalletAsync(
				It.IsAny<string>(),
				It.IsAny<Request.SetCustomerRefIdForInternalWalletModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _internalWalletService.SetCustomerRefIdForInternalWalletAsync(
			"walletId",
			new Request.SetCustomerRefIdForInternalWalletModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

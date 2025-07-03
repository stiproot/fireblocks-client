namespace Fireblocks.Client.Tests;

public class ContractWalletServiceTests : BaseServiceTests
{
	private readonly Mock<IContractWalletApi> _contractWalletApiMock;
	private readonly IContractWalletService _contractWalletService;

	public ContractWalletServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_contractWalletApiMock = new Mock<IContractWalletApi>();
		_contractWalletService = new ContractWalletService(_contractWalletApiMock.Object);
	}

	[Fact]
	public async Task CreateContractWalletAssetAsync_ShouldSucceedAsync()
	{
		// Given
		_ = _contractWalletApiMock
			.Setup(x => x.CreateContractWalletAssetAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.CreateContractWalletAssetModel>()))
			.Returns(CreateResponse<ContractAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _contractWalletService.CreateContractWalletAssetAsync(
			"walletId",
			"assetId",
			new Request.CreateContractWalletAssetModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CreateContractWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _contractWalletApiMock
			.Setup(x => x.CreateContractWalletAsync(It.IsAny<Request.CreateContractWalletModel>()))
			.Returns(CreateResponse<UnmanagedContractModel>(HttpStatusCode.OK));

		// When
		var result = await _contractWalletService.CreateContractWalletAsync(new Request.CreateContractWalletModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task DeleteContractWalletAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _contractWalletApiMock
			.Setup(x => x.DeleteContractWalletAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _contractWalletService.DeleteContractWalletAssetAsync("walletId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task DeleteContractWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _contractWalletApiMock
			.Setup(x => x.DeleteContractWalletAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _contractWalletService.DeleteContractWalletAsync("walletId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetContractWalletAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _contractWalletApiMock
			.Setup(x => x.GetContractWalletAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<ContractAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _contractWalletService.GetContractWalletAssetAsync("walletId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetContractWalletAsync_ShouldSucceed()
	{
		// Given
		_ = _contractWalletApiMock
			.Setup(x => x.GetContractWalletAsync(It.IsAny<string>()))
			.Returns(CreateResponse<UnmanagedContractModel>(HttpStatusCode.OK));

		// When
		var result = await _contractWalletService.GetContractWalletAsync("walletId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetContractWalletsAsync_ShouldSucceed()
	{
		// Given
		_ = _contractWalletApiMock
			.Setup(x => x.GetContractWalletsAsync())
			.Returns(CreateIEnumerableResponse<UnmanagedContractModel>(HttpStatusCode.OK));

		// When
		var result = await _contractWalletService.GetContractWalletsAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

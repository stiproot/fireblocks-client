namespace Fireblocks.Api.Tests;

public class VaultServiceTests : BaseServiceTests
{
	private readonly Mock<IVaultApi> _vaultApiMock;
	private readonly IVaultService _vaultService;

	public VaultServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_vaultApiMock = new Mock<IVaultApi>();
		_vaultService = new VaultService(_vaultApiMock.Object);
	}

	[Fact]
	public async Task CreateVaultAccountAsync_ShouldSucceed()
	{
		// Given
		_vaultApiMock
			.Setup(x => x.CreateVaultAccountAsync(It.IsAny<Request.CreateVaultAccountModel>()))
			.Returns(CreateResponse<VaultAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.CreateVaultAccountAsync(new Request.CreateVaultAccountModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public void CreateVaultAssetAsync_ShouldSucceed()
	{
		// Given
		_vaultApiMock
			.Setup(x => x.CreateVaultAssetAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.CreateVaultAssetModel>()))
			.Returns(CreateResponse<VaultAssetModel>(HttpStatusCode.OK));

		// When
		var result = _vaultService.CreateVaultAssetAsync(
			"vaultAccountId",
			"assetId",
			new Request.CreateVaultAssetModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
	}

	[Fact]
	public void GenerateNewAddressAsync_ShouldSucceed()
	{
		// Given
		_vaultApiMock
			.Setup(x => x.GenerateNewAddressAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.GenerateNewAddressModel>()))
			.Returns(CreateResponse<CreateAddressModel>(HttpStatusCode.OK));

		// When
		var result = _vaultService.GenerateNewAddressAsync(
			"vaultAccountId",
			"assetId",
			new Request.GenerateNewAddressModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.Result.StatusCode);
	}
}

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
		_ = _vaultApiMock
			.Setup(x => x.CreateVaultAccountAsync(It.IsAny<Request.CreateVaultAccountModel>()))
			.Returns(CreateResponse<VaultAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.CreateVaultAccountAsync(new Request.CreateVaultAccountModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task CreateVaultAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.CreateVaultAssetAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.CreateVaultAssetModel>()))
			.Returns(CreateResponse<VaultAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.CreateVaultAssetAsync(
			"vaultAccountId",
			"assetId",
			new Request.CreateVaultAssetModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GenerateNewAddressAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GenerateNewAddressAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.GenerateNewAddressModel>()))
			.Returns(CreateResponse<CreateAddressModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GenerateNewAddressAsync(
			"vaultAccountId",
			"assetId",
			new Request.GenerateNewAddressModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetDepositAddressesAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetDepositAddressesAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.GetDepositAddressesModel>()))
			.Returns(CreateIEnumerableResponse<VaultAccountAssetAddressModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetDepositAddressesAsync(
			"vaultAccountId",
			"assetId",
			new Request.GetDepositAddressesModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetMaxSpendableAmountAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetMaxSpendableAmountAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<MaxSpendableAmountModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetMaxSpendableAmountAsync(
			"vaultAccountId",
			"assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetPublicKeyInfoAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetPublicKeyInfoAsync(It.IsAny<GetPublicKeyInfoParams>()))
			.Returns(CreateResponse<PublicKeyModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetPublicKeyInfoAsync(new GetPublicKeyInfoParams());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetPublicKeyInfoForVaultAccountAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetPublicKeyInfoForVaultAccountAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<int>(),
				It.IsAny<GetPublicKeyInfoForVaultAccountParams>()))
			.Returns(CreateResponse<PublicKeyModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetPublicKeyInfoForVaultAccountAsync(
			"vaultAccountId",
			"assetId",
			"publicKey",
			1,
			new GetPublicKeyInfoForVaultAccountParams());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetUnspentInputsAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetUnspentInputsAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateIEnumerableResponse<UnspentInputsDataModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetUnspentInputsAsync("vaultAccountId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetVaultAccountAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetVaultAccountAssetAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<VaultAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetVaultAccountAssetAsync("vaultAccountId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetVaultAccountAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetVaultAccountAsync(It.IsAny<string>()))
			.Returns(CreateResponse<VaultAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetVaultAccountAsync("vaultAccountId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetVaultAccountsAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetVaultAccountsAsync(It.IsAny<GetVaultAccountsParams>()))
			.Returns(CreateIEnumerableResponse<VaultAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetVaultAccountsAsync(new GetVaultAccountsParams());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetVaultAccountsWithPageInfoAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetVaultAccountsWithPageInfoAsync(It.IsAny<GetVaultAccountsWithPageInfoParams>()))
			.Returns(CreateResponse<VaultAccountsPagedModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetVaultAccountsWithPageInfoAsync(new GetVaultAccountsWithPageInfoParams());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetVaultAssetsBalanceAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetVaultAssetsBalanceAsync(It.IsAny<GetVaultAssetsBalanceParams>()))
			.Returns(CreateIEnumerableResponse<VaultAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetVaultAssetsBalanceAsync(new GetVaultAssetsBalanceParams());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetVaultBalanceByAssetAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.GetVaultBalanceByAssetAsync(It.IsAny<string>()))
			.Returns(CreateResponse<VaultAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.GetVaultBalanceByAssetAsync("assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task HideVaultAccountAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.HideVaultAccountAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _vaultService.HideVaultAccountAsync("vaultAccountId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task RefreshVaultAssetBalanceAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.RefreshVaultAssetBalanceAsync(It.IsAny<string>(), It.IsAny<string>()))
			.Returns(CreateResponse<VaultAssetModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.RefreshVaultAssetBalanceAsync("vaultAccountId", "assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetAddressDescriptionAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.SetAddressDescriptionAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.SetAddressDescriptionModel>()))
			.Returns(CreateResponse<SetAddressDescriptionModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.SetAddressDescriptionAsync(
			"vaultAccountId",
			"assetId",
			"address",
			new Request.SetAddressDescriptionModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetAutoFuelAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.SetAutoFuelAsync(It.IsAny<string>(), It.IsAny<Request.SetAutoFuelModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _vaultService.SetAutoFuelAsync("vaultAccountId", new Request.SetAutoFuelModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetCustomerRefIdForAddressAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.SetCustomerRefIdForAddressAsync(
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<Request.SetVaultAccountCustomerRefIdModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _vaultService.SetCustomerRefIdForAddressAsync(
			"vaultAccountId",
			"assetId",
			"address",
			new Request.SetVaultAccountCustomerRefIdModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetVaultAccountCustomerRefIdAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.SetVaultAccountCustomerRefIdAsync(
				It.IsAny<string>(),
				It.IsAny<Request.SetVaultAccountCustomerRefIdModel>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _vaultService.SetVaultAccountCustomerRefIdAsync(
			"vaultAccountId",
			new Request.SetVaultAccountCustomerRefIdModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task UnhideVaultAccountAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.UnhideVaultAccountAsync(It.IsAny<string>()))
			.Returns(Task.FromResult(new ApiResponse<string>(
				new HttpResponseMessage(HttpStatusCode.OK),
				default,
				new RefitSettings())));

		// When
		var result = await _vaultService.UnhideVaultAccountAsync("vaultAccountId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task UpdateVaultAccountAsync_ShouldSucceed()
	{
		// Given
		_ = _vaultApiMock
			.Setup(x => x.UpdateVaultAccountAsync(
				It.IsAny<string>(),
				It.IsAny<Request.UpdateVaultAccountModel>()))
			.Returns(CreateResponse<VaultAccountModel>(HttpStatusCode.OK));

		// When
		var result = await _vaultService.UpdateVaultAccountAsync(
			"vaultAccountId",
			new Request.UpdateVaultAccountModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

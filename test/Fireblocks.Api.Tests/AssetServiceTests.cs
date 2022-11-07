namespace Fireblocks.Api.Tests;

public class AssetServiceTests : BaseServiceTests
{
	private readonly Mock<IAssetApi> _assetApiMock;
	private readonly IAssetService _assetService;

	public AssetServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_assetApiMock = new Mock<IAssetApi>();
		_assetService = new AssetService(_assetApiMock.Object);
	}

	[Fact]
	public async Task GetSupportedAssetsAsync_ShouldSucceed()
	{
		// Given
		_ = _assetApiMock
			.Setup(x => x.GetSupportedAssetsAsync())
			.Returns(CreateIEnumerableResponse<AssetTypeModel>(HttpStatusCode.OK));

		// When
		var result = await _assetService.GetSupportedAssetsAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

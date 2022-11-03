namespace Fireblocks.Api.Tests;

public class GasStationServiceTests : BaseServiceTests
{
	private readonly Mock<IGasStationApi> _gasStationApiMock;
	private readonly IGasStationService _gasStationService;

	public GasStationServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_gasStationApiMock = new Mock<IGasStationApi>();
		_gasStationService = new GasStationService(_gasStationApiMock.Object);
	}

	[Fact]
	public async Task GetGasStationInfoAsync_ShouldSucceed()
	{
		// Given
		_gasStationApiMock
			.Setup(x => x.GetGasStationInfoAsync())
			.Returns(CreateIEnumerableResponse<GasStationInfoModel>(HttpStatusCode.OK));

		// When
		var result = await _gasStationService.GetGasStationInfoAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetGasStationInfoAsyncPerAsset_ShouldSucceed()
	{
		// Given
		_gasStationApiMock
			.Setup(x => x.GetGasStationInfoAsync(It.IsAny<string>()))
			.Returns(CreateResponse<GasStationInfoModel>(HttpStatusCode.OK));

		// When
		var result = await _gasStationService.GetGasStationInfoAsync("assetId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetGasStationConfigurationAsync_ShouldSucceed()
	{
		// Given
		_gasStationApiMock
			.Setup(x => x.SetGasStationConfigurationAsync(It.IsAny<Request.SetGasStationConfigurationModel>()))
			.Returns(CreateResponse<GasStationInfoModel>(HttpStatusCode.OK));

		// When
		var result = await _gasStationService.SetGasStationConfigurationAsync(new Request.SetGasStationConfigurationModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task SetGasStationConfigurationAsyncPerAsset_ShouldSucceed()
	{
		// Given
		_gasStationApiMock
			.Setup(x => x.SetGasStationConfigurationAsync(
				It.IsAny<string>(),
				It.IsAny<Request.SetGasStationConfigurationModel>()))
			.Returns(CreateResponse<GasStationInfoModel>(HttpStatusCode.OK));

		// When
		var result = await _gasStationService.SetGasStationConfigurationAsync(
			"assetId",
			new Request.SetGasStationConfigurationModel());

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

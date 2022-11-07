namespace Fireblocks.Api.Tests;

public class NetworkServiceTests : BaseServiceTests
{
	private readonly Mock<INetworkApi> _networkApiMock;
	private readonly INetworkService _networkService;

	public NetworkServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_networkApiMock = new Mock<INetworkApi>();
		_networkService = new NetworkService(_networkApiMock.Object);
	}

	[Fact]
	public async Task GetNetworkConnectionAsync_ShouldSucceed()
	{
		// Given
		_ = _networkApiMock
			.Setup(x => x.GetNetworkConnectionAsync(It.IsAny<string>()))
			.Returns(CreateResponse<NetworkConnectionModel>(HttpStatusCode.OK));

		// When
		var result = await _networkService.GetNetworkConnectionAsync("connectionId");

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Fact]
	public async Task GetNetworkConnectionsAsync_ShouldSucceed()
	{
		// Given
		_ = _networkApiMock
			.Setup(x => x.GetNetworkConnectionsAsync())
			.Returns(CreateIEnumerableResponse<NetworkConnectionModel>(HttpStatusCode.OK));

		// When
		var result = await _networkService.GetNetworkConnectionsAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

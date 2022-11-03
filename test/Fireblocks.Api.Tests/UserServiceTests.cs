namespace Fireblocks.Api.Tests;

public class UserServiceTests : BaseServiceTests
{
	private readonly Mock<IUserApi> _userApiMock;
	private readonly IUserService _userService;

	public UserServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_userApiMock = new Mock<IUserApi>();
		_userService = new UserService(_userApiMock.Object);
	}

	[Fact]
	public async Task GetUsersAsync_ShouldSucceed()
	{
		// Given
		_userApiMock
			.Setup(x => x.GetUsersAsync())
			.Returns(CreateIEnumerableResponse<UserModel>(HttpStatusCode.OK));

		// When
		var result = await _userService.GetUsersAsync();

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}
}

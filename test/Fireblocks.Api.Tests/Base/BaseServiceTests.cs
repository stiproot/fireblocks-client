namespace Fireblocks.Api.Tests;

public class BaseServiceTests
{
	protected readonly ITestOutputHelper TestOutputHelper;
	protected readonly IFireblocksApiConfig FireblocksApiConfig;
	protected readonly IJwtConfig JwtConfig;

	public BaseServiceTests(ITestOutputHelper testOutputHelper)
	{
		TestOutputHelper = testOutputHelper;
		FireblocksApiConfig = new FireblocksApiConfig
		{
			BaseUrl = "http://localhost",
			ApiKey = "TestApiKey",
			SecretKey = Environment.GetEnvironmentVariable("FireblocksApiConfigSecretKey")
		};
		JwtConfig = new JwtConfig()
		{
			Nonce = "D3D2D2H7RIKAL",
			IssueAt = new DateTime(2022, 10, 10, 0, 0, 0, DateTimeKind.Utc),
			ExpiredInSeconds = 25
		};
	}

	protected static Task<ApiResponse<T>> CreateResponse<T>(HttpStatusCode statusCode)
		where T : IBaseResponseModel =>
			Task.FromResult(new ApiResponse<T>(
				new HttpResponseMessage(statusCode),
				default,
				new RefitSettings()));

	protected static Task<ApiResponse<IEnumerable<T>>> CreateIEnumerableResponse<T>(HttpStatusCode statusCode)
		where T : IBaseResponseModel =>
			Task.FromResult(new ApiResponse<IEnumerable<T>>(
				new HttpResponseMessage(statusCode),
				default,
				new RefitSettings()));
}

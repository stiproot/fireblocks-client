using System.Net.Http.Json;

namespace Fireblocks.Client.Tests;

public class TokenServiceTests : BaseServiceTests
{
	private readonly ITokenService _tokenService;

	public TokenServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) =>
		_tokenService = new TokenService(FireblocksApiConfig, JwtConfig);

	[Fact]
	public void BuildToken_ShouldSucceed()
	{
		// Given
		var requestMessgage = new HttpRequestMessage(HttpMethod.Get, $"{FireblocksApiConfig.BaseUrl}/v1/vault/accounts");
		var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1cmkiOiIvdjEvdmF1bHQvYWNjb3VudHMiLCJub25jZSI6IkQzRDJEMkg3UklLQUwiLCJpYXQiOjE2NjUzNjAwMDAsImV4cCI6MTY2NTM2MDAyNSwic3ViIjoiVGVzdEFwaUtleSIsImJvZHlIYXNoIjoiMTJhZTMyY2IxZWMwMmQwMWVkYTM1ODFiMTI3YzFmZWUzYjBkYzUzNTcyZWQ2YmFmMjM5NzIxYTAzZDgyZTEyNiJ9.q6hzgU3nw8-CX372vzRZVyplA5QP2vB5eYR_qdCp8eu2W2WSlBDoWcTzBWzVqDyk0D_BIkWJP8eGO0TBBEArh0L7LaYRVWU4lbJMxDwg5MJ3AWg_FbnC7en62e9BAK5ohQwKDOYYP4yox1SZAqpafirVoF_p9LWwIuFpnPn0nUvvEGiS3BPAniOfAqM8jp7l0c98GaH-gfkyQIr5NHhqe4zjYF6YbV6LWDuzfGst3QlL_QHLjiPJ_c9oVfGimaL0iXFgR3i4QKB2VwVhoabFS_CPBvODRbyQJTlB6DGp968MHjall7algn6QBuGTNhX6iE1WYowZLonmZM4sNnC0PaIfkHiHJt6_yqhr113PuNvzcG5ZxPXmeBUA9xwKLk6d-q1qoAcjvFRY0sjAsEqyGUTWV--tAPU5hZduQOXgnQSBk_fim-JBXftkdGNiunGNVnN15czWtXkuYIxkcoDA-kKQqXh-hFORe-_xYSszSS1akPlG95rTx1eQ-8c_XrhEcSR8Dax6dYcC8aDQH17KszLrZN7OmqRdy082naKX7OBegZxVpfxMwsIJM5wwX3KubU-_W6Gps8aH1uY-k1BFXPFLKU3RgHz4HOly3t5eAW4Tv_Ye9-mkHX-L25KNvRFAG3tIgOAfb2IFn5-J_8su92fhmFs9P30L5n9ffTUZZTY";

		// When
		var result = _tokenService.BuildToken(requestMessgage);

		// Then
		Assert.Equal(token, result);
	}

	[Fact]
	public void BuildToken_WithRequestBody_ShouldSucceed()
	{
		// Given
		var requestMessgage = new HttpRequestMessage(HttpMethod.Get, $"{FireblocksApiConfig.BaseUrl}/v1/vault/accounts")
		{
			Content = JsonContent.Create(new { })
		};
		var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1cmkiOiIvdjEvdmF1bHQvYWNjb3VudHMiLCJub25jZSI6IkQzRDJEMkg3UklLQUwiLCJpYXQiOjE2NjUzNjAwMDAsImV4cCI6MTY2NTM2MDAyNSwic3ViIjoiVGVzdEFwaUtleSIsImJvZHlIYXNoIjoiNDQxMzZmYTM1NWIzNjc4YTExNDZhZDE2ZjdlODY0OWU5NGZiNGZjMjFmZTc3ZTgzMTBjMDYwZjYxY2FhZmY4YSJ9.PQ4ATmj3nX95QAZNoy6sDohQ-B_t0uIq2OmN9PsSCtx4bP26C4xc0QGmMAKEWa3k_VGSinqSIPgIuzcA-yMzsVZ_5wbEfSBfZF6pCOxGrv2EQMpYMD93O6NIcw_gcDE2Kxrwai9e9ftg6KN195I_yWYD8gIJKbnBkCANzu4CYoPTKR8KavqY0Y3xepMjtHZFcFna87lVjypG0j0_7ArAx3b2vowoE8upollyPMaT0ddYyqHpuDu2Fa0XR0InAErTtgCwfX8EZXr7OC9LqVoxKjn2VGlkf68bEuLnbZ-_Hl-i-nDuVN99jjXU1CiGqb1Tp8EF9-hInjHUvC7AM5IO6Yn3t1tiA-DzOhUDJs28sHofNdRQ0hckCUTBh-34dzVVYa6UdgxvIeFDmD3-xZBZbhckrbDuBflhtdGXTC7Uqolf7hNd83YkZC9gMCjTrbHR_9CTkqqKsVwconmg8-IU7hZD3WKDdvrhvYh4Q5VXpylX1AHQVXzyyHf8TegWLyQ1Yn7MvS2gAyki1FBGEQfFz942wg5rJTdXE3QpEHe8QFi-NMPVM-EC-vXdTLIz4Y_qKW2WpXAkivHRTYiOPaGJ-MThPubi0g3Ym3yebFBfontpW4itE8ltRakb9lUdzDmG_S4JX4CiK2GHDJ4n7uwJ9o3HeVmvp2ULfbTR3B6lMTw";

		// When
		var result = _tokenService.BuildToken(requestMessgage);

		// Then
		Assert.Equal(token, result);
	}
}

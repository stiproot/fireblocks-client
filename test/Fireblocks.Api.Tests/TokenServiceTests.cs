namespace Fireblocks.Api.Tests;

public class TokenServiceTests : BaseServiceTests
{
	private readonly ITokenService _tokenService;
	private readonly IJwtConfig _jwtConfig;

	public TokenServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_jwtConfig = new JwtConfig()
		{
			Nonce = "D3D2D2H7RIKAL",
			IssueAt = new DateTime(2022, 10, 10, 0, 0, 0, DateTimeKind.Utc),
			ExpiredInSeconds = 25
		};

		_tokenService = new TokenService(FireblocksApiConfig, _jwtConfig);
	}

	[Fact]
	public void BuildToken_ShouldSucceed()
	{
		// Given
		var requestMessgage = new HttpRequestMessage(HttpMethod.Get, "https://api.fireblocks.com/v1/vault/accounts");
		var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1cmkiOiIvdjEvdmF1bHQvYWNjb3VudHMiLCJub25jZSI6IkQzRDJEMkg3UklLQUwiLCJpYXQiOjE2NjUzNjAwMDAsImV4cCI6MTY2NTM2MDAyNSwic3ViIjoiVGVzdEFwaUtleSIsImJvZHlIYXNoIjoiIn0.yqnHKoTdp_WbSGQcmwHjFAySLq77KLaiOAI9KBCS-pXc16FUCaBEBNG2rZvBiJCMDznf1C5VBwptiYj9L_uyAWuSoDhYRI17V9Z2Y5WeSP3R7C4LjeJuyLMOlQcYs1S7NH5clg99Gus4CCEA9yAqfinPZHCzTauv9_k_ep8EuT6d6XjfWZ9KSFMlX7o79XfG5ggglVkxT5JlkClzdyRfa3R9y0JfsMVtSEMySk0Tv-NfiUZkddPrCWmieRxaeYdS8-d5AEjbOkc3TxmrgTeALeIeWIJgzf2pmvckhxTV1T3qWajlv5h9fAzNF8dIgan1fX94r80kzEi3pd03diRt95mGTR6ypQ6JHGPuDDJpqykw5ZM-OHSt4Otpd-fyrzxWBuYxnZDrL2PqzeB1mb6V90ESwiqizvCEjJxCzHwCc4xis7TPcorl6hVLArsC_6H_OxlBMlspse-RkohzSFp6EZONGdwtFAd434n4CcaDbGRcoYiPjFFzEDRa5nrSP17-bim6sr4jNfdHBjbMntSQ8NBcp7lMeL5W3KqfmiFaM4Gc0VjwaXN4CIOnpRGUrYplEMj9oIRig2vJEHADla121Vzl_oMBgfMqWsP79qqreTd-YmBEtvS9PwaBsiC-m3djzgZGoFGpRY6YxnGCKfPnYXsSoY2U9i1EPu47llvglY4";

		// When
		var result = _tokenService.BuildToken(requestMessgage);

		// Then
		Assert.Equal(token, result);
	}
}

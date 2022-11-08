using System.Net.Http.Headers;
using Fireblocks.Api.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fireblocks.Api.Handlers;

public class AuthHeaderHandler : DelegatingHandler
{
	private readonly ILogger<AuthHeaderHandler> _logger;
	private readonly IFireblocksApiConfig _config;
	private readonly ITokenService _tokenService;

	public AuthHeaderHandler(ILogger<AuthHeaderHandler> logger, IFireblocksApiConfig config, ITokenService tokenService)
	{
		ArgumentNullException.ThrowIfNull(config.ApiKey, nameof(config.ApiKey));
		ArgumentNullException.ThrowIfNull(config.SecretKey, nameof(config.SecretKey));

		_logger = logger;
		_config = config;
		_tokenService = tokenService;
		InnerHandler = new HttpClientHandler();
	}

	protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		request.Headers.Add("X-API-Key", _config.ApiKey);
		request.Headers.Authorization = new AuthenticationHeaderValue(
			"Bearer",
			_tokenService.BuildToken(request));

		_logger.LogDebug("Sending request: {@Request}", request);

		return await base.SendAsync(request, cancellationToken);
	}
}

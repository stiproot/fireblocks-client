using System.Text.Json;
using System.Text.Json.Serialization;
using Fireblocks.Api.Configs;
using Fireblocks.Api.Handlers;
using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Fireblocks.Api.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddFireblocksApiConfigs(
		this IServiceCollection services,
		IConfiguration configuration) =>
			services
				.AddSingleton(
					configuration.GetSection("Fireblocks").GetSection("ApiConfig").Get<FireblocksApiConfig>())
				.AddSingleton(
					configuration.GetSection("Fireblocks").GetSection("JwtConfig").Get<JwtConfig>());

	public static IServiceCollection AddFireblocksApiServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		var config = configuration.GetSection("Fireblocks").GetSection("ApiConfig").Get<FireblocksApiConfig>();
		var refitSettings = new RefitSettings
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				Converters =
				{
					new JsonStringEnumConverter()
				},
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				NumberHandling = JsonNumberHandling.AllowReadingFromString,
				PropertyNameCaseInsensitive = true
			})
		};

		_ = services.AddSingleton<AuthHeaderHandler>();

		_ = services
			.AddRefitClient<IVaultApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/vault"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IInternalWalletApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/internal_wallets"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IExternalWalletApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/external_wallets"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IContractWalletApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/contracts"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IExchangeApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/exchange_accounts"))
			.AddHttpMessageHandler<AuthHeaderHandler>();

		_ = services
			.AddRefitClient<IFiatApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/fiat_accounts"))
			.AddHttpMessageHandler<AuthHeaderHandler>();

		_ = services
			.AddRefitClient<INetworkApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/fiat_accounts"))
			.AddHttpMessageHandler<AuthHeaderHandler>();

		_ = services
			.AddSingleton<IVaultService, VaultService>()
			.AddSingleton<IInternalWalletService, InternalWalletService>()
			.AddSingleton<IExternalWalletService, ExternalWalletService>()
			.AddSingleton<IContractWalletService, ContractWalletService>()
			.AddSingleton<IExchangeService, ExchangeService>()
			.AddSingleton<IFiatService, FiatService>()
			.AddSingleton<INetworkService, NetworkService>();

		return services;
	}
}

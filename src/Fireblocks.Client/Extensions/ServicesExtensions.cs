using System.Text.Json;
using System.Text.Json.Serialization;
using Fireblocks.Client.Configs;
using Fireblocks.Client.Handlers;
using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Fireblocks.Client.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddFireblocksApiConfigs(this IServiceCollection @this,
		IConfiguration configuration
	)
	{
		@this
			.AddSingleton<IFireblocksApiConfig>(
				configuration.GetSection("Fireblocks").GetSection("ApiConfig").Get<FireblocksApiConfig>()!
			)
			.AddSingleton<IJwtConfig>(
				configuration.GetSection("Fireblocks").GetSection("JwtConfig").Get<JwtConfig>()!
			);

		return @this;
	}

	public static IServiceCollection AddFireblocksApiServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		var config = configuration.GetSection("Fireblocks").GetSection("ApiConfig").Get<FireblocksApiConfig>()!;
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
			.AddRefitClient<ITransactionApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/transactions"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<INetworkApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/network_connections"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IAssetApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/supported_assets"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IGasStationApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/gas_station"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IUserApi>(refitSettings)
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/users"))
			.AddHttpMessageHandler<AuthHeaderHandler>();

		_ = services
			.AddSingleton<IVaultService, VaultService>()
			.AddSingleton<IInternalWalletService, InternalWalletService>()
			.AddSingleton<IExternalWalletService, ExternalWalletService>()
			.AddSingleton<IContractWalletService, ContractWalletService>()
			.AddSingleton<IExchangeService, ExchangeService>()
			.AddSingleton<IFiatService, FiatService>()
			.AddSingleton<ITransactionService, TransactionService>()
			.AddSingleton<INetworkService, NetworkService>()
			.AddSingleton<IAssetService, AssetService>()
			.AddSingleton<IGasStationService, GasStationService>()
			.AddSingleton<IUserService, UserService>()
			.AddSingleton<ITokenService, TokenService>();

		return services;
	}
}

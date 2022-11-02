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
					configuration.GetSection("Fireblocks").GetSection("ApiConfig").Get<IFireblocksApiConfig>())
				.AddSingleton(
					configuration.GetSection("Fireblocks").GetSection("JwtConfig").Get<IJwtConfig>());

	public static IServiceCollection AddFireblocksApiServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		var config = configuration.GetSection("Fireblocks").GetSection("ApiConfig").Get<IFireblocksApiConfig>();

		_ = services.AddSingleton<AuthHeaderHandler>();

		_ = services
			.AddRefitClient<IVaultApi>()
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/vault"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IInternalWalletApi>()
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/internal_wallets"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IExternalWalletApi>()
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/external_wallets"))
			.AddHttpMessageHandler<AuthHeaderHandler>();
		_ = services
			.AddRefitClient<IContractWalletApi>()
			.ConfigureHttpClient(c => c.BaseAddress = new Uri($"{config.BaseUrl}/{config.Version}/contracts"))
			.AddHttpMessageHandler<AuthHeaderHandler>();

		_ = services
			.AddSingleton<IVaultService, VaultService>()
			.AddSingleton<IInternalWalletService, InternalWalletService>()
			.AddSingleton<IExternalWalletService, ExternalWalletService>()
			.AddSingleton<IContractWalletService, ContractWalletService>();

		return services;
	}
}

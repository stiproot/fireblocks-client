// using Fireblocks.Client.Configs;
using Fireblocks.Client.Extensions;
// using Fireblocks.Client.Abstractions;
// using Fireblocks.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fireblocks.Console;

public static class ServiceProviderFactory
{
  private static ServiceCollection CreateServiceCollection() => new();

  public static IServiceProvider CreateServiceProvider()
  {
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    var services = CreateServiceCollection();

    // var apiConfig = new FireblocksApiConfig
    // {
    //   BaseUrl = configuration["Fireblocks:ApiConfig:BaseUrl"]!,
    //   Version = configuration["Fireblocks:ApiConfig:Version"]!,
    //   ApiKey = configuration["Fireblocks:ApiConfig:ApiKey"]!,
    //   SecretKey = configuration["Fireblocks:ApiConfig:ApiSecret"]!,
    // };

    // var jwtConfig = new JwtConfig
    // {
    //   ExpiredInSeconds = int.Parse(configuration["Fireblocks:JwtConfig:ExpiredInSeconds"]!)
    // };

    // services.AddSingleton<IFireblocksApiConfig>(apiConfig);
    // services.AddSingleton<IJwtConfig>(jwtConfig);

    services.AddSingleton<IConfiguration>(configuration);
    // services.AddSingleton<ITokenService, TokenService>();
    services
      .AddFireblocksApiConfigs(configuration)
      .AddFireblocksApiServices(configuration);

    return services.BuildServiceProvider();
  }
}
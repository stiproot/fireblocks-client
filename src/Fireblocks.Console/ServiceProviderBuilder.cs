using Fireblocks.Client.Extensions;
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

    services.AddSingleton<IConfiguration>(configuration);
    services
      .AddFireblocksApiConfigs(configuration)
      .AddFireblocksApiServices(configuration);

    return services.BuildServiceProvider();
  }
}
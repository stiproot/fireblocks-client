# Fireblocks.Client

## Description

This is a .NET6 library for interacting with the [Fireblocks](https://www.fireblocks.com/) API.

## Quick start

### Appsettings.json

```json
{
	"Fireblocks": {
		"ApiConfig": {
			"BaseUrl": "https://api.fireblocks.io",
			"Version": "v1",
			"ApiKey": "YOUR_API_KEY",
			"SecretKey": "YOUR_SECRET_KEY"
		},
		"JwtConfig": {
			"ExpiredInSeconds": 25
		}
	}
}
```

### Add configs & services

```csharp
using Fireblocks.Client.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	services
		.AddFireblocksApiConfigs(configuration);
		.AddFireblocksApiServices(configuration);
}
```

### Using services

```csharp
using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models.Responses;
using Fireblocks.Client.Services;

public class MyProcess
{
	private readonly IVaultService _vaultService;

	public MyProcess(IVaultService vaultService) =>
		_vaultService = vaultService;

	public async Task GetVaultAccountAsync()
	{
		var myVaultAccount = await _vaultService.GetVaultAccountAsync("YOUR_VAULT_ACCOUNT_ID");
	}
}
```

## Reference

- [Fireblocks REST API](https://docs.fireblocks.com/api)

# Fireblocks.Api

[![GitHub](https://img.shields.io/github/license/ed555009/fireblocks-api)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/fireblocks-api?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Fireblocks.Api)](https://www.nuget.org/packages/Fireblocks.Api)

![Coverage](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=coverage&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Quality Gate Status](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=alert_status&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Reliability Rating](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=reliability_rating&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Security Rating](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=security_rating&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)
![Vulnerabilities](http://direct.link2me.com.tw:9000/api/project_badges/measure?project=fireblocks-api&metric=vulnerabilities&token=edde8bb242d724653b64036f7a3fe6cf539b3a1a)

## Description

This is a .NET6 library for interacting with the [Fireblocks](https://www.fireblocks.com/) API.

## Quick start

### Installation

```bash
dotnet add package Fireblocks.Api
```

### Appsettings.json

```json
{
	"Fireblocks": {
		"ApiConfig":
		{
			"BaseUrl": "https://api.fireblocks.io",
			"Version": "v1",
			"ApiKey": "YOUR_API_KEY",
			"ApiSecret": "YOUR_API_SECRET"
		},
		"JwtConfig":{
			"ExpiredInSeconds": 25
		}
	}
}
```

### Add configs & services

```csharp
using Fireblocks.Api.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	services
		.AddFireblocksApiConfigs(configuration);
		.AddFireblocksApiServices(configuration);
}
```

### Using services

```csharp
using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Responses;
using Fireblocks.Api.Services;

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

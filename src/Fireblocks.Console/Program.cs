using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models;
using Microsoft.Extensions.DependencyInjection;
using Fireblocks.Console;

var svcProvider = ServiceProviderFactory.CreateServiceProvider();

var txSvc = svcProvider.GetRequiredService<ITransactionService>();

var tx = new CreateTransactionModelV2
{
  Operation = "TRANSFER",
  AssetId = "SOL_TEST",
  Amount = "0.1",
  Source = new TransactionSource
  {
    Type = "VAULT_ACCOUNT",
    Id = "8"
  },
  Destination = new TransactionDestination
  {
    Type = "ONE_TIME_ADDRESS",
    OneTimeAddress = new OneTimeAddress
    {
      Address = "A5f2ZHBTw92Ki9dU1TuqVuoADCiQ7sqvs3PSgj45iKHN"
    }
  },
  ExternalTxId = Guid.NewGuid().ToString(),
};

await txSvc.CreateTransactionAsyncV2(tx);

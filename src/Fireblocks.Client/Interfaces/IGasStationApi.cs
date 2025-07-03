using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

public interface IGasStationApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<GasStationInfoModel>>> GetGasStationInfoAsync();

	[Get("/{assetId}")]
	Task<ApiResponse<GasStationInfoModel>> GetGasStationInfoAsync(string assetId);

	[Put("/configuration")]
	Task<ApiResponse<GasStationInfoModel>> SetGasStationConfigurationAsync(
		[Body] SetGasStationConfigurationModel payload);

	[Put("/configuration/{assetId}")]
	Task<ApiResponse<GasStationInfoModel>> SetGasStationConfigurationAsync(
		string assetId,
		[Body] SetGasStationConfigurationModel payload);
}

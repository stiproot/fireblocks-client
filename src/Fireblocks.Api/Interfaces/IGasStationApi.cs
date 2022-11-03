using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IGasStationApi
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

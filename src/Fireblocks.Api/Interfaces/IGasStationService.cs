using Fireblocks.Api.Models.Requests;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IGasStationService
{
	/// <summary>
	/// Retrieve your Gas Station Settings<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-your-gas-station-settings
	/// </summary>
	Task<ApiResponse<IEnumerable<GasStationInfoModel>>> GetGasStationInfoAsync();

	/// <summary>
	/// Retrieve your Gas Station Settings per Asset<br/>
	/// Retrieves the settings of your Gas Station per the requested asset<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-your-gas-station-settings-per-asset
	/// </summary>
	Task<ApiResponse<GasStationInfoModel>> GetGasStationInfoAsync(string assetId);

	/// <summary>
	/// Edit your Gas Station settings<br/>
	/// https://docs.fireblocks.com/api/?#edit-your-gas-station-settings
	/// </summary>
	Task<ApiResponse<GasStationInfoModel>> SetGasStationConfigurationAsync(SetGasStationConfigurationModel payload);

	/// <summary>
	/// Edit your Gas Station settings per Asset<br/>
	/// Configure your Gas Station's settings of the requested asset<br/>
	/// https://docs.fireblocks.com/api/?#edit-your-gas-station-settings-2
	/// </summary>
	Task<ApiResponse<GasStationInfoModel>> SetGasStationConfigurationAsync(
		string assetId,
		SetGasStationConfigurationModel payload);
}

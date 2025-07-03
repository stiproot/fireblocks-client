using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models.Requests;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Services;

public class GasStationService : IGasStationService
{
	private readonly IGasStationApi _gasStationApi;

	public GasStationService(IGasStationApi gasStationApi) =>
		_gasStationApi = gasStationApi;

	public async Task<ApiResponse<IEnumerable<GasStationInfoModel>>> GetGasStationInfoAsync() =>
		await _gasStationApi.GetGasStationInfoAsync();

	public async Task<ApiResponse<GasStationInfoModel>> GetGasStationInfoAsync(string assetId) =>
		await _gasStationApi.GetGasStationInfoAsync(assetId);

	public async Task<ApiResponse<GasStationInfoModel>> SetGasStationConfigurationAsync(
		SetGasStationConfigurationModel payload) =>
			await _gasStationApi.SetGasStationConfigurationAsync(payload);

	public async Task<ApiResponse<GasStationInfoModel>> SetGasStationConfigurationAsync(
		string assetId,
		SetGasStationConfigurationModel payload) =>
			await _gasStationApi.SetGasStationConfigurationAsync(assetId, payload);
}

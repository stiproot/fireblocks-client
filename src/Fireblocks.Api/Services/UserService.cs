using Fireblocks.Api.Interfaces;
using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Services;

public class UserService : IUserService
{
	private readonly IUserApi _userApi;

	public UserService(IUserApi userApi) =>
		_userApi = userApi;

	public async Task<ApiResponse<IEnumerable<UserModel>>> GetUsersAsync() =>
		await _userApi.GetUsersAsync();
}

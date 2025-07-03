using Fireblocks.Client.Abstractions;
using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Services;

public class UserService : IUserService
{
	private readonly IUserApi _userApi;

	public UserService(IUserApi userApi) =>
		_userApi = userApi;

	public async Task<ApiResponse<IEnumerable<UserModel>>> GetUsersAsync() =>
		await _userApi.GetUsersAsync();
}

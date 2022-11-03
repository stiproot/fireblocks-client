using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IUserService
{
	/// <summary>
	/// Retrieve all users<br/>
	/// Retrieves the list of all users in the workspace<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-all-users
	/// </summary>
	Task<ApiResponse<IEnumerable<UserModel>>> GetUsersAsync();
}

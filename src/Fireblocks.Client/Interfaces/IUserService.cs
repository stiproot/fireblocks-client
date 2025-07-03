using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

/// <summary>
/// User services
/// </summary>
public interface IUserService
{
	/// <summary>
	/// Retrieve all users<br/>
	/// Retrieves the list of all users in the workspace<br/>
	/// https://docs.fireblocks.com/api/?#retrieve-all-users
	/// </summary>
	Task<ApiResponse<IEnumerable<UserModel>>> GetUsersAsync();
}

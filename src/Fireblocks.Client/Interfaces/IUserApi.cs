using Fireblocks.Client.Models.Responses;
using Refit;

namespace Fireblocks.Client.Abstractions;

public interface IUserApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<UserModel>>> GetUsersAsync();
}

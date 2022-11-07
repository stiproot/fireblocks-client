using Fireblocks.Api.Models.Responses;
using Refit;

namespace Fireblocks.Api.Interfaces;

public interface IUserApi : IFireblocksApi
{
	[Get("")]
	Task<ApiResponse<IEnumerable<UserModel>>> GetUsersAsync();
}

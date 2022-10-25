namespace Fireblocks.Api.Extensions;

public static class DateTimeExtensions
{
	public static long ToUnixEpochDate(this DateTime dt) =>
		(long)Math.Round((dt.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
}

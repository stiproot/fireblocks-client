namespace Fireblocks.Api.Extensions;

public static class DateTimeExtensions
{
	public static long ToUnixEpochDate(this DateTime dt) =>
		(long)Math.Round((new DateTimeOffset(dt)
					- new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalSeconds);
}

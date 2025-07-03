namespace Fireblocks.Client.Extensions;

public static class DateTimeExtensions
{
	public static long ToUnixEpochDate(this DateTime dt) =>
		(dt.Kind != DateTimeKind.Utc ? dt.ToUniversalTime() : dt)
			.Subtract(DateTime.UnixEpoch).Ticks / TimeSpan.TicksPerSecond;
}

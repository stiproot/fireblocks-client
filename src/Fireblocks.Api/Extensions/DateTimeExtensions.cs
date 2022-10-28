namespace Fireblocks.Api.Extensions;

public static class DateTimeExtensions
{
	public static long ToUnixEpochDate(this DateTime dt) =>
		TimeZoneInfo.ConvertTimeToUtc(dt).Subtract(DateTime.UnixEpoch).Ticks / TimeSpan.TicksPerSecond;
}

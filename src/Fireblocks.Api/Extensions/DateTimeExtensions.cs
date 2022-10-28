namespace Fireblocks.Api.Extensions;

public static class DateTimeExtensions
{
	public static long ToUnixEpochDate(this DateTime dt) =>
		dt.ToUniversalTime().Subtract(DateTime.UnixEpoch).Ticks / TimeSpan.TicksPerSecond;
}

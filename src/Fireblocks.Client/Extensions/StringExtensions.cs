namespace Fireblocks.Client.Extensions;

public static class StringExtensions
{
	public static byte[] ToByteArray(this string s) =>
		Convert.FromBase64String(s);
}

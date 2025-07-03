namespace Fireblocks.Client.Tests;

public class DateTimeExtensionsTests
{
	[Theory]
	[MemberData(nameof(GetTestData))]
	public void ToUnixEpochDate_ShouldSucceed(TestData data)
	{
		// Given

		// When

		// Then
		Assert.Equal(data.Expected, data.Source.ToUnixEpochDate());
	}

	public static IEnumerable<object[]> GetTestData()
	{
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 10, 9, 16, 0, 0, DateTimeKind.Utc),
				Expected = 1665331200
			}
		};
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 9, 27, 20, 51, 33, DateTimeKind.Utc),
				Expected = 1664311893
			}
		};
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 5, 15, 0, 0, 0, DateTimeKind.Utc),
				Expected = 1652572800
			}
		};
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 4, 30, 9, 24, 12, DateTimeKind.Utc),
				Expected = 1651310652
			}
		};
	}
}

public class TestData
{
	public DateTime Source { get; set; }
	public long Expected { get; set; }
}

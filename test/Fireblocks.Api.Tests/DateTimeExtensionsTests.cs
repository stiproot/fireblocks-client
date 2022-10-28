namespace Fireblocks.Api.Tests;

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

	static IEnumerable<object[]> GetTestData()
	{
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 10, 10, 0, 0, 0, DateTimeKind.Local),
				Expected = 1665331200
			}
		};
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 9, 28, 4, 51, 33, DateTimeKind.Local),
				Expected = 1664311893
			}
		};
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 5, 15, 8, 0, 0, DateTimeKind.Unspecified),
				Expected = 1652572800
			}
		};
		yield return new object[] {
			new TestData {
				Source = new DateTime(2022, 4, 30, 17, 24, 12, DateTimeKind.Unspecified),
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

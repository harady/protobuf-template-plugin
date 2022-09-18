using NUnit.Framework;

namespace UnityTest
{
	public class StringExtensionsVersionCodeTests
	{
		[SetUp]
		public void SetUp()
		{
		}

		[TearDown]
		public void TearDown()
		{
		}

		/// <summary>
		/// 値設定、取得の確認.
		/// </summary>
		[Test]
		public void StringExtensionVersionCodeGetTest()
		{
			Assert.AreEqual(1001001, "1.1.1".ToVersionCode());
			Assert.AreEqual(2009012, "2.9.12".ToVersionCode());
			Assert.AreEqual(1000, "0.1.0".ToVersionCode());
			Assert.AreEqual(1000000, "1.0".ToVersionCode());
			Assert.AreEqual(1000000, "1.0.0".ToVersionCode());
		}

		/// <summary>
		/// 値設定、取得の確認.
		/// </summary>
		[Test]
		public void StringExtensionVersionCodeDiffTest()
		{
			Assert.Less("1.1.1".ToVersionCode(), "2.9.12".ToVersionCode());
			Assert.Less("2.9.12".ToVersionCode(), "2.12.9".ToVersionCode());
			Assert.Less("0.1.0".ToVersionCode(), "1.0".ToVersionCode());
			Assert.AreEqual("1.0.0".ToVersionCode(), "1.0.0".ToVersionCode());
		}
	}
}

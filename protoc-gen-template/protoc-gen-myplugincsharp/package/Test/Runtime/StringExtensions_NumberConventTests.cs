using NUnit.Framework;

namespace UnityTest
{
	public class StringExtensions_NumberConventTests
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
		/// 数値変換処理のテスト.
		/// </summary>
		[Test]
		public void NumberConventTest()
		{
			// 変換できる.
			Assert.AreEqual(1, "1".ToInt32(100));
			// 変換できない.
			Assert.AreEqual(100, "あいうえお".ToInt32(100));
			// 変換できない.
			Assert.AreEqual(5, "100.0".ToInt32(5));
		
			// 変換できる.
			Assert.AreEqual(1.0f, "1".ToSingle(100));
			// 変換できない.
			Assert.AreEqual(100.0f, "1.0f".ToSingle(100));
			// 変換できる.
			Assert.AreEqual(1.0f, "1.0".ToSingle(100));
			// 変換できない.
			Assert.AreEqual(100.0f, "あいうえお".ToSingle(100.0f));
			// 変換できる.
			Assert.AreEqual(100.0f, "100".ToSingle(5));
		}
	}
}

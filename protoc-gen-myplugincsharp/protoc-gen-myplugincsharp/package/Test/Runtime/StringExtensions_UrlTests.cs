using NUnit.Framework;

namespace UnityTest
{
	public class StringExtensions_UrlTests
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
		public void ValidUrlTest()
		{
			string url = "http://www.example.com/web/action?param1=789456132&param2=test_string";
			Assert.AreEqual(2, url.GetQueryParameters().Count);
			Assert.AreEqual("789456132", url.GetQueryParameter("param1"));
			Assert.AreEqual("test_string", url.GetQueryParameter("param2"));
			Assert.AreEqual("", url.GetQueryParameter("param3"));
		}

		/// <summary>
		/// 値設定、取得の確認.
		/// </summary>
		[Test]
		public void InvalidUrlTest()
		{
			string url = "";
			Assert.AreEqual(0, url.GetQueryParameters().Count);
			Assert.AreEqual("", url.GetQueryParameter("param1"));
			Assert.AreEqual("", url.GetQueryParameter("param2"));
			Assert.AreEqual("", url.GetQueryParameter("param3"));
		}
	}
}

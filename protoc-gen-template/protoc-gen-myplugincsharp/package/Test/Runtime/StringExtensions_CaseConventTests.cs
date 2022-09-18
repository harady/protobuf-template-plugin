using NUnit.Framework;

namespace UnityTest
{
	public class StringExtensions_CaseConventTests
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
		/// スネークケースからの表記手法変換処理の確認.
		/// </summary>
		[Test]
		public void CaseConventTest()
		{
			// スネークケースからの変換.
			Assert.AreEqual(3, "asset_bundle_manager".ToWords().Length);
			Assert.AreEqual("assetBundleManager", "asset_bundle_manager".ToCamelCase());
			Assert.AreEqual("AssetBundleManager", "asset_bundle_manager".ToPascalCase());
			Assert.AreEqual("asset_bundle_manager", "asset_bundle_manager".ToSnakeCase());
			Assert.AreEqual("ASSET_BUNDLE_MANAGER", "asset_bundle_manager".ToUpperSnakeCase());

			// アッパースネークケースからの変換.
			Assert.AreEqual(3, "ASSET_BUNDLE_MANAGER".ToWords().Length);
			Assert.AreEqual("assetBundleManager", "ASSET_BUNDLE_MANAGER".ToCamelCase());
			Assert.AreEqual("AssetBundleManager", "ASSET_BUNDLE_MANAGER".ToPascalCase());
			Assert.AreEqual("asset_bundle_manager", "ASSET_BUNDLE_MANAGER".ToSnakeCase());
			Assert.AreEqual("ASSET_BUNDLE_MANAGER", "ASSET_BUNDLE_MANAGER".ToUpperSnakeCase());
		}

	}
}

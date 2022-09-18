using System.Collections.Generic;
using NUnit.Framework;

namespace UnityTest
{
	[TestFixture]
	public class MathExTests
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
		/// </summary>
		[Test]
		public void ModTest()
		{
			Assert.AreEqual(2, MathEx.Mod(-3, 5));
			Assert.AreEqual(2, MathEx.Mod(-103, 5));
			Assert.AreEqual(-2, MathEx.Mod(3, -5));
			Assert.AreEqual(-2, MathEx.Mod(103, -5));
			Assert.AreEqual(-3, MathEx.Mod(-3, -5));
			Assert.AreEqual(-3, MathEx.Mod(-103, -5));
		}
	}
}

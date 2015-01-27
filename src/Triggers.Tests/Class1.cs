namespace Triggers.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Class1
    {
        [Test]
        public void TeamCity_Test()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void TeamCity_Test_Fails()
        {
            Assert.AreEqual(true, false);
        }
    }
}
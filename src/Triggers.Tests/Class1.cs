namespace Triggers.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Class1
    {
        [Test]
        public void TeamCity_Test( [Values("A", "B", "C")] string x)
        {
            var fb = new FooBar(x);
            Assert.AreEqual(x, fb.MyProp);
        }
    }
}
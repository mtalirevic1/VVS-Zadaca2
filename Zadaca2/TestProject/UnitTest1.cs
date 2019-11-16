using NUnit.Framework;
using Zadaca2a;
using Zadaca2a.Klase;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Centrala c = new Centrala();
            Assert.Pass();
        }
    }
}
using NUnit.Framework;

namespace Finnhub.Client.Tests
{
    public class ClientTests
    {
        [SetUp]
        public void Setup()
        {
            var token = "test";
            var client = new FinnhubClient(token);
        }

        [Test]
        public void Test1()
        {
            //todo
            Assert.Pass();
        }
    }
}
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotnet_code_challenge
{
    [TestClass]
    public class XmlFeedTests
    {
        [TestMethod]
        public void TestDeserialise()
        {
            var feed = new XmlFeed("TestData/sample.xml");
            var markets = feed.Markets.ToArray();
            Assert.AreEqual(1, markets.Length);
            var market = markets[0];
            Assert.AreEqual("Evergreen Turf Plate", market.Name);
            var entries = market.Entries.ToArray();
            Assert.AreEqual(2, entries.Length);
            Assert.AreEqual("1", entries[0].Participant.Id);
            Assert.AreEqual("Advancing", entries[0].Participant.Name);
            Assert.AreEqual(4.2m, entries[0].Price);
            Assert.AreEqual("2", entries[1].Participant.Id);
            Assert.AreEqual("Coronel", entries[1].Participant.Name);
            Assert.AreEqual(12m, entries[1].Price);
        }
    }
}
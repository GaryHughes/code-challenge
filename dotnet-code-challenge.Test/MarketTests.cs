using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotnet_code_challenge.Test
{

    [TestClass]
    public class MarketTests
    {
        [TestMethod]
        public void TestAddEntry()
        {
            var market = new Market();
            market.Add(new Entry(new Participant("1", "Bart"), 10m));
            var entries = market.Entries.ToArray();
            Assert.AreEqual(1, entries.Length);
            Assert.AreEqual(10, entries[0].Price);
        }

        [TestMethod]
        public void TestAddMultipleEntries()
        {
            var market = new Market();
            market.Add(new Entry(new Participant("1", "Bart"), 10m));
            market.Add(new Entry(new Participant("2", "Nelson"), 11m));
        }
    }
}

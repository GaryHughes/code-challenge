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
        public void TestAddMultipleEntriesWithDifferentPrices()
        {
            var market = new Market();
            market.Add(new Entry(new Participant("1", "Bart"), 10m));
            market.Add(new Entry(new Participant("2", "Nelson"), 11m));
            var entries = market.Entries.ToArray();
            Assert.AreEqual(2, entries.Length);
            Assert.AreEqual(10m, entries[0].Price);
            Assert.AreEqual("Bart", entries[0].Participant.Name);
            Assert.AreEqual(11m, entries[1].Price);
            Assert.AreEqual("Nelson", entries[1].Participant.Name);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestAddEntryWithDuplicateParticipantId()
        {
            var market = new Market();
            market.Add(new Entry(new Participant("1", "Bart"), 10m));
            market.Add(new Entry(new Participant("1", "Nelson"), 11m));
        }

        [TestMethod]
        public void TestAddMultipleEntriesWithTheSamePrice()
        {
            var market = new Market();
            market.Add(new Entry(new Participant("1", "Bart"), 10m));
            market.Add(new Entry(new Participant("2", "Nelson"), 10m));
            var entries = market.Entries.ToArray();
            Assert.AreEqual(2, entries.Length);
            Assert.AreEqual(10m, entries[0].Price);
            Assert.AreEqual("Bart", entries[0].Participant.Name);
            Assert.AreEqual(10m, entries[1].Price);
            Assert.AreEqual("Nelson", entries[1].Participant.Name);
        }

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotnet_code_challenge.Test
{

    [TestClass]
    public class EntryTests
    {
        [TestMethod]
        public void TestInitialisation()
        {
            var participant = new Participant("1", "Pharlap");
            new Entry(participant, 1.0m);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestInitialisationZeroPrice()
        {
            var participant = new Participant("1", "Pharlap");
            new Entry(participant, 0.0m);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestInitialisationNegativePrice()
        {
            var participant = new Participant("1", "Pharlap");
            new Entry(participant, -1.0m);
        }

        [TestMethod]
        public void TestGenerationAllocation()
        {
            var bart = new Participant("1", "Bart");
            var one = new Entry(bart, 10m);
            Assert.AreEqual(1, one.Generation);
            var nelson = new Participant("2", "Nelson");
            var two = new Entry(nelson, 11m);
            Assert.AreEqual(2, two.Generation);
        }
    }
}

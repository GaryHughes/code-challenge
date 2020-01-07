using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotnet_code_challenge.Test
{

    [TestClass]
    public class ParticipantTests
    {
        [TestMethod]
        public void TestInitialisation()
        {
            new Participant("1", "Bart");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestInitialisationWithEmptyId()
        {
            new Participant("", "Nelson");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestInitialisationWithEmptyName()
        {
            new Participant("5", "");    
        }
    }
}

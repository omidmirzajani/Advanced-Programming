using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            DateTime d = new DateTime();
            Human h = new Human("ali", "mmd", d, 5);
            Assert.AreEqual(h.Firstname, "ali");
            Assert.AreEqual(h.Lastname, "mmd");
            Assert.AreEqual(h.Birthdate, d);
            Assert.AreEqual(h.Height, 5);
        }

        [TestMethod()]
        public void SumOperatorTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(true, Program.SumOperator(h1, h2));
        }

        [TestMethod()]
        public void BozorgmosaviTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(false, Program.BozorgMosavi(h1, h2));
        }

        [TestMethod()]
        public void KoochikMosaviTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(true, Program.KoochikMosavi(h1, h2));
        }

        [TestMethod()]
        public void BozorgTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(false, Program.Bozorg(h1, h2));
        }

        [TestMethod()]
        public void KoochikTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(true, Program.Koochik(h1, h2));
        }

        [TestMethod()]
        public void MosaviTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(false, Program.Mosavi(h1, h2));
        }

        [TestMethod()]
        public void NaMosaviTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(true, Program.NaMosavi(h1, h2));
        }

        [TestMethod()]
        public void HashTest()
        {
            Human h1 = new Human("ali", "mmd", DateTime.Now, 5);
            Human h2 = new Human("zahra", "hoseini", DateTime.Now, 50);
            int hash1 = Program.Hash(h1);
            int hash2 = Program.Hash(h2);
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod()]
        public void equalTest()
        {
            Human h1 = new Human("ali", "mmd", new DateTime(), 5);
            Human h2 = new Human("zahra", "hoseini", new DateTime(), 50);
            Assert.AreEqual(false, Program.equal(h1, h2));
        }
    }
}
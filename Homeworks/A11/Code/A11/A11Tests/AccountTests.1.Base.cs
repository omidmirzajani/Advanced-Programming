using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A11;

namespace A9Tests
{
    [TestClass]
    public partial class AccountTests
    {
        private const double Tolerance = 0.0001;  
        [TestMethod]
        public void TestAccountConstructor()
        {
            var account = new Account(balance: 1000);
            Assert.IsNotNull(value: account);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);
            
            using (var sw = new StringWriter()) {
                Console.SetOut(newOut: sw);

                account = new Account(balance: -100);
                Assert.IsNotNull(value: account);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 0) < Tolerance);
                Assert.AreEqual(expected: $"Initial balance is invalid. Setting balance to 0.{Environment.NewLine}",
                    actual: sw.ToString());
            }
            
        }               
        [TestMethod]
        public void TestAccountCredit()
        {
            var account = new Account(balance: 1000);
            account.Credit(amount: 100);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1100) < Tolerance);
        }        
        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException),
            noExceptionMessage: "Credit amount must be positive")]
        public void TestAccountCreditNegativeAmount()
        {
            var account = new Account(balance: 1000);
            account.Credit(amount: -100);
        }
                
        [TestMethod]
        public void TestAccountDebit()
        {
            var account = new Account(balance: 1000);
            var success = account.Debit(amount: 100);
            Assert.IsTrue(condition: success);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 900) < Tolerance);

            using (var sw = new StringWriter()) {
                Console.SetOut(newOut: sw);

                account = new Account(balance: 1000);
                success = account.Debit(amount: 1100);
                Assert.IsFalse(condition: success);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);
                Assert.AreEqual(expected: $"Debit amount exceeded account balance.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }
    }
}
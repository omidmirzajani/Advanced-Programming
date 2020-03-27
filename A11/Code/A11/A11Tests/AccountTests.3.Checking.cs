using System;
using System.IO;
using A11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A9Tests {
    public partial class AccountTests
    {
       
        [TestMethod]
        public void TestCheckingAccountConstructor()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            Assert.IsNotNull(value: account);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);

            using (var sw = new StringWriter()) {
                Console.SetOut(newOut: sw);

                account = new CheckingAccount(balance: -100, transactionFee: 3);
                Assert.IsNotNull(value: account);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 0) < Tolerance);
                Assert.AreEqual(expected: $"Initial balance is invalid. Setting balance to 0.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }
        
       
        [TestMethod]
        public void TestCheckingAccountCredit()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            account.Credit(amount: 100);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1097) < Tolerance);
        }
        
      
        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException),
            noExceptionMessage: "Credit amount must be positive")]
        public void TestCheckingAccountCreditNegativeAmount()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            account.Credit(amount: -100);
        }
        
        [TestMethod]
        public void TestCheckingAccountDebit()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            var success = account.Debit(amount: 100);
            Assert.IsTrue(condition: success);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 897) < Tolerance);

            using (var sw = new StringWriter()) {
                Console.SetOut(newOut: sw);

                account = new CheckingAccount(balance: 1000, transactionFee: 3);
                success = account.Debit(amount: 1100);
                Assert.IsFalse(condition: success);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);
                Assert.AreEqual(expected: $"Debit amount exceeded account balance.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }
        
    }
}

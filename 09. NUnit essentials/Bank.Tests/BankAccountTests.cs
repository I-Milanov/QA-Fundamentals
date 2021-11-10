using NUnit.Framework;
using System;

namespace Bank.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void TestInit()
        {
            this.account = new BankAccount(2000M);
        }



        [Test]
        [Category("Blocked")]
        public void AcountInitializeWithPositiveValue()
        {
            Assert.AreEqual(2000M, account.Amount);
        }


        [Test]
        [Category("Blocked")]
        public void AccountDepositMoneyPositive()
        {
            account.Deposit(500M);
            Assert.AreEqual(2500M, account.Amount);
        }

        [Test]
        [Category("Blocked")]
        public void AccountWithdrawLessThan1000()
        {
            account.Withdraw(800M);
            Assert.AreEqual(1160M, account.Amount);
        }
        [Test]
        [Category("Critical")]

        public void AccountWithdrawExactly1000()
        {
            account.Withdraw(1000M);
            Assert.AreEqual(980M, account.Amount);
        }

        [Test]
        [Category("Medium")]

        public void AccountWithdrawWith999()
        {
            account.Withdraw(999M);
            Assert.AreEqual((2000M-999M-999M*5/100), account.Amount);
        }

        [Test]
        [Category("Medium")]
        public void AccountWithdrawWith1001()
        {
            account.Withdraw(1001M);
            Assert.AreEqual((2000M - 1001M - 1001M * 2 / 100), account.Amount);
        }


        [Test]
        [Category("Medium")]
        public void AccountWithNegativeAmount()
        {
            TestDelegate negativeAccount = () => new BankAccount(-111);
            var ex = Assert.Throws<ArgumentException>(negativeAccount);
            Assert.That(ex.Message, Is.EqualTo("Amount can not be negative!"));
        }

        public void AccountWithNegativeDeposit()
        {
            var message = Assert.Throws<ArgumentException>(()=> account.Deposit(-22));
            Assert.AreEqual(message, "Deposit can not be negative!");
        }
    }
}

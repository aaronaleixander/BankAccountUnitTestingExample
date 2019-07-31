using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod]
        [DataRow(99)]
        [DataRow(99.99)]
        [DataRow(10000)]
        [DataRow(10.995)]
        [TestCategory("Deposit")]
        
        public void Deposit_VariousPositiveAmounts_AddsToBalance(double amt)
        {
            Account checking = new Account();
            double expectedBalance = amt;

            checking.Deposit(amt);

            Assert.AreEqual(expectedBalance, checking.Balance);
        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_AddsToBalance()
        {
            // AAA = Arrange, Act, Assert

            // Arrange -> Init objects/variables
            Account checking = new Account();
            double depositAmt = 10;
            double expectedBalance = 10;

            // Act -> Call the method under test.
            checking.Deposit(depositAmt);

            // Assert -> Verification step
            Assert.AreEqual(expectedBalance, checking.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmount_ReutrnsUpdatedBalance()
        {
            // Arrange
            Account acc = new Account();
            double depositAmount = 10.55;
            double expectedReturn = 10.55;

            // Act
            double results = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, results);


        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            // Arrange
            Account acc = new Account();
            double depositAmount = -1;

            // Act -> Assert vice versa
            Assert.ThrowsException<ArgumentException>
                (() => acc.Deposit(depositAmount));
        }

        // Would prefer at top of class. Kind of like a constructor.
        // Run this method before every unit test.
        [TestInitialize]
        public void InitTest()
        {
            acc = new Account();
            acc.Owner = "Some person";
            acc.AccountNumber = "ABC123";
        }

        Account acc;

        [TestMethod]
        public void Withdraw_PositiveAmount_ReducesBalance()
        {
            double initialDeposit = 100;
            double withdrawAmount = 10;
            double expectedAmount = 90;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedAmount, acc.Balance);
        }

        [TestMethod]
        [DataRow("123456")]
        [DataRow("ABC123")]
        [DataRow("A")]
        [DataRow("123456789")]
        public void AccountNum_SetValidAcc_UpdatesAccNum(string validAcc)
        {
            acc.AccountNumber = validAcc; // Act
            Assert.AreEqual(validAcc, acc.AccountNumber); // Assert
        }

        [TestMethod]
        [DataRow("ABC#")]
        [DataRow("#ABC")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("         ")]
        public void AccountNum_SetInvalidAcc_ThrowsException(string invalidAccNum)
        {
            // TODO: Split this into multiple tests with specific exceptions
            Assert.ThrowsException<Exception>(() => acc.AccountNumber = invalidAccNum);
        }
    }
}
using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        //Arrange
        double initialBalans = 1000.0;
        

        //Act
       BankAccount result = new BankAccount(initialBalans);

        //Assert
       Assert.AreEqual(1000.0, result.Balance,"Initial balance should be correctly");

    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        //Arrange
        double initialBalance = 500.0;
        double depositAmount = 200.0;
        BankAccount account = new BankAccount(initialBalance);

        //Act
        account.Deposit(depositAmount);

        //Assert
        Assert.AreEqual(700.0, account.Balance, "Deposit should increase balance by the deposited amount.");
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        //Arrange
        double initialBalance = 500.0;
        double depositAmount = -100.0;
        BankAccount account = new BankAccount(initialBalance);

        //Act & Assert
        Assert.Throws<ArgumentException>(() => account.Deposit(depositAmount), "Deposit amount must be greater than zero.");
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        //Arrange
        double initialBalance = 1000.0;
        double withdrawalAmount = 300.0;
        BankAccount account = new BankAccount(initialBalance);

        //Act
        account.Withdraw(withdrawalAmount);

        //Assert
        Assert.AreEqual(700.0, account.Balance, "Withdrawal should decrease balance by the withdrawn amount.");
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        //Arrange
        double initialBalance = 500.0;
        double withdrawalAmount = -300.0;
        BankAccount account = new BankAccount(initialBalance);

        //Act & Assert
        Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawalAmount), "Invalid withdrawal amount.");
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        //Arrange
        double initialBalance = 400.0;
        double withdrawalAmount = 500.0;
        BankAccount account = new BankAccount(initialBalance);

        //Act & Assert
        Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawalAmount), "Invalid withdrawal amount.");
    }
}

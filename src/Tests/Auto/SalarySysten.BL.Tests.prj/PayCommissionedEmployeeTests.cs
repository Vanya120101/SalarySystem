using NUnit.Framework;
using System;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class PayCommissionedEmployeeTests
{
	[Test]
	public void PayCommissionedEmployee_NoSalesReceipts()
	{
		//Arrange
		var employeeId = 597;
		var addEmployeeTransactions = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00, 0.15);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 23);
		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateCommissionedPaycheck(paydayTransaction, employeeId, payDate, 1500.00);
	}

	[Test]
	public void PayCommissionedEmployee_WtihSalesReceipts()
	{
		//Arrange
		var employeeId = 598;
		var addEmployeeTransactions = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00, 0.15);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 23);
		var salesReceiptTransaction = new SalesReceiptTransaction(payDate, 150, employeeId);
		salesReceiptTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateCommissionedPaycheck(paydayTransaction, employeeId, payDate, 1500.00 + 150 * 0.15);
	}

	[Test]
	public void PayCommissionedEmployee_WtihTwoSalesReceipts()
	{
		//Arrange
		var employeeId = 599;
		var addEmployeeTransactions = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00, 0.15);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 23);
		var salesReceiptTransaction = new SalesReceiptTransaction(payDate, 150, employeeId);
		salesReceiptTransaction.Execute();	
		salesReceiptTransaction = new SalesReceiptTransaction(payDate, 250, employeeId);
		salesReceiptTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateCommissionedPaycheck(paydayTransaction, employeeId, payDate, 1500.00 + 400 * 0.15 );
	}

	[Test]
	public void PayCommissionedEmployee_WtihOldSalesReceiptsPeriod()
	{
		//Arrange
		var employeeId = 600;
		var addEmployeeTransactions = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00, 0.15);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 23);
		var salesReceiptTransaction = new SalesReceiptTransaction(payDate.AddDays(-15), 150, employeeId);
		salesReceiptTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateCommissionedPaycheck(paydayTransaction, employeeId, payDate, 1500.00);
	}

	[Test]
	public void PayCommissionedEmployee_WtihWrongDate()
	{
		//Arrange
		var employeeId = 123;
		var addEmployeeTransactions = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00, 0.15);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 22);
		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		var paycheck = paydayTransaction.GetPaycheck(employeeId);
		Assert.That(paycheck, Is.Null);
	}

	private void ValidateCommissionedPaycheck(PaydayTransaction transaction, int employeeId, DateTime payDate, double pay)
	{
		var paycheck = transaction.GetPaycheck(employeeId);
		Assert.That(paycheck, Is.Not.Null);
		Assert.That(paycheck.PayDay, Is.EqualTo(payDate));
		Assert.That(paycheck.GrossPay, Is.EqualTo(pay));
		Assert.That(paycheck.Deductions, Is.EqualTo(0));
		Assert.That(paycheck.NetPay, Is.EqualTo(pay));

	}
}

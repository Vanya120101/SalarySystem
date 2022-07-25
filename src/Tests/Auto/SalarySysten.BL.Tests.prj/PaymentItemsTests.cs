using NUnit.Framework;
using SalarySystem.Database;
using SalarySystem.Entities;
using System;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class PaymentItemsTests
{
	[Test]
	public void TimeCardTransactionTest()
	{
		//Arrange
		var employeeId = 5;
		var addEmployeeTransaction = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 15.00);
		addEmployeeTransaction.Execute();

		var timeCardTransactoin = new TimeCardTransaction(new DateTime(2005, 7, 31), 8.0, employeeId);

		//Act
		timeCardTransactoin.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.Name, Is.EqualTo("Vanya"));

		var paymentClassfication = employee.PaymentClassification as HourlyClassification;
		Assert.IsNotNull(paymentClassfication);

		var timecard = paymentClassfication.GetTimeCard(new DateTime(2005, 7, 31));
		Assert.That(timecard, Is.Not.Null);
		Assert.That(timecard.Hours, Is.EqualTo(8.0));
	}

	[Test]
	public void SalesReceiptTransactionTest()
	{
		//Arrange
		var employeeId = 5;
		var addEmployeeTransaction = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1000.00, 15.00);
		addEmployeeTransaction.Execute();

		var sallesReceiptTransaction = new SalesReceiptTransaction(new DateTime(2005, 7, 31), 5, employeeId);

		//Act
		sallesReceiptTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.Name, Is.EqualTo("Vanya"));

		var paymentClassfication = employee.PaymentClassification as CommissionedClassification;
		Assert.IsNotNull(paymentClassfication);

		var timecard = paymentClassfication.GetSalesReceipt(new DateTime(2005, 7, 31));
		Assert.That(timecard, Is.Not.Null);
		Assert.That(timecard.Amount, Is.EqualTo(5));
	}
}

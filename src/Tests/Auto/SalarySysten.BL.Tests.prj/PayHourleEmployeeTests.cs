using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class PayHourleEmployeeTests
{
	[Test]
	public void PayHorleEmployeeTest_NoTimeCards()
	{
		//Arrange
		var employeeId = 123;
		var addEmployeeTransactions = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 9);
		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateHourlyPaycheck(paydayTransaction, employeeId, payDate, 0);
	}

	[Test]
	public void PayHorleEmployeeTest_WithTimeCards()
	{
		//Arrange
		var employeeId = 124;
		var addEmployeeTransactions = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 9);
		var timeCardTransaction = new TimeCardTransaction(payDate, 2.0, employeeId);
		timeCardTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateHourlyPaycheck(paydayTransaction, employeeId, payDate, 300.00);
	}

	[Test]
	public void PayHorleEmployeeTest_WithTimeCards_Overtime()
	{
		//Arrange
		var employeeId = 126;
		var addEmployeeTransactions = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 9);
		var timeCardTransaction = new TimeCardTransaction(payDate, 9.0, employeeId);
		timeCardTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateHourlyPaycheck(paydayTransaction, employeeId, payDate, (8 + 1.5) * 150.00);
	}

	[Test]
	public void PayHorleEmployeeTest_WithTimeCards_WrongDate()
	{
		//Arrange
		var employeeId = 127;
		var addEmployeeTransactions = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 8);
		var timeCardTransaction = new TimeCardTransaction(payDate, 9.0, employeeId);
		timeCardTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		var paycheck = paydayTransaction.GetPaycheck(employeeId);
		Assert.That(paycheck, Is.Null);
	}

	[Test]
	public void PayHorleEmployeeTest_WithTwoTimeCards()
	{
		//Arrange
		var employeeId = 128;
		var addEmployeeTransactions = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 9);
		var timeCardTransaction = new TimeCardTransaction(payDate, 3.0, employeeId);
		timeCardTransaction.Execute();
		var timeCardTransaction2 = new TimeCardTransaction(payDate.AddDays(-1), 5.0, employeeId);
		timeCardTransaction2.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateHourlyPaycheck(paydayTransaction, employeeId, payDate, 8.0 * 150.00);
	}

	[Test]
	public void PayHorleEmployeeTest_WithOldPeriods()
	{
		//Arrange
		var employeeId = 129;
		var addEmployeeTransactions = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00);
		addEmployeeTransactions.Execute();

		var payDate = new DateTime(2001, 11, 9);
		var timeCardTransaction = new TimeCardTransaction(payDate, 3.0, employeeId);
		timeCardTransaction.Execute();
		var timeCardTransaction2 = new TimeCardTransaction(payDate.AddDays(-10), 5.0, employeeId);
		timeCardTransaction2.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();

		//Assert
		ValidateHourlyPaycheck(paydayTransaction, employeeId, payDate, 3.0 * 150.00);
	}

	private void ValidateHourlyPaycheck(PaydayTransaction transaction, int employeeId, DateTime payDate, double pay)
	{
		var paycheck = transaction.GetPaycheck(employeeId);
		Assert.That(paycheck, Is.Not.Null);
		Assert.That(paycheck.PayDay, Is.EqualTo(payDate));
		Assert.That(paycheck.GrossPay, Is.EqualTo(pay));
		Assert.That(paycheck.Deductions, Is.EqualTo(0));
		Assert.That(paycheck.NetPay, Is.EqualTo(pay));
		
	}
}

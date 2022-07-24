using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class PaySalariedTransactionTests
{
	[Test]
	public void PaySingleSalariedEmployee()
	{
		//Arrange
		var employeeId = 144;
		var addSalariedEmployee = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1550.00);
		addSalariedEmployee.Execute();

		var payDate = new DateTime(2000, 11, 30);
		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();
		var paycheck = paydayTransaction.GetPaycheck(employeeId);

		//Assert

		Assert.That(paycheck, Is.Not.Null);
		Assert.That(payDate, Is.EqualTo(paycheck.PayDay));
		Assert.That(paycheck.GrossPay, Is.EqualTo(1550.00));
		//Assert.That(paycheck.GetField("Disposition"), "Hold");
		Assert.That(paycheck.Deductions, Is.EqualTo(0.0));
		Assert.That(paycheck.NetPay, Is.EqualTo(1550.00));
	}

	[Test]
	public void PaySingleSalariedEmployeeOnWrongDate()
	{
		//Arrange
		var employeeId = 4;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "lenina", 150.00);
		addEmployeeTransaction.Execute();

		var payDate = new DateTime(2001, 11, 29);
		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();
		var paycheck = paydayTransaction.GetPaycheck(employeeId);

		//Assert
		Assert.That(paycheck, Is.Null);
	}
}

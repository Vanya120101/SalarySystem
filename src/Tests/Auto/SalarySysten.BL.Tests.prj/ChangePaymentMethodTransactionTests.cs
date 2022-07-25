using NUnit.Framework;
using SalarySystem.Database;
using SalarySystem.Entities;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class ChangePaymentMethodTransactionTests
{
	[Test]
	public void ChangeDirectMethodTransactionTest()
	{
		//Arrange
		var employeeId = 4;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var changeMethodTransactoin = new ChangeDirectMethodTransaction(employeeId);

		//Act
		changeMethodTransactoin.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.PaymentMethod, Is.TypeOf<DirectMethod>());
	}

	[Test]
	public void ChangeMailMethodTransactionTest()
	{
		//Arrange
		var employeeId = 4;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var changeMethodTransactoin = new ChangeMailMethodTransaction(employeeId);

		//Act
		changeMethodTransactoin.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.PaymentMethod, Is.TypeOf<MailMethod>());
	}

	[Test]
	public void ChangeHoldMethodTransactionTest()
	{
		//Arrange
		var employeeId = 4;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var changeMethodTransactoin = new ChangeHoldMethodTransaction(employeeId);

		//Act
		changeMethodTransactoin.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.PaymentMethod, Is.TypeOf<HoldMethod>());
	}
}

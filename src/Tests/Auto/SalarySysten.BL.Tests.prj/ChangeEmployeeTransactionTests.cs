using NUnit.Framework;
using SalarySystem.Database;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class ChangeEmployeeTransactionTests
{
	[Test]
	public void ChangeNameTransactionTest()
	{
		//Arrange
		var employeeId = 2;
		var addHourlyemployeeTransaction = new AddHourlyEmployeeTransaction(employeeId, "Vaya", "Lenina", 15.00);
		addHourlyemployeeTransaction.Execute();

		var changeNameTransaction = new ChangeNameTransaction(employeeId, "Bob");

		//Act
		changeNameTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.Name, Is.EqualTo("Bob"));
	}

	[Test]
	public void ChangeAddressTransactionTest()
	{
		//Arrange
		var employeeId = 2;
		var addHourlyemployeeTransaction = new AddHourlyEmployeeTransaction(employeeId, "Vaya", "Lenina", 15.00);
		addHourlyemployeeTransaction.Execute();

		var changeTransaction = new ChangeAddressTransaction(employeeId, "Mars");

		//Act
		changeTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.Address, Is.EqualTo("Mars"));
	}
}

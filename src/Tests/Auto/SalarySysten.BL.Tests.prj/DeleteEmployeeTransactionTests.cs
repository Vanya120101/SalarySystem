﻿using NUnit.Framework;
using SalarySystem.Database;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class DeleteEmployeeTransactionTests
{
	[Test]
	public void DeleteEmployeeTransactionTest()
	{
		//Arrange
		var employeeId = 4;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee.Name, Is.EqualTo("Vanya"));

		var deleteEmployeeTransaction = new DeleteEmployeeTransaction(employeeId);

		//Act
		deleteEmployeeTransaction.Execute();
		
		//Assert
		employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee, Is.Null);

	}
}

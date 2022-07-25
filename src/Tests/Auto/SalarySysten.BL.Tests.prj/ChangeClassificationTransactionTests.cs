using NUnit.Framework;
using SalarySystem.Database;
using SalarySystem.Entities;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class ChangeClassificationTransactionTests
{
	[Test]
	public void ChangeHourlyTransactionTest()
	{
		//Arrange
		var employeeId = 6;
		var addEmployeeTransaction = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00, 10.00);
		addEmployeeTransaction.Execute();

		var changeClassificationTransaction = new ChangeHourlyClassification(employeeId, 15.00);

		//Act
		changeClassificationTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		var classification = employee.PaymentClassification as HourlyClassification;
		Assert.That(classification, Is.Not.Null);
		Assert.That(classification.HourlyRate, Is.EqualTo(15.00));
	}

	[Test]
	public void ChangeSalariedTransactionTest()
	{
		//Arrange
		var employeeId = 6;
		var addEmployeeTransaction = new AddCommissionedEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00, 10.00);
		addEmployeeTransaction.Execute();

		var changeClassificationTransaction = new ChangeSalariedClassification(employeeId, 1500.00);

		//Act
		changeClassificationTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		var classification = employee.PaymentClassification as SalariedClassification;
		Assert.That(classification, Is.Not.Null);
		Assert.That(classification.Salary, Is.EqualTo(1500.00));
	}

	[Test]
	public void ChangeCommissinedTransactionTest()
	{
		//Arrange
		var employeeId = 6;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 150.00);
		addEmployeeTransaction.Execute();

		var changeClassificationTransaction = new ChangeCommissionedClassification(employeeId, 1500.00, 10.00);

		//Act
		changeClassificationTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		var classification = employee.PaymentClassification as CommissionedClassification;
		Assert.That(classification, Is.Not.Null);
		Assert.That(classification.Salary, Is.EqualTo(1500.00));
		Assert.That(classification.CommissionedRate, Is.EqualTo(10.00));
	}
}

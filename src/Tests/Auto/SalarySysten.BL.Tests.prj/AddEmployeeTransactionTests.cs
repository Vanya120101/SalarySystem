using NUnit.Framework;
using SalarySystem.Database;
using SalarySystem.Entities;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class AddEmployeeTransactionTests
{
	[Test]
	public void AddSalariedEmployeeTransactionTest()
	{
		//Arrange
		var employeeId = 1;
		var addEmployeeTransaction = new SalarySystem.BL.AddSalariedEmployeeTransaction(employeeId, "Bob", "Home", 1000.00);

		//Act
		addEmployeeTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.AreEqual("Bob", employee.Name);

		var paymentClassification = employee.PaymentClassification;
		Assert.IsTrue(paymentClassification is SalariedClassification);

		var salariedClassification = paymentClassification as SalariedClassification;
		Assert.AreEqual(1000.00, salariedClassification.Salary, 0.001);

		var paymentSchedule = employee.PaymentSchedule;
		Assert.IsTrue(paymentSchedule is MonthlySchedule);

		var paymentMethod = employee.PaymentMethod;
		Assert.IsTrue(paymentMethod is HoldMethod);
	}

	[Test]
	public void AddHourlyEmployeeTransactionTest()
	{
		//Arrange
		var employeeId = 1;
		var addEmployeeTransaction = new AddHourlyEmployeeTransaction(employeeId, "Bob", "Home", 15.00);

		//Act
		addEmployeeTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.AreEqual("Bob", employee.Name);

		var paymentClassification = employee.PaymentClassification;
		Assert.IsTrue(paymentClassification is HourlyClassification);

		var horlyClassification = paymentClassification as HourlyClassification;
		Assert.AreEqual(15.00, horlyClassification.HourlyRate, 0.001);

		var paymentSchedule = employee.PaymentSchedule;
		Assert.IsTrue(paymentSchedule is WeeklySchedule);

		var paymentMethod = employee.PaymentMethod;
		Assert.IsTrue(paymentMethod is HoldMethod);
	}

	[Test]
	public void AddCommissionedEmployeeTransactionTest()
	{
		//Arrange
		var employeeId = 1;
		var addEmployeeTransaction = new AddCommissionedEmployeeTransaction(employeeId, "Bob", "Home", 700.00, 15.00);

		//Act
		addEmployeeTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.AreEqual("Bob", employee.Name);

		var paymentClassification = employee.PaymentClassification;
		Assert.IsTrue(paymentClassification is CommissionedClassification);

		var commissionedClassification = paymentClassification as CommissionedClassification;
		Assert.AreEqual(15.00, commissionedClassification.CommissionedRate, 0.001);
		Assert.AreEqual(700.00, commissionedClassification.Salary, 0.001);

		var paymentSchedule = employee.PaymentSchedule;
		Assert.IsTrue(paymentSchedule is BiweeklySchedule);

		var paymentMethod = employee.PaymentMethod;
		Assert.IsTrue(paymentMethod is HoldMethod);
	}
}

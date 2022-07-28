using NUnit.Framework;
using SalarySystem.Database;
using SalarySystem.Entities;
using System;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class ServiceChargeTests
{
	[Test]
	public void AddServiceChargeTest()
	{
		//Arrange
		var employeeId = 2;
		var addHourlyEmployeeTransaction = new AddHourlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 15.00);
		addHourlyEmployeeTransaction.Execute();
		var employee = PayrollDatabase.GetEmployee(employeeId);

		var memderId = 86;
		var unionAffiliation = new UnionAffiliation(memderId, 99.4);
		employee.Affiliation = unionAffiliation;
		PayrollDatabase.AddUnionMember(memderId, employee);

		var serviceChargeTransaction = new ServiceChargeTransaction(memderId, new DateTime(2005, 8,8), 12.95);

		//Act
		serviceChargeTransaction.Execute();

		//Assert
		var serviceCharge = unionAffiliation.GetServiceCharge(new DateTime(2005, 8, 8));
		Assert.That(serviceCharge, Is.Not.Null);
		Assert.That(serviceCharge.Amount, Is.EqualTo(12.95));
	}
}

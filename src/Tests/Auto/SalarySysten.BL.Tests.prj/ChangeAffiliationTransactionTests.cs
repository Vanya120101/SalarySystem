using NUnit.Framework;
using SalarySystem.Database;
using SalarySystem.Entities;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class ChangeAffiliationTransactionTests
{
	[Test]
	public void ChangeUnionMemberTest()
	{
		//Arrange
		var employeeId = 8;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var memberId = 7743;
		var changeUnionMemberTransaction = new ChangeMemberTransaction(employeeId, memberId, 99.42);

		//Act
		changeUnionMemberTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee, Is.Not.Null);

		Assert.That(employee.Affiliation as UnionAffiliation, Is.Not.Null);
		var affiliation = employee.Affiliation as UnionAffiliation;
		Assert.That(affiliation.Due, Is.EqualTo(99.42));

		var member = PayrollDatabase.GetUniounMember(memberId);
		Assert.That(member, Is.EqualTo(employee));
	}

	[Test]
	public void ChangeUnaffiliatedMemberTest()
	{
		//Arrange
		var employeeId = 8;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var changeUnionMemberTransaction = new ChangeUnaffiliatedTransaction(employeeId);

		//Act
		changeUnionMemberTransaction.Execute();

		//Assert
		var employee = PayrollDatabase.GetEmployee(employeeId);
		Assert.That(employee, Is.Not.Null);
		Assert.That(employee.Affiliation as NoAffiliation, Is.Not.Null);
	}
}

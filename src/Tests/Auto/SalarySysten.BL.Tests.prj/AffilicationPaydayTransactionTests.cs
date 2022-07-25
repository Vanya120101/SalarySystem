using NUnit.Framework;
using System;

namespace SalarySystem.BL.Tests;

[TestFixture]
internal class AffilicationPaydayTransactionTests
{
	[Test]
	public void SalariedUnionMemberDuesTest()
	{
		//Arrange
		var employeeId = 700;
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var memberId = 134124;
		var changeMemberTransaction = new ChangeMemberTransaction(employeeId, memberId, 150.00);
		changeMemberTransaction.Execute();

		var payday = new DateTime(2001, 11, 30);
		var paydayTransaction = new PaydayTransaction(payday);

		//Act
		paydayTransaction.Execute();
		var paycheck = paydayTransaction.GetPaycheck(employeeId);

		//Assert
		Assert.That(paycheck, Is.Not.Null);
		Assert.That(paycheck.PayDay, Is.EqualTo(payday));
		Assert.That(paycheck.GrossPay, Is.EqualTo(1500.00));
		Assert.That(paycheck.Deductions, Is.EqualTo(150.00 * 4));
		Assert.That(paycheck.NetPay, Is.EqualTo(1500.00 - 150.0 * 4));
	}

	[Test]
	public void HourlyUnionMemberServiceCharge()
	{
		//Arrange
		var employeeId = 701;
		var addEmployeeTransaction = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var memberId = 7414;
		var changeMemberTransaction = new ChangeMemberTransaction(employeeId, memberId, 150.00);
		changeMemberTransaction.Execute();

		var payDate = new DateTime(2001, 11, 9);
		var serivceChargeTransaction = new ServiceChargeTransaction(memberId, payDate, 19.00);
		serivceChargeTransaction.Execute();

		var timeCardTransaction = new TimeCardTransaction(payDate, 2.0, employeeId);
		timeCardTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();
		var paycheck = paydayTransaction.GetPaycheck(employeeId);

		//Assert
		Assert.That(paycheck, Is.Not.Null);
		Assert.That(paycheck.PayDay, Is.EqualTo(payDate));
		Assert.That(paycheck.GrossPay, Is.EqualTo(2 * 1500.00));
		Assert.That(paycheck.Deductions, Is.EqualTo(19.00 + 150.00));
		Assert.That(paycheck.NetPay, Is.EqualTo(1500.00 * 2 - 19.00 - 150.00));
	}

	[Test]
	public void ServiceChargesSpanningMultiplePayPeriods()
	{
		//Arrange
		var employeeId = 703;
		var addEmployeeTransaction = new AddHorlyEmployeeTransaction(employeeId, "Vanya", "Lenina", 1500.00);
		addEmployeeTransaction.Execute();

		var memberId = 7414;
		var changeMemberTransaction = new ChangeMemberTransaction(employeeId, memberId, 150.00);
		changeMemberTransaction.Execute();

		var payDate = new DateTime(2001, 11, 9);
		var serivceChargeTransaction = new ServiceChargeTransaction(memberId, payDate, 19.00);
		serivceChargeTransaction.Execute();

		serivceChargeTransaction = new ServiceChargeTransaction(memberId, payDate.AddDays(-14), 19.00);
		serivceChargeTransaction.Execute();
		serivceChargeTransaction = new ServiceChargeTransaction(memberId, payDate.AddDays(14), 19.00);
		serivceChargeTransaction.Execute();

		var timeCardTransaction = new TimeCardTransaction(payDate, 2.0, employeeId);
		timeCardTransaction.Execute();

		var paydayTransaction = new PaydayTransaction(payDate);

		//Act
		paydayTransaction.Execute();
		var paycheck = paydayTransaction.GetPaycheck(employeeId);

		//Assert
		Assert.That(paycheck, Is.Not.Null);
		Assert.That(paycheck.PayDay, Is.EqualTo(payDate));
		Assert.That(paycheck.GrossPay, Is.EqualTo(2 * 1500.00));
		Assert.That(paycheck.Deductions, Is.EqualTo(150.00 + 19.00));
		Assert.That(paycheck.NetPay, Is.EqualTo(1500.00 * 2 - 150.00 - 19.00));
	}
}

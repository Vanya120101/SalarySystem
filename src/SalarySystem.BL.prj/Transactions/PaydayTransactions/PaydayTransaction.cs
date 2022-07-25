using SalarySystem.Database;
using SalarySystem.Entities;
using System;
using System.Collections.Generic;

namespace SalarySystem.BL;

public class PaydayTransaction : ITransaction
{
	private readonly DateTime _payDate;
	private readonly Dictionary<int, Paycheck> _payckecks = new();
	public PaydayTransaction(DateTime payDate)
	{
		_payDate = payDate;
	}

	public void Execute()
	{
		var employees = PayrollDatabase.GetEmployees();

		foreach(var employee in employees)
		{
			if(employee.PaymentSchedule.IsPayDate(_payDate))
			{
				var startDate = employee.PaymentSchedule.GetPayPeriodStartDay(_payDate);
				var paycheck = new Paycheck(startDate,_payDate);
				_payckecks.Add(employee.Id, paycheck);
				employee.PayDay(paycheck);
			}
		}
	}

	public Paycheck? GetPaycheck(int employeeId) => _payckecks.ContainsKey(employeeId) ? _payckecks[employeeId] : null;
}

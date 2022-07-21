using SalarySystem.Database;
using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public class TimeCardTransaction : ITransaction
{
	private readonly DateTime _date;
	private readonly double _hours;
	private readonly int _employeeId;

	public TimeCardTransaction(DateTime date, double hours, int employeeId)
	{
		_date = date;
		_hours = hours;
		_employeeId = employeeId;
	}
	public void Execute()
	{
		var employee = PayrollDatabase.GetEmployee(_employeeId);
		if(employee == null)
			throw new InvalidOperationException("There is no employee with such ID");

		if(employee.PaymentClassification is not HourlyClassification hourlyClassification) 
			throw new InvalidOperationException("Attempting add time card to employee with no hourly payment classification");

		hourlyClassification.AddTimeCard(new TimeCard(_date, _hours));
	}
}

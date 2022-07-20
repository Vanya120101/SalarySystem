using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public class AddHorlyEmployeeTransaction : AddEmployeeTransaction
{
	private readonly double _hourlyRate;

	public AddHorlyEmployeeTransaction(int employeeId, string name, string address, double hourlyRate) : base(employeeId, name, address)
	{
		_hourlyRate = hourlyRate;
	}

	protected override PaymentClassification MakeClassification() => new HourlyClassification(_hourlyRate);
	protected override PaymentSchedule MakeSchedule() => new WeeklySchedule();
}

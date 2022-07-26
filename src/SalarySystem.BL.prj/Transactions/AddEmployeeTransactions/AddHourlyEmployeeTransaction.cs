﻿using SalarySystem.Entities;

namespace SalarySystem.BL;

public class AddHourlyEmployeeTransaction : AddEmployeeTransaction
{
	private readonly double _hourlyRate;

	public AddHourlyEmployeeTransaction(int employeeId, string name, string address, double hourlyRate) : base(employeeId, name, address)
	{
		_hourlyRate = hourlyRate;
	}

	protected override PaymentClassification MakeClassification() => new HourlyClassification(_hourlyRate);
	protected override PaymentSchedule MakeSchedule() => new WeeklySchedule();
}

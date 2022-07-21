using SalarySystem.Entities;

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

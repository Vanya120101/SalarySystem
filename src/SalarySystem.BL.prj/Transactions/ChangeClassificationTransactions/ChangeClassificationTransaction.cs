using SalarySystem.Entities;

namespace SalarySystem.BL;

public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
{
	public ChangeClassificationTransaction(int employeeId) : base(employeeId) { }

	protected override void Change(Employee employee)
	{
		employee.PaymentClassification = PaymentClassification;
		employee.PaymentSchedule = PaymentSchedule;
	}

	protected abstract PaymentClassification PaymentClassification { get; }
	protected abstract PaymentSchedule PaymentSchedule { get; }
}

public class ChangeHourlyClassification : ChangeClassificationTransaction
{
	private readonly double _hourlyRate;

	public ChangeHourlyClassification(int employeeId, double hourlyRate) : base(employeeId)
	{
		_hourlyRate = hourlyRate;
	}

	protected override PaymentClassification PaymentClassification => new HourlyClassification(_hourlyRate);

	protected override PaymentSchedule PaymentSchedule => new WeeklySchedule();
}

public class ChangeSalariedClassification : ChangeClassificationTransaction
{
	private readonly double _salary;

	public ChangeSalariedClassification(int employeeId, double salary) : base(employeeId)
	{
		_salary = salary;
	}

	protected override PaymentClassification PaymentClassification => new SalariedClassification(_salary);

	protected override PaymentSchedule PaymentSchedule => new MonthlySchedule();
}

public class ChangeCommissionedClassification : ChangeClassificationTransaction
{
	private readonly double _salary;
	private readonly double _commissionedRate;

	public ChangeCommissionedClassification(int employeeId, double salary, double commissionedRate) : base(employeeId)
	{
		_salary = salary;
		_commissionedRate = commissionedRate;
	}

	protected override PaymentClassification PaymentClassification => new CommissionedClassification(_salary, _commissionedRate);

	protected override PaymentSchedule PaymentSchedule => new MonthlySchedule();
}
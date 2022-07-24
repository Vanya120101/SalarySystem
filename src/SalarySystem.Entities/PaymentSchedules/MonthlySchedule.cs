namespace SalarySystem.Entities;

public class MonthlySchedule : PaymentSchedule
{
	private bool IsLastDayOfMonth(DateTime dateTime)
	{
		var m1 = dateTime.Month;
		var m2 = dateTime.AddDays(1).Month;
		return m1 != m2;
	}

	public override bool IsPayDate(DateTime payDate) => IsLastDayOfMonth(payDate);

}
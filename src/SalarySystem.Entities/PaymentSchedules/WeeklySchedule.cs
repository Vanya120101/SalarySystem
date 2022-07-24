namespace SalarySystem.Entities;

public class WeeklySchedule : PaymentSchedule
{
	public override bool IsPayDate(DateTime payDate) => payDate.DayOfWeek == DayOfWeek.Friday;
}

namespace SalarySystem.Entities;

public class WeeklySchedule : PaymentSchedule
{
	public override DateTime GetPayPeriodStartDay(DateTime payDate) => payDate.AddDays(-7);
	public override bool IsPayDate(DateTime payDate) => payDate.DayOfWeek == DayOfWeek.Friday;
}

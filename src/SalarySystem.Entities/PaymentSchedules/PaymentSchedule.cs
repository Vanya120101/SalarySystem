namespace SalarySystem.Entities;

public abstract class PaymentSchedule
{
	public abstract bool IsPayDate(DateTime payDate);
	public abstract DateTime GetPayPeriodStartDay(DateTime payDate);
}
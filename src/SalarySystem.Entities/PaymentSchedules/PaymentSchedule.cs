namespace SalarySystem.Entities;

public abstract class PaymentSchedule
{
	public abstract bool IsPayDate(DateTime payDate);
}
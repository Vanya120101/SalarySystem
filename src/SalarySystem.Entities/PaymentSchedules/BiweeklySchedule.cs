namespace SalarySystem.Entities;

public class BiweeklySchedule : PaymentSchedule
{
	public override bool IsPayDate(DateTime payDate) => true;
}

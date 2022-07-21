namespace SalarySystem.Entities;

public class ServiceCharge
{
	public ServiceCharge(DateTime date, double charge)
	{
		Date = date;
		Amount = charge;
	}

	public DateTime Date { get; }
	public double Amount { get; }
}
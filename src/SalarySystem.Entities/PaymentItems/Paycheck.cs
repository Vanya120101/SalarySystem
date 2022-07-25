namespace SalarySystem.Entities;

public class Paycheck
{
	public double NetPay { get; set; }
	public DateTime StartDate { get; }
	public DateTime PayDay { get; }
	public double GrossPay { get; set; }
	public double Deductions { get; set; }

	public Paycheck(DateTime startDate, DateTime payDay)
	{
		StartDate = startDate;
		PayDay = payDay;
	}
}

namespace SalarySystem.Entities;

public class TimeCard
{
	public TimeCard(DateTime date, double hours)
	{
		Date = date;
		Hours = hours;
	}

	public DateTime Date { get; }
	public double Hours { get; }
}

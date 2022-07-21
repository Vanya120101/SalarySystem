namespace SalarySystem.Entities;

public class HourlyClassification : PaymentClassification
{
	public double HourlyRate { get; }

	private readonly List<TimeCard> _timeCards = new();

	public HourlyClassification(double hourlyRate)
	{
		HourlyRate = hourlyRate;
	}

	public void AddTimeCard(TimeCard timeCard) => _timeCards.Add(timeCard);
	public TimeCard? GetTimeCard(DateTime dateTime) => _timeCards.FirstOrDefault(c=>c.Date == dateTime);
}

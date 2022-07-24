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
	public TimeCard? GetTimeCard(DateTime dateTime) => _timeCards.FirstOrDefault(c => c.Date == dateTime);
	public override double CalculatePay(Paycheck paycheck)
	{
		var totalPay = 0.0;
		foreach(var timeCard in _timeCards)
		{
			if(IsInPayPeriod(timeCard, paycheck.PayDay))
				totalPay += CalculatePayForTimeCard(timeCard);
		}

		return totalPay;
	}

	private bool IsInPayPeriod(TimeCard card, DateTime payPeriod)
	{
		var payPeroidEndTime = payPeriod;
		var payPeriodStartTime = payPeriod.AddDays(-5);
		return card.Date <= payPeroidEndTime && card.Date >= payPeriodStartTime;
	}

	private double CalculatePayForTimeCard(TimeCard timeCard)
	{
		var overtimeHours = Math.Max(0.0, timeCard.Hours - 8);
		var normalHours = timeCard.Hours - overtimeHours;
		return HourlyRate * normalHours + HourlyRate * 1.5 * overtimeHours;
	}
}

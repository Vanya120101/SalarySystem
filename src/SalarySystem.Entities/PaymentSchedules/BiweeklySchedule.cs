namespace SalarySystem.Entities;

public class BiweeklySchedule : PaymentSchedule
{
	public override DateTime GetPayPeriodStartDay(DateTime payDate) => payDate.AddDays(-14);

	public override bool IsPayDate(DateTime payDate)
	{
		return GetDateTime(payDate, 2, DayOfWeek.Friday) == payDate || 
			   GetDateTime(payDate, 4, DayOfWeek.Friday) == payDate;
	}

	private DateTime GetDateTime(DateTime CurDate, int Occurrence, DayOfWeek Day)
	{
		var fday = new DateTime(CurDate.Year, CurDate.Month, 1);

		var fOc = fday.DayOfWeek == Day ? fday : fday.AddDays(Day - fday.DayOfWeek);
		// CurDate = 2011.10.1 Occurance = 1, Day = Friday >> 2011.09.30 FIX. 
		if(fOc.Month < CurDate.Month) Occurrence++;
		var resultDate = fOc.AddDays(7 * (Occurrence - 1));

		return resultDate;
	}
}

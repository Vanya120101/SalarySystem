using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Entities;

public static class DateUtil
{
	public static bool IsDayInPeriod(DateTime currentDate, DateTime startDate, DateTime endDate) => currentDate >= startDate && currentDate <= endDate;
	public static int NumberOfFridaysInPayPeriod(DateTime startDate, DateTime payDay)
	{
		var fridays = 0;
		for(var currentDate = startDate; currentDate < payDay; currentDate = currentDate.AddDays(1))
		{
			if(currentDate.DayOfWeek == DayOfWeek.Friday) fridays++;
		}

		return fridays;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Entities;

public class HourlyClassification : PaymentClassification
{
	public double HourlyRate { get; }

	public HourlyClassification(double hourlyRate)
	{
		HourlyRate = hourlyRate;
	}
}

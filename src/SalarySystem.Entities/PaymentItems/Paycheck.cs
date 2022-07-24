using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Entities;

public class Paycheck
{
	public double NetPay { get; set; }
	public DateTime PayDay { get; }
	public double GrossPay { get; set; }
	public double Deductions { get; set; }

	public Paycheck(DateTime payDay)
	{
		PayDay = payDay;
	}
}

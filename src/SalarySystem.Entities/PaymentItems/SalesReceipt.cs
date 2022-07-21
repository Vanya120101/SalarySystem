using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Entities;

public class SalesReceipt
{
	public SalesReceipt(DateTime date, double amount)
	{
		Date = date;
		Amount = amount;
	}

	public DateTime Date { get; }
	public double Amount { get; }
}

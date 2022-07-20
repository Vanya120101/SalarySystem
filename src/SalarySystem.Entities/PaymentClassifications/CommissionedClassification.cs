using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Entities;

public class CommissionedClassification : PaymentClassification
{
	public CommissionedClassification(double salary, double commissionedRate)
	{
		Salary = salary;
		CommissionedRate = commissionedRate;
	}

	public double Salary { get; }
	public double CommissionedRate { get; }
}

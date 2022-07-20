using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public class AddSalariedEmployeeTransaction : AddEmployeeTransaction
{
	private readonly double _salary;

	public AddSalariedEmployeeTransaction(int employeeId, string name, string address, double salary) : base(employeeId, name, address)
	{
		_salary = salary;
	}
	protected override PaymentClassification MakeClassification() => new SalariedClassification(_salary);
	protected override PaymentSchedule MakeSchedule() => new MonthlySchedule();
}

using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public class AddCommissionedEmployeeTransaction : AddEmployeeTransaction
{
	private readonly double _salary;
	private readonly double _commissionRate;

	public AddCommissionedEmployeeTransaction(int employeeId, string name, string address, double salary, double commissionRate) : base(employeeId, name, address)
	{
		_salary = salary;
		_commissionRate = commissionRate;
	}

	protected override PaymentClassification MakeClassification() => new CommissionedClassification(_salary,_commissionRate);
	protected override PaymentSchedule MakeSchedule() => new BiweeklySchedule();
}

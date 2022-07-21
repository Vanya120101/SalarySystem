using SalarySystem.Database;
using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public class ServiceChargeTransaction : ITransaction
{
	private readonly int _memberId;
	private readonly DateTime _date;
	private readonly double _charge;

	public ServiceChargeTransaction(int memberId, DateTime date, double charge)
	{
		_memberId = memberId;
		_date = date;
		_charge = charge;
	}
	public void Execute()
	{
		var employee = PayrollDatabase.GetUniounMember(_memberId);
		if(employee == null)
			throw new InvalidOperationException("There is no employee with such member ID");

		if(employee.Affiliation is not UnionAffiliation affiliation)
			throw new InvalidOperationException("Attempting service charge to employee with no union affiliation");

		affiliation.AddServiceCharge(new ServiceCharge(_date, _charge));
	}
}

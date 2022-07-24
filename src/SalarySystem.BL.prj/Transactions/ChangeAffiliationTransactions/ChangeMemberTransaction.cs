using SalarySystem.Database;
using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
{
	protected ChangeAffiliationTransaction(int employeeId) : base(employeeId)
	{
	}

	protected override void Change(Employee employee)
	{
		if(employee is null) throw new ArgumentNullException(nameof(employee));

		RecordMembership(employee);
		employee.Affiliation = Affiliation;
	}

	protected abstract Affiliation Affiliation { get; }
	protected abstract void RecordMembership(Employee employee);
}

public class ChangeMemberTransaction : ChangeAffiliationTransaction
{
	private readonly int _memberId;
	private readonly double _due;

	public ChangeMemberTransaction(int employeeId, int memberId, double due) : base(employeeId)
	{
		_memberId = memberId;
		_due = due;
	}

	protected override Affiliation Affiliation => new UnionAffiliation(_memberId, _due);

	protected override void RecordMembership(Employee employee) => PayrollDatabase.AddUnionMember(_memberId, employee);
}

public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction
{
	public ChangeUnaffiliatedTransaction(int employeeId) : base(employeeId)
	{
	}

	protected override Affiliation Affiliation => new NoAffiliation();

	protected override void RecordMembership(Employee employee)
	{
		var affiliation = employee.Affiliation;

		if(affiliation is UnionAffiliation unionAffiliation)
			PayrollDatabase.DeleteUnionMember(unionAffiliation.MemberId);
	}
}
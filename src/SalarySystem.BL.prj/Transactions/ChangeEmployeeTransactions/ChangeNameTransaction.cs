using SalarySystem.Database;
using SalarySystem.Entities;
using System;

namespace SalarySystem.BL;

public abstract class ChangeEmployeeTransaction : ITransaction
{
	private readonly int _employeeId;

	public ChangeEmployeeTransaction(int employeeId)
	{
		_employeeId = employeeId;
	}

	public void Execute()
	{
		var employee = PayrollDatabase.GetEmployee(_employeeId);
		if(employee == null) throw new InvalidOperationException("There is no employy with such ID");

		Change(employee);
	}

	protected abstract void Change(Employee employee);
}

public class ChangeNameTransaction : ChangeEmployeeTransaction
{
	private readonly string _newName;

	public ChangeNameTransaction(int emplyeeId, string newName) : base(emplyeeId)
	{
		_newName = newName;
	}
	protected override void Change(Employee employee) => employee.Name = _newName;
}

public class ChangeAddressTransaction : ChangeEmployeeTransaction
{
	private readonly string _newAddress;

	public ChangeAddressTransaction(int employeeId, string newAddress) : base(employeeId)
	{
		_newAddress = newAddress;
	}

	protected override void Change(Employee employee) => employee.Address = _newAddress;
}

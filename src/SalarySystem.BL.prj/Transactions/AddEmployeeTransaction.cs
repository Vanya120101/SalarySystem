using SalarySystem.Database;
using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public abstract class AddEmployeeTransaction : ITransaction
{
	private readonly int _employeeId;
	private readonly string _name;
	private readonly string _address;

	public AddEmployeeTransaction(int employeeId, string name, string address)
	{
		if(string.IsNullOrEmpty(name)) throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
		if(string.IsNullOrEmpty(address)) throw new ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));

		_employeeId = employeeId;
		_name = name;
		_address = address;
	}

	protected abstract PaymentClassification MakeClassification();
	protected abstract PaymentSchedule MakeSchedule();

	public void Execute()
	{
		var paymentClassification = MakeClassification();
		var paymentSchedule = MakeSchedule();
		var paymentMethod = new HoldMethod();

		var employee = new Employee(_employeeId, _name, _address, paymentClassification, paymentSchedule, paymentMethod);
		PayrollDatabase.AddEmployee(_employeeId, employee);

	}
}

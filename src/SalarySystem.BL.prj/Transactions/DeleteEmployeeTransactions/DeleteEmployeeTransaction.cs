using SalarySystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public class DeleteEmployeeTransaction : ITransaction
{
	private readonly int _employeeId;

	public DeleteEmployeeTransaction(int employeeId)
	{
		_employeeId = employeeId;
	}
	public void Execute() => PayrollDatabase.DeleteEmployee(_employeeId);
}

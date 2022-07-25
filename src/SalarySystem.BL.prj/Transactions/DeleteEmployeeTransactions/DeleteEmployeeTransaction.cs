using SalarySystem.Database;

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

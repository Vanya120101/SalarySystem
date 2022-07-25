using SalarySystem.Database;
using SalarySystem.Entities;
using System;

namespace SalarySystem.BL;

public class SalesReceiptTransaction : ITransaction
{
	private readonly DateTime _date;
	private readonly double _amount;
	private readonly int _employeeId;

	public SalesReceiptTransaction(DateTime date, double amount, int employeeId)
	{
		_date = date;
		_amount = amount;
		_employeeId = employeeId;
	}

	public void Execute()
	{
		var employee = PayrollDatabase.GetEmployee(_employeeId);
		if(employee == null)
			throw new InvalidOperationException("There is no employee with such ID");

		if(employee.PaymentClassification is not CommissionedClassification paymentClassifation)
			throw new InvalidOperationException("Attempting add time card to employee with no hourly payment classification");

		paymentClassifation.AddSalesReceipt(new SalesReceipt(_date, _amount));
	}
}

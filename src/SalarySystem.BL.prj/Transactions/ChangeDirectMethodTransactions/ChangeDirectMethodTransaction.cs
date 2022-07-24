using SalarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.BL;

public abstract class ChangePaymentMethodTransaction : ChangeEmployeeTransaction
{
	protected ChangePaymentMethodTransaction(int employeeId) : base(employeeId) { }

	protected abstract PaymentMethod PaymentMethod { get; }

	protected override void Change(Employee employee) => employee.PaymentMethod = PaymentMethod;
}

public class ChangeDirectMethodTransaction : ChangePaymentMethodTransaction
{
	public ChangeDirectMethodTransaction(int employeeId) : base(employeeId)
	{
	}

	protected override PaymentMethod PaymentMethod => new DirectMethod();
}

public class ChangeMailMethodTransaction : ChangePaymentMethodTransaction
{
	public ChangeMailMethodTransaction(int employeeId) : base(employeeId)
	{
	}

	protected override PaymentMethod PaymentMethod => new MailMethod();
}
public class ChangeHoldMethodTransaction : ChangePaymentMethodTransaction
{
	public ChangeHoldMethodTransaction(int employeeId) : base(employeeId)
	{
	}

	protected override PaymentMethod PaymentMethod => new HoldMethod();
}
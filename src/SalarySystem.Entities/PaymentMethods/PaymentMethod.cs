namespace SalarySystem.Entities;

public abstract class PaymentMethod
{
	public abstract void Pay(Paycheck paycheck);
}

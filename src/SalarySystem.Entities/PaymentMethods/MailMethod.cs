namespace SalarySystem.Entities;

public class MailMethod : PaymentMethod
{
	public override void Pay(Paycheck paycheck)
	{

	}

	public override string ToString() => "Выплата осуществляется через почту";

}
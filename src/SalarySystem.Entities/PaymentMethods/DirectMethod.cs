namespace SalarySystem.Entities;
public class DirectMethod : PaymentMethod
{
	public override void Pay(Paycheck paycheck)
	{

	}

	public override string ToString() => "Выплата осуществляется через банк";

}

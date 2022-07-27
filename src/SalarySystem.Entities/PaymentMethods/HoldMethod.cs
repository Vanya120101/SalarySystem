namespace SalarySystem.Entities;

public class HoldMethod : PaymentMethod
{
	public HoldMethod()
	{
	}
	public override void Pay(Paycheck paycheck)
	{

	}
	public override string ToString() => "Выплата осуществляется на руки";

}

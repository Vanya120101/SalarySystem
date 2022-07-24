namespace SalarySystem.Entities;

public class SalariedClassification : PaymentClassification
{
	public double Salary { get; }

	public SalariedClassification(double salary)
	{
		Salary = salary;
	}

	public override double CalculatePay(Paycheck paycheck) => Salary;
}
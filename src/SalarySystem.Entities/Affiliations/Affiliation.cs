namespace SalarySystem.Entities;

public abstract class Affiliation
{
	public abstract double CalculateDeductions(Paycheck paycheck);
}

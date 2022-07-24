namespace SalarySystem.Entities;

public class NoAffiliation : Affiliation
{
	public override double CalculateDeductions(Paycheck paycheck) => 0;
}
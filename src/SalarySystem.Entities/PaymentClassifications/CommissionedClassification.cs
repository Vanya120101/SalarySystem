namespace SalarySystem.Entities;

public class CommissionedClassification : PaymentClassification
{
	public CommissionedClassification(double salary, double commissionedRate)
	{
		Salary           = salary;
		CommissionedRate = commissionedRate;
	}

	public double Salary { get; }
	public double CommissionedRate { get; }
}

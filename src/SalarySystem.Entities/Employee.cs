namespace SalarySystem.Entities;

public class Employee
{
	public Employee(int employeeId, string name, string address, PaymentClassification paymentClassification, PaymentSchedule paymentSchedule, PaymentMethod paymentMethod)
	{
		if(string.IsNullOrEmpty(name)) throw new System.ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
		if(string.IsNullOrEmpty(address)) throw new System.ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));

		Id                    = employeeId;
		Name                  = name;
		Address               = address;
		PaymentClassification = paymentClassification ?? throw new System.ArgumentNullException(nameof(paymentClassification));
		PaymentSchedule       = paymentSchedule ?? throw new System.ArgumentNullException(nameof(paymentSchedule));
		PaymentMethod         = paymentMethod ?? throw new System.ArgumentNullException(nameof(paymentMethod));
		EmployeeInformation   = new EmployeeInformation();
	}

	public void PayDay(Paycheck paycheck)
	{
		var grossPay        = PaymentClassification.CalculatePay(paycheck);
		paycheck.GrossPay   = grossPay;
		var deductions      = Affiliation?.CalculateDeductions(paycheck);
		paycheck.Deductions = deductions ?? 0;
		paycheck.NetPay     = paycheck.GrossPay - paycheck.Deductions;
		PaymentMethod.Pay(paycheck);
	}

	public int Id { get; }
	public string Name { get; set; }
	public string Address { get; set; }
	public EmployeeInformation EmployeeInformation { get; private set; }
	public PaymentClassification PaymentClassification { get; set; }
	public PaymentSchedule PaymentSchedule { get; set; }
	public PaymentMethod PaymentMethod { get; set; }
	public Affiliation? Affiliation { get; set; }
}
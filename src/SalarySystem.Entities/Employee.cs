namespace SalarySystem.Entities;

public class Employee
{
	public Employee(int employeeId, string name, string address, PaymentClassification paymentClassification, PaymentSchedule paymentSchedule, HoldMethod paymentMethod)
	{
		if(string.IsNullOrEmpty(name)) throw new System.ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
		if(string.IsNullOrEmpty(address)) throw new System.ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));

		EmployeeId = employeeId;
		Name = name;
		Address = address;
		PaymentClassification = paymentClassification ?? throw new System.ArgumentNullException(nameof(paymentClassification));
		PaymentSchedule = paymentSchedule ?? throw new System.ArgumentNullException(nameof(paymentSchedule));
		PaymentMethod = paymentMethod ?? throw new System.ArgumentNullException(nameof(paymentMethod));
	}

	public int EmployeeId { get; }
	public string Name { get; set; }
	public string Address { get; set; }
	public PaymentClassification PaymentClassification { get; set; }
	public PaymentSchedule PaymentSchedule { get; set; }
	public HoldMethod PaymentMethod { get; set; }
	public Affiliation? Affiliation { get; set; }
}
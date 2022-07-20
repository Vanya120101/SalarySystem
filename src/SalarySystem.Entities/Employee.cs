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
	public string Name { get; }
	public string Address { get; }
	public PaymentClassification PaymentClassification { get; }
	public PaymentSchedule PaymentSchedule { get; }
	public HoldMethod PaymentMethod { get; }
}
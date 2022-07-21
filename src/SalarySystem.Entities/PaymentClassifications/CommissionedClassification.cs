namespace SalarySystem.Entities;

public class CommissionedClassification : PaymentClassification
{
	public double Salary { get; }
	public double CommissionedRate { get; }

	private readonly List<SalesReceipt> _salesReceiptList = new();

	public CommissionedClassification(double salary, double commissionedRate)
	{
		Salary           = salary;
		CommissionedRate = commissionedRate;
	}

	public void AddSalesReceipt(SalesReceipt salesReceipt) => _salesReceiptList.Add(salesReceipt);

	public SalesReceipt? GetSalesReceipt(DateTime dateTime) => _salesReceiptList.FirstOrDefault(r=>r.Date == dateTime);
}

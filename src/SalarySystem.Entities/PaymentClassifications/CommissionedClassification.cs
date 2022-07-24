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
	public override double CalculatePay(Paycheck paycheck)
	{
		var totalPay = Salary;
		foreach(var salesReceipt in _salesReceiptList)
		{
			if(IsInDayPeriod(paycheck.PayDay, salesReceipt))
				totalPay += salesReceipt.Amount * CommissionedRate;
		}

		return totalPay;
	}

	private bool IsInDayPeriod(DateTime payDay, SalesReceipt salesReceipt)
	{
		var payPeroidEndTime = payDay;
		var payPeriodStartTime = payDay.AddDays(-14);

		return salesReceipt.Date <= payPeroidEndTime && salesReceipt.Date >= payPeriodStartTime;
	}
}

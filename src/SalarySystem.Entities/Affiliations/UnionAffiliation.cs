namespace SalarySystem.Entities;

public class UnionAffiliation : Affiliation
{
	public int MemderId { get; }
	public double Due { get; }

	private readonly List<ServiceCharge> _serviceCharges = new ();
	public int MemberId { get;}

	public UnionAffiliation(int memderId, double due)
	{
		MemderId = memderId;
		Due = due;
	}

	public void AddServiceCharge(ServiceCharge serviceCharge) => _serviceCharges.Add(serviceCharge);
	public ServiceCharge? GetServiceCharge(DateTime date) => _serviceCharges.FirstOrDefault(c=>c.Date == date);
	public override double CalculateDeductions(Paycheck paycheck) => Due;
}

namespace SalarySystem.Entities;

public class UnionAffiliation : Affiliation
{
	private readonly List<ServiceCharge> _serviceCharges = new ();
	public void AddServiceCharge(ServiceCharge serviceCharge) => _serviceCharges.Add(serviceCharge);
	public ServiceCharge? GetServiceCharge(DateTime date) => _serviceCharges.FirstOrDefault(c=>c.Date == date);
}
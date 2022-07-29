using Microsoft.AspNetCore.Mvc;
using SalarySystem.Entities;

namespace SalarySystem.WebService.Models;
public class EmployeePaycheck
{
	public Employee Employee { get; init; }
	public double Salary { get; init; }
}

using Microsoft.AspNetCore.Mvc;
using SalarySystem.Database;

namespace SalarySystem.WebService.Controllers;

/// <summary>Controller containing employee api.</summary>
[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : Controller
{
	/// <summary>Get views with all employees.</summary>
	/// <returns>View with all employees.</returns>
	[HttpGet]
	public IActionResult Employees()
	{
		var employees = PayrollDatabase.GetEmployees();
		return View(employees);
	}

	/// <summary>Get view with employee by id.</summary>
	/// <returns>Employee.</returns>
	[HttpGet]
	public IActionResult Employee([FromQuery]int id)
	{
		var employee = PayrollDatabase.GetEmployee(id);
		return View(employee);
	}
}
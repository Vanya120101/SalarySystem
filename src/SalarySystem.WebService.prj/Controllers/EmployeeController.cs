using Microsoft.AspNetCore.Mvc;

namespace SalarySystem.WebService.Controllers;

/// <summary>Controller containing employee api.</summary>
[ApiController]
[Route("Employee/[action]")]
public class EmployeeController : Controller
{
	/// <summary>Get views with all employees.</summary>
	/// <returns>View with all employees.</returns>
	[HttpGet]
	public IActionResult Employees() => View();
}
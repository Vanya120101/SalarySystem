using Microsoft.AspNetCore.Mvc;

namespace SalarySystem.WebService.Controllers;

public class EmployeeController : Controller
{
	public IActionResult Employees()
	{
		return View();
	}
}

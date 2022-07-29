using Microsoft.AspNetCore.Mvc;

namespace SalarySystem.WebService.Controllers;

/// <summary>Controller containing transaction api.</summary>
[ApiController]
[Route("[controller]/[action]")]
public class TransactionController : Controller
{
	/// <summary>Get base creating transaction view </summary>
	/// <returns>Base creating transaction view</returns>
	[HttpGet]
	public IActionResult AddingEmployee() => View();

	/// <summary>Get creating salaried employee view.</summary>
	/// <returns>View adding salaried employee.</returns>
	[HttpGet]
	public IActionResult AddSalariedEmployee() => View("AddingSalariedEmployee");

	/// <summary>Get creating hourly employee view.</summary>
	/// <returns>View adding hourly employee.</returns>
	[HttpGet]
	public IActionResult AddHourlyEmployee() => View("AddingHourlyEmployee");

	/// <summary>Get creating commissioned employee view.</summary>
	/// <returns>View adding commissioned employee.</returns>
	[HttpGet]
	public IActionResult AddCommissionedEmployee() => View("AddingCommissionedEmployee");

	/// <summary>Get deleting employee with specified id view.</summary>
	/// <returns>Deleting employee view.</returns>
	[HttpGet]
	public IActionResult DeleteEmployee() => View("DeletingEmployee");

	/// <summary>Get calculating salary employee with specified id view.</summary>
	/// <returns>Calculating salary employee view.</returns>
	[HttpGet]
	public IActionResult CalculateSalary() => View("CalculatingSalaryEmployee");
}

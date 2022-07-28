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
	public IActionResult AddingEmployee()
	{
		return View();
	}

	/// <summary>Get creating salaried employee view.</summary>
	/// <returns>View adding salaried employee.</returns>
	[HttpGet]
	public IActionResult AddSalariedEmployee()
	{
		return View("AddingSalariedEmployee");
	}

	/// <summary>Get creating hourly employee view.</summary>
	/// <returns>View adding hourly employee.</returns>
	[HttpGet]
	public IActionResult AddHourlyEmployee()
	{
		return View("AddingHourlyEmployee");
	}

	/// <summary>Get creating commissioned employee view.</summary>
	/// <returns>View adding commissioned employee.</returns>
	[HttpGet]
	public IActionResult AddCommissionedEmployee()
	{
		return View("AddingCommissionedEmployee");
	}
}

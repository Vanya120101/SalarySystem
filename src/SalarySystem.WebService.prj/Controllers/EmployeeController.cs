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

	/// <summary>Add employee.</summary>
	/// <param name="employeeDTO">Employee DTO.</param>
	/// <returns>Operation success.</returns>
	[HttpPost]
	public IActionResult AddEmployee([FromForm]EmployeeDTO employeeDTO)
	{
		var test = employeeDTO.Address;
		return View("~/Views/Transaction/AddingEmployee.cshtml");
	}
}

public record EmployeeDTO
{
	public string FirstName { get; init; }

	public string SecondName { get; init; }
	public string Role { get; init; }
	public string Address { get; init; }
	public PaymentClassification PaymentClassification { get; init; }
	public PaymentMethods PaymentMethod { get; init; }
	public PaymentSchedule PaymentSchedule { get; init; }

}

public enum PaymentClassification
{
	Commissioned,
	Hourly,
	Salaried
}

public enum PaymentMethods
{
	Direct,
	Hold,
	Mail
}

public enum PaymentSchedule
{
	Biweekly,
	Monthly,
	Weekly
}
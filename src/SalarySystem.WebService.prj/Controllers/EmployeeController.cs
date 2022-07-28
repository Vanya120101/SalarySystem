using Microsoft.AspNetCore.Mvc;
using SalarySystem.BL;
using SalarySystem.Database;
using System;

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

	/// <summary>Add salaried employee.</summary>
	/// <param name="employeeDTO">Employee DTO.</param>
	/// <returns>View adding salaried employee.</returns>
	[HttpPost]
	public IActionResult AddSalariedEmployee([FromForm] SalariedEmployeeDTO employeeDTO)
	{
		var addEmployeeTransaction = new AddSalariedEmployeeTransaction(GetRandomID(), employeeDTO.Name, employeeDTO.Address, employeeDTO.Salary);
		addEmployeeTransaction.Execute();
		return View("~/Views/Transaction/AddingSalariedEmployee.cshtml");
	}

	/// <summary>Add hourly employee.</summary>
	/// <param name="employeeDTO">Employee DTO.</param>
	/// <returns>View adding hourly employee.</returns>
	[HttpPost]
	public IActionResult AddHourlyEmployee([FromForm]HourlyEmployeeDTO employeeDTO)
	{
		var addEmployeeTransaction = new AddHourlyEmployeeTransaction(GetRandomID(), employeeDTO.Name, employeeDTO.Address, employeeDTO.HourlyRate);
		addEmployeeTransaction.Execute();
		return View("~/Views/Transaction/AddingHourlyEmployee.cshtml");
	}

	/// <summary>Add commissioned employee.</summary>
	/// <param name="employeeDTO">Employee DTO.</param>
	/// <returns>View adding commissioned employee.</returns>
	[HttpPost]
	public IActionResult AddCommissionedEmployee([FromForm]CommissionedEmployeeDTO employeeDTO)
	{
		var addEmployeeTransaction = new AddCommissionedEmployeeTransaction(GetRandomID(), employeeDTO.Name, employeeDTO.Address, employeeDTO.Salary, employeeDTO.CommissionRate);
		addEmployeeTransaction.Execute();
		return View("~/Views/Transaction/AddingCommissionedEmployee.cshtml");
	}

	private static int GetRandomID()
	{
		var rnd = new Random();
		return rnd.Next(0, int.MaxValue);
	}
}

public abstract record SalariedDTO
{
	public string Name { get; init; }

	public string Address { get; init; }
}

public record SalariedEmployeeDTO : SalariedDTO
{
	public int Salary { get; init; }
}

public record HourlyEmployeeDTO : SalariedDTO
{
	public int HourlyRate { get; init; }
}

public record CommissionedEmployeeDTO : SalariedDTO
{
	public int Salary { get; init; }
	public int CommissionRate { get; init; }
}




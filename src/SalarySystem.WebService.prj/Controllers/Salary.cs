using Microsoft.AspNetCore.Mvc;
using SalarySystem.BL;
using SalarySystem.Database;
using SalarySystem.WebService.Models;
using System;

namespace SalarySystem.WebService.Controllers;

[Controller]
[Route("[controller]/[action]")]
public class Salary : Controller
{
	[HttpGet]
	public IActionResult CalculateSalary([FromQuery]int id, [FromQuery] DateTime currentDate)
	{
		var calculateSalary = new PaydayTransaction(currentDate);
		calculateSalary.Execute();
		var paycheck = calculateSalary.GetPaycheck(id);

		var employee = PayrollDatabase.GetEmployee(id);
		if(employee == null)
		{
			return null;
		}
		return View("~/Views/Employee/Paycheck.cshtml", new EmployeePaycheck { Employee = employee, Salary = paycheck.NetPay});
	}

}

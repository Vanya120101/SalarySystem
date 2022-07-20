﻿using SalarySystem.Entities;
using System.Collections;

namespace SalarySystem.Database;

public class PayrollDatabase
{
	private static readonly Hashtable _employees = new Hashtable();
	public PayrollDatabase()
	{

	}
	public static void AddEmployee(int id, Employee employee) => _employees[id] = employee;

	public static Employee GetEmployee(int id) => (Employee)_employees[id]!;
}

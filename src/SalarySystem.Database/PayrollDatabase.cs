﻿using SalarySystem.Entities;
using System.Collections;

namespace SalarySystem.Database;

public class PayrollDatabase
{
	private static readonly Hashtable _employees = new Hashtable();
	private static readonly Hashtable _unionMembers = new Hashtable();
	public static void AddEmployee(int id, Employee employee) => _employees[id] = employee;

	public static Employee? GetEmployee(int id) => _employees[id] as Employee;

	public static void DeleteEmployee(int id) => _employees.Remove(id);
	public static Employee? GetUniounMember(int memberId) => _unionMembers[memberId] as Employee;
	public static void AddUnionMember(int memberId, Employee employee) => _unionMembers[memberId] = employee;
	public static void DeleteUnionMember(int memberId) => _unionMembers.Remove(memberId);
	public static IEnumerable<Employee> GetEmployees()
	{
		var employees = new List<Employee>();
		foreach (var employee in _employees.Values)
		{
			employees.Add((Employee)employee);
		}

		return employees;
	}
}

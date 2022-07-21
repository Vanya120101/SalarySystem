using SalarySystem.Database;
using SalarySystem.Entities;
using System;

namespace SalarySystem.BL;

/// <summary>
/// Класс, отражающий транзакцию для добавления сотрудника.
/// <remarks>
/// Применен паттерн Шаблонный метод. 
/// Для создания объекта данный паттерн вырождается в Фабричный Метод.
/// В данном паттерне принято называть методы, создающие объект, как MakeXXX.
/// 
/// Также тут применен метод Команда.
/// Конструкция сохраняет данные, которыми впоследствии будет оперировать метод Execute().
/// </remarks>
/// </summary>
public abstract class AddEmployeeTransaction : ITransaction
{
	private readonly int _employeeId;
	private readonly string _name;
	private readonly string _address;

	public AddEmployeeTransaction(int employeeId, string name, string address)
	{
		if(string.IsNullOrEmpty(name)) throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
		if(string.IsNullOrEmpty(address)) throw new ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));

		_employeeId = employeeId;
		_name       = name;
		_address    = address;
	}

	protected abstract PaymentClassification MakeClassification();
	protected abstract PaymentSchedule MakeSchedule();

	public void Execute()
	{
		var paymentClassification = MakeClassification();
		var paymentSchedule       = MakeSchedule();
		var paymentMethod         = new HoldMethod();

		var employee = new Employee(_employeeId, _name, _address, paymentClassification, paymentSchedule, paymentMethod);
		PayrollDatabase.AddEmployee(_employeeId, employee);

	}
}

﻿namespace SalarySystem.Entities;

public abstract class PaymentClassification
{
	public abstract double CalculatePay(Paycheck paycheck);
}
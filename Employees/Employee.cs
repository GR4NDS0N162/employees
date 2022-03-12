using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	abstract partial class Employee
	{
		#region Свойства

		public string Name
		{
			get { return _name; }
			set
			{
				if (value.Length > 15)
					throw new Exception("Ошибка! Длина имени превышает 15 символов!");
				else
					_name = value;
			}
		}
		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}
		public int Age
		{
			get { return _age; }
			set { _age = value; }
		}
		public float Pay
		{
			get { return _pay; }
			set { _pay = value; }
		}
		public string SSN
		{
			get { return _ssn; }
		}
		public BenefitPackage Benefits
		{
			get { return _benefits; }
			set { _benefits = value; }
		}

		#endregion

		#region Методы

		public virtual void DisplayStats()
		{
			Console.WriteLine($"Name: {Name}");
			Console.WriteLine($"ID: {ID}");
			Console.WriteLine($"Age: {Age}");
			Console.WriteLine($"Pay: {Pay}");
			Console.WriteLine($"SSN: {SSN}");
		}

		public double GetBenefitCost()
		{ return _benefits.ComputePayDeduction(); }

		public virtual void GiveBonus(float amount)
		{ Pay += amount; }

		#endregion
	}
}

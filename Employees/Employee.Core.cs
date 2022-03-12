using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	abstract partial class Employee
	{
		#region Поля

		protected string _name;
		protected int _id;
		protected int _age;
		protected float _pay;
		protected string _ssn;
		protected BenefitPackage _benefits = new BenefitPackage();

		#endregion

		#region Конструкторы

		public Employee() { }
		public Employee(string name, int age, int id, float pay, string ssn)
		{
			Name = name;
			Age = age;
			ID = id;
			Pay = pay;
			if (ssn.Length != 9 && uint.TryParse(ssn, out _))
				throw new Exception("Ошибка! SSN должен состоят из 9 цифр!");
			else
				_ssn = ssn;
		}

		#endregion
	}
}

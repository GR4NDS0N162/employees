using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	// Продавцам нужно знать количество продаж
	class SalesPerson : Employee
	{
		#region Поля
		protected int _salesNumber;
		#endregion

		#region Свойства
		public int SalesNumber
		{
			get { return _salesNumber; }
			set
			{
				if (value < 0)
					throw new Exception("Ошибка! Количество продаж не может быть отрицательным!");
				else
					_salesNumber = value;
			}
		}
		#endregion

		#region Конструкторы
		public SalesPerson() { }

		public SalesPerson(string name, int age, int id, float pay, string ssn, int numOfSales)
			: base(name, age, id, pay, ssn)
		{
			SalesNumber = numOfSales;
		}
		#endregion

		#region Методы
		public override sealed void GiveBonus(float amount)
		{
			int salesBonus;
			if (SalesNumber < 50)
				salesBonus = 0;
			else if (SalesNumber < 100)
				salesBonus = 10;
			else if (SalesNumber < 200)
				salesBonus = 15;
			else
				salesBonus = 20;
			base.GiveBonus(amount * salesBonus);
		}

		public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine($"Number of Sales: {SalesNumber}");
		}
		#endregion
	}
}

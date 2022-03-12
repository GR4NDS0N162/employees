using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	// Менеджерам нужно знать количество их фондовых опционов
	class Manager : Employee
	{
		#region Поля

		protected int _stockOptions;

		#endregion

		#region Свойства

		public int StockOptions
		{
			get { return _stockOptions; }
			set
			{
				if (value < 0)
					throw new Exception("Ошибка! Количество фондовых опционов не может быть отрицательным!");
				else
					_stockOptions = value;
			}
		}

		#endregion

		#region Конструкторы

		public Manager() { }
		public Manager(string name, int age, int id, float pay, string ssn, int numOfOpts)
			: base(name, age, id, pay, ssn)
		{
			StockOptions = numOfOpts;
		}

		#endregion

		#region Методы

		public override void GiveBonus(float amount)
		{
			base.GiveBonus(amount);
			Random r = new Random();
			StockOptions += r.Next(500);
		}

		public override void DisplayStats()
		{
			base.DisplayStats();
			Console.WriteLine($"Number of Stock Options: {StockOptions}");
		}

		#endregion
	}
}

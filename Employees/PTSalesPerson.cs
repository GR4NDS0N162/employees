using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	// Продавец, который работает на условиях частичной занятости
	sealed class PTSalesPerson : SalesPerson
	{
		#region Конструкторы
		public PTSalesPerson() { }

		public PTSalesPerson(string name, int age, int id, float pay, string ssn, int numOfSales)
			: base(name, age, id, pay, ssn, numOfSales) { }
		#endregion
	}
}

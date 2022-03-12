using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	class ConsoleUserInterface
	{
		#region Поля
		/// <summary>
		/// Список пунктов меню.
		/// </summary>
		private readonly List<MenuItem> _menuItems;
		/// <summary>
		/// Список работников
		/// </summary>
		private readonly List<Employee> _employees;
		#endregion

		#region Конструкторы
		public ConsoleUserInterface()
		{
			_menuItems = new List<MenuItem>()
			{
				new MenuItem("Exit.", ExitDialog),
				new MenuItem("Add Employee.", AddEmployeeDialog),
				new MenuItem("Delete Employee.", DeleteEmployeeDialog),
				new MenuItem("Show Employees.", ShowEmployeesDialod),
			};
			_employees = new List<Employee>();
		}
		#endregion

		#region Методы
		/// <summary>
		/// Основной цикл взаимодействия с пользователем
		/// </summary>
		public void Run()
		{
			while (true)
			{
				try
				{
					ShowMenuItems();

					var action = int.Parse(Console.ReadLine());

					if (!_menuItems[action].Dialog())
					{
						// Диалог вернул false - выходим.
						break;
					}
				}
				catch (Exception ex)
				{
					// Исключения логируем и продолжаем работу.
					Console.WriteLine(ex);
				}
			}
		}

		/// <summary>
		/// Вывод пунктов меню на экран
		/// </summary>
		private void ShowMenuItems()
		{
			// Выводим список команд от 1-й, т.к. 0-й Exit будем выводить последним отдельно.
			for (int i = 1; i < _menuItems.Count; i++)
				Console.WriteLine($"{i}.{_menuItems[i].Message}");
			Console.WriteLine($"{0}.{_menuItems[0].Message}");
		}

		/// <summary>
		/// Завершающий диалог
		/// </summary>
		/// <returns>false</returns>
		private bool ExitDialog()
		{
			Console.WriteLine("Good bye!");
			return false;
		}

		/// <summary>
		/// Диалог добавления работника в список
		/// </summary>
		/// <returns>true - если все прошло гладко</returns>
		/// <exception cref="Exception"></exception>
		private bool AddEmployeeDialog()
		{
			Console.WriteLine("What type of employee would you like to add:");
			Console.WriteLine("1.Manager.");
			Console.WriteLine("2.SalesPerson.");
			Console.WriteLine("3.PTSalesPerson.");

			var choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 1:
					_employees.Add(CreateManagerDialog());
					break;
				case 2:
					_employees.Add(CreateSalesPersonDialog());
					break;
				case 3:
					_employees.Add(CreatePTSalesPersonDialog());
					break;
				default:
					throw new Exception("Ошибка! Неправильно выбран тип работника!");
			}

			Console.WriteLine("Added successfully!");

			return true;

			void CreateEmployeeDialog(out string name, out int age, out int id, out float pay, out string ssn)
			{
				Console.WriteLine("Enter name:");
				name = Console.ReadLine();
				Console.WriteLine("Enter age:");
				age = int.Parse(Console.ReadLine());
				Console.WriteLine("Enter ID:");
				id = int.Parse(Console.ReadLine());
				Console.WriteLine("Enter pay:");
				pay = float.Parse(Console.ReadLine());
				Console.WriteLine("Enter SSN:");
				ssn = Console.ReadLine();
			}

			Manager CreateManagerDialog()
			{
				CreateEmployeeDialog(out string name, out int age, out int id, out float pay, out string ssn);

				Console.WriteLine("Enter number of stock options:");
				int numOfOpts = int.Parse(Console.ReadLine());

				return new Manager(name, age, id, pay, ssn, numOfOpts);
			}

			SalesPerson CreateSalesPersonDialog()
			{
				CreateEmployeeDialog(out string name, out int age, out int id, out float pay, out string ssn);

				Console.WriteLine("Enter number of sales:");
				int numOfSales = int.Parse(Console.ReadLine());

				return new SalesPerson(name, age, id, pay, ssn, numOfSales);
			}

			PTSalesPerson CreatePTSalesPersonDialog()
			{
				CreateEmployeeDialog(out string name, out int age, out int id, out float pay, out string ssn);

				Console.WriteLine("Enter number of sales:");
				int numOfSales = int.Parse(Console.ReadLine());

				return new PTSalesPerson(name, age, id, pay, ssn, numOfSales);
			}
		}

		/// <summary>
		/// Диалог удаления работника из списка
		/// </summary>
		/// <returns>true - если все прошло гладко</returns>
		private bool DeleteEmployeeDialog()
		{
			Console.WriteLine("Enter index of employee:");
			int index = int.Parse(Console.ReadLine());

			_employees.RemoveAt(index);

			Console.WriteLine("Deleted successfully!");

			return true;
		}

		/// <summary>
		/// Диалог вывода элементов списка работников
		/// </summary>
		/// <returns>true - если все прошло гладко</returns>
		private bool ShowEmployeesDialod()
		{
			for (int i = 0; i < _employees.Count; i++)
			{
				Console.WriteLine($"{i + 1}) {_employees[i]}");
				_employees[i].DisplayStats();
				Console.WriteLine();
			}

			return true;
		}
		#endregion

		#region Вложенные типы
		/// <summary>
		/// Структура для хранения пункта меню
		/// </summary>
		private struct MenuItem
		{
			#region Свойства
			/// <summary>
			/// Сообщение для выбора пункта меню
			/// </summary>
			public string Message { get; set; }

			/// <summary>
			/// Функция с диалогом. Если возвращает true - продолжаем, если false - завершаем работу.
			/// </summary>
			public Func<bool> Dialog { get; set; }
			#endregion

			#region Конструкторы
			public MenuItem(string message, Func<bool> dialog)
			{
				Message = message;
				Dialog = dialog;
			}
			#endregion
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	class BenefitPackage
	{
		public enum BenefitPackageLevel
		{
			Standard, Gold, Platinum
		}

		public double ComputePayDeduction()
		{
			return 125.0;
		}
	}
}

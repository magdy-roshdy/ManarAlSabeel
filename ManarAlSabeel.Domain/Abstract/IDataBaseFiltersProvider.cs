using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Abstract
{
	public interface IDataBaseFiltersProvider
	{
		int? GetSexFilter();

		int? GetBranchFilter();
	}
}

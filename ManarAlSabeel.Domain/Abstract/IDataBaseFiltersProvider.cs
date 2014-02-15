using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Abstract
{
	public interface IDataBaseFiltersProvider
	{
		int? GetSexFilter();

		Branch GetBranchFilter();
	}
}

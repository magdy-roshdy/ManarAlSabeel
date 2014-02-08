using ManarAlSabeel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class SessionBasedDataBaseFilterProvider : IDataBaseFiltersProvider
	{
		public int? GetSexFilter()
		{
			int sexParameterValue;
			if (HttpContext.Current.Session["sex-filter"] != null
				&& int.TryParse(HttpContext.Current.Session["sex-filter"].ToString(), out sexParameterValue))
			{
				return sexParameterValue;
			}

			return null;
		}


		public int? GetBranchFilter()
		{
			int branchParameterValue;
			if (HttpContext.Current.Session["branch-filter"] != null
				&& int.TryParse(HttpContext.Current.Session["branch-filter"].ToString(), out branchParameterValue))
			{
				return branchParameterValue;
			}

			return null;
		}
	}
}
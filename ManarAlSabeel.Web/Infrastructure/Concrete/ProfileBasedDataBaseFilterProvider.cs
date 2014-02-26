using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Infrastructure.Concrete
{
	public class ProfileBasedDataBaseFilterProvider : IDataBaseFiltersProvider
	{
		const string SEX_FILTER_NAME = "SexFilter";
		const string BRANCH_FILTER_NAME = "BranchFilter";

		public int? GetSexFilter()
		{
			try
			{
				if (HttpContext.Current.Profile[SEX_FILTER_NAME] != null)
				{
					return (int)HttpContext.Current.Profile[SEX_FILTER_NAME];
				}
			}
			catch { }

			return null;
		}


		public Branch GetBranchFilter()
		{
			try
			{
				if (HttpContext.Current.Profile[BRANCH_FILTER_NAME] != null)
				{
					return HttpContext.Current.Profile[BRANCH_FILTER_NAME] as Branch;
				}
			}
			catch { }

			return null;
		}
	}
}
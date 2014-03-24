using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Web.Heplers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Infrastructure.Concrete
{
	public class ProfileBasedDataBaseFilterProvider : IDataBaseFiltersProvider
	{
		public int? GetSexFilter()
		{
			try
			{
				if (Helpers.GetProfileSex() != null)
				{
					return (int)Helpers.GetProfileSex();
				}
			}
			catch { }

			return null;
		}


		public Branch GetBranchFilter()
		{
			try
			{
				if (Helpers.GetProfileBranch() != null)
				{
					return Helpers.GetProfileBranch();
				}
			}
			catch { }

			return null;
		}
	}
}
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Heplers
{
	public static class Helpers
	{
		public static string GetPageTitle(string pageTitle)
		{
			return string.Format("{0} - {1}", StringTable.ManarAlSabeel, pageTitle);
		}

		public static string GetSexCaption(Sex sex)
		{
			return
				(sex == Sex.Male)
				?
				StringTable.Male
				:
				StringTable.Female;
		}

		public static List<SelectListItem> CountriesToSelectListItems(IQueryable<Country> countries, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text="", Value="0" });
			}

			foreach (Country country in countries)
			{
				selectListItems.Add(new SelectListItem { Text = country.Name, Value = country.ID.ToString()});
			}

			return selectListItems;
		}

		public static List<SelectListItem> GuardiansToSelectListItems(IQueryable<StudentGuardian> guardians, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (StudentGuardian guardian in guardians)
			{
				selectListItems.Add(new SelectListItem { Text = guardian.Name, Value = guardian.ID.ToString() });
			}

			return selectListItems;
		}
	}
}
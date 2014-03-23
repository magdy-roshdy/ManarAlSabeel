using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using ManarAlSabeel.Web.Models;
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
			Branch currentBranch = HttpContext.Current.Profile["BranchFilter"] as Branch;
			if (currentBranch != null)
			{
				return string.Format("{0} - {1}", currentBranch.Center.Name, pageTitle);
			}

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

		public static List<SelectListItem> TeachersToSelectListItems(IQueryable<Teacher> teachers, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (Teacher teacher in teachers)
			{
				selectListItems.Add(new SelectListItem { Text = teacher.Name, Value = teacher.ID.ToString() });
			}

			return selectListItems;
		}

		public static List<SelectListItem> SemestersToSelectListItems(IQueryable<Semester> semesters, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (Semester semester in semesters)
			{
				selectListItems.Add(new SelectListItem { Text = semester.Name, Value = semester.ID.ToString() });
			}

			return selectListItems;
		}

		public static string GetBranchCenterHeaderString()
		{
			Branch currentBranch = HttpContext.Current.Profile["BranchFilter"] as Branch;
			if (currentBranch != null)
			{
				int? sexFilter = HttpContext.Current.Profile["SexFilter"] as int?;
				return string.Format("{0} - {1} ({2})",
					currentBranch.Center.Name,
					currentBranch.Name,
					sexFilter.HasValue ? GetSexCaption(sexFilter.Value) : string.Empty
					);
			}

			return StringTable.ManarAlSabeel;
		}

		public static string GetSexCaption(int sexCode)
		{
			Sex sex = (Sex)sexCode;
			return (sex == Sex.Male) ? StringTable.Males : StringTable.Females ;
		}

		public static string GetMaritalStatusCaption(MaritalStatus status)
		{
			switch(status)
			{
				case MaritalStatus.Divorced:
					return StringTable.Divorced;

				case MaritalStatus.Widow:
					return StringTable.Widow;

				case MaritalStatus.Single:
					return StringTable.Single;

				case MaritalStatus.Married:
					return StringTable.Married;

				default:
					return string.Empty;
			}
		}

		public static string GetClassPeriodCaption(ClassTeachingPeriod period)
		{
			switch(period)
			{
				case ClassTeachingPeriod.Morning:
					return StringTable.Morning;

				case ClassTeachingPeriod.Evening:
					return StringTable.Evening;

				default:
					return string.Empty;
			}
		}

		public static BranchViewModel ConvertToBranchViewModel(Branch branch)
		{
			if (branch == null) return null;

			return new BranchViewModel { ID = branch.ID, Name = branch.Name };
		}

		public static Sex? GetProfileSex()
		{
			return ((Sex)HttpContext.Current.Profile["SexFilter"]) as Sex?;
		}
	}
}
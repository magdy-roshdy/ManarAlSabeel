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
			Branch currentBranch = Helpers.GetProfileBranch();
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

		public static List<SelectListItem> StudentsToSelectListItems(IQueryable<Student> students, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (Student student in students)
			{
				selectListItems.Add(new SelectListItem { Text = student.Name, Value = student.ID.ToString() });
			}

			return selectListItems;
		}

		public static List<SelectListItem> ClassesToSelectListItems(IQueryable<Class> classes, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (Class _class in classes)
			{
				selectListItems.Add(new SelectListItem { Text = _class.Name, Value = _class.ID.ToString() });
			}

			return selectListItems;
		}

		public static List<SelectListItem> StagesToSelectListItems(IQueryable<Stage> stages, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (Stage stage in stages)
			{
				selectListItems.Add(new SelectListItem { Text = stage.Name, Value = stage.ID.ToString() });
			}

			return selectListItems;
		}

		public static List<SelectListItem> ExternalSupervisorToSelectListItems(IQueryable<ExternalSupervisor> stages, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (ExternalSupervisor supervisor in stages)
			{
				selectListItems.Add(new SelectListItem { Text = supervisor.Name, Value = supervisor.ID.ToString() });
			}

			return selectListItems;
		}

		public static List<SelectListItem> ExamTypesToSelectListItems(IQueryable<ExamType> types, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (ExamType examTypes in types)
			{
				selectListItems.Add(new SelectListItem { Text = examTypes.Name, Value = examTypes.ID.ToString() });
			}

			return selectListItems;
		}

		public static List<SelectListItem> ExamGradesToSelectListItems(IQueryable<ExamGrade> examGrades, bool addEmptyItem = false)
		{
			List<SelectListItem> selectListItems = new List<SelectListItem>();

			if (addEmptyItem)
			{
				selectListItems.Add(new SelectListItem { Text = "", Value = "0" });
			}

			foreach (ExamGrade examGrade in examGrades)
			{
				selectListItems.Add(new SelectListItem { Text = examGrade.Name, Value = examGrade.ID.ToString() });
			}

			return selectListItems;
		}

		public static string GetBranchCenterHeaderString()
		{
			Branch currentBranch = Helpers.GetProfileBranch();
			if (currentBranch != null)
			{
				Sex? sexFilter = Helpers.GetProfileSex();
				return string.Format("{0} - {1} ({2})",
					currentBranch.Center.Name,
					currentBranch.Name,
					sexFilter.HasValue ? Helpers.GetPluralSexCaption(sexFilter.Value) : string.Empty
					);
			}

			return StringTable.ManarAlSabeel;
		}

		public static string GetPluralSexCaption(Sex sexCode)
		{
			return (sexCode == Sex.Male) ? StringTable.Males : StringTable.Females;
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
			SystemAdmin admin = HttpContext.Current.Profile["SystemAdmin"] as SystemAdmin;
			return (admin == null) ? null : admin.SexToManage;
		}

		public static Branch GetProfileBranch()
		{
			SystemAdmin admin = HttpContext.Current.Profile["SystemAdmin"] as SystemAdmin;
			return (admin == null) ? null : admin.Branch;
		}

		public static BranchViewModel GetBranchViewModel(int? id, string name)
		{
			if (Helpers.GetProfileBranch() != null)
				return ConvertToBranchViewModel(Helpers.GetProfileBranch());
			else
				if (id.HasValue && !string.IsNullOrEmpty(name))
					return new BranchViewModel { ID = id.Value, Name = name };
				else
					return null;
		}
	}
}
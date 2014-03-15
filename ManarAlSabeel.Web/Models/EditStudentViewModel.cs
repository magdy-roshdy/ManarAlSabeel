using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Models
{
	public class EditStudentViewModel
	{
		public int ID { get; set; }
		public string  Name { get; set; }
		public DateTime BirthDate { get; set; }
		public string PersonalPhotoPath { get; set; }

		public int GuardianID { get; set; }
		public string GuardianName { get; set; }

		public int BranchID { get; set; }
		public string BranchName { get; set; }

		public int OriginalNationalityID { get; set; }
		public string OriginalNationalityName { get; set; }

		public int AcquiredNationalityID { get; set; }
		public string AcquiredNationalityName { get; set; }

		public string SchoolName { get; set; }
		public string LastEducationDegree { get; set; }
		public string EducationStage { get; set; }
		public string SchoolClass { get; set; }
		public HowKnewTheCenter HowKnewTheCenter { get; set; }
		public int ExpectedQuraanFinishTime { get; set; }
		public bool IsInTransportations { get; set; }
		public Sex Sex { get; set; }
		public StudentStatus Status { get; set; }
		public DateTime AddedOn { get; set; }

		public IQueryable<Country> Countries { get; set; }
		public IQueryable<StudentGuardian> Guardians { get; set; }
	}
}
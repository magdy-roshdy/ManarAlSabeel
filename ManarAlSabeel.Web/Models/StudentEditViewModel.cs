using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Models
{
	public class StudentEditViewModel
	{
		public int ID { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "StudentNameRequired")]
		public string  Name { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "StudentBirthdayRequired")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime BirthDate { get; set; }

		public string PersonalPhotoPath { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "GuardianIsRequired")]
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

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "ExpectedTimeToFinishQuraanRequired")]
		public int ExpectedQuraanFinishTime { get; set; }

		public bool IsInTransportations { get; set; }
		public Sex Sex { get; set; }
		public StudentStatus Status { get; set; }
		public DateTime AddedOn { get; set; }

		public IQueryable<Country> Countries { get; set; }
		public IQueryable<StudentGuardian> Guardians { get; set; }

		public int? AdmissionInterviewID { get; set; }

		public bool AddAdmissionInterviewNow { get; set; }
	}
}
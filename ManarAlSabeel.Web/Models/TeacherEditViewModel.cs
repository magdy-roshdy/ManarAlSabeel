using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class TeacherEditViewModel
	{
		public int ID { get; set; }

		public int BranchID { get; set; }
		public string BranchName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "TeacherNameIsRequired")]
		public string Name { get; set; }
		public Sex Sex { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "TeacherNationalityIsRequired")]
		public int NationalityID { get; set; }
		public string NationalityName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "TeacherBirthdateIsRequired")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime BirthDate { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "TeacherBirthPlaceIsRequired")]
		public int BirthPlaceID { get; set; }
		public string BirthPlaceName { get; set; }

		public MaritalStatus MaritalStatus { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? MarriageDate { get; set; }
		public string Profession { get; set; }
		public ReligiousIdeology? ReligiousIdeology { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "TeacherMobileNumberIsRequired")]
		public string MobileNumber { get; set; }
		public string HomeNumber { get; set; }
		public string Email { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "AmountOfMemorizationIsRequired")]
		public string AmountOfMemorization { get; set; }
		public bool IsSupervisor { get; set; }
		public TeacherStatus Status { get; set; }

		public IQueryable<Country> Countries { get; set; }
	}
}
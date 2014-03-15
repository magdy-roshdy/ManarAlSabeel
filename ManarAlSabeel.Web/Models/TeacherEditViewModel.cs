using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class TeacherEditViewModel
	{
		public int ID { get; set; }

		public int BranchID { get; set; }
		public string BranchName { get; set; }

		public string Name { get; set; }
		public Sex Sex { get; set; }

		public int NationalityID { get; set; }
		public string NationalityName { get; set; }

		public DateTime BirthDate { get; set; }

		public int BirthPlaceID { get; set; }
		public string BirthPlaceName { get; set; }

		public MaritalStatus MaritalStatus { get; set; }
		public DateTime? MarriageDate { get; set; }
		public string Profession { get; set; }
		public ReligiousIdeology? ReligiousIdeology { get; set; }
		public string MobileNumber { get; set; }
		public string HomeNumber { get; set; }
		public string Email { get; set; }
		public string AmountOfMemorization { get; set; }
		public bool IsSupervisor { get; set; }
		public TeacherStatus Status { get; set; }

		public IQueryable<Country> Countries { get; set; }
	}
}
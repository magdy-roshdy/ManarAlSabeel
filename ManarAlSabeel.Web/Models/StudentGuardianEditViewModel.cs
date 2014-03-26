using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class StudentGuardianEditViewModel
	{
		public int ID { get; set; }

		public int BranchID { get; set; }
		public string BranchName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "GuardianNameIsRequired")]
		public string Name { get; set; }
		public string HomePhone { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "GuardianMobileNumberIsRequired")]
		public string MobilePhone { get; set; }
		public string OtherPhone { get; set; }
		public string HomeAddress { get; set; }
		public string Email { get; set; }
		public Sex Sex { get; set; }
	}
}
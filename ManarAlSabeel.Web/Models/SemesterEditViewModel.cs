using ManarAlSabeel.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class SemesterEditViewModel
	{
		public int ID { get; set; }
		[Required(ErrorMessageResourceType = typeof(Messages),
			  ErrorMessageResourceName = "SemesterNameIsRequired")]
		public string Name { get; set; }

		public int BranchID { get; set; }
		public string BranchName { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "SemesterStartDateIsRequired")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "SemesterEndDateIsRequired")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime EndDate { get; set; }
		public bool IsTheCurrent { get; set; }
	}
}
using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class AdmissionInterviewEditModel
	{
		public int ID { get; set; }

		public int StudentID { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "InterviewDateIsRequired")]
		public DateTime Date { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "MemorizationAmountIsRequired")]
		public string MemorizationAmount { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "InterviewResultIsRequired")]
		public string Result { get; set; }

		public string Notes { get; set; }
	}
}
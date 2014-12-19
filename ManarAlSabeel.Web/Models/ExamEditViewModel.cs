using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class ExamEditViewModel
	{
		public int ID { get; set; }
		public int RegistredStudentID { get; set; }
		
		public int SupervisorID { get; set; }
		public int? ExternalSupervisorID { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "ExamDateIsRequired")]
		public DateTime Date { get; set; }
		public int ExamTypeID { get; set; }
		public int ExamGradeID { get; set; }

		public int BonusPoints { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "ExamCommentsIsRequired")]
		public string Comments { get; set; }

		public IQueryable<Teacher> Teachers { get; set; }
		public IQueryable<ExternalSupervisor> ExternalSupervisors { get; set; }
		public IQueryable<ExamType> ExamTypes { get; set; }
		public IQueryable<ExamGrade> ExamGrades { get; set; }
	}
}
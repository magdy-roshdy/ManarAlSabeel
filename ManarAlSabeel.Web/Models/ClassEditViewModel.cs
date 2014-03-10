using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class ClassEditViewModel
	{
		public int ClassID { get; set; }
		
		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "ClassNameIsRequired")]
		public string ClassName { get; set; }

		public Sex Sex { get; set; }
		public ClassTeachingPeriod TeachingPeriod { get; set; }

		public string SemesterName { get; set; }
		public int SemesterID { get; set; }

		public string BranchName { get; set; }
		public int BranchID { get; set; }

		public string TeacherName { get; set; }
		public int TeacherID { get; set; }

		public IQueryable<Teacher> Teachers { get; set; }
		public IQueryable<Semester> Semesters { get; set; }
	}
}
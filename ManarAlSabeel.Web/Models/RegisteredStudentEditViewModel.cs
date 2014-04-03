using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class RegisteredStudentEditViewModel
	{
		public int ID { get; set; }
		public int StudentID { get; set; }
		public int StageID { get; set; }
		public int ClassID { get; set; }

		public int BranchID { get; set; }
		public string BranchName { get; set; }

		public IQueryable<Class> Classes { get; set; }
		public IQueryable<Student> Students { get; set; }
		public IQueryable<Stage> Stages { get; set; }
	}
}
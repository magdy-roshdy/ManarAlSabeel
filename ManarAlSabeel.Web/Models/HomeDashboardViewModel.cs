using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class HomeDashboardViewModel
	{
		public Semester Semester { get; set; }
		public IEnumerable<IGrouping<ExamType, Exam>> ExamsGroup { get; set; }
		public List<Class> Classes { get; set; }
		public int NumberOfStudents { get; set; }
	}
}
using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class ExamsListViewModel
	{
		public IQueryable<Exam> Exams { get; set; }
	}
}
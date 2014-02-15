using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Models
{
	public class EditStudentViewModel
	{
		public Student Student { get; set; }
		public IQueryable<Country> Countries { get; set; }
		public IQueryable<StudentGuardian> Guardians { get; set; }
	}
}
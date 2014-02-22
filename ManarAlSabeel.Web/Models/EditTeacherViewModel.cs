using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class EditTeacherViewModel
	{
		public Teacher Teacher { get; set; }
		public IQueryable<Country> Countries { get; set; }
	}
}
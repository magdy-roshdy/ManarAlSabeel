using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class RegisteredStudentsListViewModel
	{
		public IQueryable<RegisteredStudent> RegisteredStudents { get; set; }
		public string SemesterName { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}
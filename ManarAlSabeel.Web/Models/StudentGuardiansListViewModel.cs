using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class StudentGuardiansListViewModel
	{
		public IQueryable<StudentGuardian> Guardians { get; set;}
		public PagingInfo PagingInfo { get; set; }
	}
}
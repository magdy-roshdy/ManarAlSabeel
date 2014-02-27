using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class SemestersListViewModel
	{
		public IQueryable<Semester> Semesters { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}
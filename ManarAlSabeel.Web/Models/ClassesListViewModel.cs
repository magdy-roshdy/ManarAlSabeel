using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class ClassesListViewModel
	{
		public IQueryable<Class> Classes { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}
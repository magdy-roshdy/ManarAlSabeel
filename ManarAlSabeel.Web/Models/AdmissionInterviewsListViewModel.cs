using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class AdmissionInterviewsListViewModel
	{
		public IQueryable<AdmissionInterview> Interviews { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}
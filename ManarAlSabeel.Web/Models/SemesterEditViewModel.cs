using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class SemesterEditViewModel
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public int BranchID { get; set; }
		public string BranchName { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsTheCurrent { get; set; }
	}
}
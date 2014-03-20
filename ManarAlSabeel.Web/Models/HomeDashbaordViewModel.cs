using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
	public class HomeDashbaordViewModel
	{
		public Semester CurrentSemester { get; set; }
		public List<Track> TracksList { get; set; }
	}
}
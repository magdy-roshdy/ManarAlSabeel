using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class RegisteredStudent
	{
		public virtual int ID { get; set; }

		public virtual Student Student { get; set; }
		public virtual Semester Semester { get; set; }
		public virtual Class Class { get; set; }
		public virtual Track Track { get; set; }

		public virtual DateTime Date { get; set; }
		public virtual string Comments { get; set; }
	}
}

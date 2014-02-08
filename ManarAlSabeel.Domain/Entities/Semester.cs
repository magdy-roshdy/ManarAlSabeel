using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class Semester
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual DateTime Start { get; set; }
		public virtual DateTime End { get; set; }
		public virtual bool IsTheCurrent { get; set; }
	}
}

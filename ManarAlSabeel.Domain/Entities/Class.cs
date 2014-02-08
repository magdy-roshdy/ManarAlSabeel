using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class Class
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual Sex Sex { get; set; }
		public virtual ClassTeachingPeriod TeachingPeriod { get; set; }

		public virtual Semester Semester { get; set; }
		public virtual Branch Branch { get; set; }
		public virtual Teacher Teacher { get; set; }
	}
}

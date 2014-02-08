using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class LearningProgressAxes
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }

		public virtual Track Track { get; set; }
	}
}

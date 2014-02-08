using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class LearningProgressUnit
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual Track Track { get; set; }

		public virtual bool IsHasSubUnits { get; set; }
		public virtual int? SubUnitCount { get; set; }
	}

	public class LearningProgressSubUnit
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
	}
}

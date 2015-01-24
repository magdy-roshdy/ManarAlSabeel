using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class LearningProgressMark
	{
		public virtual long ID { get; set; }

		public virtual LearningProgressUnit Unit { get; set; }
		public virtual int? SubUnitNumber { get; set; }
		public virtual Exam Exam { get; set; }
		public virtual LearningProgressAxes Axes { get; set; }
	}
}

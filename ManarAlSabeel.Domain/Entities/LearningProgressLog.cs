using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class LearningProgressLog
	{
		public virtual long ID { get; set; }
		public virtual Exam Exam { get; set; }
		public virtual LearningProgressMark From { get; set; }
		public virtual LearningProgressMark To { get; set; }
		public virtual LearningProgressAxes Axes { get; set; }
		public virtual string Comments { get; set; }
	}
}

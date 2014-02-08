using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class StudentBehaviorEvaluation
	{
		public virtual int ID { get; set; }
		public virtual RegisteredStudent RegisteredStudent { get; set; }
		public virtual Exam Exam { get; set; }
		public virtual StudentBehaviorLevels BehaviorLevel { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class StudentStageChangeLog
	{
		public virtual int ID { get; set; }
		public virtual RegisteredStudent RegisteredStudent { get; set; }
		public virtual Exam Exam { get; set; }
		public virtual Stage Stage { get; set; }
		public virtual int StageLevel { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual string Comments { get; set; }
	}
}
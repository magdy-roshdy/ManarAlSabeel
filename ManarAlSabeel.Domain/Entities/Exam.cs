using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class Exam
	{
		public virtual int ID { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual ExamType Type { get; set; }
		public virtual int BonusPoints { get; set; }
		public virtual ExamGrade Grade { get; set; }
		public virtual string Comments { get; set; }

		public virtual Teacher Supervisor { get; set; }
		public virtual ExternalSupervisor ExternalSupervisor { get; set; }
		public virtual RegisteredStudent RegisteredStudent { get; set; }
		
	}

	public class ExamType
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
	}

	public class ExamGrade
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
	}

}

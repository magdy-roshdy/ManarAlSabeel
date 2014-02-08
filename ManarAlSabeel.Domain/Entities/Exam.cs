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
		public virtual ExamTypes Type { get; set; }
		public virtual int BonusPoints { get; set; }
		public virtual ExamGrades Grade { get; set; }
		public virtual string Comments { get; set; }

		public virtual Teacher Supervisor { get; set; }
		public virtual ExternalSupervisor ExternalSupervisor { get; set; }
		public virtual RegisteredStudent RegisteredStudent { get; set; }
		
	}
}

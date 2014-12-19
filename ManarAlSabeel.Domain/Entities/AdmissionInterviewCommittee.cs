using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class AdmissionInterviewCommittee
	{
		public virtual long ID { get; set; }
		public virtual AdmissionInterview Interview { get; set; }
		public virtual Teacher InterviewAttendee { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class AdmissionInterview
	{
		public virtual int ID { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual Student Student { get; set; }
		public virtual IEnumerable<AdmissionInterviewCommittee> Committee { get; set; }
		public virtual string  MemorizationAmount{ get; set; }
		public virtual string Result { get; set; }
		public virtual string Notes { get; set; }
	}
}

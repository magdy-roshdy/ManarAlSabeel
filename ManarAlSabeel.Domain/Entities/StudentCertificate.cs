using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class StudentCertificate
	{
		public virtual int ID { get; set; }
		public virtual RegisteredStudent RegisteredStudent { get; set; }
		public virtual StudentCertificateType Type { get; set; }
		public virtual DateTime Date { get; set; }
	}
}

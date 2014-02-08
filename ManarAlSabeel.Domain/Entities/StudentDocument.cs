using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class StudentDocument
	{
		public virtual int ID { get; set; }
		public virtual StudentDocumentTypes Type { get; set; }
		public virtual string Name { get; set; }
		public virtual string FilePath { get; set; }

		public virtual Student Student { get; set; }
	}
}

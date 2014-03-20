﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class Semester
	{
		public virtual int ID { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "SemesterNameIsRequired")]
		public virtual string Name { get; set; }

		public virtual Branch Branch { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "SemesterStartDateIsRequired")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public virtual DateTime StartDate { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "SemesterEndDateIsRequired")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public virtual DateTime EndDate { get; set; }

		public virtual bool IsTheCurrent
		{
			get
			{
				int startDateCompare = DateTime.Compare(this.StartDate, DateTime.Now);
				int endtDateCompare = DateTime.Compare(DateTime.Now, this.EndDate);
				if ((startDateCompare == 0 || startDateCompare < 0)
					&& endtDateCompare == 0 || endtDateCompare < 0)
				{
					return true;
				}
				else
				{
					return false;
				}
				
			}
		}

		public virtual IList<Class> Classes { get; set; }
	}
}

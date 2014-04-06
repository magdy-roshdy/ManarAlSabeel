using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public enum Sex
	{
		[Description("0")]
		Female = 0,

		[Description("1")]
		Male = 1
	}

	public enum HowKnewTheCenter
	{
		Friend,
		Ad,
		Other
	}

	public enum StudentStatus
	{
		Active = 0,
		InActive = 1,
		Expelled = 2
	}

	public enum MaritalStatus
	{
		Married = 0,
		Single = 1,
		Divorced = 2,
		Widow = 3
	}

	public enum ReligiousIdeology
	{
		Hanafy = 0,
		Shafeey = 1,
		Maleky = 2,
		Hanbaly = 3
	}

	public enum TeacherStatus
	{
		Active = 0,
		InActive = 1
	}

	public enum ClassTeachingPeriod
	{
		Morning = 0,
		Evening = 1
	}

	public enum LearningProgressMarkType
	{
		From = 0,
		To = 1
	}

	public enum StudentBehaviorLevels
	{
		VeryPolite = 0,
		Polite = 1,
		Normal = 2,
		Nuaghty = 3,
		VerNuaghty = 4
	}

	public enum StudentCertificateType
	{
		Final = 0,
		Appreciation = 1
	}

	public enum StudentDocumentTypes
	{
		Passport = 0,
		IDCard = 1,
		GraduationCertificate = 2
	}
}

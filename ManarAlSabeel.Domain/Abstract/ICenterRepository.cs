using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManarAlSabeel.Domain.Entities;

namespace ManarAlSabeel.Domain.Abstract
{
	public interface ICenterRepository
	{
		IQueryable<StudentGuardian> GetAllStudentGuardians();

		IQueryable<Student> GetAllStudents();

		int? SaveStudent(Student student);

		void TEMP();
	}
}
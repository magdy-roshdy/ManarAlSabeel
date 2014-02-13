using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManarAlSabeel.Domain.Entities;

namespace ManarAlSabeel.Domain.Abstract
{
	public interface ICenterRepository
	{
		IQueryable<Student> GetAllStudents();
		int? SaveStudent(Student student);
		bool DeleteStudent(int studentId);

		IQueryable<StudentGuardian> GetAllStudentGuardians();
		int? SaveStudentGuardian(StudentGuardian studentGuardian);
		bool DeleteStudentGuardian(int studentGuardianId);

		IQueryable<Country> GetAllCountries();

		void TEMP();
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManarAlSabeel.Domain.Entities;

namespace ManarAlSabeel.Domain.Abstract
{
	public interface ICenterRepository
	{
		void SetFilterIgnore(bool ignore);
		IQueryable<Student> GetAllStudents();
		int? SaveStudent(Student student);
		bool DeleteStudent(int studentId);

		IQueryable<StudentGuardian> GetAllStudentGuardians();
		int? SaveStudentGuardian(StudentGuardian studentGuardian);
		bool DeleteStudentGuardian(int studentGuardianId);

		IQueryable<Teacher> GetAllTeachers();
		int? SaveTeacher(Teacher teacher);
		bool DeleteTeacher(int teacherId);

		SystemAdmin AuthenticateSystemAdmin(string email, string password);
		SystemAdmin GetSystemAdminByEmail(string email);

		IQueryable<Semester> GetAllSemesters(bool orderByStartDate = true);
		int? SaveSemester(Semester semester);
		bool DeleteSemeter(int semesterId);

		IQueryable<Class> GetAllClasses();
		int? SaveClass(Class aClass);
		bool DeleteClass(int classId);

		IQueryable<Track> GetAllTracks();

		IQueryable<RegisteredStudent> GetAllRegisteredStudents();

		IQueryable<Country> GetAllCountries();
	}
}
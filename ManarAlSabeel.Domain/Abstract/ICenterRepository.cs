﻿using System;
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

		SystemAdmin GetSystemAdminByEmail(string email);
		void UpdateSystemAdminLastLogin(int adminId, DateTime lastLogin);

		IQueryable<Semester> GetAllSemesters(bool orderByStartDate = true);
		int? SaveSemester(Semester semester);
		bool DeleteSemeter(int semesterId);

		IQueryable<Class> GetAllClasses();
		int? SaveClass(Class aClass);
		bool DeleteClass(int classId);

		IQueryable<Track> GetAllTracks();

		IQueryable<RegisteredStudent> GetAllRegisteredStudents();
		int? SaveRegisteredStudent(RegisteredStudent registeredStudent);
		bool DeleteRegisteredStudent(int registeredStudentId);

		IQueryable<Stage> GetAllStages();

		bool IsStudentInSemester(int studentId, int semesterId);

		IQueryable<Country> GetAllCountries();

		IQueryable<AdmissionInterview> GetAllAdmissionInterviews();
		int? SaveAddmissionInterview(AdmissionInterview interview, int? studentId = null);

		IQueryable<Exam> GetAllExams();

		IQueryable<ExternalSupervisor> GetAllExternalSupervisors();
		IQueryable<ExamType> GetAllExamTypes();
		IQueryable<ExamGrade> GetAllExamGrades();

		int? SaveExam(Exam exam);

        int? SaveDisciplinaryActivity(DisciplinaryActivityLog disciplinaryActivity);
        IQueryable<DisciplinaryActivityLog> GetStudentDisciplinaryActivities();
	}
}
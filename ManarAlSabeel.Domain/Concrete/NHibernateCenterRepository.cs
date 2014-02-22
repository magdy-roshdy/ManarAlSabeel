﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManarAlSabeel.Domain.Abstract;
using NHibernate;
using ManarAlSabeel.Domain.Entities;
using NHibernate.Linq;
using System.Web;

namespace ManarAlSabeel.Domain.Concrete
{
	public class NHibernateCenterRepository : ICenterRepository
	{
		private IDataBaseFiltersProvider filtersProvider;
		public NHibernateCenterRepository(IDataBaseFiltersProvider filtersProvider)
		{
			this.filtersProvider = filtersProvider;
		}

		public ISessionFactory SessionFactory
		{
			set;
			private get;
		}

		private ISession Session
		{
			get
			{
				ISession Session = SessionFactory.OpenSession();

				//sex filter
				int? sexFilter = filtersProvider.GetSexFilter();
				if (sexFilter.HasValue)
				{
					Session.EnableFilter("sexFilter").SetParameter("sex", sexFilter.Value);
				}
				else
				{
					Session.DisableFilter("sexFilter");
				}

				//branch filter
				Branch branchFilter = filtersProvider.GetBranchFilter();
				if (branchFilter != null)
				{
					Session.EnableFilter("branchFilter").SetParameter("branch", branchFilter.ID);
				}
				else
				{
					Session.DisableFilter("branchFilter");
				}

				return Session;
			}
		}

		public IQueryable<StudentGuardian> GetAllStudentGuardians()
		{
			var guardians = (from guardian
			in Session.Query<StudentGuardian>()
							 select guardian);

			return guardians;
		}

		public IQueryable<Student> GetAllStudents()
		{
			var students = (from student
			in Session.Query<Student>()
						select student);

			return students;
		}

		public int? SaveStudent(Student student)
		{
			int? new_id = null;
			if (student.ID > 0) //edit
			{
				new_id = student.ID;
				using (ISession session = Session)
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						Student db_student = session.Get<Student>(student.ID);
						
						if (student.AcquiredNationality.ID > 0)
						{
							db_student.AcquiredNationality = session.Get<Country>(student.AcquiredNationality.ID);
						}
						else
						{
							db_student.AcquiredNationality = null;
						}

						db_student.BirthDate = student.BirthDate;
						db_student.Branch = session.Get<Branch>(student.Branch.ID);
						db_student.EducationStage = student.EducationStage;
						db_student.ExpectedQuraanFinishTime = student.ExpectedQuraanFinishTime;
						db_student.Guardian = session.Get<StudentGuardian>(student.Guardian.ID);
						db_student.HowKnewTheCenter = student.HowKnewTheCenter;
						db_student.IsInTransportations = student.IsInTransportations;
						db_student.LastEducationDegree = student.LastEducationDegree;
						db_student.Name = student.Name;
						db_student.OriginalNationality = session.Get<Country>(student.OriginalNationality.ID);
						db_student.SchoolClass = student.SchoolClass;
						db_student.SchoolName = student.SchoolName;
						db_student.Sex = student.Sex;
						db_student.Status = student.Status;

						session.SaveOrUpdate(db_student);
						transaction.Commit();

						session.Flush();
					}
				}
			}
			else //new
			{
				using (ISession session = Session)
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						student.Branch = session.Get<Branch>(student.Branch.ID);
						student.Guardian = session.Get<StudentGuardian>(student.Guardian.ID);
						student.OriginalNationality = session.Get<Country>(student.OriginalNationality.ID);
						student.AddedOn = DateTime.Now;

						if(student.AcquiredNationality.ID > 0)
						{
							student.AcquiredNationality = session.Get<Country>(student.AcquiredNationality.ID);
						}
						else
						{
							student.AcquiredNationality = null;
						}

						session.Save(student);
						transaction.Commit();

						session.Flush();

						new_id = student.ID;
					}
				}
			}

			return new_id;
		}

		public int? SaveStudentGuardian(StudentGuardian studentGuardian)
		{
			int? new_id = null;
			if (studentGuardian.ID > 0) //edit
			{
				new_id = studentGuardian.ID;
				using (ISession session = Session)
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						StudentGuardian db_studentGuardian = session.Get<StudentGuardian>(studentGuardian.ID);

						db_studentGuardian.Name = studentGuardian.Name;
						db_studentGuardian.HomeAddress = studentGuardian.HomeAddress;
						db_studentGuardian.HomePhone = studentGuardian.HomePhone;
						db_studentGuardian.MobilePhone = studentGuardian.MobilePhone;
						db_studentGuardian.OtherPhone = studentGuardian.OtherPhone;
						db_studentGuardian.Sex = studentGuardian.Sex;
						db_studentGuardian.Email = studentGuardian.Email;

						db_studentGuardian.Branch = session.Get<Branch>(studentGuardian.Branch.ID);

						session.SaveOrUpdate(db_studentGuardian);
						transaction.Commit();

						session.Flush();
					}
				}
			}
			else //new
			{
				using (ISession session = Session)
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						studentGuardian.Branch = session.Get<Branch>(studentGuardian.Branch.ID);

						session.Save(studentGuardian);
						transaction.Commit();
						session.Flush();

						new_id = studentGuardian.ID;
					}
				}
			}

			return new_id;
		}

		public bool DeleteStudent(int studentId)
		{
			using (ISession session = Session)
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					Student db_student = session.Get<Student>(studentId);
					if(db_student != null)
					{
						session.Delete(db_student);
						transaction.Commit();
						session.Flush();

						return true;
					}
				}
			}

			return false;
		}

		public bool DeleteStudentGuardian(int studentGuardianId)
		{
			using (ISession session = Session)
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					StudentGuardian db_studentGuardian = session.Get<StudentGuardian>(studentGuardianId);
					if (db_studentGuardian != null)
					{
						session.Delete(db_studentGuardian);
						transaction.Commit();
						session.Flush();

						return true;
					}
				}
			}

			return false;
		}

		public IQueryable<Country> GetAllCountries()
		{
			var countries = (from country
			in Session.Query<Country>()
							select country);

			return countries;
		}


		public IQueryable<Teacher> GetAllTeachers()
		{
			var teachers = (from teacher
			in Session.Query<Teacher>()
							select teacher);

			return teachers;
		}


		public int? SaveTeacher(Teacher teacher)
		{
			int? new_id = null;
			if (teacher.ID > 0) //edit
			{
				new_id = teacher.ID;
				using (ISession session = Session)
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						Teacher db_teacher = session.Get<Teacher>(teacher.ID);

						db_teacher.Branch = session.Get<Branch>(teacher.Branch.ID);
						db_teacher.Name = teacher.Name;
						db_teacher.Nationality = session.Get<Country>(teacher.Nationality.ID);
						db_teacher.BirthDate = teacher.BirthDate;
						db_teacher.BirthPlace = session.Get<Country>(teacher.BirthPlace.ID);
						db_teacher.MaritalStatus = teacher.MaritalStatus;
						db_teacher.MarriageDate = teacher.MarriageDate;
						db_teacher.Profession = teacher.Profession;
						db_teacher.MobileNumber = teacher.MobileNumber;
						db_teacher.HomeNumber = teacher.HomeNumber;
						db_teacher.ReligiousIdeology = teacher.ReligiousIdeology;
						db_teacher.Email = teacher.Email;
						db_teacher.AmountOfMemorization = teacher.AmountOfMemorization;
						db_teacher.Status = teacher.Status;
						db_teacher.IsSupervisor = teacher.IsSupervisor;

						session.SaveOrUpdate(db_teacher);
						transaction.Commit();

						session.Flush();
					}
				}
			}
			else //new
			{
				using (ISession session = Session)
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						teacher.Branch = session.Get<Branch>(teacher.Branch.ID);
						teacher.Nationality = session.Get<Country>(teacher.Nationality.ID);
						teacher.BirthPlace = session.Get<Country>(teacher.BirthPlace.ID);

						session.Save(teacher);
						transaction.Commit();

						session.Flush();

						new_id = teacher.ID;
					}
				}
			}

			return new_id;
		}


		public bool DeleteTeacher(int teacherId)
		{
			using (ISession session = Session)
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					Teacher db_teacher = session.Get<Teacher>(teacherId);
					if (db_teacher != null)
					{
						session.Delete(db_teacher);
						transaction.Commit();
						session.Flush();

						return true;
					}
				}
			}

			return false;
		}
	}
}

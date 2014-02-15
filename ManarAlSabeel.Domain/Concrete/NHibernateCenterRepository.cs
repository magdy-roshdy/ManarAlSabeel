using System;
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

		public void TEMP()
		{
			//TEMP
			using (ISession session = Session)
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					Student student = new Student();
					student.Name = "student1";
					student.Sex = Sex.Male;
					student.BirthDate = new DateTime(1990, 1, 1);
					student.IsInTransportations = true;
					student.Staus = StudentStatus.Active;

					Int64 id = 2;
					student.Guardian = session.Get<StudentGuardian>(id);
					student.Branch = session.Get<Branch>(1);
					student.OriginalNationality = session.Get<Country>(1);


					session.SaveOrUpdate(student);
					transaction.Commit();
					session.Flush();
				}
			}
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
						db_student.Staus = student.Staus;

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
	}
}

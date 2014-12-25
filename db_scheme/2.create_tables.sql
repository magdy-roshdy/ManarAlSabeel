SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Countries]    Script Date: 2/10/2014 2:20:01 PM ******/
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Managers]    Script Date: 2/10/2014 2:20:29 PM ******/
CREATE TABLE [dbo].[Managers](
	[ManagerID] [int] IDENTITY(1,1) NOT NULL,
	[ManagerName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Centers]    Script Date: 2/10/2014 2:21:18 PM ******/
CREATE TABLE [dbo].[Centers](
	[CenterID] [int] IDENTITY(1,1) NOT NULL,
	[CenterManagerID] [int] NOT NULL,
	[CenterName] [nvarchar](100)  COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_Center] PRIMARY KEY CLUSTERED 
(
	[CenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Branches]    Script Date: 2/10/2014 2:22:39 PM ******/
CREATE TABLE [dbo].[Branches](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchManagerID] [int] NOT NULL,
	[BranchCenterID] [int] NOT NULL,
	[BranchName] [nvarchar](50)  COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SystemAdmins]    Script Date: 2/24/2014 5:36:10 PM ******/
CREATE TABLE [dbo].[SystemAdmins](
	[SystemAdminID] [int] IDENTITY(1,1) NOT NULL,
	[SystemAdminEmail] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[SystemAdminPassword] [nvarchar](150) COLLATE Arabic_CI_AS NOT NULL,
	[SystemAdminIsActive] [bit] NOT NULL,
	[SystemAdminIsSuperAdmin] [bit] NOT NULL,
	[SystemAdminLoginPersonType] [tinyint] NOT NULL,
	[SystemAdminBranchID] [int] NULL,
	[SystemAdminSexToManage] [tinyint] NULL,
	[SystemAdminLastLogin] [datetime] NULL,
 CONSTRAINT [PK_SystemAdmins] PRIMARY KEY CLUSTERED 
(
	[SystemAdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SystemAdmins] ADD  CONSTRAINT [DF_SystemAdmins_SystemAdminIsActive]  DEFAULT ((0)) FOR [SystemAdminIsActive]
GO

ALTER TABLE [dbo].[SystemAdmins] ADD  CONSTRAINT [DF_SystemAdmins_SystemAdminIsSuperAdmin]  DEFAULT ((0)) FOR [SystemAdminIsSuperAdmin]
GO

/****** Object:  Table [dbo].[Teachers]    Script Date: 2/10/2014 2:24:08 PM ******/
CREATE TABLE [dbo].[Teachers](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherBranchID] [int] NOT NULL,
	[TeacherName] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[TeacherNationality] [int] NOT NULL,
	[TeacherBirthDate] [date] NOT NULL,
	[TeacherBirthPlace] [int] NOT NULL,
	[TeacherMaritalStatus] [tinyint] NOT NULL,
	[TeacherMarriageDate] [date] NULL,
	[TeacherProfission] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
	[TeacherReligiousIdeology] [tinyint] NULL,
	[TeacherMobile] [nvarchar](15) COLLATE Arabic_CI_AS NOT NULL,
	[TeacherHomeNumber] [nvarchar](15) COLLATE Arabic_CI_AS NULL,
	[TeacherEmail] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
	[TeacherMemorizedQuraanAmount] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[TeacherIsSupervisor] [bit] NOT NULL,
	[TeacherSex] [tinyint] NOT NULL,
	[TeacherStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [DF_Teacher_TeacherIsSupervisor]  DEFAULT ((0)) FOR [TeacherIsSupervisor]
GO

ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [DF_Teachers_TeacherStatus]  DEFAULT ((0)) FOR [TeacherStatus]
GO


/****** Object:  Table [dbo].[Classes]    Script Date: 2/10/2014 2:25:38 PM ******/
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassSemesterID] [int] NOT NULL,
	[ClassBranchID] [int] NOT NULL,
	[ClassTeacherID] [int] NOT NULL,
	[ClassName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[ClassTeachingPeriod] [tinyint] NOT NULL,
	[ClassSex] [tinyint] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Classes] ADD  CONSTRAINT [DF_Class_ClassSex]  DEFAULT ((1)) FOR [ClassSex]
GO

/****** Object:  Table [dbo].[Tracks]    Script Date: 2/10/2014 2:26:40 PM ******/
CREATE TABLE [dbo].[Tracks](
	[TrackID] [int] IDENTITY(1,1) NOT NULL,
	[TrackBranchID] [int] NOT NULL,
	[TrackName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[TrackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[BehaviorLevels]    Script Date: 2/10/2014 2:27:21 PM ******/
CREATE TABLE [dbo].[BehaviorLevels](
	[BehaviorLevelID] [int] IDENTITY(1,1) NOT NULL,
	[BehaviorLevelName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[BehaviorLevelOrder] [tinyint] NOT NULL,
 CONSTRAINT [PK_BehaviorLevel] PRIMARY KEY CLUSTERED 
(
	[BehaviorLevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Semesters]    Script Date: 2/10/2014 2:27:50 PM ******/
CREATE TABLE [dbo].[Semesters](
	[SemesterID] [int] IDENTITY(1,1) NOT NULL,
	[SemesterBranchID] [int] NOT NULL,
	[SemesterName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[SemesterStartDate] [date] NOT NULL,
	[SemesterEndDate] [date] NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[SemesterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ExamGradeTypes]    Script Date: 2/10/2014 2:29:46 PM ******/
CREATE TABLE [dbo].[ExamGradeTypes](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[GradeName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[GradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ExamTypes]    Script Date: 2/10/2014 2:30:08 PM ******/

CREATE TABLE [dbo].[ExamTypes](
	[ExamTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[ExamTypeName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_ExamType] PRIMARY KEY CLUSTERED 
(
	[ExamTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ExternalSupervisors]    Script Date: 2/10/2014 2:30:31 PM ******/
CREATE TABLE [dbo].[ExternalSupervisors](
	[ExternalSupervisorID] [int] IDENTITY(1,1) NOT NULL,
	[ExternalSupervisorName] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[ExternalSupervisorSex] [tinyint] NOT NULL,
 CONSTRAINT [PK_ExternalSupervisor] PRIMARY KEY CLUSTERED 
(
	[ExternalSupervisorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProgressAxes]    Script Date: 2/10/2014 2:30:52 PM ******/
CREATE TABLE [dbo].[ProgressAxes](
	[ProgressAxisID] [int] IDENTITY(1,1) NOT NULL,
	[ProgressAxisName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[ProgressAxisTrackID] [int] NOT NULL,
 CONSTRAINT [PK_ProgressAxis] PRIMARY KEY CLUSTERED 
(
	[ProgressAxisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[LearningProgressUnits]    Script Date: 2/10/2014 2:31:35 PM ******/
CREATE TABLE [dbo].[LearningProgressUnits](
	[LearningProgressUnitID] [int] IDENTITY(1,1) NOT NULL,
	[LearningProgressUnitName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[LearningProgressUnitTrackID] [int] NOT NULL,
	[LearningProgressUnitHasSubUnits] [bit] NOT NULL,
	[LearningProgressUnitSubUnitsCount] [int] NULL,
 CONSTRAINT [PK_LearningProgressUnit] PRIMARY KEY CLUSTERED 
(
	[LearningProgressUnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LearningProgressUnits] ADD  CONSTRAINT [DF_LearningProgressUnit_LearningProgressUnitHasSubUnits]  DEFAULT ((0)) FOR [LearningProgressUnitHasSubUnits]
GO

ALTER TABLE [dbo].[LearningProgressUnits] ADD  CONSTRAINT [DF_LearningProgressUnit_LearningProgressUnitSubUnitsCount]  DEFAULT ((0)) FOR [LearningProgressUnitSubUnitsCount]
GO

/****** Object:  Table [dbo].[LearningProgressSubUnits]    Script Date: 2/10/2014 2:32:21 PM ******/
CREATE TABLE [dbo].[LearningProgressSubUnits](
	[LearningProgressSubUnitID] [int] IDENTITY(1,1) NOT NULL,
	[LearningProgressSubUnitName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[ProgressSubUnitParentUnitID] [int] NOT NULL,
 CONSTRAINT [PK_LearningProgressSubUnit] PRIMARY KEY CLUSTERED 
(
	[LearningProgressSubUnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Stages]    Script Date: 2/10/2014 2:33:05 PM ******/
CREATE TABLE [dbo].[Stages](
	[StageID] [int] IDENTITY(1,1) NOT NULL,
	[StageTrackID] [int] NOT NULL,
	[StageName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[LevelsCount] [tinyint] NOT NULL,
 CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED 
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[StudentGuardians]    Script Date: 2/10/2014 2:33:49 PM ******/
CREATE TABLE [dbo].[StudentGuardians](
	[GuardianID] [int] IDENTITY(1,1) NOT NULL,
	[GuardianBranchID] [int] NOT NULL,
	[GuardianName] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[GuardianHomePhone] [nvarchar](15) COLLATE Arabic_CI_AS NULL,
	[GuardianMobilePhone] [nvarchar](15) COLLATE Arabic_CI_AS NOT NULL,
	[GuardianOtherPhone] [nvarchar](15) COLLATE Arabic_CI_AS NULL,
	[GuardianHomeAddress] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
	[GuardianEmailAddress] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
	[GuardianSex] [tinyint] NOT NULL,
 CONSTRAINT [PK_Guardian] PRIMARY KEY CLUSTERED 
(
	[GuardianID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Students]    Script Date: 2/10/2014 2:34:11 PM ******/
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentGuardianID] [int] NOT NULL,
	[StudentBranchID] [int] NOT NULL,
	[StudentName] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[StudentBirthDate] [date] NOT NULL,
	[StudentPersonalPhotoPath] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[StudentOriginNationality] [int] NOT NULL,
	[StudentAcquiredNationality] [int] NULL,
	[StudentSchoolName] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
	[StudentLastEducationDegree] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
	[StudentEducationStage] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[StudentSchoolClass] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[StudentHowYouKnewTheCenter] [int] NULL,
	[StudentExpectedQuraanFinishTime] [int] NULL,
	[StudentIsInTransportations] [bit] NOT NULL,
	[StudentSex] [tinyint] NOT NULL,
	[StudentStatus] [tinyint] NOT NULL,
	[StudentAddedOn] [datetime] NOT NULL,
	[AdmissionInterviewID] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Student_StudentRegisteredIntransportation]  DEFAULT ((0)) FOR [StudentIsInTransportations]
GO

ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Student_StudentSex]  DEFAULT ((1)) FOR [StudentSex]
GO

ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [DF_Student_StudentStatus]  DEFAULT ((1)) FOR [StudentStatus]
GO

/****** Object:  Table [dbo].[RegisteredStudents]    Script Date: 2/10/2014 2:35:10 PM ******/
CREATE TABLE [dbo].[RegisteredStudents](
	[RegisteredStudentID] [int] IDENTITY(1,1) NOT NULL,
	[RegisteredStudentsStudentID] [int] NOT NULL,
	[RegisteredStudentsClassID] [int] NOT NULL,
	[RegisteredStudentsStageID] [int] NOT NULL,
	[RegisteredStudentsBranchID] [int] NOT NULL,
	[RegisteredStudentsSex] [tinyint] NOT NULL,
	[RegisteredStudentsDate] [date] NOT NULL,
	[RegisteredStudentsComments] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_SemesterRegistration] PRIMARY KEY CLUSTERED 
(
	[RegisteredStudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[AdmissionInterviews]    Script Date: 2/10/2014 2:36:00 PM ******/
CREATE TABLE [dbo].[AdmissionInterviews](
	[InterviewID] [int] IDENTITY(1,1) NOT NULL,
	[InterviewDate] [datetime] NOT NULL,
	[InterviewMemorizationAmount] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[InterviewResult] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[InterviewNotes] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Interview] PRIMARY KEY CLUSTERED 
(
	[InterviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[DisciplinaryActivitiesLog]    Script Date: 2/10/2014 2:36:54 PM ******/

CREATE TABLE [dbo].[DisciplinaryActivitiesLog](
	[DisciplinaryActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityRegisteredStudentID] [int] NOT NULL,
	[DisciplinaryActivityDate] [date] NOT NULL,
	[DisciplinaryActivityReason] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[DisciplinaryActivityDetails] [nvarchar](250) COLLATE Arabic_CI_AS NOT NULL,
	[DisciplinaryActivityComments] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_DisciplinaryExercise] PRIMARY KEY CLUSTERED 
(
	[DisciplinaryActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Exams]    Script Date: 2/10/2014 2:37:38 PM ******/
CREATE TABLE [dbo].[Exams](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[ExamRegisteredStudentID] [int] NOT NULL,
	[ExamTypeID] [tinyint] NOT NULL,
	[ExamSupervisorID] [int] NOT NULL,
	[ExamExternalSupervisorID] [int] NULL,
	[ExamGradeID] [int] NOT NULL,
	[ExamDate] [datetime] NOT NULL,
	[ExamBonusPoints] [tinyint] NOT NULL,
	[ExamComments] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Exams] ADD  CONSTRAINT [DF_Exam_ExamBonusPoints]  DEFAULT ((0)) FOR [ExamBonusPoints]
GO

/****** Object:  Table [dbo].[InterviewCommittee]    Script Date: 2/10/2014 2:38:32 PM ******/
CREATE TABLE [dbo].[InterviewCommittee](
	[InterviewID] [bigint] NOT NULL,
	[InterviewAttendeeID] [int] NOT NULL,
 CONSTRAINT [PK_InterviewCommittee] PRIMARY KEY CLUSTERED 
(
	[InterviewID] ASC,
	[InterviewAttendeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[LearningProgressLogs]    Script Date: 2/10/2014 2:39:17 PM ******/
CREATE TABLE [dbo].[LearningProgressLogs](
	[LearningProgressLogID] [int] IDENTITY(1,1) NOT NULL,
	[LearningProgressLogExamID] [int] NOT NULL,
	[LearningProgressLogAxesID] [int] NOT NULL,
	[LearningProgressComments] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_LearningProgressLog] PRIMARY KEY CLUSTERED 
(
	[LearningProgressLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[LearningProgressMarks]    Script Date: 2/10/2014 2:40:02 PM ******/
CREATE TABLE [dbo].[LearningProgressMarks](
	[LearningProgressMarkID] [int] IDENTITY(1,1) NOT NULL,
	[LearningProgressMarkProgressLogID] [int] NOT NULL,
	[LearningProgressMarkUnitID] [int] NOT NULL,
	[LearningProgressMarkSubUnitNumber] [int] NULL,
	[LearningProgressMarkType] [tinyint] NOT NULL,
 CONSTRAINT [PK_LearningProgressMark] PRIMARY KEY CLUSTERED 
(
	[LearningProgressMarkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[StudentAbsenceLogs]    Script Date: 2/10/2014 2:41:00 PM ******/
CREATE TABLE [dbo].[StudentAbsenceLogs](
	[StudentAbsenceLogID] [int] IDENTITY(1,1) NOT NULL,
	[AbsenceRegisteredStudentID] [int] NOT NULL,
	[StudentAbsenceLogDate] [datetime] NOT NULL,
	[StudentAbsenceLoggedByID] [int] NOT NULL,
	[StudentAbsenceLogIsHasExcuse] [bit] NOT NULL,
	[StudentAbsenceLogExcuseDetails] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_StudentAbsenceLog] PRIMARY KEY CLUSTERED 
(
	[StudentAbsenceLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[StudentAbsenceLogs] ADD  CONSTRAINT [DF_Table_1_StudentAbsenceLogHasExcuse]  DEFAULT ((0)) FOR [StudentAbsenceLogIsHasExcuse]
GO

/****** Object:  Table [dbo].[StudentBehaviorEvaluations]    Script Date: 2/10/2014 2:41:33 PM ******/
CREATE TABLE [dbo].[StudentBehaviorEvaluations](
	[BehaviorEvaluationLogID] [int] IDENTITY(1,1) NOT NULL,
	[BehaviorEvaluationExamID] [int] NOT NULL,
	[BehaviorEvaluationLevelID] [int] NOT NULL,
	[BehaviorEvaluationComments] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_BehaviorEvaluation] PRIMARY KEY CLUSTERED 
(
	[BehaviorEvaluationLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[StudentCertificateTypes]    Script Date: 2/10/2014 2:42:23 PM ******/
CREATE TABLE [dbo].[StudentCertificateTypes](
	[CertificateTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[CertificateTypeName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_CertificateType] PRIMARY KEY CLUSTERED 
(
	[CertificateTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[StudentCertificates]    Script Date: 2/10/2014 2:42:39 PM ******/
CREATE TABLE [dbo].[StudentCertificates](
	[StudentCertificateID] [int] IDENTITY(1,1) NOT NULL,
	[CertificateRegisteredStudentID] [int] NOT NULL,
	[StudentCertificateDate] [date] NOT NULL,
	[StudentCertificateType] [tinyint] NOT NULL,
 CONSTRAINT [PK_StudentCertificate] PRIMARY KEY CLUSTERED 
(
	[StudentCertificateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[StudentDocumentTypes]    Script Date: 2/10/2014 2:43:17 PM ******/
CREATE TABLE [dbo].[StudentDocumentTypes](
	[DocumentTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[DocumentTypeName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[StudentDocuments]    Script Date: 2/10/2014 2:43:37 PM ******/
CREATE TABLE [dbo].[StudentDocuments](
	[StudentDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentStudentID] [int] NOT NULL,
	[StudentDocumentName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[StudentDocumentFilePath] [nvarchar](300) COLLATE Arabic_CI_AS NOT NULL,
	[StudentDocumentType] [tinyint] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[StudentDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[StudentExpelLogs]    Script Date: 2/10/2014 2:44:15 PM ******/
CREATE TABLE [dbo].[StudentExpelLogs](
	[StudentExpelLogID] [int] IDENTITY(1,1) NOT NULL,
	[ExpelRegisteredStudentID] [int] NOT NULL,
	[StudentExpelDate] [date] NOT NULL,
	[StudentExpelReason] [nvarchar](150) COLLATE Arabic_CI_AS NOT NULL,
	[StudentExpelComments] [nvarchar](250) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_StudentExpelLog] PRIMARY KEY CLUSTERED 
(
	[StudentExpelLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[StudentStageChangeLogs]    Script Date: 2/10/2014 2:44:53 PM ******/
CREATE TABLE [dbo].[StudentStageChangeLogs](
	[StudentStageChangeLogID] [int] IDENTITY(1,1) NOT NULL,
	[StagesLogRegisteredStudentID] [int] NOT NULL,
	[StagesLogExamID] [int] NULL,
	[StudentStagesLogStageID] [int] NOT NULL,
	[StudentStagesLogStageLevel] [int] NOT NULL,
	[StudentStagesLogChangeDate] [date] NOT NULL,
	[StudentStagesLogComments] [nvarchar](350) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_StudentStageChangeLog] PRIMARY KEY CLUSTERED 
(
	[StudentStageChangeLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TeacherAbsenceLogs]    Script Date: 2/10/2014 2:45:43 PM ******/
CREATE TABLE [dbo].[TeacherAbsenceLogs](
	[TeacherAbsenceLogID] [int] IDENTITY(1,1) NOT NULL,
	[AbsenceLogTeacherID] [int] NOT NULL,
	[TeacherAbsenceLogDate] [date] NOT NULL,
	[AbsenceLogIsHasAnexcuse] [bit] NOT NULL,
	[AbsenceLogExcuseDetails] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_TeacherAbsenceLog] PRIMARY KEY CLUSTERED 
(
	[TeacherAbsenceLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TeacherAbsenceLogs] ADD  CONSTRAINT [DF_TeacherAbsenceLog_AbsenceLogIsHasAnexcuse]  DEFAULT ((0)) FOR [AbsenceLogIsHasAnexcuse]
GO
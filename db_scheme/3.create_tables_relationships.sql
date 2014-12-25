
/*****************************/
/*** Table [dbo].[Centers] ***/
/*****************************/

ALTER TABLE [dbo].[Centers]  WITH CHECK ADD  CONSTRAINT [FK_Managers_Centers] FOREIGN KEY([CenterManagerID])
REFERENCES [dbo].[Managers] ([ManagerID])
GO

ALTER TABLE [dbo].[Centers] CHECK CONSTRAINT [FK_Managers_Centers]
GO

/*****************************/
/*** Table [dbo].[Branches] ***/
/*****************************/
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Centers_Branches] FOREIGN KEY([BranchCenterID])
REFERENCES [dbo].[Centers] ([CenterID])
GO

ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_Centers_Branches]
GO

ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_Managers_Branches] FOREIGN KEY([BranchManagerID])
REFERENCES [dbo].[Managers] ([ManagerID])
GO

ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_Managers_Branches]
GO

/*****************************/
/*** Table [dbo].[StudentGuardians] ***/
/*****************************/
ALTER TABLE [dbo].[StudentGuardians]  WITH CHECK ADD  CONSTRAINT [FK_Branches_StudentGuardians] FOREIGN KEY([GuardianBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[StudentGuardians] CHECK CONSTRAINT [FK_Branches_StudentGuardians]
GO

/*****************************/
/*** Table [dbo].[SystemAdmins] ***/
/*****************************/
ALTER TABLE [dbo].[SystemAdmins]  WITH CHECK ADD  CONSTRAINT [FK_Branches_SystemAdmins] FOREIGN KEY([SystemAdminBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[SystemAdmins] CHECK CONSTRAINT [FK_Branches_SystemAdmins]
GO

/*****************************/
/*** Table [dbo].[Teachers] ***/
/*****************************/

ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Teachers] FOREIGN KEY([TeacherBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Branches_Teachers]
GO

ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Teachers] FOREIGN KEY([TeacherNationality])
REFERENCES [dbo].[Countries] ([CountryID])
GO

ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Countries_Teachers]
GO

ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Teachers_BirthPlace] FOREIGN KEY([TeacherBirthPlace])
REFERENCES [dbo].[Countries] ([CountryID])
GO

ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Countries_Teachers_BirthPlace]
GO

/*****************************/
/*** Table [dbo].[Classes] ***/
/*****************************/
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Classes] FOREIGN KEY([ClassBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Branches_Classes]
GO

ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Semesters_Classes] FOREIGN KEY([ClassSemesterID])
REFERENCES [dbo].[Semesters] ([SemesterID])
GO

ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Semesters_Classes]
GO

ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Classes] FOREIGN KEY([ClassTeacherID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO

ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Teachers_Classes]
GO

/*****************************/
/*** Table [dbo].[Tracks] ***/
/*****************************/
ALTER TABLE [dbo].[Tracks]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Tracks] FOREIGN KEY([TrackBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[Tracks] CHECK CONSTRAINT [FK_Branches_Tracks]
GO

/*****************************/
/*** Table [dbo].[Semesters] ***/
/*****************************/
ALTER TABLE [dbo].[Semesters]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Semesters] FOREIGN KEY([SemesterBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[Semesters] CHECK CONSTRAINT [FK_Branches_Semesters]
GO

/*****************************/
/*** Table [dbo].[ProgressAxes] ***/
/*****************************/
ALTER TABLE [dbo].[ProgressAxes]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_ProgressAxes] FOREIGN KEY([ProgressAxisTrackID])
REFERENCES [dbo].[Tracks] ([TrackID])
GO

ALTER TABLE [dbo].[ProgressAxes] CHECK CONSTRAINT [FK_Tracks_ProgressAxes]
GO

/*****************************/
/*** Table [dbo].[LearningProgressUnits] ***/
/*****************************/
ALTER TABLE [dbo].[LearningProgressUnits]  WITH CHECK ADD  CONSTRAINT [FK_Tracks_LearningProgressUnits] FOREIGN KEY([LearningProgressUnitTrackID])
REFERENCES [dbo].[Tracks] ([TrackID])
GO

ALTER TABLE [dbo].[LearningProgressUnits] CHECK CONSTRAINT [FK_Tracks_LearningProgressUnits]
GO

/*****************************/
/*** Table [dbo].[LearningProgressSubUnits] ***/
/*****************************/
ALTER TABLE [dbo].[LearningProgressSubUnits]  WITH CHECK ADD  CONSTRAINT [FK_LearningProgressUnits_LearningProgressSubUnits] FOREIGN KEY([ProgressSubUnitParentUnitID])
REFERENCES [dbo].[LearningProgressUnits] ([LearningProgressUnitID])
GO

ALTER TABLE [dbo].[LearningProgressSubUnits] CHECK CONSTRAINT [FK_LearningProgressUnits_LearningProgressSubUnits]
GO

/*****************************/
/*** Table [dbo].[Stages] ***/
/*****************************/
ALTER TABLE [dbo].[Stages]  WITH CHECK ADD  CONSTRAINT [FK_Stages_Tracks] FOREIGN KEY([StageTrackID])
REFERENCES [dbo].[Tracks] ([TrackID])
GO

ALTER TABLE [dbo].[Stages] CHECK CONSTRAINT [FK_Stages_Tracks]
GO

/*****************************/
/*** Table [dbo].[Students] ***/
/*****************************/
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK__Countries_Students] FOREIGN KEY([StudentOriginNationality])
REFERENCES [dbo].[Countries] ([CountryID])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK__Countries_Students]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK__Countries_Students_2] FOREIGN KEY([StudentAcquiredNationality])
REFERENCES [dbo].[Countries] ([CountryID])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK__Countries_Students_2]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Branches_Students] FOREIGN KEY([StudentBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Branches_Students]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_StudentGuardians_Students] FOREIGN KEY([StudentGuardianID])
REFERENCES [dbo].[StudentGuardians] ([GuardianID])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_StudentGuardians_Students]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD CONSTRAINT [FK_AdmissionInterviews_Students] FOREIGN KEY([AdmissionInterviewID])
REFERENCES [dbo].[AdmissionInterviews] (InterviewID)
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_AdmissionInterviews_Students]
GO

/*****************************/
/*** Table [dbo].[RegisteredStudents] ***/
/*****************************/
ALTER TABLE [dbo].[RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_Classes_RegisteredStudents] FOREIGN KEY([RegisteredStudentsClassID])
REFERENCES [dbo].[Classes] ([ClassID])
GO

ALTER TABLE [dbo].[RegisteredStudents] CHECK CONSTRAINT [FK_Classes_RegisteredStudents]
GO

ALTER TABLE [dbo].[RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_Students_RegisteredStudents] FOREIGN KEY([RegisteredStudentsStudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO

ALTER TABLE [dbo].[RegisteredStudents] CHECK CONSTRAINT [FK_Students_RegisteredStudents]
GO

ALTER TABLE [dbo].[RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_Stages_RegisteredStudents] FOREIGN KEY([RegisteredStudentsStageID])
REFERENCES [dbo].[Stages] ([StageID])
GO

ALTER TABLE [dbo].[RegisteredStudents] CHECK CONSTRAINT [FK_Stages_RegisteredStudents]
GO

ALTER TABLE [dbo].[RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_Branches_RegisteredStudents] FOREIGN KEY([RegisteredStudentsBranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO

ALTER TABLE [dbo].[RegisteredStudents] CHECK CONSTRAINT [FK_Branches_RegisteredStudents]
GO

/*****************************/
/*** Table [dbo].[DisciplinaryActivitiesLog] ***/
/*****************************/

ALTER TABLE [dbo].[DisciplinaryActivitiesLog]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_DisciplinaryActivitiesLog] FOREIGN KEY([ActivityRegisteredStudentID])
REFERENCES [dbo].[RegisteredStudents] ([RegisteredStudentID])
GO

ALTER TABLE [dbo].[DisciplinaryActivitiesLog] CHECK CONSTRAINT [FK_RegisteredStudents_DisciplinaryActivitiesLog]
GO

/*****************************/
/*** Table [dbo].[Exams] ***/
/*****************************/
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_ExamGradeTypes_Exams] FOREIGN KEY([ExamGradeID])
REFERENCES [dbo].[ExamGradeTypes] ([GradeID])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_ExamGradeTypes_Exams]
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_ExamTypes_Exams] FOREIGN KEY([ExamTypeID])
REFERENCES [dbo].[ExamTypes] ([ExamTypeID])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_ExamTypes_Exams]
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_ExternalSupervisors_Exams] FOREIGN KEY([ExamExternalSupervisorID])
REFERENCES [dbo].[ExternalSupervisors] ([ExternalSupervisorID])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_ExternalSupervisors_Exams]
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_Exams] FOREIGN KEY([ExamRegisteredStudentID])
REFERENCES [dbo].[RegisteredStudents] ([RegisteredStudentID])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_RegisteredStudents_Exams]
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Exams] FOREIGN KEY([ExamSupervisorID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Teachers_Exams]
GO

/*****************************/
/*** Table [dbo].[InterviewCommittee] ***/
/*****************************/
ALTER TABLE [dbo].[InterviewCommittee]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_InterviewCommittee] FOREIGN KEY([InterviewAttendeeID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO

ALTER TABLE [dbo].[InterviewCommittee] CHECK CONSTRAINT [FK_Teachers_InterviewCommittee]
GO

/*****************************/
/*** Table [dbo].[LearningProgressLogs] ***/
/*****************************/
ALTER TABLE [dbo].[LearningProgressLogs]  WITH CHECK ADD  CONSTRAINT [FK_Exams_LearningProgressLogs] FOREIGN KEY([LearningProgressLogExamID])
REFERENCES [dbo].[Exams] ([ExamID])
GO

ALTER TABLE [dbo].[LearningProgressLogs] CHECK CONSTRAINT [FK_Exams_LearningProgressLogs]
GO

ALTER TABLE [dbo].[LearningProgressLogs]  WITH CHECK ADD  CONSTRAINT [FK_ProgressAxes_LearningProgressLogs] FOREIGN KEY([LearningProgressLogAxesID])
REFERENCES [dbo].[ProgressAxes] ([ProgressAxisID])
GO

ALTER TABLE [dbo].[LearningProgressLogs] CHECK CONSTRAINT [FK_ProgressAxes_LearningProgressLogs]
GO

/*****************************/
/*** Table [dbo].[LearningProgressMarks] ***/
/*****************************/
ALTER TABLE [dbo].[LearningProgressMarks]  WITH CHECK ADD  CONSTRAINT [FK_LearningProgressLogs_LearningProgressMarks] FOREIGN KEY([LearningProgressMarkProgressLogID])
REFERENCES [dbo].[LearningProgressLogs] ([LearningProgressLogID])
GO

ALTER TABLE [dbo].[LearningProgressMarks] CHECK CONSTRAINT [FK_LearningProgressLogs_LearningProgressMarks]
GO

ALTER TABLE [dbo].[LearningProgressMarks]  WITH CHECK ADD  CONSTRAINT [FK_LearningProgressUnits_LearningProgressMarks] FOREIGN KEY([LearningProgressMarkUnitID])
REFERENCES [dbo].[LearningProgressUnits] ([LearningProgressUnitID])
GO

ALTER TABLE [dbo].[LearningProgressMarks] CHECK CONSTRAINT [FK_LearningProgressUnits_LearningProgressMarks]
GO

/*****************************/
/*** Table [dbo].[StudentAbsenceLogs] ***/
/*****************************/
ALTER TABLE [dbo].[StudentAbsenceLogs]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_StudentAbsenceLogs] FOREIGN KEY([AbsenceRegisteredStudentID])
REFERENCES [dbo].[RegisteredStudents] ([RegisteredStudentID])
GO

ALTER TABLE [dbo].[StudentAbsenceLogs] CHECK CONSTRAINT [FK_RegisteredStudents_StudentAbsenceLogs]
GO

/*****************************/
/*** Table [dbo].[StudentBehaviorEvaluations] ***/
/*****************************/
ALTER TABLE [dbo].[StudentBehaviorEvaluations]  WITH CHECK ADD  CONSTRAINT [FK_BehaviorLevels_StudentBehaviorEvaluations] FOREIGN KEY([BehaviorEvaluationLevelID])
REFERENCES [dbo].[BehaviorLevels] ([BehaviorLevelID])
GO

ALTER TABLE [dbo].[StudentBehaviorEvaluations] CHECK CONSTRAINT [FK_BehaviorLevels_StudentBehaviorEvaluations]
GO

ALTER TABLE [dbo].[StudentBehaviorEvaluations]  WITH CHECK ADD  CONSTRAINT [FK_Exams_StudentBehaviorEvaluations] FOREIGN KEY([BehaviorEvaluationExamID])
REFERENCES [dbo].[Exams] ([ExamID])
GO

ALTER TABLE [dbo].[StudentBehaviorEvaluations] CHECK CONSTRAINT [FK_Exams_StudentBehaviorEvaluations]
GO

/*****************************/
/*** Table [dbo].[StudentCertificates] ***/
/*****************************/
ALTER TABLE [dbo].[StudentCertificates]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_StudentCertificates] FOREIGN KEY([CertificateRegisteredStudentID])
REFERENCES [dbo].[RegisteredStudents] ([RegisteredStudentID])
GO

ALTER TABLE [dbo].[StudentCertificates] CHECK CONSTRAINT [FK_RegisteredStudents_StudentCertificates]
GO

ALTER TABLE [dbo].[StudentCertificates]  WITH CHECK ADD  CONSTRAINT [FK_StudentCertificateTypes_StudentCertificates] FOREIGN KEY([StudentCertificateType])
REFERENCES [dbo].[StudentCertificateTypes] ([CertificateTypeID])
GO

ALTER TABLE [dbo].[StudentCertificates] CHECK CONSTRAINT [FK_StudentCertificateTypes_StudentCertificates]
GO

/*****************************/
/*** Table [dbo].[StudentDocuments] ***/
/*****************************/
ALTER TABLE [dbo].[StudentDocuments]  WITH CHECK ADD  CONSTRAINT [FK_Students_StudentDocuments] FOREIGN KEY([DocumentStudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO

ALTER TABLE [dbo].[StudentDocuments] CHECK CONSTRAINT [FK_Students_StudentDocuments]
GO


/*****************************/
/*** Table [dbo].[StudentExpelLogs] ***/
/*****************************/
ALTER TABLE [dbo].[StudentExpelLogs]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_StudentExpelLogs] FOREIGN KEY([ExpelRegisteredStudentID])
REFERENCES [dbo].[RegisteredStudents] ([RegisteredStudentID])
GO

ALTER TABLE [dbo].[StudentExpelLogs] CHECK CONSTRAINT [FK_RegisteredStudents_StudentExpelLogs]
GO


/*****************************/
/*** Table [dbo].[StudentStageChangeLogs] ***/
/*****************************/
ALTER TABLE [dbo].[StudentStageChangeLogs]  WITH CHECK ADD  CONSTRAINT [FK_Exams_StudentStageChangeLogs] FOREIGN KEY([StagesLogExamID])
REFERENCES [dbo].[Exams] ([ExamID])
GO

ALTER TABLE [dbo].[StudentStageChangeLogs] CHECK CONSTRAINT [FK_Exams_StudentStageChangeLogs]
GO

ALTER TABLE [dbo].[StudentStageChangeLogs]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_StudentStageChangeLogs] FOREIGN KEY([StagesLogRegisteredStudentID])
REFERENCES [dbo].[RegisteredStudents] ([RegisteredStudentID])
GO

ALTER TABLE [dbo].[StudentStageChangeLogs] CHECK CONSTRAINT [FK_RegisteredStudents_StudentStageChangeLogs]
GO

ALTER TABLE [dbo].[StudentStageChangeLogs]  WITH CHECK ADD  CONSTRAINT [FK_Stages_StudentStageChangeLogs] FOREIGN KEY([StudentStagesLogStageID])
REFERENCES [dbo].[Stages] ([StageID])
GO

ALTER TABLE [dbo].[StudentStageChangeLogs] CHECK CONSTRAINT [FK_Stages_StudentStageChangeLogs]
GO

/*****************************/
/*** Table [dbo].[TeacherAbsenceLogs] ***/
/*****************************/
ALTER TABLE [dbo].[TeacherAbsenceLogs]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_TeacherAbsenceLogs] FOREIGN KEY([AbsenceLogTeacherID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO

ALTER TABLE [dbo].[TeacherAbsenceLogs] CHECK CONSTRAINT [FK_Teachers_TeacherAbsenceLogs]
GO
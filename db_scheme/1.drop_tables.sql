USE [manar_al_sabeel]
GO

--drop repationships
ALTER TABLE [dbo].[Centers] DROP [FK_Managers_Centers]

ALTER TABLE [dbo].[Branches] DROP [FK_Centers_Branches]
ALTER TABLE [dbo].[Branches] DROP [FK_Managers_Branches]

ALTER TABLE [dbo].[StudentGuardians] DROP [FK_Branches_StudentGuardians]

ALTER TABLE [dbo].[RegisteredStudents] DROP [FK_Branches_RegisteredStudents]

ALTER TABLE [dbo].[SystemAdmins] DROP [FK_Branches_SystemAdmins]

ALTER TABLE [dbo].[Teachers] DROP [FK_Branches_Teachers]
ALTER TABLE [dbo].[Teachers] DROP [FK_Countries_Teachers]
ALTER TABLE [dbo].[Teachers] DROP [FK_Countries_Teachers_BirthPlace]

ALTER TABLE [dbo].[Classes] DROP [FK_Branches_Classes]
ALTER TABLE [dbo].[Classes] DROP [FK_Semesters_Classes]
ALTER TABLE [dbo].[Classes] DROP [FK_Teachers_Classes]

ALTER TABLE [dbo].[Tracks] DROP [FK_Branches_Tracks]

ALTER TABLE [dbo].[Semesters] DROP [FK_Branches_Semesters]

ALTER TABLE [dbo].[ProgressAxes] DROP [FK_Tracks_ProgressAxes]

ALTER TABLE [dbo].[LearningProgressUnits] DROP [FK_Tracks_LearningProgressUnits]

ALTER TABLE [dbo].[LearningProgressSubUnits] DROP [FK_LearningProgressUnits_LearningProgressSubUnits]

ALTER TABLE [dbo].[Stages] DROP [FK_Stages_Tracks]

ALTER TABLE [dbo].[Students] DROP [FK__Countries_Students]
ALTER TABLE [dbo].[Students] DROP [FK__Countries_Students_2]
ALTER TABLE [dbo].[Students] DROP [FK_Branches_Students]
ALTER TABLE [dbo].[Students] DROP [FK_StudentGuardians_Students]

ALTER TABLE [dbo].[RegisteredStudents] DROP [FK_Classes_RegisteredStudents]
ALTER TABLE [dbo].[RegisteredStudents] DROP [FK_Students_RegisteredStudents]
ALTER TABLE [dbo].[RegisteredStudents] DROP [FK_Tracks_RegisteredStudents]

ALTER TABLE [dbo].[AdmissionInterviews] DROP [FK_Students_AdmissionInterviews]

ALTER TABLE [dbo].[DisciplinaryActivitiesLog] DROP [FK_RegisteredStudents_DisciplinaryActivitiesLog]

ALTER TABLE [dbo].[Exams] DROP [FK_ExamGradeTypes_Exams]
ALTER TABLE [dbo].[Exams] DROP [FK_ExamTypes_Exams]
ALTER TABLE [dbo].[Exams] DROP [FK_ExternalSupervisors_Exams]
ALTER TABLE [dbo].[Exams] DROP [FK_RegisteredStudents_Exams]
ALTER TABLE [dbo].[Exams] DROP [FK_Teachers_Exams]

ALTER TABLE [dbo].[InterviewCommittee] DROP [FK_Teachers_InterviewCommittee]

ALTER TABLE [dbo].[LearningProgressLogs] DROP [FK_Exams_LearningProgressLogs]
ALTER TABLE [dbo].[LearningProgressLogs] DROP [FK_ProgressAxes_LearningProgressLogs]

ALTER TABLE [dbo].[LearningProgressMarks] DROP [FK_LearningProgressLogs_LearningProgressMarks]
ALTER TABLE [dbo].[LearningProgressMarks] DROP [FK_LearningProgressUnits_LearningProgressMarks]

ALTER TABLE [dbo].[StudentAbsenceLogs] DROP [FK_RegisteredStudents_StudentAbsenceLogs]

ALTER TABLE [dbo].[StudentBehaviorEvaluations] DROP [FK_BehaviorLevels_StudentBehaviorEvaluations]
ALTER TABLE [dbo].[StudentBehaviorEvaluations] DROP [FK_Exams_StudentBehaviorEvaluations]

ALTER TABLE [dbo].[StudentCertificates] DROP [FK_RegisteredStudents_StudentCertificates]
ALTER TABLE [dbo].[StudentCertificates] DROP [FK_StudentCertificateTypes_StudentCertificates]

ALTER TABLE [dbo].[StudentDocuments] DROP [FK_Students_StudentDocuments]

ALTER TABLE [dbo].[StudentExpelLogs] DROP [FK_RegisteredStudents_StudentExpelLogs]

ALTER TABLE [dbo].[StudentStageChangeLogs] DROP [FK_Exams_StudentStageChangeLogs]
ALTER TABLE [dbo].[StudentStageChangeLogs] DROP [FK_RegisteredStudents_StudentStageChangeLogs]
ALTER TABLE [dbo].[StudentStageChangeLogs] DROP [FK_Stages_StudentStageChangeLogs]

ALTER TABLE [dbo].[TeacherAbsenceLogs] DROP [FK_Teachers_TeacherAbsenceLogs]
GO
--tables drop

DROP TABLE [dbo].[TeacherAbsenceLogs]
GO

DROP TABLE [dbo].[StudentStageChangeLogs]
GO

DROP TABLE [dbo].[StudentExpelLogs]
GO

DROP TABLE [dbo].[StudentDocuments]
GO

DROP TABLE [dbo].[StudentDocumentTypes]
GO

DROP TABLE [dbo].[StudentCertificates]
GO

DROP TABLE [dbo].[StudentCertificateTypes]
GO

DROP TABLE [dbo].[StudentBehaviorEvaluations]
GO

DROP TABLE [dbo].[StudentAbsenceLogs]
GO

DROP TABLE [dbo].[LearningProgressMarks]
GO

DROP TABLE [dbo].[Exams]
GO

DROP TABLE [dbo].[LearningProgressLogs]
GO

DROP TABLE [dbo].[InterviewCommittee]
GO

DROP TABLE [dbo].[DisciplinaryActivitiesLog]
GO

DROP TABLE [dbo].[AdmissionInterviews]
GO

DROP TABLE [dbo].[RegisteredStudents]
GO

DROP TABLE [dbo].[Students]
GO

DROP TABLE [dbo].[StudentGuardians]
GO

DROP TABLE [dbo].[Stages]
GO

DROP TABLE [dbo].[LearningProgressSubUnits]
GO

DROP TABLE [dbo].[LearningProgressUnits]
GO

DROP TABLE [dbo].[ProgressAxes]
GO

DROP TABLE [dbo].[ExternalSupervisors]
GO

DROP TABLE [dbo].[ExamTypes]
GO

DROP TABLE [dbo].[ExamGradeTypes]
GO

DROP TABLE [dbo].[Semesters]
GO

DROP TABLE [dbo].[BehaviorLevels]
GO

DROP TABLE [dbo].[Tracks]
GO

DROP TABLE [dbo].[Classes]
GO

DROP TABLE [dbo].[Teachers]
GO

DROP TABLE [dbo].[SystemAdmins]
GO

DROP TABLE [dbo].[Branches]
GO

DROP TABLE [dbo].[Centers]
GO

DROP TABLE [dbo].[Managers]
GO

DROP TABLE [dbo].[Countries]
GO
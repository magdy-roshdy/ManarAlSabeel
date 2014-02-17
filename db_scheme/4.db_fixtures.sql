USE [manar_al_sabeel]
GO

INSERT INTO [dbo].[Countries]
           ([CountryName])
     VALUES
           ('«·«„«—«  «·⁄—»Ì… «·„ Õœ…')

INSERT INTO [dbo].[Countries]
           ([CountryName])
     VALUES
           ('„’—')

INSERT INTO [dbo].[Countries]
           ([CountryName])
     VALUES
           ('”Ê—Ì«')
GO

-------

INSERT INTO [dbo].[Managers]
           ([ManagerName])
     VALUES
           ('œﬂ Ê—. „Õ„œ «·—«‘œÌ')

INSERT INTO [dbo].[Managers]
           ([ManagerName])
     VALUES
           ('œﬂ Ê—. «”„«⁄Ì· ”·Ì„')
GO

---

INSERT INTO [dbo].[Centers]
           ([CenterManagerID]
           ,[CenterName])
     VALUES
           (1
           ,'„—ﬂ“ „‰«— «·”»Ì·')

INSERT INTO [dbo].[Centers]
           ([CenterManagerID]
           ,[CenterName])
     VALUES
           (2
           ,'„—ﬂ“ ⁄Ã„«‰ · Õ›ÌŸ «·ﬁ—¬‰')
GO

---

INSERT INTO [dbo].[Branches]
           ([BranchManagerID]
           ,[BranchCenterID]
           ,[BranchName])
     VALUES
           (1
           ,1
           ,'›—⁄ «·‘«—ﬁ…')

INSERT INTO [dbo].[Branches]
           ([BranchManagerID]
           ,[BranchCenterID]
           ,[BranchName])
     VALUES
           (1
           ,1
           ,'›—⁄ œ»Ì')

INSERT INTO [dbo].[Branches]
           ([BranchManagerID]
           ,[BranchCenterID]
           ,[BranchName])
     VALUES
           (2
           ,2
           ,'›—⁄ ⁄Ã„«‰ «·—∆Ì”Ì')
GO

----

INSERT INTO [dbo].[StudentGuardians]
           ([GuardianName]
		   ,[GuardianBranchID]
           ,[GuardianHomePhone]
           ,[GuardianMobilePhone]
           ,[GuardianOtherPhone]
           ,[GuardianHomeAddress]
           ,[GuardianEmailAddress]
           ,[GuardianSex])
     VALUES
           ('—‘œÌ „Õ„Êœ «·‘Õ« '
		   ,1
           ,'041234567'
           ,'055123456'
           ,null
           ,null
           ,'roshdy@gmail.com'
           ,1)
GO

INSERT INTO [dbo].[StudentGuardians]
           ([GuardianName]
		   ,[GuardianBranchID]
           ,[GuardianHomePhone]
           ,[GuardianMobilePhone]
           ,[GuardianOtherPhone]
           ,[GuardianHomeAddress]
           ,[GuardianEmailAddress]
           ,[GuardianSex])
     VALUES
           ('”«„Ì „Õ„œ ⁄»œ «··Â'
		   ,1
           ,'031122334'
           ,'0551122334'
           ,null
           ,null
           ,'samy@gmail.com'
           ,1)
GO

---------

INSERT INTO [dbo].[Students]
           ([StudentGuardianID]
           ,[StudentBranchID]
           ,[StudentName]
           ,[StudentBirthDate]
           ,[StudentPersonalPhotoPath]
           ,[StudentOriginNationality]
           ,[StudentAcquiredNationality]
           ,[StudentSchoolName]
           ,[StudentLastEducationDegree]
           ,[StudentEducationStage]
           ,[StudentSchoolClass]
           ,[StudentHowYouKnewTheCenter]
           ,[StudentExpectedQuraanFinishTime]
           ,[StudentIsInTransportations]
           ,[StudentSex]
           ,[StudentStatus]
		   ,[StudentAddedOn])
     VALUES
           (1
           ,1
           ,'„ÃœÌ —‘œÌ „Õ„Êœ'
           ,'12/09/1983'
           ,null
           ,1
           ,null
           ,'«·„·ﬂ ›Âœ'
           ,null
           ,null
           ,NULL
           ,1
           ,12
           ,0
           ,1
           ,0
		   ,getdate())
GO

INSERT INTO [dbo].[Students]
           ([StudentGuardianID]
           ,[StudentBranchID]
           ,[StudentName]
           ,[StudentBirthDate]
           ,[StudentPersonalPhotoPath]
           ,[StudentOriginNationality]
           ,[StudentAcquiredNationality]
           ,[StudentSchoolName]
           ,[StudentLastEducationDegree]
           ,[StudentEducationStage]
           ,[StudentSchoolClass]
           ,[StudentHowYouKnewTheCenter]
           ,[StudentExpectedQuraanFinishTime]
           ,[StudentIsInTransportations]
           ,[StudentSex]
           ,[StudentStatus]
		   ,[StudentAddedOn])
     VALUES
           (2
           ,1
           ,'⁄»œ «·—Õ„‰ ”«„Ì'
           ,'12/11/1985'
           ,null
           ,2
           ,null
           ,'«·‰“Â… «·ÃœÌœ…'
           ,null
           ,null
           ,NULL
           ,1
           ,12
           ,0
           ,1
           ,0
		   ,getdate())
GO

	INSERT INTO [dbo].[Students]
           ([StudentGuardianID]
           ,[StudentBranchID]
           ,[StudentName]
           ,[StudentBirthDate]
           ,[StudentPersonalPhotoPath]
           ,[StudentOriginNationality]
           ,[StudentAcquiredNationality]
           ,[StudentSchoolName]
           ,[StudentLastEducationDegree]
           ,[StudentEducationStage]
           ,[StudentSchoolClass]
           ,[StudentHowYouKnewTheCenter]
           ,[StudentExpectedQuraanFinishTime]
           ,[StudentIsInTransportations]
           ,[StudentSex]
           ,[StudentStatus]
		   ,[StudentAddedOn])
     VALUES
           (2
           ,1
           ,'ﬂ—Ì„ „Õ„œ «·œÌ»'
           ,'12/11/1985'
           ,null
           ,2
           ,null
           ,'«·«”ﬂ‰œ—Ì… «·⁄”ﬂ—Ì…'
           ,null
           ,null
           ,NULL
           ,1
           ,12
           ,0
           ,1
           ,0
		   ,getdate())
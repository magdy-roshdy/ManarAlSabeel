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
           ,[GuardianHomePhone]
           ,[GuardianMobilePhone]
           ,[GuardianOtherPhone]
           ,[GuardianHomeAddress]
           ,[GuardianEmailAddress]
           ,[GuardianSex])
     VALUES
           ('—‘œÌ „Õ„Êœ «·‘Õ« '
           ,'041234567'
           ,'055123456'
           ,null
           ,null
           ,'roshdy@gmail.com'
           ,1)
GO

INSERT INTO [dbo].[StudentGuardians]
           ([GuardianName]
           ,[GuardianHomePhone]
           ,[GuardianMobilePhone]
           ,[GuardianOtherPhone]
           ,[GuardianHomeAddress]
           ,[GuardianEmailAddress]
           ,[GuardianSex])
     VALUES
           ('”«„Ì „Õ„œ ⁄»œ «··Â'
           ,'031122334'
           ,'0551122334'
           ,null
           ,null
           ,'samy@gmail.com'
           ,1)
GO

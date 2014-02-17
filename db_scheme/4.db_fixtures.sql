USE [manar_al_sabeel]
GO

INSERT INTO [dbo].[Countries]
           ([CountryName])
     VALUES
           ('�������� ������� �������')

INSERT INTO [dbo].[Countries]
           ([CountryName])
     VALUES
           ('���')

INSERT INTO [dbo].[Countries]
           ([CountryName])
     VALUES
           ('�����')
GO

-------

INSERT INTO [dbo].[Managers]
           ([ManagerName])
     VALUES
           ('�����. ���� �������')

INSERT INTO [dbo].[Managers]
           ([ManagerName])
     VALUES
           ('�����. ������� ����')
GO

---

INSERT INTO [dbo].[Centers]
           ([CenterManagerID]
           ,[CenterName])
     VALUES
           (1
           ,'���� ���� ������')

INSERT INTO [dbo].[Centers]
           ([CenterManagerID]
           ,[CenterName])
     VALUES
           (2
           ,'���� ����� ������ ������')
GO

---

INSERT INTO [dbo].[Branches]
           ([BranchManagerID]
           ,[BranchCenterID]
           ,[BranchName])
     VALUES
           (1
           ,1
           ,'��� �������')

INSERT INTO [dbo].[Branches]
           ([BranchManagerID]
           ,[BranchCenterID]
           ,[BranchName])
     VALUES
           (1
           ,1
           ,'��� ���')

INSERT INTO [dbo].[Branches]
           ([BranchManagerID]
           ,[BranchCenterID]
           ,[BranchName])
     VALUES
           (2
           ,2
           ,'��� ����� �������')
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
           ('���� ����� ������'
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
           ('���� ���� ��� ����'
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
           ,'���� ���� �����'
           ,'12/09/1983'
           ,null
           ,1
           ,null
           ,'����� ���'
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
           ,'��� ������ ����'
           ,'12/11/1985'
           ,null
           ,2
           ,null
           ,'������ �������'
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
           ,'���� ���� �����'
           ,'12/11/1985'
           ,null
           ,2
           ,null
           ,'���������� ��������'
           ,null
           ,null
           ,NULL
           ,1
           ,12
           ,0
           ,1
           ,0
		   ,getdate())
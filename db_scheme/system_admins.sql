/****** Object:  Table [dbo].[SystemAdmins]    Script Date: 03/08/2014 14:52:54 ******/
INSERT [SystemAdmins] ([SystemAdminEmail], [SystemAdminPassword], [SystemAdminIsActive],
[SystemAdminIsSuperAdmin], [SystemAdminLoginPersonType], [SystemAdminBranchID], [SystemAdminSexToManage])
	VALUES (N'admin@manaralsabeel.org', N'cPo/K+Z+Q2yHaX3BegGvmE/e4eZvEA==', 1, 0, 0, 1, 1)

INSERT [SystemAdmins] ([SystemAdminEmail], [SystemAdminPassword], [SystemAdminIsActive],
[SystemAdminIsSuperAdmin], [SystemAdminLoginPersonType], [SystemAdminBranchID], [SystemAdminSexToManage])
	VALUES (N'admin.females@manaralsabeel.org', N'Pa5ROdJRvb5WoIk8H7UdQKw2Cz58SQ==', 1, 0, 0, 1, 0)

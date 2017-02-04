USE [teromac]
GO
SET IDENTITY_INSERT [dbo].[PermissionRecord] ON 

GO
INSERT [dbo].[PermissionRecord] ([Id], [Name], [SystemName], [Category]) VALUES (1, N'Access admin area', N'AccessAdminPanel', N'Standard')
GO
INSERT [dbo].[PermissionRecord] ([Id], [Name], [SystemName], [Category]) VALUES (2, N'Manage Users', N'ManageUsers', N'Users')
GO
INSERT [dbo].[PermissionRecord] ([Id], [Name], [SystemName], [Category]) VALUES (3, N'Manage Manage Activity Log', N'ManageActivityLog', N'Configuration')
GO
SET IDENTITY_INSERT [dbo].[PermissionRecord] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

GO
INSERT [dbo].[UserRole] ([Id], [Name], [Active], [IsSystemRole], [SystemName]) VALUES (1, N'Administrators', 1, 1, N'Administrators')
GO
INSERT [dbo].[UserRole] ([Id], [Name], [Active], [IsSystemRole], [SystemName]) VALUES (2, N'Registered', 1, 1, N'Registered')
GO
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
INSERT [dbo].[PermissionRecordUserRole] ([PermissionRecordId], [UserRoleId]) VALUES (1, 1)
GO
INSERT [dbo].[PermissionRecordUserRole] ([PermissionRecordId], [UserRoleId]) VALUES (1, 2)
GO
INSERT [dbo].[PermissionRecordUserRole] ([PermissionRecordId], [UserRoleId]) VALUES (2, 1)
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [UserGuid], [Username], [Email], [Password], [PasswordSalt], [AdminComment], [Active], [Deleted], [IsSystemAccount], [SystemName], [LastIpAddress], [CreatedOnUtc], [LastLoginDateUtc], [LastActivityDateUtc]) VALUES (1, N'9168d42f-dc07-4530-a13e-300c32911c35', N'admin', N'admin@yourcompany.com', N'9F692A2BD76FE32A744AB7F1521C748EC9B69F63', N'vxUK5mk=', NULL, 1, 0, 0, NULL, NULL, CAST(N'2017-01-16 01:03:30.883' AS DateTime), CAST(N'2017-02-04 21:41:35.537' AS DateTime), CAST(N'2017-02-04 21:44:06.917' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserUserRole] ([UserId], [UserRoleId]) VALUES (1, 1)
GO
INSERT [dbo].[UserUserRole] ([UserId], [UserRoleId]) VALUES (1, 2)
GO
SET IDENTITY_INSERT [dbo].[Language] ON 

GO
INSERT [dbo].[Language] ([Id], [Name], [LanguageCulture], [UniqueSeoCode], [Rtl], [Published], [DisplayOrder]) VALUES (1, N'English', N'en-US', N'en', 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Language] OFF
GO
SET IDENTITY_INSERT [dbo].[LocaleStringResource] ON 

GO
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (1, 1, N'User.Fields.Username', N'Username')
GO
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (2, 1, N'account.login.webportal', N'Web Portal')
GO
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (4, 1, N'account.login.welcome ', N'Welcome, Please Sign In! ')
GO
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (5, 1, N'User.Fields.Password', N'Password')
GO
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (6, 1, N'Account.Login.LoginButton', N'Login')
GO
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (7, 1, N'Account.Login.Fields.Username.Required', N'Please enter username.')
GO
INSERT [dbo].[LocaleStringResource] ([Id], [LanguageId], [ResourceName], [ResourceValue]) VALUES (8, 1, N'Account.Login.Fields.Password.Required', N'Please enter password.')
GO
SET IDENTITY_INSERT [dbo].[LocaleStringResource] OFF
GO

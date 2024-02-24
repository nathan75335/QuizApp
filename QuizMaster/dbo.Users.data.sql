SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserId], [UserName], [Email], [Password], [RoleId]) VALUES (-1, N'Aristote', N'arisdev@gmail.com', N'Aristote654321', -1)
INSERT INTO [dbo].[Users] ([UserId], [UserName], [Email], [Password], [RoleId]) VALUES (1, N'Ben', N'Ben10@gmail.com', N'Ben102000', -2)
SET IDENTITY_INSERT [dbo].[Users] OFF

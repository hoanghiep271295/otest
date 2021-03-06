IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[admingroup]') AND type in (N'U'))
DROP TABLE [dbo].[admingroup]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADMINGROUPPRIORITY]') AND type in (N'U'))
DROP TABLE [dbo].[ADMINGROUPPRIORITY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADMINGROUPPRIORITY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ADMINGROUPPRIORITY](
	[objectcode] [varchar](10) NOT NULL,
	[thetype] [varchar](50) NOT NULL,
	[prioritycode] [nvarchar](40) NOT NULL,
	[forman] [int] NOT NULL,
	[func] [int] NULL,
	[inherit] [int] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
	[thecode] [varchar](10) NOT NULL,
	[extensioncode] [varchar](200) NULL,
	[tablename] [varchar](50) NOT NULL,
	[syscomponentcode] [varchar](10) NULL,
 CONSTRAINT [PK_ADMINGROUPPRIORITY_MY] PRIMARY KEY CLUSTERED 
(
	[objectcode] ASC,
	[thetype] ASC,
	[prioritycode] ASC,
	[forman] ASC,
	[thecode] ASC,
	[tablename] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMCOURSE', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMDEP', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMDIR', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMOFFLINE', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMQUESTLI', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMSTAFF', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMSTUDENT', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMSUBJECT', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMTESTST', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'LECCOURSEC', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'LECEXAM', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'LECIMPEXA', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'LECVIEXAM', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'LECVISTUDE', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'SADMENU', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'SADPRIORIT', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'STULEARN', 0, 15, 1, N'00001', CAST(0x0000A84100B82C41 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMCOURSE', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMDEP', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMDIR', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMOFFLINE', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMQUESTLI', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMSTAFF', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMSTUDENT', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMSUBJECT', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMTESTST', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'LECCOURSEC', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'LECEXAM', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'LECIMPEXA', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'LECVIEXAM', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'LECVISTUDE', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'SADMENU', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'SADPRIORIT', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'STULEARN', 0, 15, 1, N'00001', CAST(0x0000A84100B851F9 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', NULL)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[admingroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[admingroup](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_admingroup_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[admingroup] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [universitycode]) VALUES (N'1711100007', N'ADMIN', N'Admin', NULL, NULL, NULL, NULL, NULL, NULL, N'HVKTQS')
INSERT [dbo].[admingroup] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [universitycode]) VALUES (N'1711100009', N'MAN', N'Man1', NULL, N'', CAST(0x0000A83A00994A94 AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'', N'HVKTQS')
INSERT [dbo].[admingroup] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [universitycode]) VALUES (N'1711140001', N'OTHER', N'Other', NULL, NULL, NULL, NULL, NULL, NULL, N'HVKTQS')

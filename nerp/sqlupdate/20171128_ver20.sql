IF EXISTS(SELECT * FROM sys.views where name='ARMYRANK')	DROP VIEW ARMYRANK
IF EXISTS(SELECT * FROM sys.views where name='APPROVEDSTATUS')	DROP VIEW APPROVEDSTATUS
IF EXISTS(SELECT * FROM sys.views where name='ACADEMICTITLE')	DROP VIEW ACADEMICTITLE
IF EXISTS(SELECT * FROM sys.views where name='ACADEMICLEVELHISTORY')	DROP VIEW ACADEMICLEVELHISTORY
IF EXISTS(SELECT * FROM sys.views where name='ACADEMICLEVEL')	DROP VIEW ACADEMICLEVEL
IF EXISTS(SELECT * FROM sys.views where name='ACADEMICTITLEHISTORY')	DROP VIEW ACADEMICTITLEHISTORY
IF EXISTS(SELECT * FROM sys.views where name='studentresearchaward')	DROP VIEW studentresearchaward
IF EXISTS(SELECT * FROM sys.views where name='researchgrouprole')	DROP VIEW researchgrouprole
IF EXISTS(SELECT * FROM sys.views where name='projectgroup')	DROP VIEW projectgroup
IF EXISTS(SELECT * FROM sys.views where name='projectaward')	DROP VIEW projectaward
IF EXISTS(SELECT * FROM sys.views where name='PARTYLEVELTITLEHISTORY')	DROP VIEW PARTYLEVELTITLEHISTORY
IF EXISTS(SELECT * FROM sys.views where name='PARTYLEVELTITLE')	DROP VIEW PARTYLEVELTITLE
IF EXISTS(SELECT * FROM sys.views where name='studentresearchtype')	DROP VIEW studentresearchtype
IF EXISTS(SELECT * FROM sys.views where name='studentresearchstudentrole')	DROP VIEW studentresearchstudentrole
IF EXISTS(SELECT * FROM sys.views where name='studentresearchstatus')	DROP VIEW studentresearchstatus
IF EXISTS(SELECT * FROM sys.views where name='studentresearchrole')	DROP VIEW studentresearchrole
IF EXISTS(SELECT * FROM sys.views where name='studentresearchlevel')	DROP VIEW studentresearchlevel
IF EXISTS(SELECT * FROM sys.views where name='spendtype')	DROP VIEW spendtype
IF EXISTS(SELECT * FROM sys.views where name='researchstatus')	DROP VIEW researchstatus
IF EXISTS(SELECT * FROM sys.views where name='researchprizetype')	DROP VIEW researchprizetype
IF EXISTS(SELECT * FROM sys.views where name='researchprizerole')	DROP VIEW researchprizerole
IF EXISTS(SELECT * FROM sys.views where name='researchprizelevel')	DROP VIEW researchprizelevel
IF EXISTS(SELECT * FROM sys.views where name='patenttype')	DROP VIEW patenttype
IF EXISTS(SELECT * FROM sys.views where name='patentrole')	DROP VIEW patentrole
IF EXISTS(SELECT * FROM sys.views where name='patentlevel')	DROP VIEW patentlevel
IF EXISTS(SELECT * FROM sys.views where name='projecttype')	DROP VIEW projecttype
IF EXISTS(SELECT * FROM sys.views where name='projectstatus')	DROP VIEW projectstatus
IF EXISTS(SELECT * FROM sys.views where name='projectrole')	DROP VIEW projectrole
IF EXISTS(SELECT * FROM sys.views where name='projectlevel')	DROP VIEW projectlevel
IF EXISTS(SELECT * FROM sys.views where name='paperrole')	DROP VIEW paperrole
IF EXISTS(SELECT * FROM sys.views where name='paperlevel')	DROP VIEW paperlevel
IF EXISTS(SELECT * FROM sys.views where name='lablessontype')	DROP VIEW lablessontype
IF EXISTS(SELECT * FROM sys.views where name='lablessonrole')	DROP VIEW lablessonrole
IF EXISTS(SELECT * FROM sys.views where name='managelevel')	DROP VIEW managelevel
IF EXISTS(SELECT * FROM sys.views where name='marktesttype')	DROP VIEW marktesttype
IF EXISTS(SELECT * FROM sys.views where name='leveltitlepriority')	DROP VIEW leveltitlepriority
IF EXISTS(SELECT * FROM sys.views where name='LEVELTITLEHISTORY')	DROP VIEW LEVELTITLEHISTORY
IF EXISTS(SELECT * FROM sys.views where name='LEVELTITLE')	DROP VIEW LEVELTITLE
IF EXISTS(SELECT * FROM sys.views where name='languagelevel')	DROP VIEW languagelevel
IF EXISTS(SELECT * FROM sys.views where name='educationlevel')	DROP VIEW educationlevel
IF EXISTS(SELECT * FROM sys.views where name='departmentprizetype')	DROP VIEW departmentprizetype
IF EXISTS(SELECT * FROM sys.views where name='departmentprizelevel')	DROP VIEW departmentprizelevel
IF EXISTS(SELECT * FROM sys.views where name='fundtype')	DROP VIEW fundtype
IF EXISTS(SELECT * FROM sys.views where name='DEGREEHISTORY')	DROP VIEW DEGREEHISTORY
IF EXISTS(SELECT * FROM sys.views where name='DEGREE')	DROP VIEW DEGREE
IF EXISTS(SELECT * FROM sys.views where name='contractstatus')	DROP VIEW contractstatus
IF EXISTS(SELECT * FROM sys.views where name='contractrole')	DROP VIEW contractrole
IF EXISTS(SELECT * FROM sys.views where name='contractlevel')	DROP VIEW contractlevel
IF EXISTS(SELECT * FROM sys.views where name='counciltype')	DROP VIEW counciltype
IF EXISTS(SELECT * FROM sys.views where name='councilrole')	DROP VIEW councilrole
IF EXISTS(SELECT * FROM sys.views where name='councillevel')	DROP VIEW councillevel
IF EXISTS(SELECT * FROM sys.views where name='booktype')	DROP VIEW booktype
IF EXISTS(SELECT * FROM sys.views where name='bookrole')	DROP VIEW bookrole
IF EXISTS(SELECT * FROM sys.views where name='booklevel')	DROP VIEW booklevel
IF EXISTS(SELECT * FROM sys.views where name='ARMYRANKHISTORY')	DROP VIEW ARMYRANKHISTORY

/****** Object:  Table [dbo].[academiclevel]    Script Date: 11/28/2017 23:08:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[academiclevel]') AND type in (N'U'))
DROP TABLE [dbo].[academiclevel]
GO
/****** Object:  Table [dbo].[academiclevelhistory]    Script Date: 11/28/2017 23:08:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[academiclevelhistory]') AND type in (N'U'))
DROP TABLE [dbo].[academiclevelhistory]
GO
/****** Object:  Table [dbo].[academictitle]    Script Date: 11/28/2017 23:08:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[academictitle]') AND type in (N'U'))
DROP TABLE [dbo].[academictitle]
GO
/****** Object:  Table [dbo].[acedemictitlehistory]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acedemictitlehistory]') AND type in (N'U'))
DROP TABLE [dbo].[acedemictitlehistory]
GO
/****** Object:  Table [dbo].[admingroup]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[admingroup]') AND type in (N'U'))
DROP TABLE [dbo].[admingroup]
GO
/****** Object:  Table [dbo].[ADMINGROUPPRIORITY]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ADMINGROUPPRIORITY]') AND type in (N'U'))
DROP TABLE [dbo].[ADMINGROUPPRIORITY]
GO
/****** Object:  Table [dbo].[armyrank]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[armyrank]') AND type in (N'U'))
DROP TABLE [dbo].[armyrank]
GO
/****** Object:  Table [dbo].[armyrankhistory]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[armyrankhistory]') AND type in (N'U'))
DROP TABLE [dbo].[armyrankhistory]
GO
/****** Object:  Table [dbo].[dayoff]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dayoff]') AND type in (N'U'))
DROP TABLE [dbo].[dayoff]
GO
/****** Object:  Table [dbo].[degree]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[degree]') AND type in (N'U'))
DROP TABLE [dbo].[degree]
GO
/****** Object:  Table [dbo].[degreehistory]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[degreehistory]') AND type in (N'U'))
DROP TABLE [dbo].[degreehistory]
GO
/****** Object:  Table [dbo].[department]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[department]') AND type in (N'U'))
DROP TABLE [dbo].[department]
GO
/****** Object:  Table [dbo].[departmentadmingroup]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[departmentadmingroup]') AND type in (N'U'))
DROP TABLE [dbo].[departmentadmingroup]
GO
/****** Object:  Table [dbo].[departmenthistory]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[departmenthistory]') AND type in (N'U'))
DROP TABLE [dbo].[departmenthistory]
GO
/****** Object:  Table [dbo].[DEPARTMENTPRIORITY]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DEPARTMENTPRIORITY]') AND type in (N'U'))
DROP TABLE [dbo].[DEPARTMENTPRIORITY]
GO
/****** Object:  Table [dbo].[district]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[district]') AND type in (N'U'))
DROP TABLE [dbo].[district]
GO
/****** Object:  Table [dbo].[districtreference]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[districtreference]') AND type in (N'U'))
DROP TABLE [dbo].[districtreference]
GO
/****** Object:  Table [dbo].[ethnic]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ethnic]') AND type in (N'U'))
DROP TABLE [dbo].[ethnic]
GO
/****** Object:  Table [dbo].[groupname]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupname]') AND type in (N'U'))
DROP TABLE [dbo].[groupname]
GO
/****** Object:  Table [dbo].[leveltitle]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leveltitle]') AND type in (N'U'))
DROP TABLE [dbo].[leveltitle]
GO
/****** Object:  Table [dbo].[leveltitleadmingroup]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leveltitleadmingroup]') AND type in (N'U'))
DROP TABLE [dbo].[leveltitleadmingroup]
GO
/****** Object:  Table [dbo].[leveltitlehistory]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leveltitlehistory]') AND type in (N'U'))
DROP TABLE [dbo].[leveltitlehistory]
GO
/****** Object:  Table [dbo].[LEVELTITLRPRIORITY]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LEVELTITLRPRIORITY]') AND type in (N'U'))
DROP TABLE [dbo].[LEVELTITLRPRIORITY]
GO
/****** Object:  Table [dbo].[logerror]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logerror]') AND type in (N'U'))
DROP TABLE [dbo].[logerror]
GO
/****** Object:  Table [dbo].[logme]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logme]') AND type in (N'U'))
DROP TABLE [dbo].[logme]
GO
/****** Object:  Table [dbo].[logresetpassword]    Script Date: 11/28/2017 23:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logresetpassword]') AND type in (N'U'))
DROP TABLE [dbo].[logresetpassword]
GO
/****** Object:  Table [dbo].[managelevel]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[managelevel]') AND type in (N'U'))
DROP TABLE [dbo].[managelevel]
GO
/****** Object:  Table [dbo].[nation]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nation]') AND type in (N'U'))
DROP TABLE [dbo].[nation]
GO
/****** Object:  Table [dbo].[nationreference]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nationreference]') AND type in (N'U'))
DROP TABLE [dbo].[nationreference]
GO
/****** Object:  Table [dbo].[partyleveltitle]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[partyleveltitle]') AND type in (N'U'))
DROP TABLE [dbo].[partyleveltitle]
GO
/****** Object:  Table [dbo].[partyleveltitlehistory]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[partyleveltitlehistory]') AND type in (N'U'))
DROP TABLE [dbo].[partyleveltitlehistory]
GO
/****** Object:  Table [dbo].[personalparameter]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[personalparameter]') AND type in (N'U'))
DROP TABLE [dbo].[personalparameter]
GO
/****** Object:  Table [dbo].[priority]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[priority]') AND type in (N'U'))
DROP TABLE [dbo].[priority]
GO
/****** Object:  Table [dbo].[province]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[province]') AND type in (N'U'))
DROP TABLE [dbo].[province]
GO
/****** Object:  Table [dbo].[provincereference]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[provincereference]') AND type in (N'U'))
DROP TABLE [dbo].[provincereference]
GO
/****** Object:  Table [dbo].[region]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[region]') AND type in (N'U'))
DROP TABLE [dbo].[region]
GO
/****** Object:  Table [dbo].[religion]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[religion]') AND type in (N'U'))
DROP TABLE [dbo].[religion]
GO
/****** Object:  Table [dbo].[resetpassword]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[resetpassword]') AND type in (N'U'))
DROP TABLE [dbo].[resetpassword]
GO
/****** Object:  Table [dbo].[staff]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staff]') AND type in (N'U'))
DROP TABLE [dbo].[staff]
GO
/****** Object:  Table [dbo].[staffadmingroup]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffadmingroup]') AND type in (N'U'))
DROP TABLE [dbo].[staffadmingroup]
GO
/****** Object:  Table [dbo].[staffauthorize]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffauthorize]') AND type in (N'U'))
DROP TABLE [dbo].[staffauthorize]
GO
/****** Object:  Table [dbo].[staffinfo]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffinfo]') AND type in (N'U'))
DROP TABLE [dbo].[staffinfo]
GO
/****** Object:  Table [dbo].[STAFFPRIORITY]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[STAFFPRIORITY]') AND type in (N'U'))
DROP TABLE [dbo].[STAFFPRIORITY]
GO
/****** Object:  Table [dbo].[staffstatus]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffstatus]') AND type in (N'U'))
DROP TABLE [dbo].[staffstatus]
GO
/****** Object:  Table [dbo].[staffstatushistory]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffstatushistory]') AND type in (N'U'))
DROP TABLE [dbo].[staffstatushistory]
GO
/****** Object:  Table [dbo].[syscomponent]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[syscomponent]') AND type in (N'U'))
DROP TABLE [dbo].[syscomponent]
GO
/****** Object:  Table [dbo].[sysmenu]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysmenu]') AND type in (N'U'))
DROP TABLE [dbo].[sysmenu]
GO
/****** Object:  Table [dbo].[sysmenupriority]    Script Date: 11/28/2017 23:08:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysmenupriority]') AND type in (N'U'))
DROP TABLE [dbo].[sysmenupriority]
GO
/****** Object:  Table [dbo].[systemparameter]    Script Date: 11/28/2017 23:08:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[systemparameter]') AND type in (N'U'))
DROP TABLE [dbo].[systemparameter]
GO
/****** Object:  Table [dbo].[tasknote]    Script Date: 11/28/2017 23:08:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tasknote]') AND type in (N'U'))
DROP TABLE [dbo].[tasknote]
GO
/****** Object:  Table [dbo].[town]    Script Date: 11/28/2017 23:08:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[town]') AND type in (N'U'))
DROP TABLE [dbo].[town]
GO
/****** Object:  Table [dbo].[townreference]    Script Date: 11/28/2017 23:08:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[townreference]') AND type in (N'U'))
DROP TABLE [dbo].[townreference]
GO
/****** Object:  Table [dbo].[university]    Script Date: 11/28/2017 23:08:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[university]') AND type in (N'U'))
DROP TABLE [dbo].[university]
GO
/****** Object:  Table [dbo].[weekday]    Script Date: 11/28/2017 23:08:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[weekday]') AND type in (N'U'))
DROP TABLE [dbo].[weekday]
GO
/****** Object:  Table [dbo].[weekday]    Script Date: 11/28/2017 23:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[weekday]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[weekday](
	[code] [varchar](10) NOT NULL,
	[weekday] [int] NULL,
	[name] [nvarchar](100) NULL,
	[isoff] [int] NULL,
	[whois] [varchar](64) NULL,
 CONSTRAINT [PK_weekday_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[weekday] ([code], [weekday], [name], [isoff], [whois]) VALUES (N'CN', 7, N'Chủ nhật', 1, NULL)
INSERT [dbo].[weekday] ([code], [weekday], [name], [isoff], [whois]) VALUES (N'T2', 1, N'Thứ 2', 0, NULL)
INSERT [dbo].[weekday] ([code], [weekday], [name], [isoff], [whois]) VALUES (N'T3', 2, N'Thứ 3', 0, NULL)
INSERT [dbo].[weekday] ([code], [weekday], [name], [isoff], [whois]) VALUES (N'T4', 3, N'Thứ 4', 0, NULL)
INSERT [dbo].[weekday] ([code], [weekday], [name], [isoff], [whois]) VALUES (N'T5', 4, N'Thứ 5', 0, NULL)
INSERT [dbo].[weekday] ([code], [weekday], [name], [isoff], [whois]) VALUES (N'T6', 5, N'Thứ 6', 0, NULL)
INSERT [dbo].[weekday] ([code], [weekday], [name], [isoff], [whois]) VALUES (N'T7', 6, N'Thứ 7', 1, NULL)
/****** Object:  Table [dbo].[university]    Script Date: 11/28/2017 23:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[university]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[university](
	[code] [varchar](10) NOT NULL,
	[codeview] [nvarchar](50) NULL,
	[name] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[rectorcode] [varchar](10) NULL,
	[rectorname] [nvarchar](100) NULL,
	[address] [nvarchar](100) NULL,
	[phone] [varchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[website] [nvarchar](100) NULL,
	[admincode] [varchar](10) NULL,
 CONSTRAINT [PK_university_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[university] ([code], [codeview], [name], [edituser], [edittime], [lock], [lockdate], [rectorcode], [rectorname], [address], [phone], [email], [website], [admincode]) VALUES (N'HVKTQS', N'HVKTQS', N'Học viện kỹ thuật quân sự', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[townreference]    Script Date: 11/28/2017 23:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[townreference]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[townreference](
	[thecode] [varchar](10) NOT NULL,
	[currentcode] [varchar](10) NOT NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
 CONSTRAINT [PK_townreference_MY] PRIMARY KEY CLUSTERED 
(
	[thecode] ASC,
	[currentcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[town]    Script Date: 11/28/2017 23:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[town]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[town](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[parentcode] [varchar](10) NULL,
	[whois] [varchar](64) NULL,
	[begindate] [datetime] NULL,
	[enddate] [datetime] NULL,
	[thetype] [varchar](50) NULL,
 CONSTRAINT [PK_town_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tasknote]    Script Date: 11/28/2017 23:08:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tasknote]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tasknote](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](2000) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[thetype] [varchar](50) NULL,
	[eventtime] [datetime] NULL,
	[eventtimeshow] [varchar](20) NULL,
	[eventtype] [int] NULL,
	[eventwarntime] [datetime] NULL,
	[eventreminde] [int] NULL,
	[eventduewarn] [int] NULL,
	[link] [nvarchar](500) NULL,
	[staffcode] [varchar](10) NULL,
	[icon] [varchar](50) NULL,
 CONSTRAINT [PK_tasknote_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tasknote] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [thetype], [eventtime], [eventtimeshow], [eventtype], [eventwarntime], [eventreminde], [eventduewarn], [link], [staffcode], [icon]) VALUES (N'123', N'123', N'Hệ thống đã triển khai', N'Hệ thống đã triển khai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'fa-rocket')
INSERT [dbo].[tasknote] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [thetype], [eventtime], [eventtimeshow], [eventtype], [eventwarntime], [eventreminde], [eventduewarn], [link], [staffcode], [icon]) VALUES (N'124', N'124', N'Mr Uyên kiểm tra triển khai', N'Mr Uyên kiểm tra triển khai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'00001', N'fa-key')
INSERT [dbo].[tasknote] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [thetype], [eventtime], [eventtimeshow], [eventtype], [eventwarntime], [eventreminde], [eventduewarn], [link], [staffcode], [icon]) VALUES (N'125', N'125', N'Mr Dương test toàn bộ hệ thống', N'Mr Dương test toàn bộ hệ thống', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1711150001', N'fa-paper-plane-o')
/****** Object:  Table [dbo].[systemparameter]    Script Date: 11/28/2017 23:08:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[systemparameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[systemparameter](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](50) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](1000) NULL,
	[value] [nvarchar](500) NULL,
	[thetype] [nvarchar](100) NULL,
	[active] [int] NULL,
	[theorder] [int] NULL,
	[universitycode] [varchar](10) NULL,
	[languagecode] [varchar](10) NULL,
 CONSTRAINT [PK_systemparameter_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1234', N'TITLE', N'Tiêu đề của hệ thống', N'Tiêu đề của hệ thống để hiển thị trong một số báo cáo', N'MTARMS', N'Chuỗi', 1, 1, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1235', N'RECTOR', N'Tên của giám đốc', N'Tên của giám đốc, người sẽ ký các một số quyết định liên quan đến đào tạo', N'GS. TSKH Nguyễn Công Định', N'Chuỗi', 1, 4, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1236', N'HEADEDU', N'Trưởng phòng đào tạo', N'Tên của trưởng phòng đào tạo, in trong các quyết định về đào tạo', N'Đại tá. TS Mai Quang Huy', N'Chuỗi', 1, 5, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1237', N'UNIT1', N'Tên của đơn vị quản lý', N'Tên của Học viện, nhà trường', N'HỌC VIỆN KỸ THUẬT QUÂN SỰ', N'Chuỗi', 1, 2, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1238', N'UNIT2', N'Tên đơn vị phụ trách đào tạo', N'Tên của phòng đào tạo, hoặc phụ trách đào tạo', N'PHÒNG KHOA HỌC QUÂN SỰ', N'Chuỗi', 1, 3, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1239', N'BRANCH', N'Thông tin đơn vị triển khai', N'Thông tin về đơn vị triển khai', N'HVKTQS', N'Chuỗi', 1, 6, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1240', N'WEEKEND', N'Ngày nghỉ cuối tuần', N'Ngày nghỉ cuối tuần', N'2', N'Số', 1, 7, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1241', N'BRANCHCODE', N'Quy d?nh ký mã d?u cho sinh mã c?a h? th?ng', N'Chu?i quy d?nh cho vi?c sinh mã chung khu v?c phát tri?n (dành cho các phiên b?n trên các d?i tu?ng khác nhau có th? th?ng nh?t chung du?c. M?c d?nh ''''', N'KHQS', N'Chuỗi', 1, 8, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1242', N'FOLLOWSCHEDULE', N'Tuân th? theo chuong trình dào t?o', N'B?t bu?c ph?i tuân th? chuong trình dào t?o c?a sinh viên, t? dó sinh viên ch? du?c ch?n h?c các môn h?c trong gi?i h?n. M?c d?nh 0, không tuân th?', N'1', N'Số', 1, 9, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1243', N'FOLLOWSUBECT', N'Tuân th? phân công môn h?c cho giáo viên', N'B?t bu?c ph?i tuân th? ch? du?c phân công môn h?c cho giáo viên có kh? nang gi?ng d?y môn h?c dó. M?c d?nh 0, không tuân th?.', N'0', N'Số', 1, 10, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1244', N'GENSTUDENTCODE', N'Sinh mã sinh viên', N'Sinh mã sinh viên', N'''''', N'Chuỗi', 1, 11, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1245', N'GENCOURSECODE', N'Sinh mã của lớp môn học', N'Sinh mã của lớp môn học', N'0', N'Số', 1, 12, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1246', N'MINCREDIT', N'Số tín chỉ tối thiểu', N'Số tín chỉ tối thiểu', N'10', N'Số', 1, 13, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1247', N'MAXCREDIT', N'Số tín chỉ tối đa', N'Số tín chỉ tối đa', N'20', N'Số', 1, 14, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1248', N'NUMBERSTUDENT', N'Số lượng sinh viên', N'Số lượng sinh viên', N'50', N'Số', 1, 15, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1249', N'MINSTUDENT', N'Số lượng sinh viên trong lớp môn học tối thiểu', N'Số lượng sinh viên trong lớp môn học tối thiểu', N'10', N'Số', 1, 16, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1250', N'VERSION', N'Phiên bản', N'Phiên bản', N'19', N'Số', 1, 17, N'', N'')
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1251', N'CREATECOURSE', N'Cho phép giáo viên thêm các lớp môn học mới', N'Cho phép giáo viên thêm các lớp môn học mới', N'1', N'Số', 1, 18, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1252', N'BEGINTERM1', N'Ngày đầu tiên của kỳ 1', N'Ngày đầu tiên của kỳ 1', N'1/8/2015', N'Ngày tháng', 1, 19, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1253', N'ENDTERM1', N'Ngày kết thúc của kỳ 1', N'Ngày kết thúc của kỳ 1', N'15/1/2015', N'Ngày tháng', 1, 20, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1254', N'BEGINTERM2', N'Ngày đầu tiên của kỳ 2', N'Ngày đầu tiên của kỳ 2', N'16/1/2016', N'Ngày tháng', 1, 21, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1255', N'ENDTERM2', N'Ngày kết thúc của kỳ 2', N'Ngày kết thúc của kỳ 2', N'30/7/2016', N'Ngày tháng', 1, 22, NULL, NULL)
INSERT [dbo].[systemparameter] ([code], [codeview], [name], [note], [value], [thetype], [active], [theorder], [universitycode], [languagecode]) VALUES (N'1256', N'WORKINGYEAR', N'Năm nhập liệu hiện tại', N'Năm nhập liệu hiện tại', N'2017', N'Số', 1, 23, NULL, NULL)
/****** Object:  Table [dbo].[sysmenupriority]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysmenupriority]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sysmenupriority](
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[sysmenucode] [varchar](10) NOT NULL,
	[prioritycode] [nvarchar](100) NOT NULL,
	[whois] [varchar](64) NULL,
	[extensioncode] [varchar](200) NULL,
 CONSTRAINT [PK_sysmenupriority_MY] PRIMARY KEY CLUSTERED 
(
	[sysmenucode] ASC,
	[prioritycode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71200B1782A AS DateTime), N'/', N'PRESEARCH', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81600CE8F4E AS DateTime), N'01', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (N'uyennm', CAST(0x0000A6E400F49560 AS DateTime), 0, CAST(0x0000A6E400F49560 AS DateTime), N'011', N'PRESEARCH', N'', NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71200B17C66 AS DateTime), N'012', N'RESEARCHSUPPORT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71200B180EE AS DateTime), N'013', N'PRESEARCH', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71400EACBF8 AS DateTime), N'021', N'PRESEARCH', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71400EAD2CB AS DateTime), N'022', N'ALL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81600C82EC3 AS DateTime), N'03', N'ADMINMENU', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71200B0F903 AS DateTime), N'031', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71200B0FFB7 AS DateTime), N'032', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7DD00F14D50 AS DateTime), N'033', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010B0E2A AS DateTime), N'1612250001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010B86F0 AS DateTime), N'1612260002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010B5506 AS DateTime), N'1612270001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81500A1009E AS DateTime), N'1702060001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A713005CD7ED AS DateTime), N'1702060002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160106503C AS DateTime), N'1702060003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81800C6B871 AS DateTime), N'1702060004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017C3FDD AS DateTime), N'1702060005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7600181607E AS DateTime), N'1702060006', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7600183618F AS DateTime), N'1702060007', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010C4CC8 AS DateTime), N'1702060008', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010B1805 AS DateTime), N'1702060009', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601077C76 AS DateTime), N'1702070001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7600181343F AS DateTime), N'1702070002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017C3513 AS DateTime), N'1702070003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76001818B68 AS DateTime), N'1702070004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017C4DD2 AS DateTime), N'1702070005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010A25EF AS DateTime), N'1702070006', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017C91BC AS DateTime), N'1702070007', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017AA39F AS DateTime), N'1702080001', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7DD00F1E613 AS DateTime), N'1702080002', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7DD00F1C914 AS DateTime), N'1702080003', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017B4DE8 AS DateTime), N'1702080004', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017B97DD AS DateTime), N'1702080005', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017B0D4A AS DateTime), N'1702080006', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017AB493 AS DateTime), N'1702080007', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017ABE42 AS DateTime), N'1702080008', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017B73B6 AS DateTime), N'1702080011', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7DD00F1BF20 AS DateTime), N'1702080012', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71600F19C40 AS DateTime), N'1702100001', N's', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71600F1AE4F AS DateTime), N'1702100002', N'h', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71600F1C133 AS DateTime), N'1702100003', N'y', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DC5C1F AS DateTime), N'1702160001', N'DEPPRIDEP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DC5C1F AS DateTime), N'1702160001', N'DEPPRIFAL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DC5C1F AS DateTime), N'1702160001', N'MANPRIDEPREP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DAC1A7 AS DateTime), N'1702160002', N'DEPPRIDEP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DAC1A7 AS DateTime), N'1702160002', N'DEPPRIFAL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DAC1A7 AS DateTime), N'1702160002', N'MANPRIDEPREP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DB0273 AS DateTime), N'1702160003', N'DEPPRIDEP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DB0273 AS DateTime), N'1702160003', N'DEPPRIFAL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A71C00DB0273 AS DateTime), N'1702160003', N'MANPRIDEPREP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82D001751E7 AS DateTime), N'1702240001', N'USER', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010902C5 AS DateTime), N'1702240004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610012BE6E AS DateTime), N'1702240005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82D00166E15 AS DateTime), N'1702240006', N'USER', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A72400EDB0B0 AS DateTime), N'1702240007', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610009D528 AS DateTime), N'1702240008', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000FED65 AS DateTime), N'1702240009', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A72400EEB86F AS DateTime), N'1702240010', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A72400EEF2A1 AS DateTime), N'1702240011', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A72400EF287E AS DateTime), N'1702240012', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76100137B4A AS DateTime), N'1702240013', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76100135AFF AS DateTime), N'1702240014', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A75D0096203E AS DateTime), N'1702240015', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000A62CF AS DateTime), N'1702240016', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610012DD6A AS DateTime), N'1702240017', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000B0DA6 AS DateTime), N'1702240018', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610010B87B AS DateTime), N'1702240019', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000F32B2 AS DateTime), N'1702240020', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000F8D22 AS DateTime), N'1702240021', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761001399DE AS DateTime), N'1702240022', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7600181A0D6 AS DateTime), N'1702240023', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017C96EC AS DateTime), N'1702240024', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610013A636 AS DateTime), N'1702240025', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A760017C55B7 AS DateTime), N'1702240026', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610013B803 AS DateTime), N'1702240027', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610009B5FF AS DateTime), N'1702240028', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610012EDC8 AS DateTime), N'1702240029', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000C2D39 AS DateTime), N'1702240030', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610012500B AS DateTime), N'1702240031', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A72400FE1357 AS DateTime), N'1702240032', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76100106C43 AS DateTime), N'1702240033', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610013F2E1 AS DateTime), N'1702240034', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7600181A7D4 AS DateTime), N'1702240035', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A72400FEEDBD AS DateTime), N'1702240036', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000B5345 AS DateTime), N'1702240037', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010A6352 AS DateTime), N'1703070001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A72F010A9DF8 AS DateTime), N'1703070002', N'MANPRISTAFREP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A75C01175F92 AS DateTime), N'1704210002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76100132CDC AS DateTime), N'1704250001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7600182D0DC AS DateTime), N'1704250002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76001886C73 AS DateTime), N'1704250003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000077F2 AS DateTime), N'1704260001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761001367F0 AS DateTime), N'1704260002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76100099DED AS DateTime), N'1704260003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76100131E1B AS DateTime), N'1704260004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000C139C AS DateTime), N'1704260005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000D8B95 AS DateTime), N'1704260006', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000DCF83 AS DateTime), N'1704260007', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A761000F0B92 AS DateTime), N'1704260008', N'ADMINDIRE', NULL, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A76100148DE5 AS DateTime), N'1704260009', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7610012224A AS DateTime), N'1704260010', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A77000E25447 AS DateTime), N'1705110001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A77000E30222 AS DateTime), N'1705110002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A77E00851A08 AS DateTime), N'1705250001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7E50084424D AS DateTime), N'1706180001', N'ADMINMENU', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E3FCAA AS DateTime), N'1706180002', N'RESEARCHSUPPORT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E4BC57 AS DateTime), N'1706180004', N'STUDENT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79901889274 AS DateTime), N'1706180005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79901889274 AS DateTime), N'1706180005', N'DEPPRIDEP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79901889274 AS DateTime), N'1706180005', N'DEPPRIFAL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A799018889FB AS DateTime), N'1706180006', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A799018889FB AS DateTime), N'1706180006', N'DEPPRIDEP', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A799018889FB AS DateTime), N'1706180006', N'DEPPRIFAL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E6AE23 AS DateTime), N'1706180007', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E6AE23 AS DateTime), N'1706180007', N'RESEARCHSUPPORT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E6AE23 AS DateTime), N'1706180007', N'STUDENT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E71D99 AS DateTime), N'1706180009', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E71D99 AS DateTime), N'1706180009', N'RESEARCHSUPPORT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E71D99 AS DateTime), N'1706180009', N'STUDENT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600FEAC32 AS DateTime), N'1706180010', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600FEAC32 AS DateTime), N'1706180010', N'RESEARCHSUPPORT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600FEAC32 AS DateTime), N'1706180010', N'STUDENT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82D0014547A AS DateTime), N'1708280001', N'ALL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160109AA43 AS DateTime), N'1708280004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160108CCB4 AS DateTime), N'1708290001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010AA67B AS DateTime), N'1708290002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010ACC82 AS DateTime), N'1708290003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160107A28B AS DateTime), N'1708290004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A7E30104F94A AS DateTime), N'1709030001', N'STUDENT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8100004DA62 AS DateTime), N'1710180001', N'ADMINMENU', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A819009013EE AS DateTime), N'1710240001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81900B27845 AS DateTime), N'1710240002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82D001D6182 AS DateTime), N'1710240003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81901013234 AS DateTime), N'1710240004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81E008F8F4B AS DateTime), N'1710240005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81800FCEF4C AS DateTime), N'1710240008', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160112EE58 AS DateTime), N'1710240009', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160113E300 AS DateTime), N'1710240010', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82D001CAAC7 AS DateTime), N'1710240011', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816011350D1 AS DateTime), N'1710240012', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160113A3B1 AS DateTime), N'1710240013', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160113AFF9 AS DateTime), N'1710240014', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81E0099CDED AS DateTime), N'1710240015', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160114449F AS DateTime), N'1710240016', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016BC713 AS DateTime), N'1710240017', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016BD312 AS DateTime), N'1710240018', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601074E37 AS DateTime), N'1710240019', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160114C331 AS DateTime), N'1710240020', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160114D95D AS DateTime), N'1710240021', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601155EFF AS DateTime), N'1710240022', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82400E899D4 AS DateTime), N'1710240023', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A821006380BD AS DateTime), N'1710240024', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A821006387E6 AS DateTime), N'1710240025', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82100638ED1 AS DateTime), N'1710240026', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010909DF AS DateTime), N'1710240031', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014D257E AS DateTime), N'1710240032', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160139F96E AS DateTime), N'1710240033', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816013A39C7 AS DateTime), N'1710240034', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816013A751D AS DateTime), N'1710240035', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816013A8D0A AS DateTime), N'1710240036', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601171F62 AS DateTime), N'1710240038', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601172AE0 AS DateTime), N'1710240039', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160149198C AS DateTime), N'1710240040', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601465FFF AS DateTime), N'1710240041', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601470777 AS DateTime), N'1710240042', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601471B76 AS DateTime), N'1710240043', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601764609 AS DateTime), N'1710240044', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160147A9AF AS DateTime), N'1710240045', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014D136D AS DateTime), N'1710240046', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601486034 AS DateTime), N'1710240047', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601488A95 AS DateTime), N'1710240048', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160149F42B AS DateTime), N'1710240049', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014ABBA8 AS DateTime), N'1710240050', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014B834B AS DateTime), N'1710240051', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014CAA1B AS DateTime), N'1710240052', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014C5953 AS DateTime), N'1710240053', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601497DFB AS DateTime), N'1710240054', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014C1F4A AS DateTime), N'1710240055', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014C0337 AS DateTime), N'1710240056', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014C6E92 AS DateTime), N'1710240057', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014C799C AS DateTime), N'1710240058', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014DE145 AS DateTime), N'1710240059', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014DBAB6 AS DateTime), N'1710240060', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81600CDC75B AS DateTime), N'1710240061', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010C82AF AS DateTime), N'1710240062', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014E78A6 AS DateTime), N'1710240063', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014EC4E4 AS DateTime), N'1710240064', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010CDF92 AS DateTime), N'1710240065', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010D03AE AS DateTime), N'1710240066', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010C8B81 AS DateTime), N'1710240067', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816010C9A46 AS DateTime), N'1710240068', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601699AF5 AS DateTime), N'1710240069', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016993CA AS DateTime), N'1710240070', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014F2D6C AS DateTime), N'1710240071', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014F5548 AS DateTime), N'1710240072', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816014F7162 AS DateTime), N'1710240073', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816015071EC AS DateTime), N'1710240074', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601511EFF AS DateTime), N'1710240075', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160166E253 AS DateTime), N'1710240076', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160166EDD0 AS DateTime), N'1710240077', N'ADMINDIRE', NULL, NULL)
GO
print 'Processed 200 total records'
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81601675C4C AS DateTime), N'1710240078', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160167747D AS DateTime), N'1710240079', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016A0625 AS DateTime), N'1710240080', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016A156B AS DateTime), N'1710240081', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016A43E0 AS DateTime), N'1710240082', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016AE3C9 AS DateTime), N'1710240083', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81600CD087E AS DateTime), N'1710240084', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160150398C AS DateTime), N'1710240085', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160167B89E AS DateTime), N'1710240086', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160167F2CC AS DateTime), N'1710240087', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160168B0DF AS DateTime), N'1710240088', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8160168FD4E AS DateTime), N'1710240089', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016A6507 AS DateTime), N'1710240090', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016A75D4 AS DateTime), N'1710240091', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A816016AC1AD AS DateTime), N'1710240092', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82D0014CB6E AS DateTime), N'1710240093', N'ALL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82D0014D313 AS DateTime), N'1710240094', N'ALL', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A817005E7A0E AS DateTime), N'1710250001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A817005E882D AS DateTime), N'1710250002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A817005EF3AB AS DateTime), N'1710250003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81700618E08 AS DateTime), N'1710250004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A817006195EB AS DateTime), N'1710250005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81700619EC4 AS DateTime), N'1710250006', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8170061A74F AS DateTime), N'1710250007', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8170061B0CE AS DateTime), N'1710250008', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81700642ED2 AS DateTime), N'1710250009', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81800DBF79E AS DateTime), N'1710260001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81800DC62DE AS DateTime), N'1710260002', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81800DC983D AS DateTime), N'1710260003', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A81800DCE944 AS DateTime), N'1710260004', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A818010B965B AS DateTime), N'1710260005', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A8210062EEB8 AS DateTime), N'1711040001', N'ADMINDIRE', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A82C01760C94 AS DateTime), N'1711150001', N'SUPADMIN', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79B007A3485 AS DateTime), N'TOP1', N'STUDENT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E33EAF AS DateTime), N'TOP2', N'STUDENT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E3A79C AS DateTime), N'TOP31', N'RESEARCHSUPPORT', NULL, NULL)
INSERT [dbo].[sysmenupriority] ([edituser], [edittime], [lock], [lockdate], [sysmenucode], [prioritycode], [whois], [extensioncode]) VALUES (NULL, NULL, 0, CAST(0x0000A79600E3AB47 AS DateTime), N'TOP32', N'RESEARCHSUPPORT', NULL, NULL)
/****** Object:  Table [dbo].[sysmenu]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysmenu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sysmenu](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](max) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[parentcode] [varchar](10) NULL,
	[theorder] [int] NULL,
	[icon] [nvarchar](1000) NULL,
	[link] [nvarchar](1000) NULL,
	[prioritycode] [nvarchar](100) NULL,
	[thetype] [varchar](10) NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
	[img] [nvarchar](200) NULL,
	[imgtitle] [nvarchar](500) NULL,
	[imgnote] [nvarchar](max) NULL,
	[glance] [nvarchar](max) NULL,
	[extensioncode] [varchar](200) NULL,
	[lang] [varchar](10) NULL,
 CONSTRAINT [PK_sysmenu_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'01', NULL, N'Quản lý Vật tư', NULL, N'', CAST(0x0000A81600CE8F4E AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'', 4, N'fa-plug', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'01', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'03', NULL, N'Hệ thống', N'Ghi chú', N'', CAST(0x0000A81600C82EC3 AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'', 2, N'fa-home', N'#', N'ADMINMENU', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'03', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'033', N'BACKEND', N'Menu cho Giáo viên', NULL, N'K12337', CAST(0x0000A7DD00F14D50 AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'1702060001', 4, NULL, N'/sysmenu/backend', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612250001', NULL, N'Danh mục chung', NULL, N'', CAST(0x0000A816010B0E2A AS DateTime), 0, CAST(0x0000A6E7011EF074 AS DateTime), N'1702060003', 1, N'fa-list', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1612250001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612260001', N'about', N'About LQDTU', N'<p>Le Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management.</p>

<p><img alt="" src="/images/uploads/Hydrangeas.jpg" style="height:225px; width:300px" /></p>
', N'K12337', CAST(0x0000A6F40071D320 AS DateTime), 0, CAST(0x0000A6E801245868 AS DateTime), N'', 1, NULL, NULL, NULL, N'FRONTEND', N'', N'HVKTQS', N'/images/2017/01/Hydrangeas.jpg', N'Le Quy Don Technical University', N'Le Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management', N'<h2>LQDTU at a glance</h2>

<h3>Opened 1966</h3>

<h3>Student Enrollment</h3>

<ul>
	<li>Undergraduates: 12,000</li>
	<li>Graduates: 1,228</li>
</ul>

<h3>Campus</h3>

<ul>
	<li>236 Hoang Quoc Viet Street, Bac Tu Liem, Hanoi, Vietnam.</li>
	<li>Me Linh Street, Vinh Yen City, Vinh Phuc Province, Vietnam.</li>
	<li>71 Cong Hoa Street, Tan Binh District, Ho Chi Minh City, Vietnam</li>
	<li>Kieu Mai, Phuong Canh, Bac Tu Liem, Hanoi, Vietnam</li>
</ul>

<h3>Research</h3>

<ul>
	<li>Ministerial Research Projects: 29</li>
	<li>Field Research Projects: 26</li>
	<li>University Research Projects: 233</li>
</ul>

<h3>Faculty</h3>

<ul>
	<li>Faculties (including 8 engineering faculties): 10</li>
	<li>Institutes: 3</li>
	<li>Research Centers: 10</li>
	<li>Departments:41 and Laboratories:63</li>
	<li>Company: 01</li>
</ul>

<p><a href="ABU_50th.html">Learn more</a></p>
', N'1612260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612260002', NULL, N'Danh mục TTBKT', NULL, N'', CAST(0x0000A816010B86F0 AS DateTime), 0, CAST(0x0000A6E80158F486 AS DateTime), N'1702060003', 2, N'fa-list-ul', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1612260002', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612270001', NULL, N'Máy bay', NULL, N'', CAST(0x0000A816010B5506 AS DateTime), 0, CAST(0x0000A6E900252E3E AS DateTime), N'1702060003', 3, N'fa-fighter-jet', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1612270001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310001', N'academics', N' Academic', N'Le Quy Don Technical University (Vietnamese: Đại học Kỹ thuật Lê Quý Đôn), founded 1966, is one of the national key universities in Vietnam that offers multidisciplinary undergraduate and postgraduate training in engineering, technology and management. This university is also one of the largest technical universities in Vietnam.', N'K12337', CAST(0x0000A6F4007021EF AS DateTime), 0, CAST(0x0000A6ED00929FC3 AS DateTime), N'', 2, NULL, NULL, NULL, N'FRONTEND', N'', N'HVKTQS', N'/images/acd_new.png', N'Le Quy Don Technical University', N'e Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management.', N' <h2>Academic at a Glance</h2>
            <h3>Academics</h3>
            <ul>
              <li><span>Bachelor''s degree: 45 programs</span></li>
              <li><span>Master''s degree: 27 programs</span></li>
              <li><span>Doctoral degree: 20 programs</span></li>
            </ul>
            <h3>Faculties</h3>
            <ul>
              <li>Information Technology</li>
              <li>Chemico-Physical Engineering</li>
              <li>Mechanical Engineering</li>
              <li>Automotive Engineering</li>
              <li>Aerospace Engineering</li>
              <li>Radio-Electronic Engineering</li>
              <li>Control Engineering</li>
              <li>Foreign Languages</li>
              <li>Technical Management </li>
              <li>Social Sciences & Humanities</li>
            </ul>
            <h3>Majors with highest enrollment</h3>
            <ul>
              <li>Computer Science</li>
              <li>Information Systems</li>
              <li>Radar and Navigation</li>
              <li>Aerospace Control Systems</li>
            </ul>
                <p class="more-link"><a href="ACA_Under.html"><i class="fa fa-chevron-circle-right" aria-hidden="true"></i> <span>Learn more</span></a></p>
', N'1612310001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310002', N'research', N' Research', N'Research in the University makes up a significant part of its activities. Possessing a large number of scientists and modern equipment, LQDTU has been successful in scientific research, making great contributions to national industrialization and modernization.', N'K12337', CAST(0x0000A6ED0093111E AS DateTime), 0, CAST(0x0000A6ED0093111E AS DateTime), N'', 3, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/hvktqsAC.png', N'Le Quy Don Technical University', N'Research in the University makes up a significant part of its activities.', N'<h2>Research at a Glance</h2>
            <h3>RESEARCH STAFF</h3>
            <ul>
              <li>Professors, Associate Professors:       76</li>
              <li>Doctors of Science, Doctors of Philosophy:    345</li>
              <li>Masters of Science:           494</li>
              <li>Engineers:              465</li>
            </ul>
            <h3>Research projects (2011-2015)</h3>
            <ul>
              <li>National Research Projects: 23</li>
              <li>Ministerial Research Projects: 29</li>
              <li>Field Research Projects: 26</li>
              <li>University Research Projects: 233</li>
            </ul>
            <h3>Research products</h3>
            <ul>
              <li>Research papers: 1480</li>
              <li>International journal papers: 332</li>
              <li>International conferences: 10</li>
              <li>Theses &amp dissertations: 6,495 </li>
            </ul>
            <p class="more-link"><a href="RES_Overview.html"><i class="fa fa-chevron-circle-right" aria-hidden="true"></i> <span>Learn more</span></a></p>
', N'1612310002', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310003', N'Cooperation', N' International Cooperation', N'With the aim of becoming a research university, improving the quality in education and research, LQDTU pays high attention to development of international cooperation.', N'K12337', CAST(0x0000A6F4006D8200 AS DateTime), 0, CAST(0x0000A6ED00937AE2 AS DateTime), N'', 4, NULL, NULL, NULL, N'FRONTEND', N'', N'HVKTQS', N'/images/hvktqsCO.png', N'Le Quy Don Technical University', N'With the aim of becoming a research university, improving the quality in education and research, LQDTU pays high attention to development of international cooperation.', N'<h2>International Cooperation at a Glance</h2>
            <h3>Activities:</h3>
            <ul>
              <li>Exchange of students and teaching staff</li>
              <li>Exchange of information and experience</li>
              <li>Development of joint academic and research program</li>
              <li>Internship</li>
              <li>Participation in scientific conferences, workshops, symposia</li>
              <li>Conducting joint research projects</li>
            </ul>
            <h3>Cooperation in training and research</h3>
            <ul>
              <li>Universities: 50</li>
              <li>Research institutes: 50</li>
              <li>Countries: 30</li>
            </ul>
            <p class="more-link"><a href="COP_Intro.html"><i class="fa fa-chevron-circle-right" aria-hidden="true"></i> <span>Learn more</span></a></p>
', N'1612310003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310004', N'ABU_50th', N'LQDTU''S 50TH ANNIVERSARY', N'Le Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management.', N'K12337', CAST(0x0000A6ED00955912 AS DateTime), 0, CAST(0x0000A6ED00944F3F AS DateTime), N'1612260001', 1, NULL, NULL, NULL, N'FRONTEND', N'', N'HVKTQS', N'/images/about1.png', NULL, NULL, NULL, N'1612260001.1612260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310005', N'ABU_Introduction', N'Introduction', N'The University academic staff today consists of 76 Professors and Associate Professors, 347 Doctors of Philosophy and Doctors of Science. Among teaching staff there is a number of world-class engineering and technology experts.', N'K12337', CAST(0x0000A6ED0095950B AS DateTime), 0, CAST(0x0000A6ED0094C134 AS DateTime), N'1612260001', 2, NULL, NULL, NULL, N'FRONTEND', N'', N'HVKTQS', N'/images/about2.png', NULL, NULL, NULL, N'1612260001.1612260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310006', N'ABU_History', N'History', N'August 8th 1966: The 146/CP Decision of the Government marked the establishment of the second branch of Hanoi University of Science and Technology as a fully functioning university.', N'K12337', CAST(0x0000A6ED009585D9 AS DateTime), 0, CAST(0x0000A6ED009540DE AS DateTime), N'1612260001', 3, NULL, NULL, NULL, N'FRONTEND', N'', N'HVKTQS', N'/images/about3.png', NULL, NULL, NULL, N'1612260001.1612260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310007', N'ABU_role', N'Role & Mission', N'Providing a continuing source of highly qualified specialists and engineers in the field of science and technology for industrialization and modernization of the country.', N'K12337', CAST(0x0000A6ED0095F1EA AS DateTime), 0, CAST(0x0000A6ED0095F1EB AS DateTime), N'1612260001', 4, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/about4.png', NULL, NULL, NULL, N'1612260001.1612260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310008', N'ABU_rectorate', N'Rectorate', N'The university is led by President Prof. Dr.Sc. NGUYEN CONG DINH and Acting President Ph.D TRAN TAN HUNG, governed by Vietnam Ministry of Education and Training.', N'K12337', CAST(0x0000A6ED009630EC AS DateTime), 0, CAST(0x0000A6ED009630F0 AS DateTime), N'1612260001', 5, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/about5.png', NULL, NULL, NULL, N'1612260001.1612260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310009', N'ABU_news', N'News & Events', N'Get the latest LQDTU news and information about upcoming events on campus.', N'K12337', CAST(0x0000A6ED009681C9 AS DateTime), 0, CAST(0x0000A6ED009681CE AS DateTime), N'1612260001', 6, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/re3.png', NULL, NULL, NULL, N'1612260001.1612260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310010', N'ACA_Under', N'Undergraduate', N'Le Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management.', N'K12337', CAST(0x0000A6ED0096F7C7 AS DateTime), 0, CAST(0x0000A6ED0096F7C7 AS DateTime), N'1612310001', 1, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/aca1.png', NULL, NULL, NULL, N'1612310001.1612310001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310011', N'ACA_Post', N'Postgraduate', N'Le Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management.', N'K12337', CAST(0x0000A6ED00974026 AS DateTime), 0, CAST(0x0000A6ED0097402A AS DateTime), N'1612310001', 2, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/aca2.png', NULL, NULL, NULL, N'1612310001.1612310001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310012', N'ACA_Faculty', N'Faculties', N'Le Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management.', N'K12337', CAST(0x0000A6ED0097810A AS DateTime), 0, CAST(0x0000A6ED00978110 AS DateTime), N'1612310001', 3, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/aca4.png', NULL, NULL, NULL, N'1612310001.1612310001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310013', N'ACA_Library', N'Library', N'Le Quy Don Technical University is one of key national universities which offers multidisciplinary undergraduate and postgraduate training in engineering and management.', N'K12337', CAST(0x0000A6ED0097C5F2 AS DateTime), 0, CAST(0x0000A6ED0097C5F3 AS DateTime), N'1612310001', 4, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/aca3.png', NULL, NULL, NULL, N'1612310001.1612310001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310014', N'ACA_news', N'News & Events', N'Get the latest LQDTU news and information about upcoming events on campus.', N'K12337', CAST(0x0000A6ED0098199F AS DateTime), 0, CAST(0x0000A6ED0098199F AS DateTime), N'1612310001', 5, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/re3.png', NULL, NULL, NULL, N'1612310001.1612310001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310015', N'RES_Overview', N'Overview', N'Research in the University makes up a significant part of its activities. Possessing a large number of scientists and modern equipment, LQDTU has been successful in scientific research, making great contributions to national industrialization and modernization.', N'K12337', CAST(0x0000A6ED00987673 AS DateTime), 0, CAST(0x0000A6ED00987675 AS DateTime), N'1612310002', 1, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/rs1.png', NULL, NULL, NULL, N'1612310002.1612310002', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310016', N'RES_Project', N'Projects', N'In parallel with training activities, LQDTU has taken an active participation in doing scientific research and has gained remarkable achievements, among which there are tens of prizes, state and ministerial level.', N'K12337', CAST(0x0000A6ED0098AD39 AS DateTime), 0, CAST(0x0000A6ED0098AD45 AS DateTime), N'1612310002', 2, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/rs2.png', NULL, NULL, NULL, N'1612310002.1612310002', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310017', N'RES_Library', N'Library', N'In recent years, LQDTU has gained significant progress in strengthening the exchange and cooperation in the field of innovation and development of science and technology. It has hosted quite a few international conferences and seminars attracting a lot of experts -  Vietnamese and foreign scientists from research institutes, universities and companies.', N'K12337', CAST(0x0000A6ED0098F9F8 AS DateTime), 0, CAST(0x0000A6ED0098F9F8 AS DateTime), N'1612310002', 3, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/rs3.png', NULL, NULL, NULL, N'1612310002.1612310002', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310018', N'RES_news', N'News & Events ', N'Get the latest LQDTU news and information about upcoming events on campus.', N'K12337', CAST(0x0000A6ED00993B52 AS DateTime), 0, CAST(0x0000A6ED00993B53 AS DateTime), N'1612310002', 4, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/re3.png', NULL, NULL, NULL, N'1612310002.1612310002', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310019', N'COP_Intro', N'Introduction', N'With the aim of becoming a research university, improving the quality in education and research, LQDTU pays high attention to development of international cooperation.', N'K12337', CAST(0x0000A6ED00998B47 AS DateTime), 0, CAST(0x0000A6ED00998B48 AS DateTime), N'1612310003', 1, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/re1.png', NULL, NULL, NULL, N'1612310003.1612310003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310020', N'COP_Office', N'Internation Cooperation Office ', N'Provide consultancy for the Rector in planning, managing and organizing activities to sustain the University’s relationship with international universities, research institutes.', N'K12337', CAST(0x0000A6ED0099C6F7 AS DateTime), 0, CAST(0x0000A6ED0099C6F7 AS DateTime), N'1612310003', 2, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/re2.png', NULL, NULL, NULL, N'1612310003.1612310003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310021', N'COP_news', N'News & Events ', N'Get the latest LQDTU news and information about upcoming events on campus.', N'K12337', CAST(0x0000A6ED009A054B AS DateTime), 0, CAST(0x0000A6ED009A054B AS DateTime), N'1612310003', 3, NULL, NULL, NULL, N'FRONTEND', NULL, N'HVKTQS', N'/images/re3.png', NULL, NULL, NULL, N'1612310003.1612310003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310023', N'LQDTU50', N'LQDTU 50', NULL, N'K12337', CAST(0x0000A6ED009B1C39 AS DateTime), 0, CAST(0x0000A6ED009B1C39 AS DateTime), N'1612310004', 1, NULL, N'/ABU_50th.html', NULL, N'FRONTEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1612260001.1612260001.1612310004', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310024', N'LQDTU_Facts', N'LQDTU Facts', NULL, N'K12337', CAST(0x0000A6ED009B55FD AS DateTime), 0, CAST(0x0000A6ED009B55FE AS DateTime), N'1612310005', 1, NULL, N'/ABU_Introduction.html', NULL, N'FRONTEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1612260001.1612260001.1612310005', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310025', N'LQDTU_History', N'History', NULL, N'K12337', CAST(0x0000A6ED009B94B2 AS DateTime), 0, CAST(0x0000A6ED009B94B2 AS DateTime), N'1612310006', 1, NULL, N'/ABU_History.html', NULL, N'FRONTEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1612260001.1612260001.1612310006', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310026', N'LQDTU_Role', N'Role', NULL, N'K12337', CAST(0x0000A6ED009BCC25 AS DateTime), 0, CAST(0x0000A6ED009BCC25 AS DateTime), N'1612310007', 1, NULL, N'/ABU_role.html', NULL, N'FRONTEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1612260001.1612260001.1612310007', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310027', N'LQDTU_Mission', N'Mission', NULL, N'K12337', CAST(0x0000A6ED009BF685 AS DateTime), 0, CAST(0x0000A6ED009BF686 AS DateTime), N'1612310007', 2, NULL, N'/ABU_role.html', NULL, N'FRONTEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1612260001.1612260001.1612310007', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310028', N'LQDTU_Rectorate', N'Rectorate', NULL, N'K12337', CAST(0x0000A6ED009C4C43 AS DateTime), 0, CAST(0x0000A6ED009C4C49 AS DateTime), N'1612310008', 1, NULL, N'/ABU_rectorate.html', NULL, N'FRONTEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1612260001.1612260001.1612310008', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1612310029', N'ABU_news_Detail', N'Detail', NULL, N'K12337', CAST(0x0000A6ED009C883A AS DateTime), 0, CAST(0x0000A6ED009C883B AS DateTime), N'1612310009', 1, NULL, N'/NEW_home.html', NULL, N'FRONTEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1612260001.1612260001.1612310009', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702060001', NULL, N'Hệ thống mới', NULL, N'', CAST(0x0000A81500A1009E AS DateTime), 0, CAST(0x0000A71200929243 AS DateTime), N'1702060001', 1, N'fa-asterisk', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'Không có', N'', N'1702060001.1702060001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702060003', NULL, N'Quản lý TTBKT', NULL, N'', CAST(0x0000A8160106503C AS DateTime), 0, CAST(0x0000A712009B8C7C AS DateTime), N'', 5, N'fa-rocket', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702060003', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702060004', NULL, N'Quản lý Nhân sự', NULL, N'', CAST(0x0000A81800C6B871 AS DateTime), 0, CAST(0x0000A71200B2D628 AS DateTime), N'', 3, N'fa-user', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702060004', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702060008', NULL, N'TTBKT Khác', NULL, N'', CAST(0x0000A816010C4CC8 AS DateTime), 0, CAST(0x0000A712010079D6 AS DateTime), N'1702060003', 4, N'fa-binoculars', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702060008', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702060009', NULL, N'Báo cáo/In ấn', NULL, N'', CAST(0x0000A816010B1805 AS DateTime), 0, CAST(0x0000A71201033972 AS DateTime), N'1702060003', 5, N'fa-print', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702060009', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702070001', NULL, N'Danh mục chung', NULL, N'', CAST(0x0000A81601077C76 AS DateTime), 0, CAST(0x0000A713005E20FB AS DateTime), N'1702060004', 1, N'fa-list', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702070001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702070006', NULL, N'Quản lý Hồ sơ', NULL, N'', CAST(0x0000A816010A25EF AS DateTime), 0, CAST(0x0000A713017497E5 AS DateTime), N'1702060004', 3, N'fa-id-card-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702070006', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702080001', N'SACN', N'Quản lý chức năng nghiệp vụ', NULL, N'K12337', CAST(0x0000A760017AA39F AS DateTime), 1, CAST(0x0000A71400E42FC1 AS DateTime), N'1702060001', 5, NULL, N'#', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702080002', N'SAND', N'Quản lý Giáo viên', NULL, N'K12337', CAST(0x0000A7DD00F1E613 AS DateTime), 1, CAST(0x0000A71400E5110D AS DateTime), N'1702060001', 6, NULL, N'#', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702080003', N'SAQN', N'Phân quyền sử dụng', NULL, N'K12337', CAST(0x0000A7DD00F1C914 AS DateTime), 0, CAST(0x0000A71400E55C90 AS DateTime), N'1702080002', 2, NULL, N'#', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001.1702080002', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702080007', N'SANK', N'Nhật ký sử dụng hệ thống', NULL, N'K12337', CAST(0x0000A760017AB493 AS DateTime), 1, CAST(0x0000A71400E63C4E AS DateTime), N'1702060001', 11, NULL, N'#', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702080008', N'SATS', N'Tham số hệ thống', NULL, N'K12337', CAST(0x0000A760017ABE42 AS DateTime), 1, CAST(0x0000A71400E67B05 AS DateTime), N'1702060001', 12, NULL, N'#', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702080011', N'SAMK', N'Quản lý mật khẩu', NULL, N'K12337', CAST(0x0000A760017B73B6 AS DateTime), 0, CAST(0x0000A71400E7114A AS DateTime), N'1702080002', 8, NULL, N'#', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001.1702080002', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702080012', N'USERPROFILE', N'Hồ sơ Giáo viên', NULL, N'K12337', CAST(0x0000A7DD00F1BF20 AS DateTime), 0, CAST(0x0000A71400E9B3D7 AS DateTime), N'1702080002', 1, NULL, N'/staff', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001.1702080002', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702240001', NULL, N'Đăng xuất', NULL, N'00001', CAST(0x0000A82D001751E7 AS DateTime), 0, CAST(0x0000A72400EBB0BC AS DateTime), N'03', 2, N'fa-sign-out', N'/admin/logout', N'USER', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702240001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702240004', NULL, N'Danh mục chung', NULL, N'', CAST(0x0000A816010902C5 AS DateTime), 0, CAST(0x0000A72400ECACE0 AS DateTime), N'01', 1, N'fa-list', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702240004', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1702240006', NULL, N'Đổi mật khẩu', NULL, N'00001', CAST(0x0000A82D00166E15 AS DateTime), 0, CAST(0x0000A72400ED620D AS DateTime), N'03', 3, N'fa-key', N'/admin/changepass', N'USER', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1702240006', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1703070001', NULL, N'Danh mục VT', NULL, N'', CAST(0x0000A816010A6352 AS DateTime), 0, CAST(0x0000A72F010A8091 AS DateTime), N'01', 3, N'fa-microchip', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1703070001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180001', N'TOPMENU', N'Menu cho Sinh viên', NULL, N'K12337', CAST(0x0000A7E500841E29 AS DateTime), 0, CAST(0x0000A79600E0C8AC AS DateTime), N'1702060001', 3, NULL, N'/sysmenu/topmenu', N'ADMINMENU', N'BACKEND', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180002', N'MANDEPREPO', N'Báo cáo hoạt động', NULL, N'K12337', CAST(0x0000A79600E3FCA9 AS DateTime), 0, CAST(0x0000A79600E3FCAA AS DateTime), N'TOP3', 303, N'fa-dashboard', N'#', N'RESEARCHSUPPORT', N'TOPMENU', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'TOP3.TOP3', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180003', N'REPOR', N'Báo cáo thống kê', NULL, N'K12337', CAST(0x0000A79600E421EA AS DateTime), 0, CAST(0x0000A79600E421EA AS DateTime), N'', 400, N'fa-dashboard', N'#', NULL, N'TOPMENU', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180004', N'PERREPOR', N'Thống kê tải ĐT&NCKH', NULL, N'K12337', CAST(0x0000A79600E4BC57 AS DateTime), 0, CAST(0x0000A79600E48001 AS DateTime), N'1706180003', 401, N'fa-dashboard', N'/report/reports.aspx', N'PRESEARCH', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180003.1706180003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180005', N'REPPAPER', N'Tổng hợp bài báo', NULL, N'K12337', CAST(0x0000A79901889274 AS DateTime), 0, CAST(0x0000A79600E540DE AS DateTime), N'1706180003', 402, N'fa-dashboard', N'/report/syntheticreport.aspx', N'DEPPRIDEP,DEPPRIFAL,ADMINDIRE', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180003.1706180003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180006', N'REPPROJECT', N'Tổng hợp đề tài', NULL, N'K12337', CAST(0x0000A799018889FB AS DateTime), 0, CAST(0x0000A79600E65FA5 AS DateTime), N'1706180003', 403, N'fa-dashboard', N'/report/reportproject.aspx', N'DEPPRIDEP,DEPPRIFAL,ADMINDIRE', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180003.1706180003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180007', N'REPREPLY', N'Phản hồi', NULL, N'K12337', CAST(0x0000A79600E6AE23 AS DateTime), 0, CAST(0x0000A79600E6AE23 AS DateTime), N'', 500, N'fa-dashboard', N'/personal/replay.aspx', N'PRESEARCH,RESEARCHSUPPORT,ADMINDIRE', N'TOPMENU', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180007', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180008', N'REPHELP', N'Hướng dẫn', NULL, N'K12337', CAST(0x0000A79600E6C7D6 AS DateTime), 0, CAST(0x0000A79600E6C7D9 AS DateTime), N'', 600, N'fa-dashboard', N'#', NULL, N'TOPMENU', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180008', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180009', N'REPH', N'Tài liệu hướng dẫn', NULL, N'K12337', CAST(0x0000A79600E71D98 AS DateTime), 0, CAST(0x0000A79600E71D99 AS DateTime), N'1706180008', 601, N'fa-dashboard', N'/home/help.aspx', N'PRESEARCH,RESEARCHSUPPORT,ADMINDIRE', N'TOPMENU', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180008.1706180008', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706180010', N'REPDEPV', N'Nhóm phát triển', NULL, N'K12337', CAST(0x0000A79600FEAC32 AS DateTime), 0, CAST(0x0000A79600E761AE AS DateTime), N'1706180008', 602, N'fa-dashboard', N'/home/developergroup', N'PRESEARCH,RESEARCHSUPPORT,ADMINDIRE', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'1706180008.1706180008', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1706230001', N'HOMEALL', N'Trang chủ', NULL, N'K12337', CAST(0x0000A7E30104D746 AS DateTime), 0, CAST(0x0000A79B007A4EFF AS DateTime), N'', 0, N'fa-dashboard', N'/home/index', NULL, N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, N'<p>a</p>
', N'1706230001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1708280001', NULL, N'Đăng nhập', NULL, N'00001', CAST(0x0000A82D00145479 AS DateTime), 0, CAST(0x0000A7DD00F352C1 AS DateTime), N'03', 1, N'fa-sign-in', N'/Admin/Login', N'ALL', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1708280001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1708280004', NULL, N'Danh mục Kho', NULL, N'', CAST(0x0000A8160109AA43 AS DateTime), 0, CAST(0x0000A7DD0112E27F AS DateTime), N'01', 2, N'fa-building', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1708280004', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1708290001', NULL, N'Báo cáo/In ấn', NULL, N'', CAST(0x0000A8160108CCB4 AS DateTime), 0, CAST(0x0000A7DE000CBF1C AS DateTime), N'1702060004', 4, N'fa-print', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1708290001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1708290002', NULL, N'Nhập/Xuất kho', NULL, N'', CAST(0x0000A816010AA67B AS DateTime), 0, CAST(0x0000A7DE000DB607 AS DateTime), N'01', 4, N'fa-refresh', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1708290002', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1708290003', NULL, N'Nghiệp vụ khác', NULL, N'', CAST(0x0000A816010ACC82 AS DateTime), 0, CAST(0x0000A7DE000E31C9 AS DateTime), N'01', 7, N'fa-list-ul', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1708290003', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1708290004', NULL, N'DM Đơn vị', NULL, N'', CAST(0x0000A8160107A28B AS DateTime), 0, CAST(0x0000A7DE00926D77 AS DateTime), N'1702060004', 2, N'fa-sitemap', N'/department', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1708290004', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1709030001', N'HELLO', N'HELLo', NULL, N'K12337', CAST(0x0000A7E30104F948 AS DateTime), 0, CAST(0x0000A7E30104F94A AS DateTime), N'', 1, NULL, N'#', N'STUDENT', N'TOPMENU', NULL, N'HVKTQS', NULL, NULL, NULL, N'<p>a</p>
', N'1709030001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710180001', NULL, N'HELLO', NULL, N'', CAST(0x0000A81000047A8D AS DateTime), 0, CAST(0x0000A8100004D03C AS DateTime), N'1702060001', 0, NULL, N'#', N'ADMINMENU', NULL, NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1702060001.1702060001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240001', NULL, N'Cấp bậc', NULL, N'', CAST(0x0000A819009013EE AS DateTime), 0, CAST(0x0000A81600A4E653 AS DateTime), N'1702070001', 1, N'fa-star-o', N'/armyrank', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240002', NULL, N'Chức vụ', NULL, N'', CAST(0x0000A81900B27845 AS DateTime), 0, CAST(0x0000A81600A5016C AS DateTime), N'1702070001', 2, N'fa-signal', N'/leveltitle', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240002', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240003', NULL, N'Dân tộc', NULL, N'00001', CAST(0x0000A82D001D6182 AS DateTime), 0, CAST(0x0000A81600A54C39 AS DateTime), N'1702070001', 3, N'fa-users', N'/admin/ethnic', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240003', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240004', NULL, N'Tôn giáo', NULL, N'', CAST(0x0000A81901013234 AS DateTime), 0, CAST(0x0000A81600A55DA7 AS DateTime), N'1702070001', 4, N'fa-connectdevelop', N'/Religion', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240004', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240005', NULL, N'Tỉnh, Huyện, Xã', NULL, N'', CAST(0x0000A81E008F8F4B AS DateTime), 0, CAST(0x0000A81600A57343 AS DateTime), N'1702070001', 5, N'fa-map-marker', N'/province', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240005', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240008', NULL, N'Hồ sơ CBNV', NULL, N'', CAST(0x0000A81800FCEF4C AS DateTime), 0, CAST(0x0000A81600A6886D AS DateTime), N'1702070006', 1, N'fa-suitcase', N'/staff', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240008', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240009', NULL, N'QT Đào tạo', NULL, N'', CAST(0x0000A8160112EE58 AS DateTime), 0, CAST(0x0000A81600A6BC2A AS DateTime), N'1702070006', 2, N'fa-graduation-cap', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240009', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240010', NULL, N'QT Công tác', NULL, N'', CAST(0x0000A8160113E300 AS DateTime), 0, CAST(0x0000A81600A724E0 AS DateTime), N'1702070006', 3, N'fa-share-alt', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240010', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240011', NULL, N'QT Cấp bậc', NULL, N'00001', CAST(0x0000A82D001CAAC7 AS DateTime), 0, CAST(0x0000A81600A7517A AS DateTime), N'1702070006', 4, N'fa-star-o', N'/armyrank', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240011', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240012', NULL, N'QT Chức vụ', NULL, N'', CAST(0x0000A816011350D1 AS DateTime), 0, CAST(0x0000A81600A76863 AS DateTime), N'1702070006', 5, N'fa-signal', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240012', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240013', NULL, N'QT Khen thưởng', NULL, N'', CAST(0x0000A8160113A3B1 AS DateTime), 0, CAST(0x0000A81600A77FE0 AS DateTime), N'1702070006', 6, N'fa-smile-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240013', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240014', NULL, N'QT Kỷ thuật', NULL, N'', CAST(0x0000A8160113AFF9 AS DateTime), 0, CAST(0x0000A81600A79A3D AS DateTime), N'1702070006', 7, N'fa-frown-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240014', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240015', NULL, N'Danh sách CBNV', NULL, N'', CAST(0x0000A81E0099CDED AS DateTime), 0, CAST(0x0000A81600A7F52D AS DateTime), N'1708290001', 1, N'fa-list-ol', N'/Stafflist', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240015', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240016', NULL, N'TH Cấp bậc', NULL, N'', CAST(0x0000A8160114449F AS DateTime), 0, CAST(0x0000A81600A86E91 AS DateTime), N'1708290001', 2, N'fa-bar-chart', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240016', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240017', NULL, N'TH Chức vụ', NULL, N'', CAST(0x0000A816016BC713 AS DateTime), 0, CAST(0x0000A81600A882A8 AS DateTime), N'1708290001', 3, N'fa-area-chart', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240017', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240018', NULL, N'TH Tuổi', NULL, N'', CAST(0x0000A816016BD312 AS DateTime), 0, CAST(0x0000A81600A8A690 AS DateTime), N'1708290001', 4, N'fa-line-chart', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240018', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240019', NULL, N'Quản lý Menu', NULL, N'', CAST(0x0000A81601074E37 AS DateTime), 0, CAST(0x0000A81600AAA284 AS DateTime), N'03', 4, N'fa-list-alt', N'/sysmenu/index', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240019', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240020', NULL, N'Phân loại VT', NULL, N'', CAST(0x0000A8160114C331 AS DateTime), 0, CAST(0x0000A81600AB3AEF AS DateTime), N'1702240004', 1, N'fa-cogs', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240020', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240021', NULL, N'Nhóm vật tư', NULL, N'', CAST(0x0000A8160114D95D AS DateTime), 0, CAST(0x0000A81600AB5921 AS DateTime), N'1702240004', 2, N'fa-object-group', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240021', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240022', NULL, N'Đơn vị tính', NULL, N'', CAST(0x0000A81601155EFF AS DateTime), 0, CAST(0x0000A81600AB7087 AS DateTime), N'1702240004', 3, N'fa-asterisk', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240022', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240023', NULL, N'Cấp kho', N'Qui định phân cấp của KHO', N'', CAST(0x0000A82400E899D4 AS DateTime), 0, CAST(0x0000A81600ABA03B AS DateTime), N'1702240004', 7, N'fa-list-ul', N'/Warehouselevel', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240023', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240024', NULL, N'Hãng SX', NULL, N'', CAST(0x0000A821006380BD AS DateTime), 0, CAST(0x0000A81600ABAE07 AS DateTime), N'1702240004', 4, N'fa-bug', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240024', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240025', NULL, N'Nhà cung cấp', NULL, N'', CAST(0x0000A821006387E6 AS DateTime), 0, CAST(0x0000A81600ABC3F5 AS DateTime), N'1702240004', 5, N'fa-truck', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240025', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240026', NULL, N'Phân cấp CL', NULL, N'', CAST(0x0000A82100638ED1 AS DateTime), 0, CAST(0x0000A81600ABDCF0 AS DateTime), N'1702240004', 6, N'fa-list-ol', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240026', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240031', NULL, N'Báo cáo/In ấn', NULL, N'', CAST(0x0000A816010909DF AS DateTime), 0, CAST(0x0000A81600AD852F AS DateTime), N'01', 6, N'fa-print', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240031', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240032', NULL, N'Tồn kho', NULL, N'', CAST(0x0000A816014D257E AS DateTime), 0, CAST(0x0000A81600AD9CB4 AS DateTime), N'1710240031', 1, N'fa-tasks', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240032', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240033', NULL, N'BC nhập', NULL, N'', CAST(0x0000A8160139F96E AS DateTime), 0, CAST(0x0000A81600ADB065 AS DateTime), N'1710240031', 2, N'fa-arrow-right', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240033', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240034', NULL, N'BC Xuất', NULL, N'', CAST(0x0000A816013A39C7 AS DateTime), 0, CAST(0x0000A81600ADBEF4 AS DateTime), N'1710240031', 3, N'fa-arrow-left', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240034', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240035', NULL, N'Thẻ kho', NULL, N'', CAST(0x0000A816013A751D AS DateTime), 0, CAST(0x0000A81600ADD3AB AS DateTime), N'1710240031', 4, N'fa-file-text-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240035', N'')
GO
print 'Processed 100 total records'
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240036', NULL, N'VT quá hạn', NULL, N'', CAST(0x0000A816013A8D0A AS DateTime), 0, CAST(0x0000A81600ADE60E AS DateTime), N'1710240031', 5, N'fa-gavel', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240036', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240038', NULL, N'Nhập', NULL, N'', CAST(0x0000A81601171F62 AS DateTime), 0, CAST(0x0000A81600AECC6B AS DateTime), N'1708290002', 1, N'fa-arrow-right', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240038', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240039', NULL, N'Xuất', NULL, N'', CAST(0x0000A81601172AE0 AS DateTime), 0, CAST(0x0000A81600AED5DF AS DateTime), N'1708290002', 2, N'fa-arrow-left', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240039', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240040', NULL, N'Chuyển nội bộ', NULL, N'', CAST(0x0000A8160149198C AS DateTime), 0, CAST(0x0000A81600AEEF24 AS DateTime), N'1708290002', 3, N'fa-exchange', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240040', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240041', NULL, N'VT tương đương', NULL, N'', CAST(0x0000A81601465FFF AS DateTime), 0, CAST(0x0000A81600AF9905 AS DateTime), N'1708290003', 1, N'fa-object-ungroup', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240041', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240042', NULL, N'Huỷ vật tư', NULL, N'', CAST(0x0000A81601470777 AS DateTime), 0, CAST(0x0000A81600AFE4A2 AS DateTime), N'1708290003', 2, N'fa-check-circle', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240042', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240043', NULL, N'Thanh lý VT', NULL, N'', CAST(0x0000A81601471B75 AS DateTime), 0, CAST(0x0000A81600AFF970 AS DateTime), N'1708290003', 3, N'fa-check-circle-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240043', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240044', NULL, N'Kiểm kê kho', NULL, N'', CAST(0x0000A81601764609 AS DateTime), 0, CAST(0x0000A81600B09BE8 AS DateTime), N'1708290003', 4, N'fa-calculator', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240044', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240045', NULL, N'Hạn mức lưu kho', NULL, N'', CAST(0x0000A8160147A9AF AS DateTime), 0, CAST(0x0000A81600B0B9EA AS DateTime), N'1708290003', 5, N'fa-clock-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240045', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240046', NULL, N'Tồn đầu', NULL, N'', CAST(0x0000A816014D136D AS DateTime), 0, CAST(0x0000A81600B0CDC2 AS DateTime), N'1708290003', 6, N'fa-tasks', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240046', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240047', NULL, N'Phân loại TTBKT', NULL, N'', CAST(0x0000A81601486034 AS DateTime), 0, CAST(0x0000A81600B19601 AS DateTime), N'1612250001', 1, N'fa-cogs', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240047', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240048', NULL, N'Nhóm ch.ngành', NULL, N'', CAST(0x0000A81601488A95 AS DateTime), 0, CAST(0x0000A81600B1B17F AS DateTime), N'1612250001', 2, N'fa-object-group', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240048', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240049', NULL, N'Lý lịch máy bay', NULL, N'', CAST(0x0000A8160149F42B AS DateTime), 0, CAST(0x0000A81600B29853 AS DateTime), N'1612270001', 1, N'fa-plane', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240049', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240050', NULL, N'TTBKT trên MB', NULL, N'', CAST(0x0000A816014ABBA8 AS DateTime), 0, CAST(0x0000A81600B2B52D AS DateTime), N'1612270001', 2, N'fa-steam', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240050', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240051', NULL, N'Giờ bay', NULL, N'', CAST(0x0000A816014B834B AS DateTime), 0, CAST(0x0000A81600B2DC41 AS DateTime), N'1612270001', 3, N'fa-tachometer', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240051', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240052', NULL, N'Lý lịch TTBKT', NULL, N'', CAST(0x0000A816014CAA1B AS DateTime), 0, CAST(0x0000A81600B31783 AS DateTime), N'1702060008', 1, N'fa-file-text-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240052', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240053', NULL, N'TTBKT trên TB', NULL, N'', CAST(0x0000A816014C5953 AS DateTime), 0, CAST(0x0000A81600B36122 AS DateTime), N'1702060008', 2, N'fa-steam', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240053', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240054', NULL, N'Tình trạng hỏng', NULL, N'', CAST(0x0000A81601497DFB AS DateTime), 0, CAST(0x0000A81600B3B4D3 AS DateTime), N'1612250001', 3, N'fa-chain-broken', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240054', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240055', NULL, N'Tình trạng hỏng', NULL, N'', CAST(0x0000A816014C1F4A AS DateTime), 0, CAST(0x0000A81600B4DFC4 AS DateTime), N'1612270001', 4, N'fa-chain-broken', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240055', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240056', NULL, N'Nhật ký hoạt động', NULL, N'', CAST(0x0000A816014C0337 AS DateTime), 0, CAST(0x0000A81600B50710 AS DateTime), N'1612270001', 5, N'fa-calendar', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240056', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240057', NULL, N'Tình trạng hỏng', NULL, N'', CAST(0x0000A816014C6E92 AS DateTime), 0, CAST(0x0000A81600B5B2BD AS DateTime), N'1702060008', 3, N'fa-chain-broken', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240057', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240058', NULL, N'Nhật ký hoạt động', NULL, N'', CAST(0x0000A816014C799C AS DateTime), 0, CAST(0x0000A81600B5C9C9 AS DateTime), N'1702060008', 4, N'fa-calendar', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240058', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240059', NULL, N'Danh sách TTBKT', NULL, N'', CAST(0x0000A816014DE145 AS DateTime), 0, CAST(0x0000A81600B6325E AS DateTime), N'1702060009', 1, N'fa-list-ul', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240059', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240060', NULL, N'Tình trạng hỏng', NULL, N'', CAST(0x0000A816014DBAB6 AS DateTime), 0, CAST(0x0000A81600B69F05 AS DateTime), N'1702060009', 2, N'fa-chain-broken', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240060', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240061', NULL, N'Quản lý BDSCTT', NULL, N'', CAST(0x0000A81600CDC75B AS DateTime), 0, CAST(0x0000A81600B6EC7D AS DateTime), N'', 6, N'fa-wrench', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240061', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240062', NULL, N'Danh mục chung', NULL, N'', CAST(0x0000A816010C82AF AS DateTime), 0, CAST(0x0000A81600B72BA5 AS DateTime), N'1710240061', 1, N'fa-list', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240062', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240063', NULL, N'Phân loại BDTT', NULL, N'', CAST(0x0000A816014E78A6 AS DateTime), 0, CAST(0x0000A81600B75D11 AS DateTime), N'1710240062', 1, N'fa-cogs', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240063', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240064', NULL, N'Phân loại T.Báo', NULL, N'', CAST(0x0000A816014EC4E4 AS DateTime), 0, CAST(0x0000A81600B78876 AS DateTime), N'1710240062', 2, N'fa-cog', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240064', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240065', NULL, N'BD Máy bay', NULL, N'', CAST(0x0000A816010CDF92 AS DateTime), 0, CAST(0x0000A81600B7C428 AS DateTime), N'1710240061', 2, N'fa-fighter-jet', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240065', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240066', NULL, N'BD TTBKT khác', NULL, N'', CAST(0x0000A816010D03AE AS DateTime), 0, CAST(0x0000A81600B7D6DA AS DateTime), N'1710240061', 3, N'fa-binoculars', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240066', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240067', NULL, N'Báo cáo/In ấn', NULL, N'', CAST(0x0000A816010C8B81 AS DateTime), 0, CAST(0x0000A81600B7FC50 AS DateTime), N'1710240061', 4, N'fa-print', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240067', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240068', NULL, N'Nghiệp vụ khác', NULL, N'', CAST(0x0000A816010C9A46 AS DateTime), 0, CAST(0x0000A81600B8123C AS DateTime), N'1710240061', 5, N'fa-list-ul', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240068', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240069', NULL, N'Chương trình BD', NULL, N'', CAST(0x0000A81601699AF5 AS DateTime), 0, CAST(0x0000A81600B88FE3 AS DateTime), N'1710240065', 100, N'fa-th', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240069', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240070', NULL, N'Chương trình TT', NULL, N'', CAST(0x0000A816016993CA AS DateTime), 0, CAST(0x0000A81600B89D22 AS DateTime), N'1710240065', 101, N'fa-th-large', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240070', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240071', NULL, N'Chu kỳ ', NULL, N'', CAST(0x0000A816014F2D6C AS DateTime), 0, CAST(0x0000A81600B95BA4 AS DateTime), N'1710240062', 3, N'fa-retweet', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240071', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240072', NULL, N'Mốc thời gian', NULL, N'', CAST(0x0000A816014F5548 AS DateTime), 0, CAST(0x0000A81600B9AB01 AS DateTime), N'1710240062', 4, N'fa-clock-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240072', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240073', NULL, N'Qui trình CN', NULL, N'', CAST(0x0000A816014F7162 AS DateTime), 0, CAST(0x0000A81600B9C0C9 AS DateTime), N'1710240062', 5, N'fa-random', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240073', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240074', NULL, N'Công cụ sử dụng', NULL, N'', CAST(0x0000A816015071EC AS DateTime), 0, CAST(0x0000A81600BAE32F AS DateTime), N'1710240062', 6, N'fa-gavel', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240074', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240075', NULL, N'Vật tư sử dụng', NULL, N'', CAST(0x0000A81601511EFF AS DateTime), 0, CAST(0x0000A81600BAF66A AS DateTime), N'1710240062', 7, N'fa-trello', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240075', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240076', NULL, N'Kế hoạch BD', NULL, N'', CAST(0x0000A8160166E253 AS DateTime), 0, CAST(0x0000A81600BB4473 AS DateTime), N'1710240065', 1, N'fa-list', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240076', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240077', NULL, N'Kế hoạch TT', NULL, N'', CAST(0x0000A8160166EDD0 AS DateTime), 0, CAST(0x0000A81600BB88C7 AS DateTime), N'1710240065', 2, N'fa-list-ul', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240077', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240078', NULL, N'Thông báo KT', NULL, N'', CAST(0x0000A81601675C4C AS DateTime), 0, CAST(0x0000A81600BBB908 AS DateTime), N'1710240065', 3, N'fa-comment-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240078', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240079', NULL, N'Phiếu công việc', NULL, N'', CAST(0x0000A8160167747D AS DateTime), 0, CAST(0x0000A81600BBEE61 AS DateTime), N'1710240065', 4, N'fa-file-text-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240079', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240080', NULL, N'Kế hoạch BDTT', NULL, N'', CAST(0x0000A816016A0625 AS DateTime), 0, CAST(0x0000A81600BCC80A AS DateTime), N'1710240066', 1, N'fa-list', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240080', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240081', NULL, N'Thông báo KT', NULL, N'', CAST(0x0000A816016A156B AS DateTime), 0, CAST(0x0000A81600BCDB40 AS DateTime), N'1710240066', 2, N'fa-comment-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240081', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240082', NULL, N'Phiếu công việc', NULL, N'', CAST(0x0000A816016A43E0 AS DateTime), 0, CAST(0x0000A81600BCF037 AS DateTime), N'1710240066', 3, N'fa-file-text-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240082', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240083', NULL, N'C.Trình BDTT', NULL, N'', CAST(0x0000A816016AE3C9 AS DateTime), 0, CAST(0x0000A81600BD0576 AS DateTime), N'1710240066', 100, N'fa-th', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240083', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240084', NULL, N'Quản lý NVKT', NULL, N'', CAST(0x0000A81600CD087E AS DateTime), 0, CAST(0x0000A81600BD4D6B AS DateTime), N'', 7, N'fa-user-md', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240084', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240085', NULL, N'Hướng dẫn SD', NULL, N'', CAST(0x0000A8160150398C AS DateTime), 0, CAST(0x0000A81600BD6983 AS DateTime), N'', 99, N'fa-question-circle-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240085', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240086', NULL, N'Gói công việc', NULL, N'', CAST(0x0000A8160167B89D AS DateTime), 0, CAST(0x0000A81600BE5F51 AS DateTime), N'1710240065', 5, N'fa-spinner', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240086', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240087', NULL, N'Phiếu CV bổ sung', NULL, N'', CAST(0x0000A8160167F2CC AS DateTime), 0, CAST(0x0000A81600BE8334 AS DateTime), N'1710240065', 6, N'fa-file-text', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240087', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240088', NULL, N'Kết quả BDTT', NULL, N'', CAST(0x0000A8160168B0DF AS DateTime), 0, CAST(0x0000A81600BE9E03 AS DateTime), N'1710240065', 7, N'fa-clipboard', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240088', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240089', NULL, N'Đăng ký BDTT', NULL, N'', CAST(0x0000A8160168FD4E AS DateTime), 0, CAST(0x0000A81600BEB12B AS DateTime), N'1710240065', 8, N'fa-check-square', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240089', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240090', NULL, N'Gói công việc', NULL, N'', CAST(0x0000A816016A6507 AS DateTime), 0, CAST(0x0000A81600BF09AD AS DateTime), N'1710240066', 4, N'fa-spinner', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240090', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240091', NULL, N'Phiếu CV bổ sung', NULL, N'', CAST(0x0000A816016A75D4 AS DateTime), 0, CAST(0x0000A81600BF2CD5 AS DateTime), N'1710240066', 5, N'fa-file-text', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240091', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240092', NULL, N'Đăng ký BDTT', NULL, N'', CAST(0x0000A816016AC1AD AS DateTime), 0, CAST(0x0000A81600BF4A7B AS DateTime), N'1710240066', 6, N'fa-check-square', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240092', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240093', NULL, N'Nội dung', NULL, N'00001', CAST(0x0000A82D0014CB6E AS DateTime), 0, CAST(0x0000A81600BFAF36 AS DateTime), N'1710240085', 1, N'fa-book', N'#', N'ALL', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240093', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710240094', NULL, N'Military ERP 2017', NULL, N'00001', CAST(0x0000A82D0014D313 AS DateTime), 0, CAST(0x0000A816016D5F42 AS DateTime), N'1710240085', 2, N'fa-registered', N'#', N'ALL', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710240094', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250001', NULL, N'Giờ HĐ máy bay', NULL, N'', CAST(0x0000A817005E7A0E AS DateTime), 0, CAST(0x0000A817005B52EC AS DateTime), N'1710240067', 1, N'fa-tachometer', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250002', NULL, N'Hỏng hóc MB', NULL, N'', CAST(0x0000A817005E882D AS DateTime), 0, CAST(0x0000A817005E1CC1 AS DateTime), N'1710240067', 2, N'fa-chain-broken', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250002', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250003', NULL, N'TTBKT trên MB', NULL, N'', CAST(0x0000A817005EF3AB AS DateTime), 0, CAST(0x0000A817005ED121 AS DateTime), N'1710240067', 3, N'fa-steam', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250003', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250004', NULL, N'KT hết tổng NHSD', NULL, N'', CAST(0x0000A81700618E08 AS DateTime), 0, CAST(0x0000A817005F46D8 AS DateTime), N'1710240067', 4, N'fa-hourglass-end', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250004', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250005', NULL, N'KT hết theo NHSD', NULL, N'', CAST(0x0000A817006195EB AS DateTime), 0, CAST(0x0000A817005F7FC1 AS DateTime), N'1710240067', 5, N'fa-hourglass-half', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250005', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250006', NULL, N'KT hết tổng TM', NULL, N'', CAST(0x0000A81700619EC4 AS DateTime), 0, CAST(0x0000A817005FDFEF AS DateTime), N'1710240067', 6, N'fa-hourglass-end', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250006', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250007', NULL, N'KT hết theo TM', NULL, N'', CAST(0x0000A8170061A74F AS DateTime), 0, CAST(0x0000A817005FF85D AS DateTime), N'1710240067', 7, N'fa-hourglass-half', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250007', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250008', NULL, N'KT hết theo CK', NULL, N'', CAST(0x0000A8170061B0CE AS DateTime), 0, CAST(0x0000A81700602452 AS DateTime), N'1710240067', 8, N'fa-hourglass-end', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250008', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710250009', NULL, N'Phiếu YC bay KT', NULL, N'', CAST(0x0000A81700642ED2 AS DateTime), 0, CAST(0x0000A81700624A54 AS DateTime), N'1710240068', 1, N'fa-check-square-o', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710250009', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710260001', NULL, N'Danh mục chung', NULL, N'', CAST(0x0000A81800DBF79E AS DateTime), 0, CAST(0x0000A81800DBF79E AS DateTime), N'1710240084', 1, N'fa-list', N'#', N'ADMINDIRE', N'BACKEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1710260001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710260002', NULL, N'Hồ sơ NVCMKT', NULL, N'', CAST(0x0000A81800DC62DE AS DateTime), 0, CAST(0x0000A81800DC2856 AS DateTime), N'1710240084', 2, N'fa-suitcase', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710260002', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710260003', NULL, N'Báo cáo/In ấn', NULL, N'', CAST(0x0000A81800DC983D AS DateTime), 0, CAST(0x0000A81800DC983D AS DateTime), N'1710240084', 3, N'fa-print', N'#', N'ADMINDIRE', N'BACKEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1710260003', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710260004', NULL, N'Chứng chỉ', NULL, N'', CAST(0x0000A81800DCE944 AS DateTime), 0, CAST(0x0000A81800DCCA25 AS DateTime), N'1710260001', 1, N'fa-graduation-cap', N'#', N'ADMINDIRE', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1710260004', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1710260005', NULL, N'Chuyển đơn vị', NULL, N'', CAST(0x0000A818010B9658 AS DateTime), 0, CAST(0x0000A818010B965B AS DateTime), N'1702070006', 8, N'fa-exchange', N'#', N'ADMINDIRE', N'BACKEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1710260005', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1711040001', NULL, N'Quốc gia', NULL, N'', CAST(0x0000A8210062EEB6 AS DateTime), 0, CAST(0x0000A8210062EEB8 AS DateTime), N'1702070001', 6, N'fa-globe', N'/nation', N'ADMINDIRE', N'BACKEND', NULL, N'HVKTQS', NULL, NULL, NULL, NULL, N'1711040001', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'1711150001', NULL, N'Nhóm quyền', NULL, N'', CAST(0x0000A82C01760C94 AS DateTime), 0, CAST(0x0000A82C0175E539 AS DateTime), N'03', 10, N'fa-users', N'/admin/admingroup', N'SUPADMIN', N'BACKEND', N'', N'HVKTQS', N'', N'', N'', N'', N'1711150001', N'')
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'TOP1', N'HOME', N'Trang chủ quản trị', NULL, N'K12337', CAST(0x0000A79B007A3485 AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'', 100, N'fa-dashboard', N'/home/admin', N'PRESEARCH', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'TOP1', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'TOP2', N'PREPORT', N'Báo cáo cá nhân', NULL, N'K12337', CAST(0x0000A79600E33EAF AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'', 200, N'fa-dashboard', N'/personal/staff.aspx', N'PRESEARCH', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'TOP2', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'TOP3', N'MANDEP', N'Quản lý đơn vị', NULL, N'K12337', CAST(0x0000A79600E345A2 AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'', 300, N'fa-dashboard', N'#', NULL, N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'TOP3', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'TOP31', N'MANAPPROVE', N'Duyệt chủ nhiệm bộ môn', NULL, N'K12337', CAST(0x0000A79600E3A79C AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'TOP3', 301, N'fa-dashboard', N'/management/staffapproved.aspx', N'RESEARCHSUPPORT', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'TOP3.TOP3', NULL)
INSERT [dbo].[sysmenu] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [theorder], [icon], [link], [prioritycode], [thetype], [whois], [universitycode], [img], [imgtitle], [imgnote], [glance], [extensioncode], [lang]) VALUES (N'TOP32', N'MANSTAFF', N'Quản lý cán bộ', NULL, N'K12337', CAST(0x0000A79600E3AB47 AS DateTime), 0, CAST(0xFFFF2E4600000000 AS DateTime), N'TOP3', 302, N'fa-dashboard', N'/management/staffworking.aspx', N'RESEARCHSUPPORT', N'TOPMENU', N'', N'HVKTQS', NULL, NULL, NULL, NULL, N'TOP3.TOP3', NULL)
/****** Object:  Table [dbo].[syscomponent]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[syscomponent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[syscomponent](
	[code] [varchar](10) NOT NULL,
	[description] [nvarchar](800) NULL,
	[showauth] [int] NULL,
	[name] [nvarchar](100) NULL,
	[lock] [int] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_syscomponent_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[syscomponent] ([code], [description], [showauth], [name], [lock], [whois], [universitycode]) VALUES (N'CORE', N'Phân hệ về nhân viên', 1, N'Phân hệ về nhân viên', 0, NULL, N'HVKTQS')
INSERT [dbo].[syscomponent] ([code], [description], [showauth], [name], [lock], [whois], [universitycode]) VALUES (N'EQUIPMENT', N'Phân hệ về thiết bị', 1, N'Phân hệ về thiết bị', 0, NULL, N'HVKTQS')
INSERT [dbo].[syscomponent] ([code], [description], [showauth], [name], [lock], [whois], [universitycode]) VALUES (N'PARTT', N'Phân hệ về Đảng', 1, N'Phận hệ về Đảng', 0, NULL, N'HVKTQS')
INSERT [dbo].[syscomponent] ([code], [description], [showauth], [name], [lock], [whois], [universitycode]) VALUES (N'STORE', N'Phân hệ về kho', 1, N'Phân hệ về kho', 0, NULL, N'HVKTQS')
INSERT [dbo].[syscomponent] ([code], [description], [showauth], [name], [lock], [whois], [universitycode]) VALUES (N'SUPPLY', N'Phân hệ về vật tư', 1, N'Phân hệ về vật tư', 0, NULL, N'HVKTQS')
INSERT [dbo].[syscomponent] ([code], [description], [showauth], [name], [lock], [whois], [universitycode]) VALUES (N'SYSTEM', N'Phân hệ về phân quyền', 1, N'Phân hệ phân quyền', 0, NULL, N'HVKTQS')
/****** Object:  Table [dbo].[staffstatushistory]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffstatushistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[staffstatushistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](50) NULL,
	[staffinfocode] [varchar](10) NULL,
 CONSTRAINT [PK_staffstatushistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[staffstatus]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffstatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[staffstatus](
	[code] [varchar](10) NOT NULL,
	[codeview] [nvarchar](50) NULL,
	[name] [nvarchar](1000) NULL,
	[edittime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[isstaff] [int] NULL,
	[theorder] [int] NULL,
	[edufactor] [float] NULL,
	[researchfactor] [float] NULL,
 CONSTRAINT [PK_staffstatus_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'CB', N'CB', N'Chửa bệnh dài ngày', NULL, NULL, 0, NULL, NULL, 5, 5, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'CC', N'CC', N'Chuyển công tác', NULL, NULL, 0, NULL, NULL, 8, 8, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'CH', N'CH', N'Chờ hưu', NULL, NULL, 0, NULL, NULL, 6, 6, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'CT', N'CT', N'Đang đi công tác ngắn ngày', NULL, NULL, 0, NULL, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'DH', N'DH', N'Đang đi học không tập trung', NULL, NULL, 0, NULL, NULL, 2, 2, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'DHTT', N'DHTT', N'Đang đi học tập trung', NULL, NULL, 0, NULL, NULL, 3, 3, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'DN', N'DN', N'Đang đi dự nhiệm', NULL, NULL, 0, NULL, NULL, 4, 4, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'HS', N'HS', N'Hi sinh', NULL, NULL, 0, NULL, NULL, 9, 9, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'HT', N'HT', N'Hưu trí', NULL, NULL, 0, NULL, NULL, 7, 7, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'HTLV', N'HTLV', N'Hợp tác làm việc', NULL, NULL, 0, NULL, NULL, 100, 100, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'LV', N'LV', N'Đang làm việc', NULL, NULL, 0, NULL, NULL, 0, 0, NULL, NULL)
INSERT [dbo].[staffstatus] ([code], [codeview], [name], [edittime], [edituser], [lock], [lockdate], [whois], [isstaff], [theorder], [edufactor], [researchfactor]) VALUES (N'MT', N'MT', N'Đã chết', NULL, NULL, 0, NULL, NULL, 10, 10, NULL, NULL)
/****** Object:  Table [dbo].[STAFFPRIORITY]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[STAFFPRIORITY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[STAFFPRIORITY](
	[objectcode] [varchar](10) NOT NULL,
	[thetype] [varchar](50) NOT NULL,
	[prioritycode] [nvarchar](40) NOT NULL,
	[forman] [int] NOT NULL,
	[func] [int] NULL,
	[thecode] [varchar](10) NOT NULL,
	[extensioncode] [varchar](200) NULL,
	[tablename] [varchar](50) NOT NULL,
	[inherit] [int] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
	[syscomponentcode] [varchar](10) NULL,
 CONSTRAINT [PK_STAFFPRIORITY_MY] PRIMARY KEY CLUSTERED 
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
/****** Object:  Table [dbo].[staffinfo]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffinfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[staffinfo](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[officialdate] [datetime] NULL,
	[officialdateshow] [varchar](20) NULL,
	[note] [nvarchar](1000) NULL,
	[abstract] [nvarchar](max) NULL,
	[name] [nvarchar](1000) NULL,
	[universitycode] [varchar](10) NULL,
	[releaseoffice] [nvarchar](1000) NULL,
	[releaseofficer] [nvarchar](100) NULL,
 CONSTRAINT [PK_staffinfo_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[staffauthorize]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffauthorize]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[staffauthorize](
	[stafffrom] [varchar](10) NOT NULL,
	[prioritycode] [varchar](10) NOT NULL,
	[staffto] [varchar](10) NOT NULL,
	[func] [int] NULL,
	[thecode] [varchar](10) NULL,
	[tablename] [varchar](50) NULL,
	[inherit] [int] NULL,
	[begintime] [datetime] NULL,
	[endtime] [datetime] NULL,
	[lock] [int] NULL,
	[edittime] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_staffauthorize_MY] PRIMARY KEY CLUSTERED 
(
	[stafffrom] ASC,
	[prioritycode] ASC,
	[staffto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[staffadmingroup]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staffadmingroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[staffadmingroup](
	[objectcode] [varchar](10) NOT NULL,
	[thetype] [varchar](50) NOT NULL,
	[admingroupcode] [nvarchar](40) NOT NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[whois] [varchar](64) NULL,
 CONSTRAINT [PK_staffadmingroup_MY] PRIMARY KEY CLUSTERED 
(
	[objectcode] ASC,
	[thetype] ASC,
	[admingroupcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[staffadmingroup] ([objectcode], [thetype], [admingroupcode], [edituser], [edittime], [lock], [whois]) VALUES (N'00001', N'STAFFADMINGROUP', N'1711100007', NULL, NULL, 0, NULL)
INSERT [dbo].[staffadmingroup] ([objectcode], [thetype], [admingroupcode], [edituser], [edittime], [lock], [whois]) VALUES (N'00001', N'STAFFADMINGROUP', N'1711100009', NULL, NULL, 0, NULL)
INSERT [dbo].[staffadmingroup] ([objectcode], [thetype], [admingroupcode], [edituser], [edittime], [lock], [whois]) VALUES (N'1711150001', N'STAFFADMINGROUP', N'1711100009', NULL, NULL, 0, NULL)
INSERT [dbo].[staffadmingroup] ([objectcode], [thetype], [admingroupcode], [edituser], [edittime], [lock], [whois]) VALUES (N'1711150001', N'STAFFADMINGROUP', N'1711140001', NULL, NULL, 0, NULL)
/****** Object:  Table [dbo].[staff]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[staff]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[staff](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](max) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[birthday] [datetime] NULL,
	[address] [nvarchar](400) NULL,
	[academictitlecode] [varchar](10) NULL,
	[degreecode] [varchar](10) NULL,
	[leveltitlecode] [varchar](10) NULL,
	[departmentcode] [varchar](10) NULL,
	[armyrankcode] [varchar](10) NULL,
	[partyleveltitlecode] [varchar](10) NULL,
	[mobiphone] [varchar](20) NULL,
	[tel] [varchar](20) NULL,
	[userpassword] [varchar](100) NULL,
	[photo] [nvarchar](200) NULL,
	[teaching] [int] NULL,
	[manager] [int] NULL,
	[email] [nvarchar](100) NULL,
	[changepass] [smallint] NULL,
	[academiclevelcode] [varchar](10) NULL,
	[staffstatuscode] [varchar](10) NULL,
	[provincecode] [varchar](10) NULL,
	[districtcode] [varchar](10) NULL,
	[towncode] [varchar](10) NULL,
	[internalemail] [nvarchar](100) NULL,
	[whois] [varchar](64) NULL,
	[sex] [int] NULL,
	[hometown] [nvarchar](500) NULL,
	[username] [nvarchar](100) NULL,
	[universitycode] [varchar](10) NULL,
	[languagecode] [varchar](10) NULL,
	[originalcode] [varchar](10) NULL,
	[researchdepartmentcode] [varchar](10) NULL,
	[researchstatus] [int] NULL,
	[expertspecializecode] [varchar](10) NULL,
	[expertgroupcode] [varchar](10) NULL,
	[expertfield] [varchar](10) NULL,
	[unitype] [nvarchar](500) NULL,
	[uniname] [nvarchar](500) NULL,
	[unifield] [nvarchar](500) NULL,
	[unination] [nvarchar](500) NULL,
	[uniyear] [int] NULL,
	[masterfield] [nvarchar](500) NULL,
	[masteryear] [int] NULL,
	[masteruniname] [nvarchar](500) NULL,
	[masterthesis] [nvarchar](1000) NULL,
	[phdfield] [nvarchar](500) NULL,
	[phdyear] [int] NULL,
	[phduniname] [nvarchar](500) NULL,
	[phdthesis] [nvarchar](1000) NULL,
	[havebirth] [datetime] NULL,
	[statusdateshow] [varchar](20) NULL,
	[statusdate] [datetime] NULL,
	[ethniccode] [varchar](10) NULL,
	[religioncode] [varchar](10) NULL,
	[civilid] [varchar](50) NULL,
	[extensioncode] [varchar](200) NULL,
 CONSTRAINT [PK_staff_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[staff] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [birthday], [address], [academictitlecode], [degreecode], [leveltitlecode], [departmentcode], [armyrankcode], [partyleveltitlecode], [mobiphone], [tel], [userpassword], [photo], [teaching], [manager], [email], [changepass], [academiclevelcode], [staffstatuscode], [provincecode], [districtcode], [towncode], [internalemail], [whois], [sex], [hometown], [username], [universitycode], [languagecode], [originalcode], [researchdepartmentcode], [researchstatus], [expertspecializecode], [expertgroupcode], [expertfield], [unitype], [uniname], [unifield], [unination], [uniyear], [masterfield], [masteryear], [masteruniname], [masterthesis], [phdfield], [phdyear], [phduniname], [phdthesis], [havebirth], [statusdateshow], [statusdate], [ethniccode], [religioncode], [civilid], [extensioncode]) VALUES (N'00001', N'uyennm', N'Nguyễn Mậu Uyên', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1710240002', NULL, NULL, NULL, NULL, N'b384937a18f544742a965b815d8e4ce94bc36015531cd0399e1b7e72464a8791', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'uyennm', N'HVKTQS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [birthday], [address], [academictitlecode], [degreecode], [leveltitlecode], [departmentcode], [armyrankcode], [partyleveltitlecode], [mobiphone], [tel], [userpassword], [photo], [teaching], [manager], [email], [changepass], [academiclevelcode], [staffstatuscode], [provincecode], [districtcode], [towncode], [internalemail], [whois], [sex], [hometown], [username], [universitycode], [languagecode], [originalcode], [researchdepartmentcode], [researchstatus], [expertspecializecode], [expertgroupcode], [expertfield], [unitype], [uniname], [unifield], [unination], [uniyear], [masterfield], [masteryear], [masteruniname], [masterthesis], [phdfield], [phdyear], [phduniname], [phdthesis], [havebirth], [statusdateshow], [statusdate], [ethniccode], [religioncode], [civilid], [extensioncode]) VALUES (N'1711150001', N'duonghd', N'Hà Đại Dương', NULL, N'', CAST(0x0000A82C00E9E771 AS DateTime), 0, CAST(0x0000A82C00E9E774 AS DateTime), CAST(0x00006C6E00000000 AS DateTime), NULL, NULL, NULL, NULL, N'1710240002', NULL, NULL, NULL, NULL, N'3f5fe9658f06e9c7433f0cea08bd3aedb00b3ce0ba46127f934e254c2502f8f9', NULL, 0, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'duonghd', N'HVKTQS', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[resetpassword]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[resetpassword]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[resetpassword](
	[code] [varchar](10) NOT NULL,
	[requesttime] [datetime] NULL,
	[username] [nvarchar](50) NULL,
	[IP] [varchar](64) NULL,
	[email] [nvarchar](100) NULL,
	[processed] [int] NULL,
	[webbrowser] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[deparmentname] [nvarchar](100) NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_resetpassword_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[religion]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[religion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[religion](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[comparelevel] [int] NULL,
 CONSTRAINT [PK_religion_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[religion] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel]) VALUES (N'1711280001', N'LUONG', N'Lương giáo', NULL, N'', CAST(0x0000A83900129570 AS DateTime), 0, CAST(0x0000A83900129572 AS DateTime), NULL, 0)
INSERT [dbo].[religion] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel]) VALUES (N'1711280002', N'THIENCHUA', N'Thiên chúa giáo', NULL, N'', CAST(0x0000A83900B2CC97 AS DateTime), 0, CAST(0x0000A83900B2CC98 AS DateTime), NULL, 0)
/****** Object:  Table [dbo].[region]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[region]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[region](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[thetype] [varchar](50) NULL,
 CONSTRAINT [PK_region_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[region] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel], [theorder], [thetype]) VALUES (N'V1', N'V2', N'Vùng 1', NULL, NULL, NULL, 0, NULL, NULL, 1, 1, N'REGION')
INSERT [dbo].[region] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel], [theorder], [thetype]) VALUES (N'V2', N'V2', N'Vùng 2', NULL, NULL, NULL, 0, NULL, NULL, 2, 2, N'REGION')
INSERT [dbo].[region] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel], [theorder], [thetype]) VALUES (N'V3', N'V3', N'Vùng 3', NULL, NULL, NULL, 0, NULL, NULL, 3, 3, N'REGION')
INSERT [dbo].[region] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel], [theorder], [thetype]) VALUES (N'V4', N'V4', N'Vùng 4', NULL, NULL, NULL, 0, NULL, NULL, 4, 4, N'REGION')
INSERT [dbo].[region] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel], [theorder], [thetype]) VALUES (N'V5', N'V5', N'Vùng 5', NULL, NULL, NULL, 0, NULL, NULL, 5, 5, N'REGION')
/****** Object:  Table [dbo].[provincereference]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[provincereference]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[provincereference](
	[thecode] [varchar](10) NOT NULL,
	[currentcode] [varchar](10) NOT NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
 CONSTRAINT [PK_provincereference_MY] PRIMARY KEY CLUSTERED 
(
	[thecode] ASC,
	[currentcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[province]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[province]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[province](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[begindate] [datetime] NULL,
	[enddate] [datetime] NULL,
	[parentcode] [varchar](10) NULL,
	[thetype] [varchar](50) NULL,
 CONSTRAINT [PK_province_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[priority]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[priority]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[priority](
	[code] [nvarchar](40) NOT NULL,
	[description] [nvarchar](800) NULL,
	[showauth] [int] NULL,
	[name] [nvarchar](100) NULL,
	[lock] [int] NULL,
	[whois] [varchar](64) NULL,
	[groupcode] [varchar](10) NULL,
	[syscomponentcode] [varchar](10) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_priority_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[priority] ([code], [description], [showauth], [name], [lock], [whois], [groupcode], [syscomponentcode], [universitycode]) VALUES (N'ADMINCORE', N'Quản trị đơn vị', NULL, N'Quản trị đơn vị', NULL, NULL, N'DIR', N'CORE', N'HVKTQS')
INSERT [dbo].[priority] ([code], [description], [showauth], [name], [lock], [whois], [groupcode], [syscomponentcode], [universitycode]) VALUES (N'ADMINDIRE', N'Quản lý các danh mục', NULL, N'Quản lý các danh mục', NULL, NULL, N'DIR', N'SYSTEM', N'HVKTQS')
INSERT [dbo].[priority] ([code], [description], [showauth], [name], [lock], [whois], [groupcode], [syscomponentcode], [universitycode]) VALUES (N'ADMINMENU', N'Quản trị hệ thống menu', NULL, N'Quản trị hệ thống menu', NULL, NULL, N'ADMIN', N'SYSTEM', N'HVKTQS')
INSERT [dbo].[priority] ([code], [description], [showauth], [name], [lock], [whois], [groupcode], [syscomponentcode], [universitycode]) VALUES (N'LOGGED', N'Người dùng đã đăng nhập', NULL, N'Người dùng đã đăng nhập', 0, NULL, N'USER', N'NONE', N'HVKTQS')
INSERT [dbo].[priority] ([code], [description], [showauth], [name], [lock], [whois], [groupcode], [syscomponentcode], [universitycode]) VALUES (N'SUPADMIN', N'Quản trị hệ thống', NULL, N'Quản trị hệ thống', NULL, NULL, N'ADMIN', N'SYSTEM', N'HVKTQS')
/****** Object:  Table [dbo].[personalparameter]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[personalparameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[personalparameter](
	[staffcode] [varchar](10) NOT NULL,
	[thetypecode] [varchar](50) NOT NULL,
	[thevalue] [nvarchar](200) NULL,
	[datatype] [nvarchar](50) NULL,
 CONSTRAINT [PK_personalparameter_MY] PRIMARY KEY CLUSTERED 
(
	[staffcode] ASC,
	[thetypecode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[partyleveltitlehistory]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[partyleveltitlehistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[partyleveltitlehistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[theorder] [int] NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](50) NULL,
	[staffinfocode] [varchar](10) NULL,
	[departmentcode] [varchar](10) NULL,
 CONSTRAINT [PK_partyleveltitlehistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[partyleveltitle]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[partyleveltitle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[partyleveltitle](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[man] [int] NULL,
	[whois] [varchar](64) NULL,
	[eduduty1] [int] NULL,
	[researchduty1] [int] NULL,
	[edureducerate] [int] NULL,
	[researchreducerate] [int] NULL,
	[eduduty] [int] NULL,
	[researchduty] [int] NULL,
 CONSTRAINT [PK_partyleveltitle_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nationreference]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nationreference]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[nationreference](
	[nationcode] [varchar](10) NOT NULL,
	[currentcode] [varchar](10) NOT NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
 CONSTRAINT [PK_nationreference_MY] PRIMARY KEY CLUSTERED 
(
	[nationcode] ASC,
	[currentcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nation]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[nation](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[begindate] [datetime] NULL,
	[enddate] [datetime] NULL,
 CONSTRAINT [PK_nation_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[managelevel]    Script Date: 11/28/2017 23:08:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[managelevel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[managelevel](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[thetype] [varchar](50) NULL,
 CONSTRAINT [PK_managelevel_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[managelevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel], [theorder], [thetype]) VALUES (N'BQP', N'BQP', N'Bộ quốc phòng', NULL, NULL, NULL, 0, NULL, NULL, 0, 0, N'MANAGELEVEL')
INSERT [dbo].[managelevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel], [theorder], [thetype]) VALUES (N'QC', N'QC', N'Quân chủng', NULL, NULL, NULL, 0, NULL, NULL, 1, 1, N'MANAGELEVEL')
/****** Object:  Table [dbo].[logresetpassword]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logresetpassword]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[logresetpassword](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](2000) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[requirestaff] [varchar](10) NULL,
	[password] [varchar](100) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_logresetpassword_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[logme]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logme]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[logme](
	[code] [varchar](20) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[staffname] [nvarchar](100) NULL,
	[createtime] [datetime] NULL,
	[tablename] [nvarchar](100) NULL,
	[action] [varchar](10) NULL,
	[recordcode] [varchar](50) NULL,
	[note] [nvarchar](1000) NULL,
	[ip] [varchar](64) NULL,
	[computername] [nvarchar](100) NULL,
	[webbrowser] [nvarchar](100) NULL,
	[endtime] [datetime] NULL,
	[OS] [nvarchar](500) NULL,
	[sessioncode] [varchar](20) NULL,
	[urlshort] [nvarchar](1000) NULL,
	[urlname] [nvarchar](1000) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_logme_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171026000000000001', N'00001', N'uyennm', CAST(0x0000A81800CD1EA7 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (61.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000001', N'00001', N'uyennm', CAST(0x0000A82400AF2F2C AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000002', N'00001', N'uyennm', CAST(0x0000A82400AFD74E AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000003', N'00001', N'uyennm', CAST(0x0000A82400AFE26F AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000004', N'00001', N'uyennm', CAST(0x0000A82400B0A4B3 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000005', N'00001', N'uyennm', CAST(0x0000A82400B37602 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000006', N'00001', N'uyennm', CAST(0x0000A82400B6BAB5 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000007', N'00001', N'uyennm', CAST(0x0000A82400BBC276 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000008', N'00001', N'uyennm', CAST(0x0000A82400BC3C2A AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000009', N'00001', N'uyennm', CAST(0x0000A82400BCD942 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000010', N'00001', N'uyennm', CAST(0x0000A82400BDA4A5 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000011', N'00001', N'uyennm', CAST(0x0000A82400BE2102 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'127.0.0.1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000012', N'00001', N'uyennm', CAST(0x0000A82400CD91B6 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', CAST(0x0000A82400CD9D4C AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000013', N'00001', N'uyennm', CAST(0x0000A82400CDDDA6 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000014', N'00001', N'uyennm', CAST(0x0000A82400CE58D1 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000015', N'00001', N'uyennm', CAST(0x0000A82400CF7DAA AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000016', N'00001', N'uyennm', CAST(0x0000A82400CFE27A AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000017', N'00001', N'uyennm', CAST(0x0000A82400D08D18 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000018', N'00001', N'uyennm', CAST(0x0000A82400D268E8 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000019', N'00001', N'uyennm', CAST(0x0000A82400D67353 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000020', N'00001', N'uyennm', CAST(0x0000A82400E2C1B7 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000021', N'00001', N'uyennm', CAST(0x0000A82400F2938E AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000022', N'00001', N'uyennm', CAST(0x0000A82400F47CE1 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000023', N'00001', N'uyennm', CAST(0x0000A82400F55013 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000024', N'00001', N'uyennm', CAST(0x0000A82400F7810F AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000025', N'00001', N'uyennm', CAST(0x0000A82400FE602B AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000026', N'00001', N'uyennm', CAST(0x0000A82400FEDF43 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000027', N'00001', N'uyennm', CAST(0x0000A82400FFF864 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000028', N'00001', N'uyennm', CAST(0x0000A82401038EBB AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', CAST(0x0000A82401058380 AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000029', N'00001', N'uyennm', CAST(0x0000A82401065B1F AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000030', N'00001', N'uyennm', CAST(0x0000A8240107A12C AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000031', N'00001', N'uyennm', CAST(0x0000A824010AF621 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000032', N'00001', N'uyennm', CAST(0x0000A824010EBAC5 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000033', N'00001', N'uyennm', CAST(0x0000A82401103A2A AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (56.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000034', N'00001', N'uyennm', CAST(0x0000A82401628B87 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (61.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36 OPR/48.0.2685.52)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171107000000000035', N'00001', N'uyennm', CAST(0x0000A824016EA5D2 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (61.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36 OPR/48.0.2685.52)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000001', N'1711150001', N'duonghd', CAST(0x0000A82D000DABEB AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', CAST(0x0000A82D001192AC AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000002', N'00001', N'uyennm', CAST(0x0000A82D0011CD1D AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000003', N'00001', N'uyennm', CAST(0x0000A82D0013378E AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000004', N'00001', N'uyennm', CAST(0x0000A82D0013999E AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', CAST(0x0000A82D0013F555 AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000005', N'1711150001', N'duonghd', CAST(0x0000A82D0014086B AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', CAST(0x0000A82D00143419 AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000006', N'00001', N'uyennm', CAST(0x0000A82D00143AD7 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', CAST(0x0000A82D0014DFB4 AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000007', N'00001', N'uyennm', CAST(0x0000A82D00151F75 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', CAST(0x0000A82D00161240 AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000008', N'1711150001', N'duonghd', CAST(0x0000A82D00161A2E AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', CAST(0x0000A82D0016555D AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000009', N'00001', N'uyennm', CAST(0x0000A82D00165901 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', CAST(0x0000A82D00167D85 AS DateTime), N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000010', N'00001', N'uyennm', CAST(0x0000A82D00168675 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000011', N'00001', N'uyennm', CAST(0x0000A82D001717C6 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000012', N'00001', N'uyennm', CAST(0x0000A82D00172DFA AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000013', N'00001', N'uyennm', CAST(0x0000A82D001AEE7C AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000014', N'00001', N'uyennm', CAST(0x0000A82D001C7AAB AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171116000000000015', N'00001', N'uyennm', CAST(0x0000A82D002048F9 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Chrome (62.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Safari/537.36)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171126000000000001', N'00001', N'uyennm', CAST(0x0000A8370178791A AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (57.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171127000000000001', N'00001', N'uyennm', CAST(0x0000A838017D5949 AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (57.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171128000000000001', N'00001', N'uyennm', CAST(0x0000A839000702BD AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (57.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171128000000000002', N'00001', N'uyennm', CAST(0x0000A83900B6DEFC AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (57.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171128000000000003', N'00001', N'uyennm', CAST(0x0000A83900CC7A4D AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (57.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0)', N'', N'', N'', NULL)
INSERT [dbo].[logme] ([code], [staffcode], [staffname], [createtime], [tablename], [action], [recordcode], [note], [ip], [computername], [webbrowser], [endtime], [OS], [sessioncode], [urlshort], [urlname], [universitycode]) VALUES (N'20171128000000000004', N'00001', N'uyennm', CAST(0x0000A839010931BA AS DateTime), N'STAFF', N'LOG', N'', N'Login to admin', N'::1', N'', N'Firefox (57.0)', NULL, N'WinNT(Windows 7)-(Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0)', N'', N'', N'', NULL)
/****** Object:  Table [dbo].[logerror]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[logerror]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[logerror](
	[code] [varchar](20) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[staffname] [nvarchar](100) NULL,
	[createtime] [datetime] NULL,
	[tablename] [nvarchar](100) NULL,
	[action] [varchar](10) NULL,
	[recordcode] [varchar](50) NULL,
	[note] [nvarchar](1000) NULL,
	[ip] [varchar](64) NULL,
	[computername] [nvarchar](100) NULL,
	[webbrowser] [nvarchar](100) NULL,
	[endtime] [datetime] NULL,
	[OS] [nvarchar](500) NULL,
	[sessioncode] [varchar](20) NULL,
	[urlshort] [nvarchar](1000) NULL,
	[urlname] [nvarchar](1000) NULL,
	[universitycode] [varchar](10) NULL,
	[mes] [nvarchar](max) NULL,
	[func] [nvarchar](200) NULL,
 CONSTRAINT [PK_logerror_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LEVELTITLRPRIORITY]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LEVELTITLRPRIORITY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LEVELTITLRPRIORITY](
	[objectcode] [varchar](10) NOT NULL,
	[thetype] [varchar](50) NOT NULL,
	[prioritycode] [nvarchar](40) NOT NULL,
	[forman] [int] NOT NULL,
	[func] [int] NULL,
	[thecode] [varchar](10) NOT NULL,
	[extensioncode] [varchar](200) NULL,
	[tablename] [varchar](50) NOT NULL,
	[inherit] [int] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_LEVELTITLRPRIORITY_MY] PRIMARY KEY CLUSTERED 
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
/****** Object:  Table [dbo].[leveltitlehistory]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leveltitlehistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[leveltitlehistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[departmentcode] [varchar](10) NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[theorder] [int] NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](10) NULL,
	[staffinfocode] [varchar](10) NULL,
 CONSTRAINT [PK_leveltitlehistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[leveltitleadmingroup]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leveltitleadmingroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[leveltitleadmingroup](
	[objectcode] [varchar](10) NOT NULL,
	[thetype] [varchar](50) NOT NULL,
	[admingroupcode] [nvarchar](40) NOT NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_leveltitleadmingroup_MY] PRIMARY KEY CLUSTERED 
(
	[objectcode] ASC,
	[thetype] ASC,
	[admingroupcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[leveltitle]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[leveltitle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[leveltitle](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[edureducerate] [int] NULL,
	[researchreducerate] [int] NULL,
	[eduduty] [int] NULL,
	[researchduty] [int] NULL,
	[man] [int] NULL,
	[whois] [varchar](64) NULL,
	[eduduty1] [int] NULL,
	[researchduty1] [int] NULL,
 CONSTRAINT [PK_leveltitle_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304040001', N'GD', N'Giám đốc', N'Không có', N'1304070001', CAST(0x0000A1B0007C31FA AS DateTime), 0, NULL, 10, 101, 95, 95, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270012', N'TL', N'Trợ lý', N'', N'1304070001', CAST(0x0000A1AD006723F9 AS DateTime), 0, NULL, 80, 903, 15, 15, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270013', N'GV', N'Giáo viên', N'', N'1304070001', CAST(0x0000A1AD0066D6A0 AS DateTime), 0, NULL, 80, 901, 0, 0, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270014', N'TDT', N'Tiểu đoàn trưởng', N'', N'1304070001', CAST(0x0000A1AD0066003D AS DateTime), 0, NULL, 32, 205, 0, 0, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270015', N'PTDT', N'Phó Tiểu đoàn trưởng', N'', N'1304070001', CAST(0x0000A1AD00661DA3 AS DateTime), 0, NULL, 33, 206, 0, 0, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270016', N'HET', N'Hệ trưởng', N'', N'1304070001', CAST(0x0000A1AD00664BDA AS DateTime), 0, NULL, 32, 207, 0, 0, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270017', N'PHET', N'Phó Hệ trưởng', N'', N'1304070001', CAST(0x0000A1AD00667170 AS DateTime), 0, NULL, 33, 208, 0, 0, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270018', N'HVSV', N'Học viên - Sinh viên', N'', N'1304070001', CAST(0x0000A1AD0067191D AS DateTime), 0, NULL, 90, 902, 0, 0, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270019', N'CS', N'Chiến sỹ', N'', N'1304070001', CAST(0x0000A1AD0067419B AS DateTime), 0, NULL, 91, 904, 0, 0, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270020', N'DDT', N'Đại đội trưởng', N'', N'1304070001', CAST(0x0000A1AD0067A437 AS DateTime), 0, NULL, 40, 305, 0, 0, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270021', N'PDDT', N'Phó Đại đội trưởng', N'', N'1304070001', CAST(0x0000A1AD0067C44D AS DateTime), 0, NULL, 41, 306, 0, 0, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270022', N'KHAC', N'Khác', N'', N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 99, 999, 0, 0, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270023', N'TPTN', N'Trưởng phòng thí nghiệm', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 40, 305, 15, 15, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270024', N'TKBM', N'Thư ký bộ môn', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 50, 306, 15, 15, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270025', N'CNLOP', N'Chủ nhiệm lớp', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 60, 307, 15, 15, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270026', N'BTDCS', N'Bí thư đoàn cơ sở', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 70, 308, 20, 20, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270027', N'GVCH', N'Giáo viên đang học cao học không tập trung', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 81, 310, 50, 50, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270028', N'GVTS', N'Giáo viên đang nghiên cứu sinh không tập trung', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 80, 309, 70, 70, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270029', N'GDTT', N'Giám đốc trung tâm', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 30, 209, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270030', N'PGDTT', N'Phó giám đốc trung tâm', NULL, N'1304070001', CAST(0x0000A1AD0067FB41 AS DateTime), 0, NULL, 31, 210, 20, 20, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270031', N'TTT', N'Trưởng trung tâm', NULL, NULL, NULL, 0, NULL, 30, 211, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270032', N'PTT', N'Phó trung tâm', NULL, NULL, NULL, 0, NULL, 32, 212, 20, 20, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270033', N'TPV', N'Trưởng phòng thuộc viện', NULL, NULL, NULL, 0, NULL, 30, 213, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270034', N'PTPV', N'Phó trưởng phòng thuộc viện', NULL, NULL, NULL, 0, NULL, 31, 214, 20, 20, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270035', N'VT', N'Viện trưởng', NULL, NULL, NULL, 0, NULL, 20, 204, 30, 30, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270036', N'PVT', N'Phó viện trưởng', NULL, NULL, NULL, 0, NULL, 21, 205, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270037', N'TTTHV', N'Trưởng trung tâm (Trực thuộc học viện)', N'Trưởng trung tâm (Trực thuộc học viện)', N'1304070001', CAST(0x0000A1AD0065C79F AS DateTime), 0, NULL, 20, 201, 30, 30, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'1304270038', N'PTTTHV', N'Phó trưởng trung tâm (Trực thuộc học viện)', N'Phó trưởng trung tâm (Trực thuộc học viện)', N'1304070001', CAST(0x0000A1AD0065DD45 AS DateTime), 0, NULL, 21, 203, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270001', N'PGD', N'Phó Giám đốc', N'', N'1304070001', CAST(0x0000A1AD0065A10D AS DateTime), 0, NULL, 12, 103, 95, 95, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270002', N'CU', N'Chính Ủy', N'', N'1304070001', CAST(0x0000A1AD0065902D AS DateTime), 0, NULL, 11, 102, 95, 95, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270003', N'PCU', N'Phó Chính ủy', N'', N'1304070001', CAST(0x0000A1AD0065ACC4 AS DateTime), 0, NULL, 13, 104, 95, 95, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270004', N'TP', N'Trưởng phòng', N'', N'1304070001', CAST(0x0000A1AD0065CF56 AS DateTime), 0, NULL, 20, 202, 85, 85, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270005', N'CNK', N'Chủ nhiệm khoa', N'', N'1304070001', CAST(0x0000A1AD0065C79F AS DateTime), 0, NULL, 20, 201, 30, 30, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270006', N'PTP', N'Phó Trưởng phòng', N'', N'1304070001', CAST(0x0000A1AD0065E542 AS DateTime), 0, NULL, 21, 204, 70, 70, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270007', N'PCNK', N'Phó Chủ nhiệm khoa', N'', N'1304070001', CAST(0x0000A1AD0065DD45 AS DateTime), 0, NULL, 21, 203, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270008', N'TB', N'Trưởng ban', N'', N'1304070001', CAST(0x0000A1AD006690D4 AS DateTime), 0, NULL, 30, 302, 30, 30, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270009', N'CNBM', N'Chủ nhiệm bộ môn', N'', N'1304070001', CAST(0x0000A1AD00668760 AS DateTime), 0, NULL, 30, 301, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270010', N'PTB', N'Phó Trưởng ban', N'', N'1304070001', CAST(0x0000A1AD0066A3A3 AS DateTime), 0, NULL, 31, 304, 25, 25, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[leveltitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [edureducerate], [researchreducerate], [eduduty], [researchduty], [man], [whois], [eduduty1], [researchduty1]) VALUES (N'LT04270011', N'PCNBM', N'Phó Chủ nhiệm bộ môn', N'', N'1304070001', CAST(0x0000A1AD00669B65 AS DateTime), 0, NULL, 31, 303, 20, 20, NULL, NULL, 1, NULL, NULL, NULL)
/****** Object:  Table [dbo].[groupname]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groupname]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groupname](
	[code] [varchar](10) NOT NULL,
	[description] [nvarchar](800) NULL,
	[showauth] [int] NULL,
	[name] [nvarchar](100) NULL,
	[lock] [int] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_groupname_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ethnic]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ethnic]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ethnic](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
	[comparelevel] [int] NULL,
 CONSTRAINT [PK_ethnic_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ethnic] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [comparelevel]) VALUES (N'1711270001', N'KINH', N'Dân tộc KINH', NULL, N'', CAST(0x0000A838018984CF AS DateTime), 0, CAST(0x0000A838018984D0 AS DateTime), NULL, 0)
/****** Object:  Table [dbo].[districtreference]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[districtreference]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[districtreference](
	[thecode] [varchar](10) NOT NULL,
	[currentcode] [varchar](10) NOT NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[whois] [varchar](64) NULL,
 CONSTRAINT [PK_districtreference_MY] PRIMARY KEY CLUSTERED 
(
	[thecode] ASC,
	[currentcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[district]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[district]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[district](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[parentcode] [varchar](10) NULL,
	[whois] [varchar](64) NULL,
	[begindate] [datetime] NULL,
	[enddate] [datetime] NULL,
	[thetype] [varchar](50) NULL,
 CONSTRAINT [PK_district_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPARTMENTPRIORITY]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DEPARTMENTPRIORITY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DEPARTMENTPRIORITY](
	[objectcode] [varchar](10) NOT NULL,
	[thetype] [varchar](50) NOT NULL,
	[prioritycode] [nvarchar](40) NOT NULL,
	[forman] [int] NOT NULL,
	[func] [int] NULL,
	[thecode] [varchar](10) NOT NULL,
	[extensioncode] [varchar](200) NULL,
	[tablename] [varchar](50) NOT NULL,
	[inherit] [int] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_DEPARTMENTPRIORITY_MY] PRIMARY KEY CLUSTERED 
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
/****** Object:  Table [dbo].[departmenthistory]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[departmenthistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[departmenthistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](50) NULL,
	[staffinfocode] [varchar](10) NULL,
 CONSTRAINT [PK_departmenthistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[departmentadmingroup]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[departmentadmingroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[departmentadmingroup](
	[objectcode] [varchar](10) NOT NULL,
	[thetype] [varchar](50) NOT NULL,
	[admingroupcode] [nvarchar](40) NOT NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[whois] [varchar](64) NULL,
	[universitycode] [varchar](10) NULL,
 CONSTRAINT [PK_departmentadmingroup_MY] PRIMARY KEY CLUSTERED 
(
	[objectcode] ASC,
	[thetype] ASC,
	[admingroupcode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[department]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[department](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[parentcode] [varchar](10) NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[whois] [varchar](64) NULL,
	[amount] [int] NULL,
	[description] [nvarchar](max) NULL,
	[universitycode] [varchar](10) NULL,
	[originalcode] [varchar](10) NULL,
	[extensioncode] [varchar](120) NULL,
	[levelextension] [int] NULL,
	[managelevelcode] [varchar](10) NULL,
	[address] [nvarchar](1000) NULL,
	[regioncode] [varchar](10) NULL,
	[foundeddate] [datetime] NULL,
	[foundeddateshow] [varchar](20) NULL,
	[syscomponentcode] [varchar](10) NULL,
 CONSTRAINT [PK_department_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[department] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [comparelevel], [theorder], [phone], [email], [whois], [amount], [description], [universitycode], [originalcode], [extensioncode], [levelextension], [managelevelcode], [address], [regioncode], [foundeddate], [foundeddateshow], [syscomponentcode]) VALUES (N'1', N'HVKTQS', N'Học viện kỹ thuật quân sự', N'Không có note', NULL, NULL, NULL, NULL, N'', NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[department] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [comparelevel], [theorder], [phone], [email], [whois], [amount], [description], [universitycode], [originalcode], [extensioncode], [levelextension], [managelevelcode], [address], [regioncode], [foundeddate], [foundeddateshow], [syscomponentcode]) VALUES (N'1710240001', N'HVKTQS', N'Học viện kỹ thuật quân sự', NULL, N'', CAST(0x0000A81600A4CBA6 AS DateTime), 0, CAST(0x0000A81600A4CBA7 AS DateTime), N'', 0, 1, NULL, NULL, NULL, 0, NULL, N'HVKTQS', NULL, N'1710240001', 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[department] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [comparelevel], [theorder], [phone], [email], [whois], [amount], [description], [universitycode], [originalcode], [extensioncode], [levelextension], [managelevelcode], [address], [regioncode], [foundeddate], [foundeddateshow], [syscomponentcode]) VALUES (N'1710240002', N'K12', N'Khoa Công nghệ thông tin', NULL, N'', CAST(0x0000A81600A51A01 AS DateTime), 0, CAST(0x0000A81600A51A01 AS DateTime), N'1710240001', 0, 102, NULL, NULL, NULL, 0, NULL, N'HVKTQS', NULL, N'1710240001.1710240002', 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[department] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [parentcode], [comparelevel], [theorder], [phone], [email], [whois], [amount], [description], [universitycode], [originalcode], [extensioncode], [levelextension], [managelevelcode], [address], [regioncode], [foundeddate], [foundeddateshow], [syscomponentcode]) VALUES (N'1710240003', N'K13', N'Khoa Ngoại ngữ', NULL, N'', CAST(0x0000A81600A52978 AS DateTime), 0, CAST(0x0000A81600A52978 AS DateTime), N'1710240001', 0, 103, NULL, NULL, NULL, 0, NULL, N'HVKTQS', NULL, N'1710240001.1710240003', 0, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[degreehistory]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[degreehistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[degreehistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](10) NULL,
	[staffinfocode] [varchar](10) NULL,
 CONSTRAINT [PK_degreehistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[degree]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[degree]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[degree](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[whois] [varchar](64) NULL,
	[eduduty1] [int] NULL,
	[researchduty1] [int] NULL,
	[rate] [float] NULL,
	[edureducerate] [int] NULL,
	[researchreducerate] [int] NULL,
	[eduduty] [int] NULL,
	[researchduty] [int] NULL,
 CONSTRAINT [PK_degree_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[degree] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'AM04070001', N'KS', N'Kỹ sư', N'Không', N'1304070001', CAST(0x0000A1AD005A7DAA AS DateTime), 0, NULL, 9, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[degree] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'AM04070002', N'CN', N'Cử nhân', N'', N'1304070001', CAST(0x0000A1AD005A85FB AS DateTime), 0, NULL, 10, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[degree] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'DE04270001', N'TSKH', N'Tiến sỹ Khoa học', N'', N'1304070001', CAST(0x0000A1AD005A6CE1 AS DateTime), 0, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[degree] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'DE04270002', N'TS', N'Tiến sỹ', N'', N'1304070001', CAST(0x0000A1AD005A9A2E AS DateTime), 0, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[degree] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'DE04270003', N'ThS', N'Thạc sỹ', N'', N'1304070001', CAST(0x0000A1AD005ABAF6 AS DateTime), 0, NULL, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[degree] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'DE04270004', N'KH', N'Khác', N'', N'1304070001', CAST(0x0000A1AD00681768 AS DateTime), 0, NULL, 99, 99, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[dayoff]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dayoff]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[dayoff](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[dayoff] [datetime] NULL,
	[allyear] [int] NULL,
	[whois] [varchar](64) NULL,
 CONSTRAINT [PK_dayoff_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[dayoff] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [dayoff], [allyear], [whois]) VALUES (N'DOCLAP', N'DOCLAP', N'Nghỉ 30/4', NULL, NULL, NULL, 0, NULL, CAST(0x0000A76500000000 AS DateTime), 1, NULL)
INSERT [dbo].[dayoff] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [dayoff], [allyear], [whois]) VALUES (N'LAODONG', N'LAODONG', N'Nghỉ lao động', NULL, NULL, NULL, 0, NULL, CAST(0x0000A76600000000 AS DateTime), 1, NULL)
INSERT [dbo].[dayoff] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [dayoff], [allyear], [whois]) VALUES (N'QUOCKHA', N'QUOCKHANH', N'Nghỉ quốc khánh', NULL, NULL, NULL, 0, NULL, CAST(0x0000A7E200000000 AS DateTime), 1, NULL)
INSERT [dbo].[dayoff] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [dayoff], [allyear], [whois]) VALUES (N'TET', N'TET', N'Tết dương lịch', NULL, NULL, NULL, 0, NULL, CAST(0x0000A6EE00000000 AS DateTime), 1, NULL)
/****** Object:  Table [dbo].[armyrankhistory]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[armyrankhistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[armyrankhistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](50) NULL,
	[staffinfocode] [varchar](10) NULL,
 CONSTRAINT [PK_armyrankhistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[armyrank]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[armyrank]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[armyrank](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[whois] [varchar](64) NULL,
	[edureducerate] [int] NULL,
	[researchreducerate] [int] NULL,
	[eduduty] [int] NULL,
	[researchduty] [int] NULL,
	[eduduty1] [int] NULL,
	[researchduty1] [int] NULL,
 CONSTRAINT [PK_armyrank_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304070001', N'1/', N'Thiếu úy', N'', N'admin', CAST(0x0000A5B4017E0CC5 AS DateTime), 0, CAST(0x0000A5B4017E0CC5 AS DateTime), 12, 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304070002', N'2/', N'Trung úy', NULL, N'1304070001', CAST(0x0000A1AD005D842B AS DateTime), 0, CAST(0x0000A1AD005D842B AS DateTime), 11, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270006', N'3//', N'Thượng tá', NULL, N'1304070001', CAST(0x0000A1AD005CD6DC AS DateTime), 0, CAST(0x0000A1AD005CD6DC AS DateTime), 6, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270007', N'2//', N'Trung tá', NULL, N'1304070001', CAST(0x0000A1AD005CED05 AS DateTime), 0, CAST(0x0000A1AD005CED05 AS DateTime), 7, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270008', N'1//', N'Thiếu tá', NULL, N'1304070001', CAST(0x0000A1AD005D1389 AS DateTime), 0, CAST(0x0000A1AD005D1389 AS DateTime), 8, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270009', N'4/', N'Đại úy', NULL, N'1304070001', CAST(0x0000A1AD005D2D18 AS DateTime), 0, CAST(0x0000A1AD005D2D18 AS DateTime), 9, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270010', N'3/', N'Thượng úy', NULL, N'1304070001', CAST(0x0000A1AD005D4184 AS DateTime), 0, CAST(0x0000A1AD005D4184 AS DateTime), 10, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270011', N'CNV', N'Công nhân viên quốc phòng', NULL, N'1304070001', CAST(0x0000A1AD00F39C89 AS DateTime), 0, CAST(0x0000A1AD00F39C89 AS DateTime), 1, 99, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1602030001', N'KH', N'Khác', N'', N'admin', CAST(0x0000A5A1008F75F8 AS DateTime), 0, CAST(0x0000A5A1008F75F8 AS DateTime), 0, 100, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'AM04270002', N'4//', N'Đại tá', NULL, N'1304070001', CAST(0x0000A1AD005CC385 AS DateTime), 0, CAST(0x0000A1AD005CC385 AS DateTime), 5, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'AM04270003', N'2///', N'Trung tướng', NULL, N'1304070001', CAST(0x0000A1AD005C6DFB AS DateTime), 0, CAST(0x0000A1AD005C6DFB AS DateTime), 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'AM04270004', N'1///', N'Thiếu tướng', NULL, N'1304070001', CAST(0x0000A1AD005C8D4C AS DateTime), 0, CAST(0x0000A1AD005C8D4C AS DateTime), 4, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[armyrank] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'AM04270005', N'3///', N'Thượng tướng', N'', N'1211363', CAST(0x0000A5F000F67BB5 AS DateTime), 0, CAST(0x0000A5F000F67BB5 AS DateTime), 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[ADMINGROUPPRIORITY]    Script Date: 11/28/2017 23:08:42 ******/
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
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMINCORE', 0, 15, 1, N'', CAST(0x0000A838017D0390 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'CORE')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMINDIRE', 0, 15, 1, N'1711150001', CAST(0x0000A82D0010A60F AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'SYSTEM')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'ADMINMENU', 0, 15, 1, N'', CAST(0x0000A82C00E0E4FC AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'SYSTEM')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'LOGGED', 0, 15, 1, N'', CAST(0x0000A838017D0390 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'NONE')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100007', N'ADMINGROUPPRIORITY', N'SUPADMIN', 0, 15, 1, N'1711150001', CAST(0x0000A82D0010A60F AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'SYSTEM')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMINCORE', 0, 15, 1, N'', CAST(0x0000A82C00CEE930 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'CORE')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'ADMINMENU', 0, 15, 1, N'', CAST(0x0000A82B00CECF07 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'SYSTEM')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711100009', N'ADMINGROUPPRIORITY', N'LOGGED', 0, 15, 1, N'', CAST(0x0000A82B00CECF07 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'NONE')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711140001', N'ADMINGROUPPRIORITY', N'ADMINCORE', 0, 15, 1, N'1711150001', CAST(0x0000A82D0010F924 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'CORE')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711140001', N'ADMINGROUPPRIORITY', N'ADMINDIRE', 0, 15, 1, N'1711150001', CAST(0x0000A82D0010F924 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'SYSTEM')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711140001', N'ADMINGROUPPRIORITY', N'ADMINMENU', 0, 15, 1, N'00001', CAST(0x0000A8370178D3A0 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'SYSTEM')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711140001', N'ADMINGROUPPRIORITY', N'LOGGED', 0, 15, 1, N'1711150001', CAST(0x0000A82D0010F924 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'NONE')
INSERT [dbo].[ADMINGROUPPRIORITY] ([objectcode], [thetype], [prioritycode], [forman], [func], [inherit], [edituser], [edittime], [lock], [whois], [universitycode], [thecode], [extensioncode], [tablename], [syscomponentcode]) VALUES (N'1711140001', N'ADMINGROUPPRIORITY', N'SUPADMIN', 0, 15, 1, N'00001', CAST(0x0000A8370178D3A0 AS DateTime), 0, N'', N'HVKTQS', N'', N'', N'DEPARTMENT', N'SYSTEM')
/****** Object:  Table [dbo].[admingroup]    Script Date: 11/28/2017 23:08:42 ******/
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
INSERT [dbo].[admingroup] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [universitycode]) VALUES (N'1711100009', N'MAN', N'Man', NULL, NULL, NULL, NULL, NULL, NULL, N'HVKTQS')
INSERT [dbo].[admingroup] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [universitycode]) VALUES (N'1711140001', N'OTHER', N'Other', NULL, NULL, NULL, NULL, NULL, NULL, N'HVKTQS')
/****** Object:  Table [dbo].[acedemictitlehistory]    Script Date: 11/28/2017 23:08:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acedemictitlehistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[acedemictitlehistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[whois] [varchar](64) NULL,
	[officialnumber] [nvarchar](50) NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](50) NULL,
	[staffinfocode] [varchar](10) NULL,
 CONSTRAINT [PK_acedemictitlehistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[academictitle]    Script Date: 11/28/2017 23:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[academictitle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[academictitle](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[whois] [varchar](64) NULL,
	[eduduty1] [int] NULL,
	[researchduty1] [int] NULL,
	[rate] [float] NULL,
	[edureducerate] [int] NULL,
	[researchreducerate] [int] NULL,
	[eduduty] [int] NULL,
	[researchduty] [int] NULL,
 CONSTRAINT [PK_academictitle_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[academictitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'1304270001', N'PGS', N'Phó Giáo sư', N'', N'admin', CAST(0x0000A5B901031F5E AS DateTime), 0, NULL, 20, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academictitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'1604070001', N'GS', N'Giáo sư', N'', N'1211363', CAST(0x0000A5E1001B102D AS DateTime), 0, NULL, 10, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academictitle] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [eduduty1], [researchduty1], [rate], [edureducerate], [researchreducerate], [eduduty], [researchduty]) VALUES (N'AT04270005', N'KH', N'Khác', N'', N'1304070001', CAST(0x0000A1AD006833C7 AS DateTime), 0, NULL, 30, 99, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[academiclevelhistory]    Script Date: 11/28/2017 23:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[academiclevelhistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[academiclevelhistory](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NULL,
	[thecode] [varchar](10) NULL,
	[approvedstatus] [int] NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[changecurrrent] [int] NULL,
	[pickupdate] [datetime] NULL,
	[pickupdateshow] [varchar](20) NULL,
	[endtime] [datetime] NULL,
	[endtimeshow] [varchar](20) NULL,
	[whois] [varchar](64) NULL,
	[researchstatuslink] [int] NULL,
	[officialnumber] [nvarchar](50) NULL,
	[universitycode] [varchar](10) NULL,
	[thetype] [varchar](50) NULL,
	[staffinfocode] [varchar](10) NULL,
 CONSTRAINT [PK_academiclevelhistory_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[academiclevel]    Script Date: 11/28/2017 23:08:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[academiclevel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[academiclevel](
	[code] [varchar](10) NOT NULL,
	[codeview] [varchar](20) NULL,
	[name] [nvarchar](200) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](20) NULL,
	[edittime] [datetime] NULL,
	[lock] [smallint] NULL,
	[lockdate] [datetime] NULL,
	[comparelevel] [int] NULL,
	[theorder] [int] NULL,
	[whois] [varchar](64) NULL,
	[edureducerate] [int] NULL,
	[researchreducerate] [int] NULL,
	[eduduty] [int] NULL,
	[researchduty] [int] NULL,
	[eduduty1] [int] NULL,
	[researchduty1] [int] NULL,
 CONSTRAINT [PK_academiclevel_MY] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270002', N'GVC', N'Giảng viên chính', N'', N'1304070001', CAST(0x0000A1AD005BA1B5 AS DateTime), 0, NULL, 1, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270003', N'GV', N'Giảng viên', N'', N'1304070001', CAST(0x0000A1AD005BB4CB AS DateTime), 0, NULL, 1, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270004', N'TG', N'Trợ giảng', N'', N'1304070001', CAST(0x0000A1AD005BCA1C AS DateTime), 0, NULL, 11, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'1304270005', N'KH', N'Khác', N'', N'1304070001', CAST(0x0000A1AD006833C7 AS DateTime), 0, NULL, 12, 99, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'GVCC', N'GVCC', N'Giảng viên cao cấp', NULL, NULL, NULL, 0, NULL, 4, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'KTV', N'KTV', N'Kỹ thuật viên', NULL, NULL, NULL, 0, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'KTVC', N'KTVC', N'Kỹ thuật viên chính', NULL, NULL, NULL, 0, NULL, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'KTVCC', N'KTVCC', N'Kỹ thuật viên cao cấp', NULL, NULL, NULL, 0, NULL, 4, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'NCV', N'NCV', N'Nghiên cứu viên', NULL, NULL, NULL, 0, NULL, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'NCVC', N'NCVC', N'Nghiên cứu viên chính', NULL, NULL, NULL, 0, NULL, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'NCVCC', N'NCVCC', N'Nghiên cứu viên cao cấp', NULL, NULL, NULL, 0, NULL, 4, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'TLKT', N'TLKT', N'Trợ lý kỹ thuật', NULL, NULL, NULL, 0, NULL, 13, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[academiclevel] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [comparelevel], [theorder], [whois], [edureducerate], [researchreducerate], [eduduty], [researchduty], [eduduty1], [researchduty1]) VALUES (N'TLNC', N'TLNC', N'Trợ lý nghiên cứu', NULL, NULL, NULL, 0, NULL, 14, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

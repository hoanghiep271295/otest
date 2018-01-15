IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[contenttypequestionuse]') AND type in (N'U'))
DROP TABLE [dbo].[contenttypequestionuse]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[contenttypequestionuse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[contenttypequestionuse](
	[contenttypecode] [varchar](10) NOT NULL,
	[questionusecode] [varchar](10) NOT NULL,
 CONSTRAINT [PK_contenttypequestionuse_MY] PRIMARY KEY CLUSTERED 
(
	[contenttypecode] ASC,
	[questionusecode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[contenttypequestionuse] ([contenttypecode], [questionusecode]) VALUES (N'BT', N'1707140001')
INSERT [dbo].[contenttypequestionuse] ([contenttypecode], [questionusecode]) VALUES (N'KT', N'1707130010')
INSERT [dbo].[contenttypequestionuse] ([contenttypecode], [questionusecode]) VALUES (N'TH', N'1707130011')
GO 
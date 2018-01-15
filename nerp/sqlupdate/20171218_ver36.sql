IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[studentparameter]') AND type in (N'U'))
DROP TABLE [dbo].[studentparameter]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[studentparameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[studentparameter](
	[studentcode] [varchar](10) NOT NULL,
	[thetypecode] [varchar](50) NOT NULL,
	[thevalue] [nvarchar](200) NULL,
	[datatype] [nvarchar](50) NULL,
 CONSTRAINT [PK_studentparameter] PRIMARY KEY CLUSTERED 
(
	[studentcode] ASC,
	[thetypecode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
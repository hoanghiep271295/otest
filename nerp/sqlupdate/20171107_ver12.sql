IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tasknote]') AND type in (N'U'))
DROP TABLE [dbo].[tasknote]
GO
CREATE TABLE [tasknote]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(2000) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [thetype] varchar(50) NULL,
  [eventtime] datetime NULL,
  [eventtimeshow] varchar(20) NULL,
  [eventtype] int NULL,
  [eventwarntime] datetime NULL,
  [eventreminde] int NULL,
  [eventduewarn] int NULL,
  [link] nvarchar(500) NULL,

    CONSTRAINT [PK_tasknote_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 

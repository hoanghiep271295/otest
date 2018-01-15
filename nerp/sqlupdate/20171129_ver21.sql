IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[educationlevel]') AND type in (N'U'))
DROP TABLE [dbo].[educationlevel]
GO
-------------
CREATE TABLE [educationlevel]
(
  [code] varchar(10) NOT NULL,
  [codeview] nvarchar(20) NULL,
  [name] nvarchar(1000) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [theorder] int NULL,
  [thetype] varchar(20) NULL,
  [comparelevel] int NULL,
  [whois] varchar(64) NULL,
  [lang] varchar(10) NULL,

    CONSTRAINT [PK_educationlevel_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
insert into educationlevel select * FROM genlevel where thetype='EDUCATIONLEVEL'
GO
-----------------begin teststructcontent--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[teststructcontent]') AND type in (N'U'))
DROP TABLE [dbo].[teststructcontent]
GO
-------------
CREATE TABLE [teststructcontent]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [subjectcode] varchar(10) NULL,
  [languagecode] varchar(10) NULL,
  [universitycode] varchar(10) NULL,
  [theorder] int NULL,
  [itemnumber] nvarchar(50) NULL,
  [parentcode] varchar(10) NULL,
  [extensioncode] varchar(110) NULL,
  [teststructcode] varchar(10) NULL,

    CONSTRAINT [PK_teststructcontent_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'teststructcontentcode' AND OBJECT_ID = OBJECT_ID(N'teststructdetail'))
BEGIN
alter table teststructdetail add teststructcontentcode varchar(10) null
END 
GO
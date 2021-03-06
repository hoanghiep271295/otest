CREATE TABLE dbo.Tmp_questiongroupuse
	(
	quesitongroupcode varchar(10) NOT NULL,
	questionusecode varchar(10) NOT NULL,
	lock int NULL,
	lockdate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_questiongroupuse SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.questiongroupuse)
	 EXEC('INSERT INTO dbo.Tmp_questiongroupuse (quesitongroupcode, questionusecode, lock, lockdate)
		SELECT quesitongroupcode, questionusecode, lock, lockdate FROM dbo.questiongroupuse WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.questiongroupuse
GO
EXECUTE sp_rename N'dbo.Tmp_questiongroupuse', N'questiongroupuse', 'OBJECT' 
GO
ALTER TABLE dbo.questiongroupuse ADD CONSTRAINT
	PK_questiongroupuse_MY PRIMARY KEY CLUSTERED 
	(
	quesitongroupcode,
	questionusecode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
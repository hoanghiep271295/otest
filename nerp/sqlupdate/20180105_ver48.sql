IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'QUESTIONGROUP'
                 AND COLUMN_NAME = 'MARK')
BEGIN
	alter table TESTSTRUCT add mark float default 1
	,theorder int default 0
	,univeristycode varchar(10) default 'HVKTQS'

END
GO

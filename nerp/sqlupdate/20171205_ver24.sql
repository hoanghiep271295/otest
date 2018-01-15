IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'postcode' AND OBJECT_ID = OBJECT_ID(N'nation'))
BEGIN
alter table nation add postcode varchar(10) null
END 
GO
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'mailcode' AND OBJECT_ID = OBJECT_ID(N'nation'))
BEGIN
alter table nation add mailcode varchar(10) null
END 
GO
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'postcode' AND OBJECT_ID = OBJECT_ID(N'province'))
BEGIN
alter table province add postcode varchar(10) null
END 
GO
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'mailcode' AND OBJECT_ID = OBJECT_ID(N'province'))
BEGIN
alter table province add mailcode varchar(10) null
END 
GO
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'postcode' AND OBJECT_ID = OBJECT_ID(N'district'))
BEGIN
alter table district add postcode varchar(10) null
END 
GO
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'mailcode' AND OBJECT_ID = OBJECT_ID(N'district'))
BEGIN
alter table district add mailcode varchar(10) null
END 
GO   
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'postcode' AND OBJECT_ID = OBJECT_ID(N'town'))
BEGIN
alter table town add postcode varchar(10) null
END 
GO
IF NOT EXISTS(SELECT * FROM sys.columns
WHERE Name = N'mailcode' AND OBJECT_ID = OBJECT_ID(N'town'))
BEGIN
alter table town add mailcode varchar(10) null
END 
GO
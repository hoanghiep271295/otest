-----------------begin warehouselevel--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouselevel]') AND type in (N'U'))
DROP TABLE [dbo].[warehouselevel]
GO
-------------
CREATE TABLE [warehouselevel]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [thetype] varchar(50) NULL,
  [office] int NULL,

    CONSTRAINT [PK_warehouselevel_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end warehouselevel--------------------
GO


-----------------begin warehouse--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouse]') AND type in (N'U'))
DROP TABLE [dbo].[warehouse]
GO
-------------
CREATE TABLE [warehouse]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [warehouselevelcode] varchar(10) NULL,
  [theorder] int NULL,
  [thetype] varchar(50) NULL,
  [provincecodoe] varchar(10) NULL,
  [districtcode] varchar(10) NULL,
  [towncode] varchar(10) NULL,
  [departmentcode] varchar(10) NULL,
  [regioncode] varchar(10) NULL,
  [address] nvarchar(1000) NULL,
  [phone] varchar(20) NULL,
  [email] varchar(10) NULL,
  [mailcode] varchar(20) NULL,
  [staffcode1] varchar(10) NULL,
  [staffcode2] varchar(10) NULL,
  [parentcode] varchar(10) NULL,
  [extensioncode] varchar(100) NULL,

    CONSTRAINT [PK_warehouse_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end warehouse--------------------
GO


-----------------begin warehouseequipmenttype--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[warehouseequipmenttype]') AND type in (N'U'))
DROP TABLE [dbo].[warehouseequipmenttype]
GO
-------------
CREATE TABLE [warehouseequipmenttype]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [whois] varchar(64) NULL,
  [edureducerate] int NULL,
  [researchreducerate] int NULL,
  [eduduty] int NULL,
  [researchduty] int NULL,
  [eduduty1] int NULL,
  [researchduty1] int NULL,

    CONSTRAINT [PK_warehouseequipmenttype_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end warehouseequipmenttype--------------------
GO


-----------------begin equipmentfield--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipmentfield]') AND type in (N'U'))
DROP TABLE [dbo].[equipmentfield]
GO
-------------
CREATE TABLE [equipmentfield]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,

    CONSTRAINT [PK_equipmentfield_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end equipmentfield--------------------
GO


-----------------begin equipmentgroup--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipmentgroup]') AND type in (N'U'))
DROP TABLE [dbo].[equipmentgroup]
GO
-------------
CREATE TABLE [equipmentgroup]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,

    CONSTRAINT [PK_equipmentgroup_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end equipmentgroup--------------------
GO


-----------------begin equipmenttype--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipmenttype]') AND type in (N'U'))
DROP TABLE [dbo].[equipmenttype]
GO
-------------
CREATE TABLE [equipmenttype]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,

    CONSTRAINT [PK_equipmenttype_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end equipmenttype--------------------
GO


-----------------begin equipmentlevel--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipmentlevel]') AND type in (N'U'))
DROP TABLE [dbo].[equipmentlevel]
GO
-------------
CREATE TABLE [equipmentlevel]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,

    CONSTRAINT [PK_equipmentlevel_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end equipmentlevel--------------------
GO


-----------------begin qualitylevel--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[qualitylevel]') AND type in (N'U'))
DROP TABLE [dbo].[qualitylevel]
GO
-------------
CREATE TABLE [qualitylevel]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,

    CONSTRAINT [PK_qualitylevel_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end qualitylevel--------------------
GO


-----------------begin producer--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[producer]') AND type in (N'U'))
DROP TABLE [dbo].[producer]
GO
-------------
CREATE TABLE [producer]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,
  [address] nvarchar(500) NULL,
  [email] nvarchar(100) NULL,
  [phone] varchar(20) NULL,
  [mailaddress] nvarchar(500) NULL,
  [presenter] nvarchar(200) NULL,
  [nationcode] varchar(10) NULL,

    CONSTRAINT [PK_producer_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end producer--------------------
GO


-----------------begin supplier--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[supplier]') AND type in (N'U'))
DROP TABLE [dbo].[supplier]
GO
-------------
CREATE TABLE [supplier]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,
  [address] nvarchar(500) NULL,
  [email] nvarchar(100) NULL,
  [phone] varchar(20) NULL,
  [mailaddress] nvarchar(500) NULL,
  [presenter] nvarchar(200) NULL,
  [nationcode] varchar(10) NULL,
  [taxnumber] varchar(20) NULL,

    CONSTRAINT [PK_supplier_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end supplier--------------------
GO


-----------------begin quantity--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[quantity]') AND type in (N'U'))
DROP TABLE [dbo].[quantity]
GO
-------------
CREATE TABLE [quantity]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(200) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [comparelevel] int NULL,
  [theorder] int NULL,
  [Thetype] varchar(50) NULL,
  [basecode] varchar(10) NULL,
  [rate] decimal(5,2) NULL,

    CONSTRAINT [PK_quantity_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end quantity--------------------
GO


-----------------begin equipment--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipment]') AND type in (N'U'))
DROP TABLE [dbo].[equipment]
GO
-------------
CREATE TABLE [equipment]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(1000) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [equipmenttypecode] varchar(10) NULL,
  [equipmentlevelcode] varchar(10) NULL,
  [equipmentgroupcode] varchar(10) NULL,
  [equipmentfieldcode] varchar(10) NULL,
  [quantitycode] varchar(10) NULL,
  [suppliercode] varchar(10) NULL,
  [nationcode] varchar(10) NULL,

    CONSTRAINT [PK_equipment_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end equipment--------------------
GO


-----------------begin equipmentconfig--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipmentconfig]') AND type in (N'U'))
DROP TABLE [dbo].[equipmentconfig]
GO
-------------
CREATE TABLE [equipmentconfig]
(
  [code] Varchar(10) NOT NULL,
  [parentcode] varchar(10) NULL,
  [childcode] varchar(10) NULL,
  [mincount] int NULL,
  [maxcount] int NULL,

    CONSTRAINT [PK_equipmentconfig_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end equipmentconfig--------------------
GO


-----------------begin equipmentreplace--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipmentreplace]') AND type in (N'U'))
DROP TABLE [dbo].[equipmentreplace]
GO
-------------
CREATE TABLE [equipmentreplace]
(
  [code] Varchar(10) NOT NULL,
  [parentcode] varchar(10) NULL,
  [childcode] varchar(10) NULL,
  [parentcount] int NULL,
  [childcount] int NULL,

    CONSTRAINT [PK_equipmentreplace_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end equipmentreplace--------------------
GO


-----------------begin devicestatus--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[devicestatus]') AND type in (N'U'))
DROP TABLE [dbo].[devicestatus]
GO
-------------
CREATE TABLE [devicestatus]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(1000) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [statusnum] int NULL,

    CONSTRAINT [PK_devicestatus_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end devicestatus--------------------
GO


-----------------begin device--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[device]') AND type in (N'U'))
DROP TABLE [dbo].[device]
GO
-------------
CREATE TABLE [device]
(
  [code] Varchar(10) NOT NULL,
  [codeview] Varchar(20) NULL,
  [recodeview] varchar(20) NULL,
  [name] Nvarchar(200) NULL,
  [note] Nvarchar(1000) NULL,
  [edituser] Varchar(20) NULL,
  [edittime] Datetime NULL,
  [lock] smallint NULL,
  [lockdate] datetime NULL,
  [whois] varchar(64) NULL,
  [equipmenttypecode] varchar(10) NULL,
  [equipmentlevelcode] varchar(10) NULL,
  [equipmentgroupcode] varchar(10) NULL,
  [equipmentfieldcode] varchar(10) NULL,
  [quantitycode] varchar(10) NULL,
  [suppliercode] varchar(10) NULL,
  [nationcode] varchar(10) NULL,
  [equipmentcode] varchar(10) NULL,
  [warehousecode] varchar(10) NULL,
  [departmentcode] varchar(10) NULL,
  [qualitylevelcode] varchar(10) NULL,
  [parentcode] varchar(10) NULL,
  [extensioncode] varchar(100) NULL,
  [rootcode] varchar(10) NULL,
  [lastcheck] datetime NULL,
  [lastrepair] datetime NULL,
  [documentfile] nvarchar(200) NULL,
  [technicalfile] nvarchar(200) NULL,
  [technicalnote] nvarchar(1000) NULL,
  [technicalsize] nvarchar(1000) NULL,

    CONSTRAINT [PK_device_MY] PRIMARY KEY CLUSTERED 
    (
        [code] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end device--------------------
GO


-----------------begin devicefile--------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[devicefile]') AND type in (N'U'))
DROP TABLE [dbo].[devicefile]
GO
-------------
CREATE TABLE [devicefile]
(
  [devicecode] Varchar(10) NOT NULL,
  [filename] Varchar(20) NOT NULL,
  [filetype] int NULL,

    CONSTRAINT [PK_devicefile_MY] PRIMARY KEY CLUSTERED 
    (
        [devicecode] ASC
        ,[filename] ASC

    ) ON [PRIMARY]
)
GO 
-----------------end devicefile--------------------
GO




ALTER TABLE TASKNOTE ADD icon varchar(50) null
GO
INSERT [dbo].[tasknote] ([code], [codeview], [name], [note], [edituser], [edittime], [lock], [lockdate], [whois], [thetype], [eventtime], [eventtimeshow], [eventtype], [eventwarntime], [eventreminde], [eventduewarn], [link], [staffcode], [icon]) VALUES (N'123', N'123', N'Kh�ng', N'Kh�ng co', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', N'fa-rocket bg-yellow')
GO
﻿---Create the table for the DB

CREATE TABLE [dbo].[Requests]
(
	[ID]	INT IDENTITY(1,1) NOT NULL,
	[DATEREQ] DATETIME NOT NULL,
	[REQUEST] NVARCHAR(100) NOT NULL,
	[IPADDRESS] NVARCHAR(128) NOT NULL,
	[BROWSERAG] NVARCHAR(128) NOT NULL,

	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)

);
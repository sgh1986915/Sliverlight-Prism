
--After this please rerun PopulateDimDate.sql adn PopulateDimTime.sql

USE [ProcbelApps];
GO
SET IDENTITY_INSERT [dbo].[Sites] ON;
INSERT [dbo].[Sites] ([Id], [Name]) VALUES (1, N'Stanwell Corporation');
INSERT [dbo].[Sites] ([Id], [Name]) VALUES (2, N'Other Corporation');

SET IDENTITY_INSERT [dbo].[Sites] OFF;
GO

INSERT [dbo].[Code] ([CodeID], [CodeType], [CodeName], [Description], [AssocText], [AssocValue], [ChangeDate], [CreateDate], [ParentID]) VALUES (1, N'Priority', N'High', NULL, NULL, 3, NULL, CAST(0x0000A235000920A6 AS DateTime), NULL)
GO
INSERT [dbo].[Code] ([CodeID], [CodeType], [CodeName], [Description], [AssocText], [AssocValue], [ChangeDate], [CreateDate], [ParentID]) VALUES (2, N'Priority', N'Low', NULL, NULL, 1, NULL, CAST(0x0000A2350009329A AS DateTime), NULL)
GO
INSERT [dbo].[Code] ([CodeID], [CodeType], [CodeName], [Description], [AssocText], [AssocValue], [ChangeDate], [CreateDate], [ParentID]) VALUES (3, N'Priority', N'Midium', NULL, NULL, 2, NULL, CAST(0x0000A235000948FF AS DateTime), NULL)
GO

SET IDENTITY_INSERT [dbo].[Images] ON
INSERT INTO [dbo].[Images] ([Id], [ImagePath], [Extension], [MimeType], [Name], [Size],[Content]) VALUES (1, N'/Images/CompanyLogos/defaultCompany.jpg', N'jpg', NULL, N'defaultCompany', 0,null)
INSERT INTO [dbo].[Images] ([Id], [ImagePath], [Extension], [MimeType], [Name], [Size],[Content]) VALUES (2, N'/Images/CompanyLogos/defaultCompany.jpg', N'jpg', NULL, N'defaultCompany', 0,null)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO

SET IDENTITY_INSERT [dbo].[Company] ON
INSERT INTO [dbo].[Company] ([CompanyID], [Name], [Address], [City], [State], [Country], [Postcode], [Website], [Notes], [Revenue], [NASDAQ], [Industry], [IsActive], [ImageId], [SiteId]) VALUES (1, N'My Company', N'Best Street nº 123', N'Madrid', N'Madrid', N'Spain', N'28080', N'www.example.com', N'Notes of Information', CAST(12000.0000 AS Decimal(19, 4)), N'NAS23DQ', N'Automation', 1, 1, 1)
INSERT INTO [dbo].[Company] ([CompanyID], [Name], [Address], [City], [State], [Country], [Postcode], [Website], [Notes], [Revenue], [NASDAQ], [Industry], [IsActive], [ImageId], [SiteId]) VALUES (2, N'Other Company', N'Best Street nº 123', N'Barcelona', N'Barcelona', N'Spain', N'28080', N'www.example.net', N'Notes of Information', CAST(12000.0000 AS Decimal(19, 4)), N'NAS23DQ', N'Automation', 1, 2, 2)
SET IDENTITY_INSERT [dbo].[Company] OFF
Go

SET IDENTITY_INSERT [dbo].[SalesTrend] ON
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (673, CAST(2181.0000 AS Money), N'2010-01-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (674, CAST(1867.0000 AS Money), N'2010-02-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (675, CAST(3135.0000 AS Money), N'2010-03-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (676, CAST(3808.0000 AS Money), N'2010-04-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (677, CAST(2649.0000 AS Money), N'2010-05-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (678, CAST(2209.0000 AS Money), N'2010-06-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (679, CAST(1839.0000 AS Money), N'2010-07-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (680, CAST(3009.0000 AS Money), N'2010-08-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (681, CAST(4826.0000 AS Money), N'2010-09-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (682, CAST(4090.0000 AS Money), N'2010-10-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (683, CAST(4711.0000 AS Money), N'2010-11-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (684, CAST(4476.0000 AS Money), N'2010-12-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (685, CAST(1809.0000 AS Money), N'2011-01-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (686, CAST(1707.0000 AS Money), N'2011-02-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (687, CAST(1195.0000 AS Money), N'2011-03-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (688, CAST(4147.0000 AS Money), N'2011-04-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (689, CAST(3067.0000 AS Money), N'2011-05-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (690, CAST(3963.0000 AS Money), N'2011-06-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (691, CAST(2051.0000 AS Money), N'2011-07-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (692, CAST(4672.0000 AS Money), N'2011-08-01 00:00:00', 1)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (693, CAST(1206.0000 AS Money), N'2010-01-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (694, CAST(1272.0000 AS Money), N'2010-02-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (695, CAST(1120.0000 AS Money), N'2010-03-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (696, CAST(3326.0000 AS Money), N'2010-04-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (697, CAST(1947.0000 AS Money), N'2010-05-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (698, CAST(1463.0000 AS Money), N'2010-06-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (699, CAST(2412.0000 AS Money), N'2010-07-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (700, CAST(1848.0000 AS Money), N'2010-08-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (701, CAST(3898.0000 AS Money), N'2010-09-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (702, CAST(2972.0000 AS Money), N'2010-10-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (703, CAST(1110.0000 AS Money), N'2010-11-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (704, CAST(1562.0000 AS Money), N'2010-12-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (705, CAST(3488.0000 AS Money), N'2011-01-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (706, CAST(3942.0000 AS Money), N'2011-02-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (707, CAST(1206.0000 AS Money), N'2011-03-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (708, CAST(3940.0000 AS Money), N'2011-04-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (709, CAST(1093.0000 AS Money), N'2011-05-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (710, CAST(2864.0000 AS Money), N'2011-06-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (711, CAST(2661.0000 AS Money), N'2011-07-01 00:00:00', 2)
INSERT INTO [dbo].[SalesTrend] ([SalesTrendID], [Amount], [Date], [CompanyID]) VALUES (712, CAST(3482.0000 AS Money), N'2011-08-01 00:00:00', 2)
SET IDENTITY_INSERT [dbo].[SalesTrend] OFF


SET IDENTITY_INSERT [dbo].[LocationTypes] ON
INSERT INTO [dbo].[LocationTypes] ([Id], [SiteId], [Name], [Description]) VALUES (1, 1, N'HQ', N'HQ Location')
INSERT INTO [dbo].[LocationTypes] ([Id], [SiteId], [Name], [Description]) VALUES (2,1, N'Warehouse', N'Whre Products are')
INSERT INTO [dbo].[LocationTypes] ([Id], [SiteId], [Name], [Description]) VALUES (3,1, N'Production', N'Here we made goods')
INSERT INTO [dbo].[LocationTypes] ([Id], [SiteId], [Name], [Description]) VALUES (4,1, N'Office', N'Office facility')
INSERT INTO [dbo].[LocationTypes] ([Id], [SiteId], [Name], [Description]) VALUES (5,1, N'Division', N'A Financial/Sales Division')
SET IDENTITY_INSERT [dbo].[LocationTypes] OFF
Go

--examples of EF code to use this hierarchy model, inside Issues.txt
Create TRIGGER [dbo].[trg_LocationInsert] ON [dbo].Locations FOR INSERT AS BEGIN
 DECLARE @numrows int SET @numrows = @@ROWCOUNT if @numrows > 1
  BEGIN RAISERROR('Only single row insertion is supported', 16, 1) 
  ROLLBACK TRAN END ELSE BEGIN UPDATE E SET hierarchyLevel = CASE WHEN
   E.parentId IS NULL THEN 0 ELSE Parent.hierarchyLevel + 1 END,
    fullPath = CASE WHEN E.parentId IS NULL THEN '.' 
	ELSE Parent.fullPath END + CAST(E.id AS varchar(10)) + '.' FROM Locations AS E INNER JOIN inserted AS I ON I.id = E.id LEFT OUTER JOIN Locations AS Parent ON Parent.id = E.parentId
	 END
 END;
 GO 

 Create TRIGGER [dbo].[trg_LocationUpdate] ON [dbo].Locations FOR UPDATE AS BEGIN
  IF @@ROWCOUNT = 0 RETURN if UPDATE(parentid)
   BEGIN UPDATE E SET hierarchyLevel = E.hierarchyLevel - I.hierarchyLevel + CASE WHEN I.parentId IS NULL THEN 0 ELSE Parent.hierarchyLevel + 1 END,
    fullPath = ISNULL(Parent.fullPath, '.') + CAST(I.id as varchar(10)) + '.' + RIGHT(E.fullPath, len(E.fullPath) - len(I.fullPath)) FROM Locations AS E INNER JOIN inserted AS I ON E.fullPath LIKE I.fullPath + '%'
	 LEFT OUTER JOIN Locations AS Parent ON I.parentId = Parent.id
	  END
 END;
 Go
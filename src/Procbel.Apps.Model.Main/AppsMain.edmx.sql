CREATE DATABASE [ProcbelApps] ON  PRIMARY 
( NAME = N'ProcbelApps', FILENAME = N'C:\__REPOSITORIES\PROCBEL.APPS\PROCBEL.APPS.MODEL.MAIN\PROCBELAPPS.MDF' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
LOG ON 
( NAME = N'ProcbelApps_log', FILENAME = N'C:\__repositories\Procbel.Apps\Procbel.Apps.Model.Main\ProcbelApps_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/17/2013 20:18:05
-- Generated from EDMX file: C:\__repositories\Procbel.Apps\Procbel.Apps.Model.Main\AppsMain.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProcbelApps];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SiteEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_SiteEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteFactTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactTags] DROP CONSTRAINT [FK_SiteFactTag];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_SiteCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [FK_SiteSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteAsset]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assets] DROP CONSTRAINT [FK_SiteAsset];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sites] DROP CONSTRAINT [FK_SiteImage];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_SiteLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_SiteProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteProductBox]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductBoxes] DROP CONSTRAINT [FK_SiteProductBox];
GO
IF OBJECT_ID(N'[dbo].[FK_InfoTagLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InfoTags] DROP CONSTRAINT [FK_InfoTagLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_ReaderTagReaderTagAntena]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReaderTagAntenas] DROP CONSTRAINT [FK_ReaderTagReaderTagAntena];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCategoryProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductCategoryProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCategoryFactTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactTags] DROP CONSTRAINT [FK_ProductCategoryFactTag];
GO
IF OBJECT_ID(N'[dbo].[FK_productAssortmentFactTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactTags] DROP CONSTRAINT [FK_productAssortmentFactTag];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductBoxFactTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactTags] DROP CONSTRAINT [FK_ProductBoxFactTag];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeEmployeeShifts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeShifts] DROP CONSTRAINT [FK_EmployeeEmployeeShifts];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketAttachments_Tickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketAttachments] DROP CONSTRAINT [FK_TicketAttachments_Tickets];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketComments_Tickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketComments] DROP CONSTRAINT [FK_TicketComments_Tickets];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketEventNotifications_TicketComments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketEventNotifications] DROP CONSTRAINT [FK_TicketEventNotifications_TicketComments];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_SiteTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteSetting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Settings] DROP CONSTRAINT [FK_SiteSetting];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketCategoryTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketCategoryTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketTypeTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketTypeTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketStatusTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketStatusTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_Activity_Opportunity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity] DROP CONSTRAINT [FK_Activity_Opportunity];
GO
IF OBJECT_ID(N'[dbo].[FK_Contact_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_Opportunity_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_Opportunity_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesTrend_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesTrend] DROP CONSTRAINT [FK_SalesTrend_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeActivity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activity] DROP CONSTRAINT [FK_EmployeeActivity];
GO
IF OBJECT_ID(N'[dbo].[FK_ImageContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_ImageContact];
GO
IF OBJECT_ID(N'[dbo].[FK_ImageProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ImageProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductOpportunity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_ProductOpportunity];
GO
IF OBJECT_ID(N'[dbo].[FK_ImageEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_ImageEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_SiteCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationHierarchyParent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_LocationHierarchyParent];
GO
IF OBJECT_ID(N'[dbo].[FK_ImageLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_ImageLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_CompanyCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanySupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [FK_CompanySupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactOpportunity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_ContactOpportunity];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationLocationType_Location]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationLocationType] DROP CONSTRAINT [FK_LocationLocationType_Location];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationLocationType_LocationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationLocationType] DROP CONSTRAINT [FK_LocationLocationType_LocationType];
GO
IF OBJECT_ID(N'[dbo].[FK_LocationLocationHierarchyLevel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Locations] DROP CONSTRAINT [FK_LocationLocationHierarchyLevel];
GO
IF OBJECT_ID(N'[dbo].[FK_ImageCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK_ImageCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteLocationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationTypes] DROP CONSTRAINT [FK_SiteLocationType];
GO
IF OBJECT_ID(N'[dbo].[FK_SiteOpportunity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Opportunity] DROP CONSTRAINT [FK_SiteOpportunity];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketTicketTag_Ticket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketTicketTag] DROP CONSTRAINT [FK_TicketTicketTag_Ticket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketTicketTag_TicketTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketTicketTag] DROP CONSTRAINT [FK_TicketTicketTag_TicketTag];
GO
IF OBJECT_ID(N'[dbo].[FK_Code_Code]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Code] DROP CONSTRAINT [FK_Code_Code];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sites];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[FactTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactTags];
GO
IF OBJECT_ID(N'[dbo].[Assets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assets];
GO
IF OBJECT_ID(N'[dbo].[DimDates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DimDates];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[InfoTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InfoTags];
GO
IF OBJECT_ID(N'[dbo].[ReaderTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReaderTags];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[ProductCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategories];
GO
IF OBJECT_ID(N'[dbo].[productAssortments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productAssortments];
GO
IF OBJECT_ID(N'[dbo].[ProductBoxes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductBoxes];
GO
IF OBJECT_ID(N'[dbo].[EmployeeShifts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeShifts];
GO
IF OBJECT_ID(N'[dbo].[ReaderTagAntenas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReaderTagAntenas];
GO
IF OBJECT_ID(N'[dbo].[DimTime]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DimTime];
GO
IF OBJECT_ID(N'[dbo].[TicketAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketAttachments];
GO
IF OBJECT_ID(N'[dbo].[TicketComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketComments];
GO
IF OBJECT_ID(N'[dbo].[TicketEventNotifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketEventNotifications];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[TicketTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketTags];
GO
IF OBJECT_ID(N'[dbo].[Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Settings];
GO
IF OBJECT_ID(N'[dbo].[TicketTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketTypeSet];
GO
IF OBJECT_ID(N'[dbo].[TicketCategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketCategorySet];
GO
IF OBJECT_ID(N'[dbo].[TicketStatusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketStatusSet];
GO
IF OBJECT_ID(N'[dbo].[Activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activity];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[Opportunity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opportunity];
GO
IF OBJECT_ID(N'[dbo].[SalesTrend]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesTrend];
GO
IF OBJECT_ID(N'[dbo].[LocationTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationTypes];
GO
IF OBJECT_ID(N'[dbo].[LocationHierarchyLevels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationHierarchyLevels];
GO
IF OBJECT_ID(N'[dbo].[ProductCatalogStructures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCatalogStructures];
GO
IF OBJECT_ID(N'[dbo].[ProductCatalogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCatalogs];
GO
IF OBJECT_ID(N'[dbo].[DocumentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentSet];
GO
IF OBJECT_ID(N'[dbo].[Code]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Code];
GO
IF OBJECT_ID(N'[dbo].[LocationLocationType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationLocationType];
GO
IF OBJECT_ID(N'[dbo].[TicketTicketTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketTicketTag];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sites'
CREATE TABLE [dbo].[Sites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(100)  NOT NULL,
    [ImageId] int  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [Propiedad1] nvarchar(max)  NOT NULL,
    [Credito] decimal(19,4)  NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [IdentificationTagId] nchar(30)  NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NULL,
    [BirthDate] datetime  NULL,
    [Position] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Name] nvarchar(50)  NULL,
    [IsActive] bit  NULL,
    [ImageId] int  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImagePath] nvarchar(max)  NULL,
    [Content] varbinary(max)  NULL,
    [Extension] nvarchar(50)  NULL,
    [MimeType] nvarchar(50)  NULL,
    [Name] nvarchar(50)  NULL,
    [Size] float  NOT NULL
);
GO

-- Creating table 'FactTags'
CREATE TABLE [dbo].[FactTags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [DimDateId] int  NOT NULL,
    [DimTimeId] int  NOT NULL,
    [TagId] nchar(30)  NOT NULL,
    [LocationId] int  NOT NULL,
    [ProductId] int  NULL,
    [EmployeeId] int  NULL,
    [ProductCategoryId] int  NULL,
    [productAssortmentId] int  NULL,
    [ProductBoxId] int  NULL
);
GO

-- Creating table 'Assets'
CREATE TABLE [dbo].[Assets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL
);
GO

-- Creating table 'DimDates'
CREATE TABLE [dbo].[DimDates] (
    [Id] int  NOT NULL,
    [FullDate] nvarchar(max)  NOT NULL,
    [DateName] nvarchar(max)  NOT NULL,
    [DateNameUS] nvarchar(max)  NULL,
    [DateNameEU] nvarchar(max)  NULL,
    [DayOfWeek] nvarchar(max)  NOT NULL,
    [DayOfWeekName] nvarchar(max)  NOT NULL,
    [DayOfWeekNameSpanish] nvarchar(max)  NULL,
    [DayOfWeekNameChinese] nvarchar(max)  NULL,
    [DayOfMonth] nvarchar(max)  NOT NULL,
    [DayOfYear] nvarchar(max)  NOT NULL,
    [WeekdayWeekend] nvarchar(max)  NOT NULL,
    [WeekOfYear] nvarchar(max)  NOT NULL,
    [MonthName] nvarchar(max)  NOT NULL,
    [MonthNameSpanish] nvarchar(max)  NULL,
    [MonthNameChinese] nvarchar(max)  NULL,
    [MonthOfYear] nvarchar(max)  NOT NULL,
    [IsLastDayOfMonth] nvarchar(max)  NOT NULL,
    [CalendarQuarter] nvarchar(max)  NOT NULL,
    [CalendarYear] nvarchar(max)  NOT NULL,
    [CalendarYearMonth] nvarchar(max)  NOT NULL,
    [CalendarYearQtr] nvarchar(max)  NOT NULL,
    [FiscalMonthOfYear] nvarchar(max)  NOT NULL,
    [FiscalQuarter] nvarchar(max)  NOT NULL,
    [FiscalYear] smallint  NOT NULL,
    [FiscalYearMonth] nvarchar(max)  NOT NULL,
    [FiscalYearQtr] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [SpaceCenter] geography  NULL,
    [parentId] int  NULL,
    [hierarchyLevel] smallint  NOT NULL,
    [fullPath] nvarchar(max)  NOT NULL,
    [ImageId] int  NULL,
    [MapPath] geometry  NULL,
    [HierarchyLevelId] int  NOT NULL,
    [ShapeFileUri] nvarchar(max)  NULL,
    [ShapeFileDataUri] nvarchar(max)  NULL
);
GO

-- Creating table 'InfoTags'
CREATE TABLE [dbo].[InfoTags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TagId] nchar(30)  NOT NULL,
    [LocationId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [SpaceRead] geography  NULL,
    [isCompleted] bit  NOT NULL,
    [isSync] bit  NOT NULL
);
GO

-- Creating table 'ReaderTags'
CREATE TABLE [dbo].[ReaderTags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(20)  NOT NULL,
    [Model] nchar(20)  NULL,
    [IP] nvarchar(max)  NULL,
    [Port] nvarchar(max)  NULL,
    [Com] nvarchar(max)  NULL,
    [CanWrite] bit  NOT NULL,
    [OnDemand] bit  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [ProductNumber] nvarchar(25)  NOT NULL,
    [Name] nchar(100)  NOT NULL,
    [EnglishName] nchar(100)  NULL,
    [FrenchName] nchar(100)  NULL,
    [ChineseName] nchar(100)  NULL,
    [ProductCategoryId] int  NULL,
    [ProductType] int  NOT NULL,
    [Features] nvarchar(600)  NULL,
    [UnitPrice] decimal(19,4)  NULL,
    [ImageId] int  NOT NULL,
    [Description] nvarchar(400)  NULL,
    [EnglishDescription] nvarchar(400)  NULL,
    [FrenchDescription] nvarchar(400)  NULL,
    [ChineseDescription] nvarchar(400)  NULL,
    [ArabicDescription] nvarchar(400)  NULL,
    [HebrewDescription] nvarchar(400)  NULL,
    [ThaiDescription] nvarchar(400)  NULL,
    [GermanDescription] nvarchar(400)  NULL,
    [JapaneseDescription] nvarchar(400)  NULL,
    [TurkishDescription] nvarchar(400)  NULL
);
GO

-- Creating table 'ProductCategories'
CREATE TABLE [dbo].[ProductCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(100)  NOT NULL,
    [NameEnglish] nchar(100)  NULL,
    [NameChinese] nchar(100)  NULL
);
GO

-- Creating table 'productAssortments'
CREATE TABLE [dbo].[productAssortments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(100)  NOT NULL,
    [NameEnglish] nchar(100)  NULL,
    [NameChinese] nchar(100)  NULL
);
GO

-- Creating table 'ProductBoxes'
CREATE TABLE [dbo].[ProductBoxes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [Name] nchar(100)  NOT NULL,
    [NameEnglish] nchar(100)  NULL,
    [NameChinese] nchar(100)  NULL,
    [NetWeight] float  NOT NULL,
    [ProductType] int  NOT NULL
);
GO

-- Creating table 'EmployeeShifts'
CREATE TABLE [dbo].[EmployeeShifts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeId] int  NOT NULL,
    [DimTimeId] int  NOT NULL,
    [DimDateId] int  NOT NULL
);
GO

-- Creating table 'ReaderTagAntenas'
CREATE TABLE [dbo].[ReaderTagAntenas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AntenaArray] nvarchar(max)  NOT NULL,
    [ReaderTagId] int  NOT NULL
);
GO

-- Creating table 'DimTime'
CREATE TABLE [dbo].[DimTime] (
    [Id] smallint  NOT NULL,
    [hour_of_day_24] tinyint  NULL,
    [hour_of_day_12] tinyint  NULL,
    [am_pm] char(2)  NULL,
    [minute_of_hour] tinyint  NULL,
    [half_hour] tinyint  NULL,
    [half_hour_of_day] tinyint  NULL,
    [quarter_hour] tinyint  NULL,
    [quarter_hour_of_day] tinyint  NULL,
    [string_representation_24] char(5)  NULL,
    [string_representation_12] char(5)  NULL
);
GO

-- Creating table 'TicketAttachments'
CREATE TABLE [dbo].[TicketAttachments] (
    [TicketId] int  NULL,
    [FileId] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(255)  NOT NULL,
    [FileSize] int  NOT NULL,
    [FileType] nvarchar(250)  NOT NULL,
    [UploadedBy] nvarchar(100)  NOT NULL,
    [UploadedDate] datetime  NOT NULL,
    [FileContents] varbinary(max)  NOT NULL,
    [FileDescription] nvarchar(500)  NULL,
    [IsPending] bit  NOT NULL,
    [FileUrl] nvarchar(max)  NULL
);
GO

-- Creating table 'TicketComments'
CREATE TABLE [dbo].[TicketComments] (
    [TicketId] int  NOT NULL,
    [CommentId] int IDENTITY(1,1) NOT NULL,
    [CommentEvent] nvarchar(500)  NULL,
    [Comment] nvarchar(max)  NULL,
    [IsHtml] bit  NOT NULL,
    [CommentedBy] nvarchar(100)  NOT NULL,
    [CommentedDate] datetime  NOT NULL,
    [Version] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'TicketEventNotifications'
CREATE TABLE [dbo].[TicketEventNotifications] (
    [TicketId] int  NOT NULL,
    [CommentId] int  NOT NULL,
    [NotifyUser] nvarchar(100)  NOT NULL,
    [NotifyUserDisplayName] nvarchar(100)  NOT NULL,
    [NotifyEmail] nvarchar(255)  NOT NULL,
    [NotifyUserReason] nvarchar(50)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [DeliveryAttempts] int  NOT NULL,
    [LastDeliveryAttemptDate] datetime  NULL,
    [Status] nvarchar(20)  NOT NULL,
    [NextDeliveryAttemptDate] datetime  NULL,
    [EventGeneratedByUser] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [TicketId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(500)  NOT NULL,
    [Details] nvarchar(max)  NOT NULL,
    [IsHtml] bit  NOT NULL,
    [TagList] nvarchar(100)  NULL,
    [CreatedBy] nvarchar(100)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Owner] nvarchar(100)  NOT NULL,
    [AssignedTo] nvarchar(100)  NULL,
    [CurrentStatusDate] datetime  NOT NULL,
    [CurrentStatusSetBy] nvarchar(100)  NOT NULL,
    [LastUpdateBy] nvarchar(100)  NOT NULL,
    [LastUpdateDate] datetime  NOT NULL,
    [Priority] nvarchar(25)  NULL,
    [AffectsCustomer] bit  NOT NULL,
    [PublishedToKb] bit  NOT NULL,
    [Version] uniqueidentifier  NOT NULL,
    [DimCreatedDateId] int  NOT NULL,
    [DimCreatedTimeId] int  NOT NULL,
    [DimCurrentStatusDateId] int  NOT NULL,
    [DimCurrentStatusTimeId] int  NOT NULL,
    [SiteId] int  NOT NULL,
    [TicketCategoryTicketCategoryId] int  NOT NULL,
    [TicketTypeTicketTypeId] int  NOT NULL,
    [TicketStatusTicketStatusId] int  NOT NULL
);
GO

-- Creating table 'TicketTags'
CREATE TABLE [dbo].[TicketTags] (
    [TicketTagId] int IDENTITY(1,1) NOT NULL,
    [TagName] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [SettingName] nvarchar(50)  NOT NULL,
    [SettingValue] nvarchar(max)  NULL,
    [DefaultValue] nvarchar(max)  NULL,
    [SettingType] nvarchar(50)  NOT NULL,
    [SettingDescription] nvarchar(max)  NULL,
    [SiteId] int  NULL
);
GO

-- Creating table 'TicketTypeSet'
CREATE TABLE [dbo].[TicketTypeSet] (
    [TicketTypeId] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'TicketCategorySet'
CREATE TABLE [dbo].[TicketCategorySet] (
    [TicketCategoryId] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'TicketStatusSet'
CREATE TABLE [dbo].[TicketStatusSet] (
    [TicketStatusId] int IDENTITY(1,1) NOT NULL,
    [StatusName] nvarchar(100)  NOT NULL,
    [ImportanceSize] smallint  NULL,
    [Editable] bit  NULL
);
GO

-- Creating table 'Activity'
CREATE TABLE [dbo].[Activity] (
    [ActivityID] int IDENTITY(1,1) NOT NULL,
    [Type] int  NULL,
    [Description] nvarchar(100)  NULL,
    [DueDate] datetime  NULL,
    [Status] int  NULL,
    [Priority] int  NULL,
    [Notes] nvarchar(100)  NULL,
    [OpportunityID] int  NULL,
    [DateCreated] datetime  NULL,
    [EmployeeId] int  NULL,
    [DimDateCreatedId] int  NOT NULL,
    [DimTimeCreatedId] int  NOT NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [CompanyID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL,
    [Postcode] nvarchar(50)  NULL,
    [Website] nvarchar(100)  NULL,
    [Notes] nvarchar(600)  NULL,
    [Revenue] decimal(19,4)  NULL,
    [NASDAQ] nvarchar(20)  NULL,
    [Industry] nvarchar(20)  NULL,
    [IsActive] bit  NULL,
    [SiteId] int  NOT NULL,
    [ImageId] int  NULL
);
GO

-- Creating table 'Contact'
CREATE TABLE [dbo].[Contact] (
    [ContactID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Position] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL,
    [Postcode] nvarchar(10)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Email] nvarchar(50)  NULL,
    [Notes] nvarchar(600)  NULL,
    [Birthday] datetime  NULL,
    [IsEmployee] bit  NULL,
    [Division] nvarchar(50)  NULL,
    [Facebook] nvarchar(100)  NULL,
    [Twitter] nvarchar(100)  NULL,
    [GooglePlus] nvarchar(100)  NULL,
    [Blog] nvarchar(100)  NULL,
    [IsImportantPerson] bit  NULL,
    [ImageID] int  NULL,
    [CompanyID] int  NULL,
    [IsActive] bit  NULL,
    [IsMale] bit  NULL
);
GO

-- Creating table 'Opportunity'
CREATE TABLE [dbo].[Opportunity] (
    [OpportunityID] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [Description] nvarchar(100)  NULL,
    [Quantity] int  NULL,
    [Price] decimal(19,4)  NULL,
    [Lead] nvarchar(50)  NULL,
    [Status] int  NULL,
    [Stage] int  NULL,
    [SuccessProbability] int  NULL,
    [WonLostReason] nvarchar(100)  NULL,
    [DiscountPercent] int  NULL,
    [DiscountReason] nvarchar(100)  NULL,
    [EstimationCloseDate] datetime  NULL,
    [Priority] int  NULL,
    [ProductID] int  NULL,
    [ContactID] int  NULL,
    [CompanyID] int  NULL,
    [DateCreated] datetime  NULL,
    [DimDateCreatedId] int  NOT NULL,
    [DimTimeCreatedId] int  NOT NULL
);
GO

-- Creating table 'SalesTrend'
CREATE TABLE [dbo].[SalesTrend] (
    [SalesTrendID] int IDENTITY(1,1) NOT NULL,
    [Amount] decimal(19,4)  NULL,
    [Date] datetime  NULL,
    [CompanyID] int  NULL
);
GO

-- Creating table 'LocationTypes'
CREATE TABLE [dbo].[LocationTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SiteId] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'LocationHierarchyLevels'
CREATE TABLE [dbo].[LocationHierarchyLevels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [IconUri] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductCatalogStructures'
CREATE TABLE [dbo].[ProductCatalogStructures] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'ProductCatalogs'
CREATE TABLE [dbo].[ProductCatalogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(100)  NOT NULL,
    [EnglishName] nchar(100)  NULL,
    [FrenchName] nchar(100)  NULL,
    [ChineseName] nchar(100)  NULL,
    [Description] nvarchar(400)  NULL,
    [EnglishDescription] nvarchar(400)  NULL,
    [FrenchDescription] nvarchar(400)  NULL,
    [ChineseDescription] nvarchar(400)  NULL
);
GO

-- Creating table 'DocumentSet'
CREATE TABLE [dbo].[DocumentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocumentPath] nvarchar(max)  NULL,
    [Content] varbinary(max)  NULL,
    [Extension] nvarchar(50)  NULL,
    [MimeType] nvarchar(50)  NULL,
    [Name] nvarchar(50)  NULL,
    [Size] float  NOT NULL
);
GO

-- Creating table 'Code'
CREATE TABLE [dbo].[Code] (
    [CodeID] int  NOT NULL,
    [CodeType] varchar(50)  NOT NULL,
    [CodeName] varchar(150)  NOT NULL,
    [Description] varchar(500)  NULL,
    [AssocText] varchar(50)  NULL,
    [AssocValue] int  NULL,
    [ChangeDate] datetime  NULL,
    [CreateDate] datetime  NOT NULL,
    [ParentID] int  NULL
);
GO

-- Creating table 'LocationLocationType'
CREATE TABLE [dbo].[LocationLocationType] (
    [Locations_Id] int  NOT NULL,
    [LocationTypes_Id] int  NOT NULL
);
GO

-- Creating table 'TicketTicketTag'
CREATE TABLE [dbo].[TicketTicketTag] (
    [Tickets_TicketId] int  NOT NULL,
    [TicketTags_TicketTagId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Sites'
ALTER TABLE [dbo].[Sites]
ADD CONSTRAINT [PK_Sites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FactTags'
ALTER TABLE [dbo].[FactTags]
ADD CONSTRAINT [PK_FactTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [PK_Assets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DimDates'
ALTER TABLE [dbo].[DimDates]
ADD CONSTRAINT [PK_DimDates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InfoTags'
ALTER TABLE [dbo].[InfoTags]
ADD CONSTRAINT [PK_InfoTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReaderTags'
ALTER TABLE [dbo].[ReaderTags]
ADD CONSTRAINT [PK_ReaderTags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCategories'
ALTER TABLE [dbo].[ProductCategories]
ADD CONSTRAINT [PK_ProductCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'productAssortments'
ALTER TABLE [dbo].[productAssortments]
ADD CONSTRAINT [PK_productAssortments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductBoxes'
ALTER TABLE [dbo].[ProductBoxes]
ADD CONSTRAINT [PK_ProductBoxes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeShifts'
ALTER TABLE [dbo].[EmployeeShifts]
ADD CONSTRAINT [PK_EmployeeShifts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReaderTagAntenas'
ALTER TABLE [dbo].[ReaderTagAntenas]
ADD CONSTRAINT [PK_ReaderTagAntenas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DimTime'
ALTER TABLE [dbo].[DimTime]
ADD CONSTRAINT [PK_DimTime]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [FileId] in table 'TicketAttachments'
ALTER TABLE [dbo].[TicketAttachments]
ADD CONSTRAINT [PK_TicketAttachments]
    PRIMARY KEY CLUSTERED ([FileId] ASC);
GO

-- Creating primary key on [TicketId], [CommentId] in table 'TicketComments'
ALTER TABLE [dbo].[TicketComments]
ADD CONSTRAINT [PK_TicketComments]
    PRIMARY KEY CLUSTERED ([TicketId], [CommentId] ASC);
GO

-- Creating primary key on [TicketId], [CommentId], [NotifyUser] in table 'TicketEventNotifications'
ALTER TABLE [dbo].[TicketEventNotifications]
ADD CONSTRAINT [PK_TicketEventNotifications]
    PRIMARY KEY CLUSTERED ([TicketId], [CommentId], [NotifyUser] ASC);
GO

-- Creating primary key on [TicketId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([TicketId] ASC);
GO

-- Creating primary key on [TicketTagId] in table 'TicketTags'
ALTER TABLE [dbo].[TicketTags]
ADD CONSTRAINT [PK_TicketTags]
    PRIMARY KEY CLUSTERED ([TicketTagId] ASC);
GO

-- Creating primary key on [SettingName] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([SettingName] ASC);
GO

-- Creating primary key on [TicketTypeId] in table 'TicketTypeSet'
ALTER TABLE [dbo].[TicketTypeSet]
ADD CONSTRAINT [PK_TicketTypeSet]
    PRIMARY KEY CLUSTERED ([TicketTypeId] ASC);
GO

-- Creating primary key on [TicketCategoryId] in table 'TicketCategorySet'
ALTER TABLE [dbo].[TicketCategorySet]
ADD CONSTRAINT [PK_TicketCategorySet]
    PRIMARY KEY CLUSTERED ([TicketCategoryId] ASC);
GO

-- Creating primary key on [TicketStatusId] in table 'TicketStatusSet'
ALTER TABLE [dbo].[TicketStatusSet]
ADD CONSTRAINT [PK_TicketStatusSet]
    PRIMARY KEY CLUSTERED ([TicketStatusId] ASC);
GO

-- Creating primary key on [ActivityID] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [PK_Activity]
    PRIMARY KEY CLUSTERED ([ActivityID] ASC);
GO

-- Creating primary key on [CompanyID] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [ContactID] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [PK_Contact]
    PRIMARY KEY CLUSTERED ([ContactID] ASC);
GO

-- Creating primary key on [OpportunityID] in table 'Opportunity'
ALTER TABLE [dbo].[Opportunity]
ADD CONSTRAINT [PK_Opportunity]
    PRIMARY KEY CLUSTERED ([OpportunityID] ASC);
GO

-- Creating primary key on [SalesTrendID] in table 'SalesTrend'
ALTER TABLE [dbo].[SalesTrend]
ADD CONSTRAINT [PK_SalesTrend]
    PRIMARY KEY CLUSTERED ([SalesTrendID] ASC);
GO

-- Creating primary key on [Id] in table 'LocationTypes'
ALTER TABLE [dbo].[LocationTypes]
ADD CONSTRAINT [PK_LocationTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationHierarchyLevels'
ALTER TABLE [dbo].[LocationHierarchyLevels]
ADD CONSTRAINT [PK_LocationHierarchyLevels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCatalogStructures'
ALTER TABLE [dbo].[ProductCatalogStructures]
ADD CONSTRAINT [PK_ProductCatalogStructures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCatalogs'
ALTER TABLE [dbo].[ProductCatalogs]
ADD CONSTRAINT [PK_ProductCatalogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentSet'
ALTER TABLE [dbo].[DocumentSet]
ADD CONSTRAINT [PK_DocumentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CodeID] in table 'Code'
ALTER TABLE [dbo].[Code]
ADD CONSTRAINT [PK_Code]
    PRIMARY KEY CLUSTERED ([CodeID] ASC);
GO

-- Creating primary key on [Locations_Id], [LocationTypes_Id] in table 'LocationLocationType'
ALTER TABLE [dbo].[LocationLocationType]
ADD CONSTRAINT [PK_LocationLocationType]
    PRIMARY KEY NONCLUSTERED ([Locations_Id], [LocationTypes_Id] ASC);
GO

-- Creating primary key on [Tickets_TicketId], [TicketTags_TicketTagId] in table 'TicketTicketTag'
ALTER TABLE [dbo].[TicketTicketTag]
ADD CONSTRAINT [PK_TicketTicketTag]
    PRIMARY KEY NONCLUSTERED ([Tickets_TicketId], [TicketTags_TicketTagId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SiteId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_SiteEmployee]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteEmployee'
CREATE INDEX [IX_FK_SiteEmployee]
ON [dbo].[Employees]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'FactTags'
ALTER TABLE [dbo].[FactTags]
ADD CONSTRAINT [FK_SiteFactTag]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteFactTag'
CREATE INDEX [IX_FK_SiteFactTag]
ON [dbo].[FactTags]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_SiteCustomer]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteCustomer'
CREATE INDEX [IX_FK_SiteCustomer]
ON [dbo].[Customers]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [FK_SiteSupplier]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteSupplier'
CREATE INDEX [IX_FK_SiteSupplier]
ON [dbo].[Suppliers]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [FK_SiteAsset]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteAsset'
CREATE INDEX [IX_FK_SiteAsset]
ON [dbo].[Assets]
    ([SiteId]);
GO

-- Creating foreign key on [ImageId] in table 'Sites'
ALTER TABLE [dbo].[Sites]
ADD CONSTRAINT [FK_SiteImage]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteImage'
CREATE INDEX [IX_FK_SiteImage]
ON [dbo].[Sites]
    ([ImageId]);
GO

-- Creating foreign key on [SiteId] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [FK_SiteLocation]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteLocation'
CREATE INDEX [IX_FK_SiteLocation]
ON [dbo].[Locations]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_SiteProduct]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteProduct'
CREATE INDEX [IX_FK_SiteProduct]
ON [dbo].[Products]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'ProductBoxes'
ALTER TABLE [dbo].[ProductBoxes]
ADD CONSTRAINT [FK_SiteProductBox]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteProductBox'
CREATE INDEX [IX_FK_SiteProductBox]
ON [dbo].[ProductBoxes]
    ([SiteId]);
GO

-- Creating foreign key on [LocationId] in table 'InfoTags'
ALTER TABLE [dbo].[InfoTags]
ADD CONSTRAINT [FK_InfoTagLocation]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InfoTagLocation'
CREATE INDEX [IX_FK_InfoTagLocation]
ON [dbo].[InfoTags]
    ([LocationId]);
GO

-- Creating foreign key on [ReaderTagId] in table 'ReaderTagAntenas'
ALTER TABLE [dbo].[ReaderTagAntenas]
ADD CONSTRAINT [FK_ReaderTagReaderTagAntena]
    FOREIGN KEY ([ReaderTagId])
    REFERENCES [dbo].[ReaderTags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReaderTagReaderTagAntena'
CREATE INDEX [IX_FK_ReaderTagReaderTagAntena]
ON [dbo].[ReaderTagAntenas]
    ([ReaderTagId]);
GO

-- Creating foreign key on [ProductCategoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductCategoryProduct]
    FOREIGN KEY ([ProductCategoryId])
    REFERENCES [dbo].[ProductCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategoryProduct'
CREATE INDEX [IX_FK_ProductCategoryProduct]
ON [dbo].[Products]
    ([ProductCategoryId]);
GO

-- Creating foreign key on [ProductCategoryId] in table 'FactTags'
ALTER TABLE [dbo].[FactTags]
ADD CONSTRAINT [FK_ProductCategoryFactTag]
    FOREIGN KEY ([ProductCategoryId])
    REFERENCES [dbo].[ProductCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategoryFactTag'
CREATE INDEX [IX_FK_ProductCategoryFactTag]
ON [dbo].[FactTags]
    ([ProductCategoryId]);
GO

-- Creating foreign key on [productAssortmentId] in table 'FactTags'
ALTER TABLE [dbo].[FactTags]
ADD CONSTRAINT [FK_productAssortmentFactTag]
    FOREIGN KEY ([productAssortmentId])
    REFERENCES [dbo].[productAssortments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productAssortmentFactTag'
CREATE INDEX [IX_FK_productAssortmentFactTag]
ON [dbo].[FactTags]
    ([productAssortmentId]);
GO

-- Creating foreign key on [ProductBoxId] in table 'FactTags'
ALTER TABLE [dbo].[FactTags]
ADD CONSTRAINT [FK_ProductBoxFactTag]
    FOREIGN KEY ([ProductBoxId])
    REFERENCES [dbo].[ProductBoxes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductBoxFactTag'
CREATE INDEX [IX_FK_ProductBoxFactTag]
ON [dbo].[FactTags]
    ([ProductBoxId]);
GO

-- Creating foreign key on [EmployeeId] in table 'EmployeeShifts'
ALTER TABLE [dbo].[EmployeeShifts]
ADD CONSTRAINT [FK_EmployeeEmployeeShifts]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeEmployeeShifts'
CREATE INDEX [IX_FK_EmployeeEmployeeShifts]
ON [dbo].[EmployeeShifts]
    ([EmployeeId]);
GO

-- Creating foreign key on [TicketId] in table 'TicketAttachments'
ALTER TABLE [dbo].[TicketAttachments]
ADD CONSTRAINT [FK_TicketAttachments_Tickets]
    FOREIGN KEY ([TicketId])
    REFERENCES [dbo].[Tickets]
        ([TicketId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketAttachments_Tickets'
CREATE INDEX [IX_FK_TicketAttachments_Tickets]
ON [dbo].[TicketAttachments]
    ([TicketId]);
GO

-- Creating foreign key on [TicketId] in table 'TicketComments'
ALTER TABLE [dbo].[TicketComments]
ADD CONSTRAINT [FK_TicketComments_Tickets]
    FOREIGN KEY ([TicketId])
    REFERENCES [dbo].[Tickets]
        ([TicketId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TicketId], [CommentId] in table 'TicketEventNotifications'
ALTER TABLE [dbo].[TicketEventNotifications]
ADD CONSTRAINT [FK_TicketEventNotifications_TicketComments]
    FOREIGN KEY ([TicketId], [CommentId])
    REFERENCES [dbo].[TicketComments]
        ([TicketId], [CommentId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SiteId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_SiteTicket]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteTicket'
CREATE INDEX [IX_FK_SiteTicket]
ON [dbo].[Tickets]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [FK_SiteSetting]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteSetting'
CREATE INDEX [IX_FK_SiteSetting]
ON [dbo].[Settings]
    ([SiteId]);
GO

-- Creating foreign key on [TicketCategoryTicketCategoryId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketCategoryTicket]
    FOREIGN KEY ([TicketCategoryTicketCategoryId])
    REFERENCES [dbo].[TicketCategorySet]
        ([TicketCategoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketCategoryTicket'
CREATE INDEX [IX_FK_TicketCategoryTicket]
ON [dbo].[Tickets]
    ([TicketCategoryTicketCategoryId]);
GO

-- Creating foreign key on [TicketTypeTicketTypeId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketTypeTicket]
    FOREIGN KEY ([TicketTypeTicketTypeId])
    REFERENCES [dbo].[TicketTypeSet]
        ([TicketTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketTypeTicket'
CREATE INDEX [IX_FK_TicketTypeTicket]
ON [dbo].[Tickets]
    ([TicketTypeTicketTypeId]);
GO

-- Creating foreign key on [TicketStatusTicketStatusId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketStatusTicket]
    FOREIGN KEY ([TicketStatusTicketStatusId])
    REFERENCES [dbo].[TicketStatusSet]
        ([TicketStatusId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketStatusTicket'
CREATE INDEX [IX_FK_TicketStatusTicket]
ON [dbo].[Tickets]
    ([TicketStatusTicketStatusId]);
GO

-- Creating foreign key on [OpportunityID] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [FK_Activity_Opportunity]
    FOREIGN KEY ([OpportunityID])
    REFERENCES [dbo].[Opportunity]
        ([OpportunityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Activity_Opportunity'
CREATE INDEX [IX_FK_Activity_Opportunity]
ON [dbo].[Activity]
    ([OpportunityID]);
GO

-- Creating foreign key on [CompanyID] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [FK_Contact_Company]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Company]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Contact_Company'
CREATE INDEX [IX_FK_Contact_Company]
ON [dbo].[Contact]
    ([CompanyID]);
GO

-- Creating foreign key on [CompanyID] in table 'Opportunity'
ALTER TABLE [dbo].[Opportunity]
ADD CONSTRAINT [FK_Opportunity_Company]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Company]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Opportunity_Company'
CREATE INDEX [IX_FK_Opportunity_Company]
ON [dbo].[Opportunity]
    ([CompanyID]);
GO

-- Creating foreign key on [CompanyID] in table 'SalesTrend'
ALTER TABLE [dbo].[SalesTrend]
ADD CONSTRAINT [FK_SalesTrend_Company]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[Company]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesTrend_Company'
CREATE INDEX [IX_FK_SalesTrend_Company]
ON [dbo].[SalesTrend]
    ([CompanyID]);
GO

-- Creating foreign key on [EmployeeId] in table 'Activity'
ALTER TABLE [dbo].[Activity]
ADD CONSTRAINT [FK_EmployeeActivity]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeActivity'
CREATE INDEX [IX_FK_EmployeeActivity]
ON [dbo].[Activity]
    ([EmployeeId]);
GO

-- Creating foreign key on [ImageID] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [FK_ImageContact]
    FOREIGN KEY ([ImageID])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ImageContact'
CREATE INDEX [IX_FK_ImageContact]
ON [dbo].[Contact]
    ([ImageID]);
GO

-- Creating foreign key on [ImageId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ImageProduct]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ImageProduct'
CREATE INDEX [IX_FK_ImageProduct]
ON [dbo].[Products]
    ([ImageId]);
GO

-- Creating foreign key on [ProductID] in table 'Opportunity'
ALTER TABLE [dbo].[Opportunity]
ADD CONSTRAINT [FK_ProductOpportunity]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductOpportunity'
CREATE INDEX [IX_FK_ProductOpportunity]
ON [dbo].[Opportunity]
    ([ProductID]);
GO

-- Creating foreign key on [ImageId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_ImageEmployee]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ImageEmployee'
CREATE INDEX [IX_FK_ImageEmployee]
ON [dbo].[Employees]
    ([ImageId]);
GO

-- Creating foreign key on [SiteId] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [FK_SiteCompany]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteCompany'
CREATE INDEX [IX_FK_SiteCompany]
ON [dbo].[Company]
    ([SiteId]);
GO

-- Creating foreign key on [parentId] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [FK_LocationHierarchyParent]
    FOREIGN KEY ([parentId])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationHierarchyParent'
CREATE INDEX [IX_FK_LocationHierarchyParent]
ON [dbo].[Locations]
    ([parentId]);
GO

-- Creating foreign key on [ImageId] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [FK_ImageLocation]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ImageLocation'
CREATE INDEX [IX_FK_ImageLocation]
ON [dbo].[Locations]
    ([ImageId]);
GO

-- Creating foreign key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_CompanyCustomer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Company]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [FK_CompanySupplier]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Company]
        ([CompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ContactID] in table 'Opportunity'
ALTER TABLE [dbo].[Opportunity]
ADD CONSTRAINT [FK_ContactOpportunity]
    FOREIGN KEY ([ContactID])
    REFERENCES [dbo].[Contact]
        ([ContactID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactOpportunity'
CREATE INDEX [IX_FK_ContactOpportunity]
ON [dbo].[Opportunity]
    ([ContactID]);
GO

-- Creating foreign key on [Locations_Id] in table 'LocationLocationType'
ALTER TABLE [dbo].[LocationLocationType]
ADD CONSTRAINT [FK_LocationLocationType_Location]
    FOREIGN KEY ([Locations_Id])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [LocationTypes_Id] in table 'LocationLocationType'
ALTER TABLE [dbo].[LocationLocationType]
ADD CONSTRAINT [FK_LocationLocationType_LocationType]
    FOREIGN KEY ([LocationTypes_Id])
    REFERENCES [dbo].[LocationTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationLocationType_LocationType'
CREATE INDEX [IX_FK_LocationLocationType_LocationType]
ON [dbo].[LocationLocationType]
    ([LocationTypes_Id]);
GO

-- Creating foreign key on [HierarchyLevelId] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [FK_LocationLocationHierarchyLevel]
    FOREIGN KEY ([HierarchyLevelId])
    REFERENCES [dbo].[LocationHierarchyLevels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationLocationHierarchyLevel'
CREATE INDEX [IX_FK_LocationLocationHierarchyLevel]
ON [dbo].[Locations]
    ([HierarchyLevelId]);
GO

-- Creating foreign key on [ImageId] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [FK_ImageCompany]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ImageCompany'
CREATE INDEX [IX_FK_ImageCompany]
ON [dbo].[Company]
    ([ImageId]);
GO

-- Creating foreign key on [SiteId] in table 'LocationTypes'
ALTER TABLE [dbo].[LocationTypes]
ADD CONSTRAINT [FK_SiteLocationType]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteLocationType'
CREATE INDEX [IX_FK_SiteLocationType]
ON [dbo].[LocationTypes]
    ([SiteId]);
GO

-- Creating foreign key on [SiteId] in table 'Opportunity'
ALTER TABLE [dbo].[Opportunity]
ADD CONSTRAINT [FK_SiteOpportunity]
    FOREIGN KEY ([SiteId])
    REFERENCES [dbo].[Sites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SiteOpportunity'
CREATE INDEX [IX_FK_SiteOpportunity]
ON [dbo].[Opportunity]
    ([SiteId]);
GO

-- Creating foreign key on [Tickets_TicketId] in table 'TicketTicketTag'
ALTER TABLE [dbo].[TicketTicketTag]
ADD CONSTRAINT [FK_TicketTicketTag_Ticket]
    FOREIGN KEY ([Tickets_TicketId])
    REFERENCES [dbo].[Tickets]
        ([TicketId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TicketTags_TicketTagId] in table 'TicketTicketTag'
ALTER TABLE [dbo].[TicketTicketTag]
ADD CONSTRAINT [FK_TicketTicketTag_TicketTag]
    FOREIGN KEY ([TicketTags_TicketTagId])
    REFERENCES [dbo].[TicketTags]
        ([TicketTagId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketTicketTag_TicketTag'
CREATE INDEX [IX_FK_TicketTicketTag_TicketTag]
ON [dbo].[TicketTicketTag]
    ([TicketTags_TicketTagId]);
GO

-- Creating foreign key on [ParentID] in table 'Code'
ALTER TABLE [dbo].[Code]
ADD CONSTRAINT [FK_Code_Code]
    FOREIGN KEY ([ParentID])
    REFERENCES [dbo].[Code]
        ([CodeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Code_Code'
CREATE INDEX [IX_FK_Code_Code]
ON [dbo].[Code]
    ([ParentID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
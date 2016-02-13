USE [ProcbelApps]
GO

/****** Object:  Table [dbo].[Code]    Script Date: 9/10/2013 12:29:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Code](
	[CodeID] [int] NOT NULL,
	[CodeType] [varchar](50) NOT NULL,
	[CodeName] [varchar](150) NOT NULL,
	[Description] [varchar](500) NULL,
	[AssocText] [varchar](50) NULL,
	[AssocValue] [int] NULL,
	[ChangeDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_Code] PRIMARY KEY CLUSTERED 
(
	[CodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Code] ADD  CONSTRAINT [DF_Code_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Code]  WITH CHECK ADD  CONSTRAINT [FK_Code_Code] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Code] ([CodeID])
GO

ALTER TABLE [dbo].[Code] CHECK CONSTRAINT [FK_Code_Code]
GO



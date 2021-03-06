USE [Dotnetnuke]
GO
/****** Object:  Table [dbo].[Science_Invention]    Script Date: 06/20/2014 09:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Science_Invention](
	[InventionId] [int] IDENTITY(1,1) NOT NULL,
	[YearOfCreation] [date] NULL,
	[Description] [nvarchar](max) NOT NULL,
	[InventionEssence] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Advantages] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[ModuleID] [int] NOT NULL,
 CONSTRAINT [PK_Science_Development] PRIMARY KEY CLUSTERED 
(
	[InventionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObserverOfScience_ObserverOfSciences]    Script Date: 06/20/2014 09:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObserverOfScience_ObserverOfSciences](
	[ObserverOfScienceID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[CreatedByUser] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[ListOfDevelopment] [nvarchar](50) NULL,
	[YearOfDevelopment] [int] NULL,
	[Development] [nvarchar](50) NULL,
	[Image] [nvarchar](max) NULL,
	[InventionId] [int] NOT NULL,
 CONSTRAINT [PK_ObserverOfScience_ObserverOfSciences_1] PRIMARY KEY CLUSTERED 
(
	[ObserverOfScienceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Science_Scientist]    Script Date: 06/20/2014 09:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Science_Scientist](
	[ScientistId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[InventionId] [int] NOT NULL,
 CONSTRAINT [PK_Science_Scientist] PRIMARY KEY CLUSTERED 
(
	[ScientistId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Science_Introduction]    Script Date: 06/20/2014 09:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Science_Introduction](
	[IntroductionId] [int] NOT NULL,
	[YearIntroduction] [date] NULL,
	[VendorId] [int] NOT NULL,
	[InventionId] [int] NOT NULL,
 CONSTRAINT [PK_Science_Introduction] PRIMARY KEY CLUSTERED 
(
	[IntroductionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Science_InvTerms]    Script Date: 06/20/2014 09:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Science_InvTerms](
	[InvTermId] [int] IDENTITY(1,1) NOT NULL,
	[TermId] [int] NOT NULL,
	[InventionId] [int] NOT NULL,
	[VocabularyId] [int] NOT NULL,
 CONSTRAINT [PK_Science_GroupOfDevelopment] PRIMARY KEY CLUSTERED 
(
	[InvTermId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Science_InventionResource]    Script Date: 06/20/2014 09:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Science_InventionResource](
	[ResourceId] [int] IDENTITY(1,1) NOT NULL,
	[UrlId] [int] NULL,
	[FileId] [int] NULL,
	[InventionId] [int] NOT NULL,
 CONSTRAINT [PK_Science_Resource] PRIMARY KEY CLUSTERED 
(
	[ResourceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ObserverOfScience_ObserverOfSciences_Science_Invention]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[ObserverOfScience_ObserverOfSciences]  WITH CHECK ADD  CONSTRAINT [FK_ObserverOfScience_ObserverOfSciences_Science_Invention] FOREIGN KEY([InventionId])
REFERENCES [dbo].[Science_Invention] ([InventionId])
GO
ALTER TABLE [dbo].[ObserverOfScience_ObserverOfSciences] CHECK CONSTRAINT [FK_ObserverOfScience_ObserverOfSciences_Science_Invention]
GO
/****** Object:  ForeignKey [FK_Science_Introduction_Science_Invention]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_Introduction]  WITH CHECK ADD  CONSTRAINT [FK_Science_Introduction_Science_Invention] FOREIGN KEY([InventionId])
REFERENCES [dbo].[Science_Invention] ([InventionId])
GO
ALTER TABLE [dbo].[Science_Introduction] CHECK CONSTRAINT [FK_Science_Introduction_Science_Invention]
GO
/****** Object:  ForeignKey [FK_Science_Introduction_Vendors]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_Introduction]  WITH CHECK ADD  CONSTRAINT [FK_Science_Introduction_Vendors] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([VendorId])
GO
ALTER TABLE [dbo].[Science_Introduction] CHECK CONSTRAINT [FK_Science_Introduction_Vendors]
GO
/****** Object:  ForeignKey [FK_Science_Resource_Files]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_InventionResource]  WITH CHECK ADD  CONSTRAINT [FK_Science_Resource_Files] FOREIGN KEY([FileId])
REFERENCES [dbo].[Files] ([FileId])
GO
ALTER TABLE [dbo].[Science_InventionResource] CHECK CONSTRAINT [FK_Science_Resource_Files]
GO
/****** Object:  ForeignKey [FK_Science_Resource_Science_Development]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_InventionResource]  WITH CHECK ADD  CONSTRAINT [FK_Science_Resource_Science_Development] FOREIGN KEY([InventionId])
REFERENCES [dbo].[Science_Invention] ([InventionId])
GO
ALTER TABLE [dbo].[Science_InventionResource] CHECK CONSTRAINT [FK_Science_Resource_Science_Development]
GO
/****** Object:  ForeignKey [FK_Science_Resource_Urls]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_InventionResource]  WITH CHECK ADD  CONSTRAINT [FK_Science_Resource_Urls] FOREIGN KEY([UrlId])
REFERENCES [dbo].[Urls] ([UrlID])
GO
ALTER TABLE [dbo].[Science_InventionResource] CHECK CONSTRAINT [FK_Science_Resource_Urls]
GO
/****** Object:  ForeignKey [FK_Science_GroupOfDevelopment_Science_Development]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_InvTerms]  WITH CHECK ADD  CONSTRAINT [FK_Science_GroupOfDevelopment_Science_Development] FOREIGN KEY([InventionId])
REFERENCES [dbo].[Science_Invention] ([InventionId])
GO
ALTER TABLE [dbo].[Science_InvTerms] CHECK CONSTRAINT [FK_Science_GroupOfDevelopment_Science_Development]
GO
/****** Object:  ForeignKey [FK_Science_GroupOfDevelopment_Taxonomy_Terms]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_InvTerms]  WITH CHECK ADD  CONSTRAINT [FK_Science_GroupOfDevelopment_Taxonomy_Terms] FOREIGN KEY([TermId])
REFERENCES [dbo].[Taxonomy_Terms] ([TermID])
GO
ALTER TABLE [dbo].[Science_InvTerms] CHECK CONSTRAINT [FK_Science_GroupOfDevelopment_Taxonomy_Terms]
GO
/****** Object:  ForeignKey [FK_Science_InvTerms_Taxonomy_Vocabularies]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_InvTerms]  WITH CHECK ADD  CONSTRAINT [FK_Science_InvTerms_Taxonomy_Vocabularies] FOREIGN KEY([VocabularyId])
REFERENCES [dbo].[Taxonomy_Vocabularies] ([VocabularyID])
GO
ALTER TABLE [dbo].[Science_InvTerms] CHECK CONSTRAINT [FK_Science_InvTerms_Taxonomy_Vocabularies]
GO
/****** Object:  ForeignKey [FK_Science_Scientist_Science_Invention]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_Scientist]  WITH CHECK ADD  CONSTRAINT [FK_Science_Scientist_Science_Invention] FOREIGN KEY([InventionId])
REFERENCES [dbo].[Science_Invention] ([InventionId])
GO
ALTER TABLE [dbo].[Science_Scientist] CHECK CONSTRAINT [FK_Science_Scientist_Science_Invention]
GO
/****** Object:  ForeignKey [FK_Science_Scientist_Users]    Script Date: 06/20/2014 09:31:02 ******/
ALTER TABLE [dbo].[Science_Scientist]  WITH CHECK ADD  CONSTRAINT [FK_Science_Scientist_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Science_Scientist] CHECK CONSTRAINT [FK_Science_Scientist_Users]
GO

USE [eindWerk]
GO

/****** Object:  Table [dbo].[adres]    Script Date: 28/05/2021 11:43:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[adres](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[straatID] [int] NOT NULL,
	[huisnummer] [int] NOT NULL,
	[appartementnummer] [int] NULL,
	[busnummer] [int] NULL,
	[huisnummerlabel] [nvarchar](50) NULL,
	[adreslocatieID] [int] NOT NULL,
	[postcode] [int] NOT NULL,
 CONSTRAINT [PK_adres] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[adres]  WITH CHECK ADD  CONSTRAINT [FK_adres_adreslocatie] FOREIGN KEY([adreslocatieID])
REFERENCES [dbo].[adreslocatie] ([id])
GO

ALTER TABLE [dbo].[adres] CHECK CONSTRAINT [FK_adres_adreslocatie]
GO

ALTER TABLE [dbo].[adres]  WITH CHECK ADD  CONSTRAINT [FK_adres_straat] FOREIGN KEY([straatID])
REFERENCES [dbo].[straat] ([id])
GO

ALTER TABLE [dbo].[adres] CHECK CONSTRAINT [FK_adres_straat]
GO


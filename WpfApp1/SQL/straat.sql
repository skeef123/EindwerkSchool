USE [eindWerk]
GO

/****** Object:  Table [dbo].[straat]    Script Date: 28/05/2021 11:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[straat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[straatnaam] [nvarchar](255) NOT NULL,
	[NIScode] [int] NOT NULL,
 CONSTRAINT [PK_straat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[straat]  WITH NOCHECK ADD  CONSTRAINT [FK_straat_gemeente] FOREIGN KEY([NIScode])
REFERENCES [dbo].[gemeente] ([NIScode])
GO

ALTER TABLE [dbo].[straat] CHECK CONSTRAINT [FK_straat_gemeente]
GO


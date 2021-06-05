USE [eindWerk]
GO

/****** Object:  Table [dbo].[gemeente]    Script Date: 28/05/2021 11:43:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[gemeente](
	[NIScode] [int] IDENTITY(1,1) NOT NULL,
	[Gemeentenaam] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_gemeente] PRIMARY KEY CLUSTERED 
(
	[NIScode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

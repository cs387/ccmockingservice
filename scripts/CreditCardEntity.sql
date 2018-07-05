/****** Object:  Table [dbo].[CreditCardEntity]    Script Date: 7/5/2018 12:55:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CreditCardEntity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_dbo.CreditCardEntity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [master]
GO
/****** Object:  Database [dbEMS]    Script Date: 19/03/2025 08:32:07 AM ******/
CREATE DATABASE [dbEMS]
GO
USE [dbEMS]
GO
/****** Object:  Table [dbo].[tbl_positions]    Script Date: 19/03/2025 08:32:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_positions] ON 

GO
INSERT [dbo].[tbl_positions] ([Id], [title], [description]) VALUES (1, N'Programmer', N'Programming')
GO
INSERT [dbo].[tbl_positions] ([Id], [title], [description]) VALUES (2, N'Associate Programmer', N'Mini Programming')
GO
INSERT [dbo].[tbl_positions] ([Id], [title], [description]) VALUES (3, N'Mid Programmer', N'Middle')
GO
SET IDENTITY_INSERT [dbo].[tbl_positions] OFF
GO
USE [master]
GO
ALTER DATABASE [dbEMS] SET  READ_WRITE 
GO

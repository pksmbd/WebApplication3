GO
/****** Object:  Table [dbo].[tblfees]    Script Date: 10/25/2023 7:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblfees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reg_date] [date] NULL,
	[fees_date] [date] NULL,
	[student_name] [nvarchar](200) NULL,
	[father_name] [nvarchar](200) NULL,
	[email] [nvarchar](200) NULL,
	[dob] [date] NULL,
	[mobile] [nvarchar](200) NULL,
	[student_id] [nvarchar](200) NULL,
	[course_name] [nvarchar](200) NULL,
	[installment] [nvarchar](200) NULL,
	[photo] [nvarchar](200) NULL,
	[fees] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/25/2023 7:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Email] [varchar](200) NULL,
	[Age] [int] NULL,
	[Image] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblfees] ON 

INSERT [dbo].[tblfees] ([id], [reg_date], [fees_date], [student_name], [father_name], [email], [dob], [mobile], [student_id], [course_name], [installment], [photo], [fees]) VALUES (3, CAST(0x00000000 AS Date), CAST(0xF3450B00 AS Date), N'adil malik', N'mohd sattar', N'adilm@gmail.com', CAST(0xF3450B00 AS Date), N'8191912633', N'am8191912633', N'ADCA', N'1', N'04_2018_wallpaper_iphone_art.jpg', N'500')
SET IDENTITY_INSERT [dbo].[tblfees] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (5, N'asd', N'asd@dshgsdhf', 21, N'')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (6, N'asd', N'adil@asd.kjh', 22, N'')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (7, N'zxczx', N'ass@asd', 22, N'')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (8, N'asd', N'adil@asd.kjh', 21, N'')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (9, N'asd', N'asd@dshgsdhf', 21, N'')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (10, N'asd', N'asd@dshgsdhf', 21, N'')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (11, N'asd', N'asd@dshgsdhf', 21, N'')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Age], [Image]) VALUES (12, N'asd', N'ass@asd', 21, N'4e22ace2dd23c3a31cdefb7683ab566c.jpeg')
SET IDENTITY_INSERT [dbo].[Users] OFF

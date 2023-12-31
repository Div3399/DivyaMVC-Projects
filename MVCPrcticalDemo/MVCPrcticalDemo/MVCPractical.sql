USE [MVCPractical]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 06/23/2018 15:56:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](100) NULL,
	[Birthdate] [date] NULL,
	[Gender] [varchar](1) NULL,
	[Salary] [decimal](7, 2) NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](6) NULL,
	[Country] [varchar](60) NULL,
	[Email] [varchar](60) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT [dbo].[Employee] ([EmpID], [EmpName], [Birthdate], [Gender], [Salary], [Address1], [Address2], [City], [State], [ZipCode], [Country], [Email]) VALUES (1, N'Arish', CAST(0x713D0B00 AS Date), N'M', CAST(2000.00 AS Decimal(7, 2)), N'Add1', N'Add2', N'Amalsad', N'Gujarat', N'39310', N'India', N'aa@gmail.com')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [Birthdate], [Gender], [Salary], [Address1], [Address2], [City], [State], [ZipCode], [Country], [Email]) VALUES (4, N'ccccc', CAST(0x24230B00 AS Date), N'M', CAST(5000.00 AS Decimal(7, 2)), N'asdasdasdas', NULL, NULL, N'Maharashtra', NULL, N'India', N'cc@gmail.com')
INSERT [dbo].[Employee] ([EmpID], [EmpName], [Birthdate], [Gender], [Salary], [Address1], [Address2], [City], [State], [ZipCode], [Country], [Email]) VALUES (7, N'asdasd', CAST(0x5A160B00 AS Date), N'M', CAST(3345.00 AS Decimal(7, 2)), N'ertret', NULL, NULL, N'Texas', NULL, NULL, N'aa@gmail.com')
SET IDENTITY_INSERT [dbo].[Employee] OFF

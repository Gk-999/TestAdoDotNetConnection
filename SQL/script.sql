USE [Gk_Test]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9/10/2020 5:28:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Salary] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/10/2020 5:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Marks] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/10/2020 5:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [Name], [City], [Salary]) VALUES (1, N'Shivanand', N'Delhi', 50000)
GO
INSERT [dbo].[Employee] ([Id], [Name], [City], [Salary]) VALUES (2, N'Tukaram', N'Pune', 35000)
GO
INSERT [dbo].[Employee] ([Id], [Name], [City], [Salary]) VALUES (3, N'Khagendra', N'Delhi', 60000)
GO
INSERT [dbo].[Employee] ([Id], [Name], [City], [Salary]) VALUES (4, N'Gaurav', N'Delhi', 25000)
GO
INSERT [dbo].[Employee] ([Id], [Name], [City], [Salary]) VALUES (5, N'Jaidev', N'Pune', 90000)
GO
INSERT [dbo].[Employee] ([Id], [Name], [City], [Salary]) VALUES (6, N'Siddhu', N'Mumbai', 95000)
GO
INSERT [dbo].[Employee] ([Id], [Name], [City], [Salary]) VALUES (7, N'Sameer', N'Mumbai', 85000)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([Id], [Name], [City], [Marks]) VALUES (1, N'Shivanand', N'Porvorim', 50)
GO
INSERT [dbo].[Student] ([Id], [Name], [City], [Marks]) VALUES (2, N'Tukaram', N'Colvale', 70)
GO
INSERT [dbo].[Student] ([Id], [Name], [City], [Marks]) VALUES (3, N'Khagendra', N'Ponda', 80)
GO
INSERT [dbo].[Student] ([Id], [Name], [City], [Marks]) VALUES (4, N'Gaurav', N'Sanquelim', 45)
GO
INSERT [dbo].[Student] ([Id], [Name], [City], [Marks]) VALUES (5, N'Jaidev', N'Bicholim', 60)
GO
INSERT [dbo].[Student] ([Id], [Name], [City], [Marks]) VALUES (6, N'Siddhu', N'Panaji', 75)
GO
INSERT [dbo].[Student] ([Id], [Name], [City], [Marks]) VALUES (7, N'Sameer', N'Valpoi', 80)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (1, N'Gaurav', N'gk123')
GO
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (2, N'Shiva', N'shiva123')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_GetEmployeesAndStudents]    Script Date: 9/10/2020 5:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetEmployeesAndStudents]
AS
BEGIN
	SELECT * FROM Employee

	SELECT * FROM Student
END
GO

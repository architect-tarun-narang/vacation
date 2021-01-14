USE [Vacation]
GO
ALTER TABLE [dbo].[TravelAgenda] DROP CONSTRAINT [FK_VacationType_TravelAgenda]
GO
ALTER TABLE [dbo].[TravelAgenda] DROP CONSTRAINT [FK_TravelAgenda_VacationType]
GO
ALTER TABLE [dbo].[TravelAgenda] DROP CONSTRAINT [FK_TravelAgenda_Employee]
GO
ALTER TABLE [dbo].[EmployeeWFH] DROP CONSTRAINT [FK_EmployeeWFH_WFHDays]
GO
ALTER TABLE [dbo].[EmployeeWFH] DROP CONSTRAINT [FK_EmployeeWFH_VacationType]
GO
ALTER TABLE [dbo].[EmployeeWFH] DROP CONSTRAINT [FK_EmployeeWFH_Employee]
GO
ALTER TABLE [dbo].[EmployeeVacation] DROP CONSTRAINT [FK_EmployeeVacation_VacationType]
GO
ALTER TABLE [dbo].[EmployeeVacation] DROP CONSTRAINT [FK_EmployeeVacation_Employee]
GO
ALTER TABLE [dbo].[EmployeeTraining] DROP CONSTRAINT [FK_EmployeeTraining_Training]
GO
ALTER TABLE [dbo].[EmployeeTraining] DROP CONSTRAINT [FK_EmployeeTraining_Employee]
GO
/****** Object:  Table [dbo].[WFHDays]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[WFHDays]
GO
/****** Object:  Table [dbo].[VacationType]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[VacationType]
GO
/****** Object:  Table [dbo].[TravelAgenda]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[TravelAgenda]
GO
/****** Object:  Table [dbo].[Training]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[Training]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[Holiday]
GO
/****** Object:  Table [dbo].[EmployeeWFH]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[EmployeeWFH]
GO
/****** Object:  Table [dbo].[EmployeeVacation]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[EmployeeVacation]
GO
/****** Object:  Table [dbo].[EmployeeTraining]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[EmployeeTraining]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/22/2020 9:52:10 PM ******/
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MgrId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTraining]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTraining](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[TrainingId] [int] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[TrainingHours] [int] NOT NULL,
	[Approved] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeVacation]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeVacation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[VacationTypeId] [int] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[TotalDaysOff] [int] NOT NULL,
	[Approved] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeeVacation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeWFH]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeWFH](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[VacationTypeId] [int] NOT NULL,
	[WFHDaysId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeWFH] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Training]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Training](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Training] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TravelAgenda]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravelAgenda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[VacationTypeId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[Purpose] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TravelAgenda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VacationType]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VacationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_VacationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WFHDays]    Script Date: 5/22/2020 9:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WFHDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Days] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WFHDays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [MgrId]) VALUES (11111, N'Rohit', N'Rangroo', 0)
GO
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [MgrId]) VALUES (48011, N'Nikhil', N'Sharma', 48012)
GO
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [MgrId]) VALUES (48012, N'Parveen', N'Kumar', 11111)
GO
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [MgrId]) VALUES (48013, N'Tarun', N'Narang', 11111)
GO
SET IDENTITY_INSERT [dbo].[EmployeeVacation] ON 
GO
INSERT [dbo].[EmployeeVacation] ([Id], [EmployeeId], [VacationTypeId], [DateFrom], [DateTo], [TotalDaysOff], [Approved]) VALUES (1, 48013, 1, CAST(N'2020-05-06T00:00:00.000' AS DateTime), CAST(N'2020-05-08T00:00:00.000' AS DateTime), 3, 0)
GO
INSERT [dbo].[EmployeeVacation] ([Id], [EmployeeId], [VacationTypeId], [DateFrom], [DateTo], [TotalDaysOff], [Approved]) VALUES (2, 48013, 1, CAST(N'2020-06-10T00:00:00.000' AS DateTime), CAST(N'2020-06-15T00:00:00.000' AS DateTime), 6, 0)
GO
INSERT [dbo].[EmployeeVacation] ([Id], [EmployeeId], [VacationTypeId], [DateFrom], [DateTo], [TotalDaysOff], [Approved]) VALUES (3, 48012, 1, CAST(N'2020-06-01T00:00:00.000' AS DateTime), CAST(N'2020-06-01T00:00:00.000' AS DateTime), 1, 0)
GO
INSERT [dbo].[EmployeeVacation] ([Id], [EmployeeId], [VacationTypeId], [DateFrom], [DateTo], [TotalDaysOff], [Approved]) VALUES (5, 11111, 1, CAST(N'2020-06-12T00:00:00.000' AS DateTime), CAST(N'2020-06-18T00:00:00.000' AS DateTime), 4, 0)
GO
INSERT [dbo].[EmployeeVacation] ([Id], [EmployeeId], [VacationTypeId], [DateFrom], [DateTo], [TotalDaysOff], [Approved]) VALUES (6, 48013, 2, CAST(N'2020-07-24T00:00:00.000' AS DateTime), CAST(N'2020-08-23T00:00:00.000' AS DateTime), 23, 1)
GO
INSERT [dbo].[EmployeeVacation] ([Id], [EmployeeId], [VacationTypeId], [DateFrom], [DateTo], [TotalDaysOff], [Approved]) VALUES (7, 48012, 2, CAST(N'2020-06-23T00:00:00.000' AS DateTime), CAST(N'2020-06-28T00:00:00.000' AS DateTime), 5, 0)
GO
SET IDENTITY_INSERT [dbo].[EmployeeVacation] OFF
GO
SET IDENTITY_INSERT [dbo].[VacationType] ON 
GO
INSERT [dbo].[VacationType] ([Id], [Type]) VALUES (1, N'Vacation')
GO
INSERT [dbo].[VacationType] ([Id], [Type]) VALUES (2, N'Travel')
GO
INSERT [dbo].[VacationType] ([Id], [Type]) VALUES (3, N'Training')
GO
INSERT [dbo].[VacationType] ([Id], [Type]) VALUES (4, N'WFHAdhoc')
GO
INSERT [dbo].[VacationType] ([Id], [Type]) VALUES (5, N'WFHPermanent')
GO
SET IDENTITY_INSERT [dbo].[VacationType] OFF
GO
ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTraining_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK_EmployeeTraining_Employee]
GO
ALTER TABLE [dbo].[EmployeeTraining]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTraining_Training] FOREIGN KEY([TrainingId])
REFERENCES [dbo].[Training] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeTraining] CHECK CONSTRAINT [FK_EmployeeTraining_Training]
GO
ALTER TABLE [dbo].[EmployeeVacation]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeVacation_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeVacation] CHECK CONSTRAINT [FK_EmployeeVacation_Employee]
GO
ALTER TABLE [dbo].[EmployeeVacation]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeVacation_VacationType] FOREIGN KEY([VacationTypeId])
REFERENCES [dbo].[VacationType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeVacation] CHECK CONSTRAINT [FK_EmployeeVacation_VacationType]
GO
ALTER TABLE [dbo].[EmployeeWFH]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeWFH_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeWFH] CHECK CONSTRAINT [FK_EmployeeWFH_Employee]
GO
ALTER TABLE [dbo].[EmployeeWFH]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeWFH_VacationType] FOREIGN KEY([VacationTypeId])
REFERENCES [dbo].[VacationType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeWFH] CHECK CONSTRAINT [FK_EmployeeWFH_VacationType]
GO
ALTER TABLE [dbo].[EmployeeWFH]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeWFH_WFHDays] FOREIGN KEY([WFHDaysId])
REFERENCES [dbo].[WFHDays] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeWFH] CHECK CONSTRAINT [FK_EmployeeWFH_WFHDays]
GO
ALTER TABLE [dbo].[TravelAgenda]  WITH CHECK ADD  CONSTRAINT [FK_TravelAgenda_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TravelAgenda] CHECK CONSTRAINT [FK_TravelAgenda_Employee]
GO
ALTER TABLE [dbo].[TravelAgenda]  WITH CHECK ADD  CONSTRAINT [FK_TravelAgenda_VacationType] FOREIGN KEY([VacationTypeId])
REFERENCES [dbo].[VacationType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TravelAgenda] CHECK CONSTRAINT [FK_TravelAgenda_VacationType]
GO
ALTER TABLE [dbo].[TravelAgenda]  WITH CHECK ADD  CONSTRAINT [FK_VacationType_TravelAgenda] FOREIGN KEY([VacationTypeId])
REFERENCES [dbo].[VacationType] ([Id])
GO
ALTER TABLE [dbo].[TravelAgenda] CHECK CONSTRAINT [FK_VacationType_TravelAgenda]
GO

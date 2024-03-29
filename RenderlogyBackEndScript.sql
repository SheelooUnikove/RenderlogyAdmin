USE [master]
GO
/****** Object:  Database [Render17even]    Script Date: 09/23/2014 18:21:32 ******/
CREATE DATABASE [Render17even] ON  PRIMARY 
( NAME = N'Render17even', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SYSPREP\MSSQL\DATA\Render17even.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Render17even_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SYSPREP\MSSQL\DATA\Render17even_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Render17even] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Render17even].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Render17even] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Render17even] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Render17even] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Render17even] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Render17even] SET ARITHABORT OFF
GO
ALTER DATABASE [Render17even] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Render17even] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Render17even] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Render17even] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Render17even] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Render17even] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Render17even] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Render17even] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Render17even] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Render17even] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Render17even] SET  ENABLE_BROKER
GO
ALTER DATABASE [Render17even] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Render17even] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Render17even] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Render17even] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Render17even] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Render17even] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Render17even] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Render17even] SET  READ_WRITE
GO
ALTER DATABASE [Render17even] SET RECOVERY FULL
GO
ALTER DATABASE [Render17even] SET  MULTI_USER
GO
ALTER DATABASE [Render17even] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Render17even] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Render17even', N'ON'
GO
USE [Render17even]
GO
/****** Object:  Table [dbo].[AccountTypeMasters]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypeMasters](
	[AccountTypeId] [int] IDENTITY(1,1) NOT NULL,
	[AccountTypeName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AccountTypeMasters] PRIMARY KEY CLUSTERED 
(
	[AccountTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountTypeMasters] ON
INSERT [dbo].[AccountTypeMasters] ([AccountTypeId], [AccountTypeName]) VALUES (1, N'Residential')
INSERT [dbo].[AccountTypeMasters] ([AccountTypeId], [AccountTypeName]) VALUES (2, N'Commercial')
INSERT [dbo].[AccountTypeMasters] ([AccountTypeId], [AccountTypeName]) VALUES (3, N'Hospitality')
INSERT [dbo].[AccountTypeMasters] ([AccountTypeId], [AccountTypeName]) VALUES (4, N'Builder Alliance')
SET IDENTITY_INSERT [dbo].[AccountTypeMasters] OFF
/****** Object:  Table [dbo].[AccountMasterStatus]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountMasterStatus](
	[AccountStatusId] [int] IDENTITY(1,1) NOT NULL,
	[AccountStatusName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AccountMasterStatus] PRIMARY KEY CLUSTERED 
(
	[AccountStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountMasterStatus] ON
INSERT [dbo].[AccountMasterStatus] ([AccountStatusId], [AccountStatusName]) VALUES (1, N'Active')
INSERT [dbo].[AccountMasterStatus] ([AccountStatusId], [AccountStatusName]) VALUES (2, N'InActive')
SET IDENTITY_INSERT [dbo].[AccountMasterStatus] OFF
/****** Object:  Table [dbo].[AccountMasters]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountMasters](
	[AccountMasterId] [int] IDENTITY(1,1) NOT NULL,
	[AccountMasterName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AccountMasters] PRIMARY KEY CLUSTERED 
(
	[AccountMasterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountMasters] ON
INSERT [dbo].[AccountMasters] ([AccountMasterId], [AccountMasterName]) VALUES (1, N'Yashlok')
INSERT [dbo].[AccountMasters] ([AccountMasterId], [AccountMasterName]) VALUES (2, N'Other')
SET IDENTITY_INSERT [dbo].[AccountMasters] OFF
/****** Object:  Table [dbo].[AccountMasterContacts]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountMasterContacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [nvarchar](max) NULL,
	[AccountId] [int] NOT NULL,
	[MobileNumber] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[ContactEmailAddress] [nvarchar](max) NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.AccountMasterContacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountManagerMasters]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountManagerMasters](
	[AccountManagerId] [int] IDENTITY(1,1) NOT NULL,
	[AccountManagerName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AccountManagerMasters] PRIMARY KEY CLUSTERED 
(
	[AccountManagerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountManagerMasters] ON
INSERT [dbo].[AccountManagerMasters] ([AccountManagerId], [AccountManagerName]) VALUES (1, N'Anand')
SET IDENTITY_INSERT [dbo].[AccountManagerMasters] OFF
/****** Object:  Table [dbo].[Typeofconversations]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Typeofconversations](
	[TypeofconversationId] [int] IDENTITY(1,1) NOT NULL,
	[TypeofconversationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Typeofconversations] PRIMARY KEY CLUSTERED 
(
	[TypeofconversationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Typeofconversations] ON
INSERT [dbo].[Typeofconversations] ([TypeofconversationId], [TypeofconversationName]) VALUES (1, N'Face to Face')
INSERT [dbo].[Typeofconversations] ([TypeofconversationId], [TypeofconversationName]) VALUES (2, N'Phone call')
INSERT [dbo].[Typeofconversations] ([TypeofconversationId], [TypeofconversationName]) VALUES (3, N'Skype/VideoConference')
INSERT [dbo].[Typeofconversations] ([TypeofconversationId], [TypeofconversationName]) VALUES (4, N'Email')
INSERT [dbo].[Typeofconversations] ([TypeofconversationId], [TypeofconversationName]) VALUES (5, N'Whatsapp')
SET IDENTITY_INSERT [dbo].[Typeofconversations] OFF
/****** Object:  Table [dbo].[TagsDictionary]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagsDictionary](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagTitle] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[ActionAPI] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TagsDictionary] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TagsDictionary] ON
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (1, N'Grillage foundation ', N'Issue', N'API for creating new issue')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (2, N'Defective', N'New customer ', N'API for creating New customer')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (3, N'bad design', N'issue', N'API for creating new issue')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (4, N'replace wallpapers or wall decal', N'issue', N'API for creating new issue')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (5, N'new or repaint', N'issue or new requirement', N'API for creating new issue')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (6, N'restyling or rededigning', N'new requirement', N'API for creating new requirement')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (7, N'flooring and lighting', N'new requirement', N'API for creating new requirement')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (8, N'furniture or furnishing', N'new requirement or issue', N'API for creating new issue or requirement')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (9, N'art and craft', N'new customer', N'API for creating New customer')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (10, N'design plan change', N'issue', N'API for creating new issue')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (11, N'Ligting or textiles', N'new requirement', N'API for creating new requirement')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (12, N'furbish or refurbish', N'new requrirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (13, N'kitchen or rooms', N'new customer or issue', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (14, N'cabinets,windows', N'issue or new requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (15, N'ceiling or rooftops', N'new customer or requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (16, N'countertops,sinks,basins', N'new requirement or new customer', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (17, N'fences or walls or gates', N'new requirement or issue', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (18, N'doors,doorways', N'new customer or requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (19, N'architecture or architectural', N'issue or new requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (20, N'driveways or walkways or courtyards', N'new customer or requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (21, N'home and kitchen appliances', N'new requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (22, N'mirrors or wood work', N'new requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (23, N'new house or villa or apartment', N'new customer', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (24, N'bath fittings and sanitaryware', N'new requirement or issue', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (25, N'home security and services', N'new customer or new requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (26, N'vaaastu and feng shui', N'new requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (27, N'Glass partitions ', N'new requirement', NULL)
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (28, N'Create ', N'Issue', N'API for create new issue')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (29, N'weekly status report ', N'FollowUp', N'API for create Contact Alert')
INSERT [dbo].[TagsDictionary] ([TagId], [TagTitle], [Action], [ActionAPI]) VALUES (30, N'Geometrical stair', N'NA', NULL)
SET IDENTITY_INSERT [dbo].[TagsDictionary] OFF
/****** Object:  Table [dbo].[StringFile]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StringFile](
	[StringText] [varchar](50) NOT NULL,
	[FileName] [varchar](max) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[StringFile] ([StringText], [FileName]) VALUES (N'contact', N'Contact.xml')
/****** Object:  Table [dbo].[States]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StatName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.States] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[States] ON
INSERT [dbo].[States] ([StateID], [StatName]) VALUES (1, N'Delhi')
INSERT [dbo].[States] ([StateID], [StatName]) VALUES (2, N'UP')
SET IDENTITY_INSERT [dbo].[States] OFF
/****** Object:  Table [dbo].[SignUps]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SignUps](
	[SignUpId] [int] IDENTITY(1,1) NOT NULL,
	[DesignHouseName] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[EmailId] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[State] [int] NOT NULL,
	[StateName] [nvarchar](max) NULL,
	[City] [int] NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[NoOfEmployeeDesHouse] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[RandomPwd] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SignUps] PRIMARY KEY CLUSTERED 
(
	[SignUpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SignUps] ON
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (1, N'Abc', N'deepika', N'deepika@unikove.com', N'noida sec 22', 1, N'Delhi', 1, N'Delhi', N'7987785545', N'12222', N'123456', N'Admin', 1, N'123')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (2, N'abc', N'Rahul', N'Rahul@hotmail.com', N'Noida', 1, NULL, 1, NULL, N'5968645445', N'45454545', N'1111111', N'Admin', 1, N'123')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (3, N'abc', N'Rathor', N'rathor@gmail.com', N'Noida', 1, NULL, 1, NULL, N'4565859857', N'45454545', N'123456', NULL, 1, N'123')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (4, N'abc', N'sumit', N'sumit@unikove.com', N'Delhi', 2, NULL, 2, NULL, N'9898986532', N'123456', N'123456', NULL, 1, N'123')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (5, N'abc', N'Sharik', N'sharik@unikove.com', N'mujaffer nagar', 2, NULL, 2, NULL, N'9999952636', N'123456', N'123456', NULL, 1, N'123')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (6, N'abc', N'admin', N'admin@jbr.com', N'Admin Adress', 2, NULL, 2, NULL, N'9999999999', N'111', N'111111', NULL, 1, N'456')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (7, N'abc', N'Tech', N'Tech@unikove.com', N'tech', 1, NULL, 1, NULL, N'8888888888', N'123456', N'123456', NULL, 0, N'789')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (8, N'abc', N'Rohit', N'rohit@unikove.com', N'Delhi', 1, NULL, 1, NULL, N'9887654444', N'45454545', N'123456', N'Admin', 1, N'123')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (9, N'yashlok', N'renderlogy', N'renderlogy@unikove.com', N'noida', 1, NULL, 1, NULL, N'1111111111', N'45454545', N'123456', N'Admin', 1, N'123')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (14, N'ABC', N'yash', N'yashlok.1kumar@gmail.com', N'234234', 1, NULL, 1, NULL, N'23423423', N'234234', N'111111', N'Admin', 1, N'RZQF*wRX2D')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (17, N'yashlok', N'abc', N'yashlok.kumar1@gmail.com', N'23423', 1, NULL, 1, NULL, N'123456', N'45454545', N'123456', NULL, 0, N'm7aLX4xkzX')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (18, N'House', N'Yashlok ', N'yashlok.kumar@gmail1.com', N'Delhi', 1, NULL, 1, NULL, N'12455', N'1234', N'123456', NULL, 1, N'@+eGtMxpmm')
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (19, N'yashlok', N'abc', N'yashlok.kumar@gmail.com', N'Delhi', 1, NULL, 1, NULL, N'123456', N'123456', N'123456', NULL, 1, NULL)
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (20, N'Sachan Housing', N'Sheeloo Sachan', N'sheeloo@unikove.com', N'B-44 Sector-60', 1, NULL, 1, NULL, N'9717036547', N'80', N'123456', NULL, 1, NULL)
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (22, N'anand', N'Anand Jaiswal', N'akj007.2009@gmail.com', N'B-44 Sector 60', 1, NULL, 1, NULL, N'0120456798955', N'12', N'123456', NULL, 1, NULL)
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (23, N'House', N'Yashlok kumar', N'yashlok@unikovel.com', N'Delhi', 1, NULL, 1, NULL, N'123456', N'1234', N'123456', NULL, 0, NULL)
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (24, N'House', N'Yashlok kumar', N'yashlok@unikove.com', N'Delhi', 1, NULL, 1, NULL, N'123456', N'1234', N'123456', NULL, 1, NULL)
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (25, N'House', N'yash', N'yashlok.kumar6@gmail.com', N'Delhi', 1, NULL, 1, NULL, N'123456', N'1234', N'123456', NULL, 0, NULL)
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (26, N'House', N'yashlok', N'yashlok.mca6@gmail.ocm', N'Delhi', 1, NULL, 1, NULL, N'123456', N'100', N'123456', NULL, 0, NULL)
INSERT [dbo].[SignUps] ([SignUpId], [DesignHouseName], [FullName], [EmailId], [Address], [State], [StateName], [City], [CityName], [PhoneNo], [NoOfEmployeeDesHouse], [Password], [RoleName], [IsActive], [RandomPwd]) VALUES (27, N'yash', N'yashh fact', N'sheeloo@uniikove.com', N'noida', 2, NULL, 2, NULL, N'9717036547', N'10', N'passwards', NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[SignUps] OFF
/****** Object:  Table [dbo].[Roles]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (2, N'User', NULL)
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (3, N'CRM', NULL)
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (4, N'PMO', NULL)
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (5, N'Finance', NULL)
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (6, N'Interior Designer', NULL)
INSERT [dbo].[Roles] ([RoleId], [Name], [Description]) VALUES (7, N'Business Developer', NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[ReferralSources]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferralSources](
	[ReferralSourceId] [int] IDENTITY(1,1) NOT NULL,
	[ReferralSourceName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ReferralSources] PRIMARY KEY CLUSTERED 
(
	[ReferralSourceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ReferralSources] ON
INSERT [dbo].[ReferralSources] ([ReferralSourceId], [ReferralSourceName]) VALUES (1, N'Agent')
INSERT [dbo].[ReferralSources] ([ReferralSourceId], [ReferralSourceName]) VALUES (2, N'Just Dial')
INSERT [dbo].[ReferralSources] ([ReferralSourceId], [ReferralSourceName]) VALUES (3, N'Referral')
SET IDENTITY_INSERT [dbo].[ReferralSources] OFF
/****** Object:  Table [dbo].[mailsData]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mailsData](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[FromEmail] [nvarchar](max) NULL,
	[ToEmail] [nvarchar](max) NULL,
	[CC] [nvarchar](max) NULL,
	[BCC] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[AttachFileName] [nvarchar](max) NULL,
	[EmailRecvDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.mailsData] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FollowAlerts]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FollowAlerts](
	[AlertId] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[FollowUpDate] [datetime] NULL,
	[FollowUpHH] [nvarchar](max) NULL,
	[FollowUpMM] [nvarchar](max) NULL,
	[FollowUpAMPM] [nvarchar](max) NULL,
	[RemindMe2Hours] [bit] NOT NULL,
	[RemindMeToDay] [bit] NOT NULL,
	[RemindMe2Days] [bit] NOT NULL,
	[Status] [int] NOT NULL,
	[TypeofconversationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.FollowAlerts] PRIMARY KEY CLUSTERED 
(
	[AlertId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FollowAlerts] ON
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (1, 1, N'dfdf', CAST(0x0000A3AA00000000 AS DateTime), N'7', N'22', N'PM', 0, 0, 0, 1, 1)
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (2, 1, N'cddasd', CAST(0x0000A3A900000000 AS DateTime), N'7', N'21', N'PM', 0, 0, 0, 1, 1)
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (3, 1, N'gggg', CAST(0x0000A3AA00000000 AS DateTime), N'10', N'9', N'PM', 0, 0, 0, 1, 2)
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (4, 1, N'call  to deepika', CAST(0x0000A3A300000000 AS DateTime), N'6', N'21', N'PM', 0, 0, 0, 1, 1)
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (5, 1, N'sasasasasasasasas', CAST(0x0000A3B200000000 AS DateTime), N'8', N'20', N'PM', 0, 0, 0, 1, 0)
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (6, 1, N'asas', CAST(0x0000A3AA00000000 AS DateTime), N'9', N'22', N'AM', 0, 0, 0, 1, 2)
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (7, 1, N'dfggdf', CAST(0x0000A3B100000000 AS DateTime), N'9', N'21', N'PM', 1, 1, 1, 1, 3)
INSERT [dbo].[FollowAlerts] ([AlertId], [ContactId], [Comments], [FollowUpDate], [FollowUpHH], [FollowUpMM], [FollowUpAMPM], [RemindMe2Hours], [RemindMeToDay], [RemindMe2Days], [Status], [TypeofconversationId]) VALUES (8, 59, N'lkjrslkgjd', CAST(0x0000A3A800000000 AS DateTime), N'10', N'8', N'AM', 0, 0, 0, 1, 3)
SET IDENTITY_INSERT [dbo].[FollowAlerts] OFF
/****** Object:  Table [dbo].[EngagementTypes]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EngagementTypes](
	[EngagementTypesId] [int] IDENTITY(1,1) NOT NULL,
	[EngagementTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.EngagementTypes] PRIMARY KEY CLUSTERED 
(
	[EngagementTypesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailStorage]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailStorage](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[FromEmail] [varchar](100) NOT NULL,
	[ToEmail] [varchar](250) NOT NULL,
	[CC] [varchar](250) NOT NULL,
	[BCC] [varchar](250) NOT NULL,
	[Subject] [varchar](250) NOT NULL,
	[Body] [varchar](max) NULL,
	[EmailRecvDate] [datetime] NOT NULL,
	[AttachFileName] [varchar](150) NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_EmailStorage] PRIMARY KEY CLUSTERED 
(
	[FromEmail] ASC,
	[ToEmail] ASC,
	[Subject] ASC,
	[EmailRecvDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EmailStorage] ON
INSERT [dbo].[EmailStorage] ([MessageId], [FromEmail], [ToEmail], [CC], [BCC], [Subject], [Body], [EmailRecvDate], [AttachFileName], [CreationDate]) VALUES (2, N'jasmeet@unikove.com', N'renderlogy@unikove.com;', N'mallikaravi@jbrinteriotech.com;', N'', N'Status Report Submission', N'> [Create Action Item] Jasmeet to submit weekly status report on 22/08/14
> 
> 
>> 
', CAST(0x0000A3A4012F9DC8 AS DateTime), N'E:\Renderlogy1709\Renderlogy1609\Project\RenderLogy\Attachments\Interior_Design_Doc.docx||', CAST(0x0000A3AA00FABFBE AS DateTime))
SET IDENTITY_INSERT [dbo].[EmailStorage] OFF
/****** Object:  Table [dbo].[DeveloperMasters]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeveloperMasters](
	[DeveloperId] [int] IDENTITY(1,1) NOT NULL,
	[DeveloperName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DeveloperMasters] PRIMARY KEY CLUSTERED 
(
	[DeveloperId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DeveloperMasters] ON
INSERT [dbo].[DeveloperMasters] ([DeveloperId], [DeveloperName]) VALUES (1, N'Mukund')
INSERT [dbo].[DeveloperMasters] ([DeveloperId], [DeveloperName]) VALUES (2, N'Other')
SET IDENTITY_INSERT [dbo].[DeveloperMasters] OFF
/****** Object:  Table [dbo].[Customers]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Cusid] [int] IDENTITY(1,1) NOT NULL,
	[Contid] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[UnitId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreationDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Cusid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT [dbo].[Customers] ([Cusid], [Contid], [Email], [Password], [UnitId], [IsActive], [CreationDate], [CreatedBy]) VALUES (1, 1, N'anand@unikove.com', N'123456', 1, 1, CAST(0x0000A3AE00ECB06C AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Customers] OFF
/****** Object:  Table [dbo].[CRMContacts]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMContacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [nvarchar](max) NOT NULL,
	[AccountMasterId] [int] NOT NULL,
	[OtherAccountName] [nvarchar](max) NULL,
	[DeveloperId] [int] NOT NULL,
	[OtherDeveloperName] [nvarchar](max) NULL,
	[AccountTypeId] [int] NOT NULL,
	[ProjectLocationId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[MobileNumber] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[ContactEmailAddress] [nvarchar](max) NOT NULL,
	[AccountManagerId] [int] NOT NULL,
	[ContactStatusId] [int] NOT NULL,
	[Budget] [nvarchar](max) NOT NULL,
	[ReferralSourceId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreationDate] [datetime] NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.CRMContacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRMContacts] ON
INSERT [dbo].[CRMContacts] ([ContactId], [ContactName], [AccountMasterId], [OtherAccountName], [DeveloperId], [OtherDeveloperName], [AccountTypeId], [ProjectLocationId], [Address], [MobileNumber], [PhoneNumber], [ContactEmailAddress], [AccountManagerId], [ContactStatusId], [Budget], [ReferralSourceId], [CreatedBy], [CreationDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'ANAND KUMAR JAISWAL', 1, N'', 1, N'', 1, 1, N'B-44 Sector 60', N'8802814698', N'01204656974566', N'anand@unikove.com', 5, 1, N'1245', 1, 1, CAST(0x0000A3A9012B86F0 AS DateTime), 4, CAST(0x0000A3AE01282F03 AS DateTime))
INSERT [dbo].[CRMContacts] ([ContactId], [ContactName], [AccountMasterId], [OtherAccountName], [DeveloperId], [OtherDeveloperName], [AccountTypeId], [ProjectLocationId], [Address], [MobileNumber], [PhoneNumber], [ContactEmailAddress], [AccountManagerId], [ContactStatusId], [Budget], [ReferralSourceId], [CreatedBy], [CreationDate], [ModifiedBy], [ModifiedDate]) VALUES (59, N'Sheeloo', 1, N'', 1, N'', 2, 2, N'pokslfdkgs', N'985985985759', N'8409834953098', N'msdlfkjsdflkj@jfk.com', 5, 2, N'8484949484849', 1, 1, CAST(0x0000A3AA0102EFDA AS DateTime), 4, CAST(0x0000A3AE01284EA0 AS DateTime))
SET IDENTITY_INSERT [dbo].[CRMContacts] OFF
/****** Object:  Table [dbo].[CRMAccountMasters]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMAccountMasters](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountMasterName] [nvarchar](max) NOT NULL,
	[DeveloperName] [nvarchar](max) NOT NULL,
	[AccountTypeId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ProjectWebsite] [nvarchar](max) NOT NULL,
	[AccountManagerId] [int] NOT NULL,
	[AccountStatusId] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreationDate] [datetime] NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.CRMAccountMasters] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactStatus]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactStatus](
	[ContactStatusId] [int] IDENTITY(1,1) NOT NULL,
	[ContactStatusName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ContactStatus] PRIMARY KEY CLUSTERED 
(
	[ContactStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ContactStatus] ON
INSERT [dbo].[ContactStatus] ([ContactStatusId], [ContactStatusName]) VALUES (1, N'Leads')
INSERT [dbo].[ContactStatus] ([ContactStatusId], [ContactStatusName]) VALUES (2, N'Qualified')
INSERT [dbo].[ContactStatus] ([ContactStatusId], [ContactStatusName]) VALUES (3, N'Prospects')
INSERT [dbo].[ContactStatus] ([ContactStatusId], [ContactStatusName]) VALUES (4, N'Closed')
INSERT [dbo].[ContactStatus] ([ContactStatusId], [ContactStatusName]) VALUES (5, N'Dead')
SET IDENTITY_INSERT [dbo].[ContactStatus] OFF
/****** Object:  Table [dbo].[Cities]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[StateID] [int] NULL,
 CONSTRAINT [PK_dbo.Cities] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_StateID] ON [dbo].[Cities] 
(
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID]) VALUES (1, N'Delhi', 1)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID]) VALUES (2, N'Noida', 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID]) VALUES (3, N'Meerut', 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID]) VALUES (4, N'Lucknow', 2)
INSERT [dbo].[Cities] ([CityID], [CityName], [StateID]) VALUES (5, N'Kanpur', 2)
SET IDENTITY_INSERT [dbo].[Cities] OFF
/****** Object:  Table [dbo].[UserRoles]    Script Date: 09/23/2014 18:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[SignUpId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserRoles] PRIMARY KEY CLUSTERED 
(
	[SignUpId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[UserRoles] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_SignUpId] ON [dbo].[UserRoles] 
(
	[SignUpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (6, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (7, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (8, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (9, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (14, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (17, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (19, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (20, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (22, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (23, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (25, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (26, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (27, 1)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (4, 3)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (24, 3)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (2, 4)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (3, 4)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (18, 5)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (1, 6)
INSERT [dbo].[UserRoles] ([SignUpId], [RoleId]) VALUES (5, 7)
/****** Object:  StoredProcedure [dbo].[SpLogin]    Script Date: 09/23/2014 18:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yashlok
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SpLogin]              --SpLogin 'anand@unikove.com','123456'
	-- Add the parameters for the stored procedure here
	@UserName varchar(100) , 
	@Password varchar(100) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    
 --   if EXISTS(select 1 from Users where UserName=@UserName AND Password=@Password)
	--SELECT   UserId ,UserName,	Password,	RoleId,	IsActive,	IsDeleted ,CreatedDate,ModifiedDate from Users where UserName=@UserName AND Password=@Password
	 if EXISTS(select 1 from Customers where Email=@UserName AND Password=@Password)
	SELECT    Cusid CustomerId,Password,IsActive,CRMContacts.ContactName UserName  from Customers 
	join CRMContacts on CRMContacts.ContactId=Customers.Contid
	where Email=@UserName AND Password=@Password
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveAccountXML]    Script Date: 09/23/2014 18:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[sp_SaveAccountXML]
@AccountDetailsXML NVARCHAR(max),
@UserId Int
As
BEGIN
DECLARE @Index INT
	EXEC sp_xml_preparedocument @Index OUTPUT, @AccountDetailsXML    
			
   SELECT  ContactName,Developer,AccountName,AccountType,City,Address,MobileNumber,PhoneNumber,EmailAddress,AccountManager,Status,Budget,ReferalSource 
   INTO #tmpBPCS FROM OPENXML (@Index, '/NewDataSet/Account_x0024_',2)WITH 
   (ContactName VARCHAR(50),Developer VARCHAR(50),AccountName VARCHAR(50),AccountType VARCHAR(50),City VARCHAR(30),Address VARCHAR(500),MobileNumber VARCHAR(30),PhoneNumber VARCHAR(30),
   EmailAddress NVARCHAR(100),AccountManager VARCHAR(50),Status VARCHAR(50),Budget VARCHAR(50),ReferalSource VARCHAR(50))	
   --SELECT * FROM #tmpBPCS
   INSERT INTO CRMContacts(ContactName,ContactEmailAddress,MobileNumber,ProjectLocationId,CreatedBy,CreationDate,ModifiedBy,ModifiedDate,AccountManagerId,
   AccountMasterId,AccountTypeId,ContactStatusId,DeveloperId,ReferralSourceId,Budget,Address,PhoneNumber)
   SELECT  DISTINCT t.ContactName,EmailAddress,t.MobileNumber,ct.CityID ,@UserId,GETDATE(),@UserId,GETDATE(),AccMngr.AccountManagerId,AcMs.AccountMasterId,AcTyp.AccountTypeId,
   ConSts.ContactStatusId,Devp.DeveloperId,Refs.ReferralSourceId,t.Budget,t.Address,t.PhoneNumber
   FROM #tmpBPCS t
   JOIN Cities ct ON ct.CityName=t.City
   JOIN AccountManagerMasters AccMngr ON AccMngr.AccountManagerName=t.AccountManager
   JOIN AccountMasters AcMs ON AcMs.AccountMasterName=t.AccountName
   JOIN AccountTypeMasters AcTyp ON AcTyp.AccountTypeName=t.AccountType
   JOIN ContactStatus ConSts ON ConSts.ContactStatusName=t.Status
   JOIN DeveloperMasters Devp ON Devp.DeveloperName=t.Developer
   JOIN ReferralSources Refs ON Refs.ReferralSourceName=t.ReferalSource
   ----
   JOIN CRMContacts c ON c.ContactEmailAddress<>t.EmailAddress AND c.MobileNumber<>t.MobileNumber   
   
END
GO
/****** Object:  Default [DF_EmailStorage_CC]    Script Date: 09/23/2014 18:21:33 ******/
ALTER TABLE [dbo].[EmailStorage] ADD  CONSTRAINT [DF_EmailStorage_CC]  DEFAULT (NULL) FOR [CC]
GO
/****** Object:  Default [DF_EmailStorage_BCC]    Script Date: 09/23/2014 18:21:33 ******/
ALTER TABLE [dbo].[EmailStorage] ADD  CONSTRAINT [DF_EmailStorage_BCC]  DEFAULT (NULL) FOR [BCC]
GO
/****** Object:  Default [DF__Customers__Creat__300424B4]    Script Date: 09/23/2014 18:21:33 ******/
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Customers__Creat__300424B4]  DEFAULT ((0)) FOR [CreatedBy]
GO
/****** Object:  ForeignKey [FK_dbo.Cities_dbo.States_StateID]    Script Date: 09/23/2014 18:21:33 ******/
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cities_dbo.States_StateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_dbo.Cities_dbo.States_StateID]
GO
/****** Object:  ForeignKey [FK_dbo.UserRoles_dbo.Roles_RoleId]    Script Date: 09/23/2014 18:21:33 ******/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRoles_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_dbo.UserRoles_dbo.Roles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.UserRoles_dbo.SignUps_SignUpId]    Script Date: 09/23/2014 18:21:33 ******/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRoles_dbo.SignUps_SignUpId] FOREIGN KEY([SignUpId])
REFERENCES [dbo].[SignUps] ([SignUpId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_dbo.UserRoles_dbo.SignUps_SignUpId]
GO

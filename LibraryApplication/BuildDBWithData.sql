USE [master]
GO
/****** Object:  Database [Lib2020]    Script Date: 9/4/2019 5:07:49 PM ******/
CREATE DATABASE [Lib2020]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Lib2020', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Lib2020.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Lib2020_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Lib2020_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Lib2020] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Lib2020].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Lib2020] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Lib2020] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Lib2020] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Lib2020] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Lib2020] SET ARITHABORT OFF 
GO
ALTER DATABASE [Lib2020] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Lib2020] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Lib2020] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Lib2020] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Lib2020] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Lib2020] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Lib2020] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Lib2020] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Lib2020] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Lib2020] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Lib2020] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Lib2020] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Lib2020] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Lib2020] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Lib2020] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Lib2020] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Lib2020] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Lib2020] SET RECOVERY FULL 
GO
ALTER DATABASE [Lib2020] SET  MULTI_USER 
GO
ALTER DATABASE [Lib2020] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Lib2020] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Lib2020] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Lib2020] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Lib2020] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Lib2020', N'ON'
GO
ALTER DATABASE [Lib2020] SET QUERY_STORE = OFF
GO
USE [Lib2020]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Isbn] [nvarchar](20) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCopy]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCopy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[LibraryId] [int] NOT NULL,
	[Available] [bit] NOT NULL,
 CONSTRAINT [PK_BookCopy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserAccountId] [int] NULL,
	[LibraryId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Librarian]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Librarian](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Librarian] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Library]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nchar](2) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[HashedPassword] [nvarchar](200) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 9/4/2019 5:07:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserAccountId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserAccountId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (1, N'Carl', N'Sagan')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (2, N'Frank', N'Herbert')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (3, N'Michio', N'Kaku')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (4, N'Isaac', N'Asimov')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (5, N'Ray', N'Bradbury')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (6, N'Isaac', N'Newton')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (7, N'Ronald', N'McDonald')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (8, N'Jose', N'Rizal')
INSERT [dbo].[Author] ([Id], [FirstName], [LastName]) VALUES (9, N'Jeff', N'Grubb')
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (1, N'Foundation', 4, N'0553293354')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (2, N'Foundation and Empire', 4, N'0553293371')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (3, N'Second Foundation', 4, N'0553293364')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (4, N'Dune', 2, N'0441172717')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (5, N'Fahrenheit 451', 5, N'0345342966')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (6, N'Physics of the Impossible', 3, N'0307278824')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (8, N'The Demon-Haunted World', 1, N'0345409469')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (10, N'Cosmos', 1, N'0345539434')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (12, N'🍔🍔', 7, N'Big Mac')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (14, N'Parallel Worlds', 3, N'1400033721')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (16, N'🍟', 7, N'World Famous Fries')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (17, N'The Last Guardian', 9, N'0989700127')
INSERT [dbo].[Book] ([Id], [Title], [AuthorId], [Isbn]) VALUES (18, N'Pale Blue Dot', 1, N'0345376595')
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[BookCopy] ON 

INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (1, 10, 8, 1)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (2, 10, 8, 1)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (3, 10, 8, 0)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (4, 10, 9, 1)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (5, 10, 9, 0)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (6, 4, 13, 0)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (7, 4, 13, 0)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (8, 4, 8, 0)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (9, 4, 11, 1)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (10, 4, 13, 1)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (11, 1, 8, 1)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (12, 1, 11, 0)
INSERT [dbo].[BookCopy] ([Id], [BookId], [LibraryId], [Available]) VALUES (13, 1, 8, 0)
SET IDENTITY_INSERT [dbo].[BookCopy] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [UserAccountId], [LibraryId]) VALUES (1, 1, 17)
INSERT [dbo].[Employee] ([Id], [UserAccountId], [LibraryId]) VALUES (2, 2, 14)
INSERT [dbo].[Employee] ([Id], [UserAccountId], [LibraryId]) VALUES (3, 3, 15)
INSERT [dbo].[Employee] ([Id], [UserAccountId], [LibraryId]) VALUES (4, 4, 16)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Librarian] ON 

INSERT [dbo].[Librarian] ([Id], [EmployeeId]) VALUES (1, 1)
INSERT [dbo].[Librarian] ([Id], [EmployeeId]) VALUES (2, 2)
INSERT [dbo].[Librarian] ([Id], [EmployeeId]) VALUES (3, 3)
INSERT [dbo].[Librarian] ([Id], [EmployeeId]) VALUES (4, 4)
SET IDENTITY_INSERT [dbo].[Librarian] OFF
SET IDENTITY_INSERT [dbo].[Library] ON 

INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (8, N'Commack Public Library', N'19 Hauppauge Road', NULL, N'Commack', 18, N'11725')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (9, N'Frank Melville, Jr. Memorial Library', N'Stony Brook University', NULL, N'Stony Brook', 39, N'11794')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (10, N'Fresno County Public Library', N'2420 Mariposa Street', NULL, N'Fresno', 11, N'93721')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (11, N'Seattle Public Library - Central Library', N'1000 4th Ave', NULL, N'Seattle', 55, N'98104')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (12, N'Multomah County Library - Central Library', N'801 SW 10th Avenue', NULL, N'Portland', 44, N'97205')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (13, N'Smithtown Library - Smithtown Building', N'One North Country Road', NULL, N'Smithtown', 39, N'11787')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (14, N'Test Library', N'1000 Encyclopedia Rd', N'Suite A', N'Biblioteca', 8, N'Book')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (15, N'The Arcaneum', N'College of Winterhold', NULL, N'Winterhold', 8, N'N/A')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (16, N'Library of Congress', N'101 Independence Ave SE', NULL, N'Washington', 15, N'20540')
INSERT [dbo].[Library] ([Id], [Name], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (17, N'Scarlet Monastery Library', N'Scarlet Monastery', NULL, N'Tirisfal Glades', 11, N'WoW-14')
SET IDENTITY_INSERT [dbo].[Library] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Patron')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Librarian')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (1, N'Alabama', N'AL')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (8, N'Alaska', N'AK')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (9, N'Arizona', N'AZ')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (10, N'Arkansas', N'AR')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (11, N'California', N'CA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (12, N'Colorado', N'CO')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (13, N'Connecticut', N'CT')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (14, N'Delaware', N'DE')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (15, N'District of Columbia', N'DC')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (16, N'Florida', N'FL')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (17, N'Georgia', N'GA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (18, N'Hawaii', N'HI')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (19, N'Idaho', N'ID')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (20, N'Illinois', N'IL')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (21, N'Indiana', N'IN')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (22, N'Iowa', N'IA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (23, N'Kansas', N'KS')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (24, N'Kentucky', N'KY')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (25, N'Louisiana', N'LA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (26, N'Maine', N'ME')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (27, N'Maryland', N'MD')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (28, N'Massachusetts', N'MA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (29, N'Michigan', N'MI')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (30, N'Minnesota', N'MN')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (31, N'Mississippi', N'MS')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (32, N'Missouri', N'MO')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (33, N'Montana', N'MT')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (34, N'Nebraska', N'NE')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (35, N'Nevada', N'NV')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (36, N'New Hampshire', N'NH')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (37, N'New Jersey', N'NJ')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (38, N'New Mexico', N'NM')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (39, N'New York', N'NY')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (40, N'North Carolina', N'NC')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (41, N'North Dakota', N'ND')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (42, N'Ohio', N'OH')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (43, N'Oklahoma', N'OK')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (44, N'Oregon', N'OR')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (45, N'Pennsylvania', N'PA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (46, N'Puerto Rico', N'PR')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (47, N'Rhode Island', N'RI')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (48, N'South Carolina', N'SC')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (49, N'South Dakota', N'SD')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (50, N'Tennessee', N'TN')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (51, N'Texas', N'TX')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (52, N'Utah', N'UT')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (53, N'Vermont', N'VT')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (54, N'Virginia', N'VA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (55, N'Washington', N'WA')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (56, N'West Virginia', N'WV')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (57, N'Wisconsin', N'WI')
INSERT [dbo].[State] ([Id], [Name], [Abbreviation]) VALUES (58, N'Wyoming', N'WY')
SET IDENTITY_INSERT [dbo].[State] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([Id], [Username], [HashedPassword], [FirstName], [LastName], [EmailAddress], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (1, N'WhopperMaster', N'$2a$10$niRtLAOaD2ZJhNghVnqL4.zr8hfkmGC56MmvuzeycgzlREy59Lfj.', N'Burger', N'King', N'WhopperMaster@BurgerKing.com', N'21 Lettuce Drive', NULL, N'Flavortown', 16, N'12345')
INSERT [dbo].[UserAccount] ([Id], [Username], [HashedPassword], [FirstName], [LastName], [EmailAddress], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (2, N'BigMacDaddy', N'$2a$10$iPqkhDog3M63HPNQXG.v4OioR/iVHQS9qD8AsKThRpDL9U3iMd0re', N'Ronald', N'McDonald', N'BigMacDaddy@McDonalds.com', N'13 French Fry Road', N'Apt 101', N'McDonaldLand', 20, N'54321')
INSERT [dbo].[UserAccount] ([Id], [Username], [HashedPassword], [FirstName], [LastName], [EmailAddress], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (3, N'TheEldestScroll', N'$2a$10$mO74CGGvWTIWBXn112Jf/u4lfl/0.MM9r4Cz5DkPIUWQmKpQ68ROC', N'Urag', N'gro-Shub', N'urag.gro-shub@winterhold.edu', N'College of Winterhold', NULL, N'Winterhold', 8, N'N/A')
INSERT [dbo].[UserAccount] ([Id], [Username], [HashedPassword], [FirstName], [LastName], [EmailAddress], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (4, N'Archivist', N'$2a$10$i1UxjwfTjbR6/WWRZ/qsPeyjqQCeyR0Pc6z6bClJsqLn1YpPZJJBi', N'Karen', N'Yearling', N'karen.yearling@bos.mil', N'The Citadel', NULL, N'Capital Wasteland', 15, N'22202')
INSERT [dbo].[UserAccount] ([Id], [Username], [HashedPassword], [FirstName], [LastName], [EmailAddress], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (5, N'OrangeFarmer', N'$2a$10$A1K.gTsq26680QYnq9HnW.rZ/SsU9LIiAh3ra9GiXPPDX.j39lSgG', N'John', N'Peters', N'jpetersthefarmer@aol.com', N'404 Farmer Ln', NULL, N'Night Vale', 35, N'89106')
INSERT [dbo].[UserAccount] ([Id], [Username], [HashedPassword], [FirstName], [LastName], [EmailAddress], [AddressLine1], [AddressLine2], [City], [StateId], [PostalCode]) VALUES (6, N'Ectobiologist', N'$2a$10$s1OtKvvPRVNP0JpQdQeHYenvs5RRr1Jf/Ykr4U39c7tCxO9OgY2cm', N'John', N'Egbert', N'ectobiologist@sburb.net', N'21605 SE 267th St', NULL, N'Maple Valley', 55, N'98038')
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (1, 2)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (2, 1)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (2, 2)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (3, 1)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (3, 2)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (4, 1)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (4, 2)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (5, 1)
INSERT [dbo].[UserRole] ([UserAccountId], [RoleId]) VALUES (6, 1)
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_Isbn_notnull]    Script Date: 9/4/2019 5:07:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idx_Isbn_notnull] ON [dbo].[Book]
(
	[Isbn] ASC
)
WHERE ([Isbn] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_UserAccount_Username]    Script Date: 9/4/2019 5:07:49 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_UserAccount_Username] ON [dbo].[UserAccount]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([Id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[BookCopy]  WITH CHECK ADD  CONSTRAINT [FK_BookCopy_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
GO
ALTER TABLE [dbo].[BookCopy] CHECK CONSTRAINT [FK_BookCopy_Book]
GO
ALTER TABLE [dbo].[BookCopy]  WITH CHECK ADD  CONSTRAINT [FK_BookCopy_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([Id])
GO
ALTER TABLE [dbo].[BookCopy] CHECK CONSTRAINT [FK_BookCopy_Library]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Library]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_UserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccount] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_UserAccount]
GO
ALTER TABLE [dbo].[Librarian]  WITH CHECK ADD  CONSTRAINT [FK_Librarian_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Librarian] CHECK CONSTRAINT [FK_Librarian_Employee]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_State]
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD  CONSTRAINT [FK_UserAccount_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[UserAccount] CHECK CONSTRAINT [FK_UserAccount_State]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_UserAccount] FOREIGN KEY([UserAccountId])
REFERENCES [dbo].[UserAccount] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_UserAccount]
GO
USE [master]
GO
ALTER DATABASE [Lib2020] SET  READ_WRITE 
GO

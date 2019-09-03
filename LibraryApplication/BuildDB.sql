USE [Lib2020]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 9/3/2019 8:55:31 AM ******/
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
/****** Object:  Table [dbo].[Book]    Script Date: 9/3/2019 8:55:32 AM ******/
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
/****** Object:  Table [dbo].[BookCopy]    Script Date: 9/3/2019 8:55:32 AM ******/
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
/****** Object:  Table [dbo].[BorrowBook]    Script Date: 9/3/2019 8:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LibrarianId] [int] NOT NULL,
	[PatronId] [int] NOT NULL,
	[BookCopyId] [int] NOT NULL,
	[ReservedOn] [date] NOT NULL,
	[CheckedOutOn] [date] NOT NULL,
	[DueBackOn] [date] NOT NULL,
	[ReturnedOn] [date] NULL,
 CONSTRAINT [PK_BorrowBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9/3/2019 8:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[LibraryId] [int] NOT NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Librarian]    Script Date: 9/3/2019 8:55:32 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Librarian_EmployeeNumber] UNIQUE NONCLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Library]    Script Date: 9/3/2019 8:55:32 AM ******/
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
/****** Object:  Table [dbo].[Patron]    Script Date: 9/3/2019 8:55:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patron](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Patron] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 9/3/2019 8:55:32 AM ******/
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
ALTER TABLE [dbo].[BorrowBook]  WITH CHECK ADD  CONSTRAINT [FK_BorrowBook_Librarian] FOREIGN KEY([LibrarianId])
REFERENCES [dbo].[Librarian] ([Id])
GO
ALTER TABLE [dbo].[BorrowBook] CHECK CONSTRAINT [FK_BorrowBook_Librarian]
GO
ALTER TABLE [dbo].[BorrowBook]  WITH CHECK ADD  CONSTRAINT [FK_BorrowBook_Patron] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Patron] ([Id])
GO
ALTER TABLE [dbo].[BorrowBook] CHECK CONSTRAINT [FK_BorrowBook_Patron]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Library]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_State]
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
ALTER TABLE [dbo].[Patron]  WITH CHECK ADD  CONSTRAINT [FK_Patron_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Patron] CHECK CONSTRAINT [FK_Patron_State]
GO

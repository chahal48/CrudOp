USE [master]
GO
/****** Object:  Database [CrudOpDB]    Script Date: 23/12/2022 00:39:47 ******/
CREATE DATABASE [CrudOpDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrudOpDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CrudOpDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrudOpDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CrudOpDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrudOpDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrudOpDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CrudOpDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CrudOpDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CrudOpDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CrudOpDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CrudOpDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CrudOpDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CrudOpDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CrudOpDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CrudOpDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CrudOpDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CrudOpDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CrudOpDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CrudOpDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CrudOpDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CrudOpDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CrudOpDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CrudOpDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CrudOpDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CrudOpDB] SET  MULTI_USER 
GO
ALTER DATABASE [CrudOpDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CrudOpDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CrudOpDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CrudOpDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CrudOpDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CrudOpDB', N'ON'
GO
USE [CrudOpDB]
GO
/****** Object:  Table [dbo].[tbl_Contacts]    Script Date: 23/12/2022 00:39:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Contacts](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionID] [int] NOT NULL,
	[fName] [nvarchar](50) NOT NULL,
	[lName] [nvarchar](50) NULL,
	[emailAddr] [nvarchar](100) NOT NULL,
	[Company] [nvarchar](100) NOT NULL,
	[Category] [tinyint] NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[DOB] [datetime] NOT NULL,
	[ModeSlack] [bit] NOT NULL,
	[ModeWhatsapp] [bit] NOT NULL,
	[ModeEmail] [bit] NOT NULL,
	[ModePhone] [bit] NOT NULL,
	[ContactImage] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Profession]    Script Date: 23/12/2022 00:39:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Profession](
	[ProfessionID] [int] IDENTITY(1,1) NOT NULL,
	[Profession] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_Profession] PRIMARY KEY CLUSTERED 
(
	[ProfessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Contacts] ON 

INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (3, 2, N'Sachin', N'Chahal', N'sachin.c@antheminfotech.com', N'Anthem Infotech Pvt. Ltd.', 1, 0, CAST(N'1994-04-05T00:00:00.000' AS DateTime), 1, 1, 0, 1, N'7b1b5a50-bf25-4e3b-b17a-c6dd8066935e.jpg')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (6, 12, N'Poonam', N'Devi', N'devi@p.com', N'ABCABC', 0, 1, CAST(N'2017-12-17T00:00:00.000' AS DateTime), 1, 0, 1, 0, N'')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (18, 16, N'Manoj', N'Kumar', N'rakesh@r.com', N'ABCABC', 0, 0, CAST(N'2000-12-07T00:00:00.000' AS DateTime), 0, 0, 0, 1, N'')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (21, 5, N'Nisha', N'Kumari', N'nisha@n.com', N'XYZ Company', 0, 1, CAST(N'2017-12-15T00:00:00.000' AS DateTime), 1, 1, 1, 0, N'')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (23, 20, N'Dilljeet', N'Rana', N'diljeet@antheminfotech.com', N'Anthem Infotech Pvt Ltd', 1, 0, CAST(N'1989-04-12T00:00:00.000' AS DateTime), 1, 0, 1, 1, N'ce8daa8a-3ab6-47cc-93a3-ab8437a7d7b9.jpeg')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (24, 5, N'Sonia', N'Singh', N'sonia@s.com', N'ABCABC', 0, 1, CAST(N'2017-12-17T00:00:00.000' AS DateTime), 0, 0, 1, 0, N'')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (28, 5, N'Test', N'User', N'test@test.net', N'Net company', 0, 0, CAST(N'2015-06-17T00:00:00.000' AS DateTime), 0, 1, 1, 0, N'')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (29, 5, N'Kajol', N'Kumari', N'kajol@k.com', N'ABCABC', 0, 1, CAST(N'1982-12-02T00:00:00.000' AS DateTime), 0, 0, 1, 0, N'c5894f7c-4932-4184-b8a1-8a517af63c74.png')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (31, 5, N'Seema', N'', N'seema@sms.com', N'sms', 0, 1, CAST(N'2017-12-15T00:00:00.000' AS DateTime), 0, 1, 1, 1, N'')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (32, 2, N'Vikarant', N'Rana', N'vikarant@antheminfotech.com', N'Anthem Infotech Pvt. Ltd.', 1, 0, CAST(N'2000-05-15T00:00:00.000' AS DateTime), 1, 0, 1, 1, N'')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (33, 5, N'Testing', N'Users', N'Testing@t.co.in', N'ABC Company', 0, 1, CAST(N'2000-01-01T00:00:00.000' AS DateTime), 1, 0, 0, 1, N'9e2b7370-a7b1-405d-a6e6-a7f9c925b4d9.jpg')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (36, 5, N'Manoj', N'Kumar', N'Manoj@jj.com', N'XYZ Company', 0, 0, CAST(N'1980-01-01T00:00:00.000' AS DateTime), 0, 0, 0, 1, N'9e36c6be-077d-4fdb-99f8-48e2e2c4abf9.jpg')
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category], [Gender], [DOB], [ModeSlack], [ModeWhatsapp], [ModeEmail], [ModePhone], [ContactImage]) VALUES (38, 5, N'Neha', N'', N'neha123@gmail.com', N'Test Company', 1, 1, CAST(N'1998-01-08T00:00:00.000' AS DateTime), 1, 0, 1, 0, N'b075ee1b-fb9e-4bba-9b84-5360c53b0c90.jpg')
SET IDENTITY_INSERT [dbo].[tbl_Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Profession] ON 

INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (1, N'Manager', N'Manage all role')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (2, N'Jr Developer', N'')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (3, N'Senior Developer', NULL)
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (5, N'Account Staff', N'Maintain  all account details')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (12, N'System Operator', N'Required to test all system are working properly')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (15, N'Cleaning Staff', N'To Clean floor and other Equipment etc')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (16, N'Food makers', N'need to made for all staff')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (20, N'SEO Analyst', N'Search Engine Optimisation Analyst')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (22, N'Bottle Cleaner', N'To clean bottle')
SET IDENTITY_INSERT [dbo].[tbl_Profession] OFF
GO
ALTER TABLE [dbo].[tbl_Contacts]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Contacts_tbl_Profession] FOREIGN KEY([ProfessionID])
REFERENCES [dbo].[tbl_Profession] ([ProfessionID])
GO
ALTER TABLE [dbo].[tbl_Contacts] CHECK CONSTRAINT [FK_tbl_Contacts_tbl_Profession]
GO
/****** Object:  StoredProcedure [dbo].[AddContact]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddContact]
@ProfessionID int
           ,@fName nvarchar(30)
           ,@lName nvarchar(30) = ''
           ,@emailAddr nvarchar(max)
           ,@Company nvarchar(50)
           ,@Category tinyint
		   ,@Gender tinyint
		   ,@DOB datetime
		   ,@ModeSlack bit
		   ,@ModeWhatsapp bit
		   ,@ModeEmail bit
		   ,@ModePhone bit
		   ,@ContactImage nvarchar(max) = ''
as
begin

INSERT INTO [dbo].[tbl_Contacts]
           ([ProfessionID]
           ,[fName]
           ,[lName]
           ,[emailAddr]
           ,[Company]
           ,[Category]
		   ,[Gender]
		   ,[DOB]
		   ,[ModeSlack]
		   ,[ModeWhatsapp]
		   ,[ModeEmail]
		   ,[ModePhone]
		   ,[ContactImage]
		   )
     VALUES(@ProfessionID,@fName,@lName,@emailAddr,@Company,@Category,@Gender,@DOB,@ModeSlack,@ModeWhatsapp,@ModeEmail,@ModePhone,@ContactImage)
end
GO
/****** Object:  StoredProcedure [dbo].[AddNewProfession]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddNewProfession]  
(   
   @Profession nvarchar (50),  
   @Description nvarchar (200)  = ''
)  
as  
begin  
   Insert into tbl_Profession values(@Profession,@Description)  
End 
GO
/****** Object:  StoredProcedure [dbo].[DeleteContact]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[DeleteContact]
@ContactID int
as
Begin
	-- Delete Contact record where ContactID = @ContactID
	DELETE FROM [dbo].[tbl_Contacts] WHERE ContactID = @ContactID
End


GO
/****** Object:  StoredProcedure [dbo].[DeleteProf_Contact]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteProf_Contact]
@ProfessionID int
as
Begin
	Begin Try
		Begin Tran

		-- Delete First from Child table
		DELETE FROM [dbo].[tbl_Contacts] WHERE ProfessionID = @ProfessionID

		-- Finally Delete from parent table
		DELETE FROM [dbo].[tbl_Profession] WHERE ProfessionID = @ProfessionID

		Commit Tran
	End Try
	Begin Catch
		Rollback Tran
	End Catch
End


GO
/****** Object:  StoredProcedure [dbo].[GetAllContact]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllContact]
as
begin
SELECT 
ROW_NUMBER() OVER (order by [ContactID] asc) SerialNo
      ,[ContactID]
	  ,[tbl_Contacts].ProfessionID as ProfID
      ,[Profession]
      ,[fName]
	  ,[lName]
      ,[emailAddr]
      ,[Company]
      ,[Category]
	  ,[Gender]
	  ,[DOB]
	  ,[ModeSlack]
	  ,[ModeWhatsapp]
	  ,[ModeEmail]
	  ,[ModePhone]
	  ,[ContactImage]
  FROM [CrudOpDB].[dbo].[tbl_Contacts]
  join [CrudOpDB].[dbo].[tbl_Profession]
  on [tbl_Contacts].ProfessionID = [tbl_Profession].ProfessionID
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllProfessions]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllProfessions]  
as  
begin  
   select ROW_NUMBER() OVER (order by [ProfessionID] asc) SerialNo, [ProfessionID], [Profession], [Description] from tbl_Profession
End 
GO
/****** Object:  StoredProcedure [dbo].[UpdateContact]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[UpdateContact]
@ContactID int,
@ProfessionID int
           ,@fName nvarchar(30)
           ,@lName nvarchar(30) = ''
           ,@emailAddr nvarchar(100)
           ,@Company nvarchar(50)
           ,@Category tinyint
		   ,@Gender tinyint
		   ,@DOB datetime
		   ,@ModeSlack bit
		   ,@ModeWhatsapp bit
		   ,@ModeEmail bit
		   ,@ModePhone bit
		   ,@ContactImage nvarchar(max) = ''
as
begin

IF @ContactImage = ''   
BEGIN
  set @ContactImage = (select [ContactImage] from [dbo].[tbl_Contacts] where [ContactID] = @ContactID)
END

UPDATE [dbo].[tbl_Contacts]
SET [ProfessionID] = @ProfessionID
      ,[fName] = @fName
      ,[lName] = @lName
      ,[emailAddr] = @emailAddr
      ,[Company] = @Company
      ,[Category] = @Category
	  ,[Gender] = @Gender
	  ,[DOB] = @DOB
	  ,[ModeSlack] = @ModeSlack
	  ,[ModeWhatsapp] = @ModeWhatsapp
	  ,[ModeEmail] = @ModeEmail
	  ,[ModePhone] = @ModePhone
	  ,[ContactImage] = @ContactImage
	  where [ContactID] = @ContactID
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateProfession]    Script Date: 23/12/2022 00:39:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[UpdateProfession]
@ProfessionID int,
@Profession nvarchar(50),
@Description nvarchar(200) = ''
as
begin

UPDATE [dbo].[tbl_Profession]
   SET [Profession] = @Profession
      ,[Description] = @Description
 WHERE ProfessionID = @ProfessionID
end


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-Male,
2-Female,
3-Other' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Contacts', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 - Client,
1 - Vendor
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Contacts'
GO
USE [master]
GO
ALTER DATABASE [CrudOpDB] SET  READ_WRITE 
GO

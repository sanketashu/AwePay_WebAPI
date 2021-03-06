USE [master]
GO
/****** Object:  Database [UserDbAwePay]    Script Date: 4/19/2021 8:09:15 AM ******/
CREATE DATABASE [UserDbAwePay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserDbAwePay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UserDbAwePay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UserDbAwePay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UserDbAwePay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UserDbAwePay] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserDbAwePay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserDbAwePay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserDbAwePay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserDbAwePay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserDbAwePay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserDbAwePay] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserDbAwePay] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserDbAwePay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserDbAwePay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserDbAwePay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserDbAwePay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserDbAwePay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserDbAwePay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserDbAwePay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserDbAwePay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserDbAwePay] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserDbAwePay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserDbAwePay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserDbAwePay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserDbAwePay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserDbAwePay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserDbAwePay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserDbAwePay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserDbAwePay] SET RECOVERY FULL 
GO
ALTER DATABASE [UserDbAwePay] SET  MULTI_USER 
GO
ALTER DATABASE [UserDbAwePay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserDbAwePay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserDbAwePay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserDbAwePay] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserDbAwePay] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UserDbAwePay', N'ON'
GO
ALTER DATABASE [UserDbAwePay] SET QUERY_STORE = OFF
GO
USE [UserDbAwePay]
GO
/****** Object:  Table [dbo].[UserData]    Script Date: 4/19/2021 8:09:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNo] [nvarchar](20) NULL,
	[Age] [int] NOT NULL,
	[CreatedTimestamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UserData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserData] ADD  CONSTRAINT [DF__UserData__Create__276EDEB3]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedTimestamp]
GO
USE [master]
GO
ALTER DATABASE [UserDbAwePay] SET  READ_WRITE 
GO

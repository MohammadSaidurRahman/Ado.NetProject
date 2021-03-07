USE [master]
GO
/****** Object:  Database [Hotel_Managment_System_DB]    Script Date: 10/19/2020 12:40:46 PM ******/
CREATE DATABASE [Hotel_Managment_System_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotel_Managment_System_DB', FILENAME = N'C:\Users\idb_c#\Hotel_Managment_System_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hotel_Managment_System_DB_log', FILENAME = N'C:\Users\idb_c#\Hotel_Managment_System_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotel_Managment_System_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET QUERY_STORE = OFF
GO
USE [Hotel_Managment_System_DB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Hotel_Managment_System_DB]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 10/19/2020 12:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[BookingDate] [varchar](30) NOT NULL,
	[RoomNumber] [varchar](30) NOT NULL,
	[BookingType] [nvarchar](20) NULL,
	[CustomerID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/19/2020 12:40:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](25) NULL,
	[Address] [nvarchar](25) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](20) NULL,
	[Picture] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 
GO
INSERT [dbo].[Booking] ([BookingID], [BookingDate], [RoomNumber], [BookingType], [CustomerID]) VALUES (1, N'05-01-2019', N'R44', N'Instant', 1)
GO
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [Address], [Phone], [Email], [Picture]) VALUES (1, N'Sakil', N'Dhaka', N'01451540879', N'Sakil@gmail', N'C:\Users\idb_c#\Pictures\image8.jpg')
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [Address], [Phone], [Email], [Picture]) VALUES (3, N'Sayed', N'Chittagong', N'056465465', N'sayed@gmail.com', N'C:\Users\idb_c#\Pictures\image8.jpg')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
USE [master]
GO
ALTER DATABASE [Hotel_Managment_System_DB] SET  READ_WRITE 
GO

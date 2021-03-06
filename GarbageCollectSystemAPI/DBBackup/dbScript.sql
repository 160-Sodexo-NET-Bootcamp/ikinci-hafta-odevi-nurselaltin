USE [master]
GO
/****** Object:  Database [GarbageCollectDB]    Script Date: 7.01.2022 21:05:40 ******/
CREATE DATABASE [GarbageCollectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GarbageCollectDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GarbageCollectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GarbageCollectDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\GarbageCollectDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GarbageCollectDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GarbageCollectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GarbageCollectDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GarbageCollectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GarbageCollectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GarbageCollectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GarbageCollectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GarbageCollectDB] SET  MULTI_USER 
GO
ALTER DATABASE [GarbageCollectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GarbageCollectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GarbageCollectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GarbageCollectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GarbageCollectDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GarbageCollectDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GarbageCollectDB] SET QUERY_STORE = OFF
GO
USE [GarbageCollectDB]
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_barkodstr]    Script Date: 7.01.2022 21:05:40 ******/
CREATE TYPE [dbo].[nvarchar_barkodstr] FROM [nvarchar](25) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_belgeno]    Script Date: 7.01.2022 21:05:40 ******/
CREATE TYPE [dbo].[nvarchar_belgeno] FROM [nvarchar](20) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_evrakseri]    Script Date: 7.01.2022 21:05:40 ******/
CREATE TYPE [dbo].[nvarchar_evrakseri] FROM [nvarchar](6) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_maxhesapisimno]    Script Date: 7.01.2022 21:05:40 ******/
CREATE TYPE [dbo].[nvarchar_maxhesapisimno] FROM [nvarchar](90) NULL
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7.01.2022 21:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Container]    Script Date: 7.01.2022 21:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Container](
	[ContainerID] [int] IDENTITY(1,1) NOT NULL,
	[ContainerName] [nvarchar](50) NULL,
	[Latitude] [decimal](10, 6) NOT NULL,
	[Longitude] [decimal](10, 6) NOT NULL,
	[VehicleID] [int] NOT NULL,
 CONSTRAINT [PK_Container] PRIMARY KEY CLUSTERED 
(
	[ContainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 7.01.2022 21:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleName] [nvarchar](50) NULL,
	[VehiclePlate] [nvarchar](50) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Container_VehicleID]    Script Date: 7.01.2022 21:05:40 ******/
CREATE NONCLUSTERED INDEX [IX_Container_VehicleID] ON [dbo].[Container]
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Container]  WITH CHECK ADD  CONSTRAINT [FK_Container_Vehicles_VehicleID] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicles] ([VehicleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Container] CHECK CONSTRAINT [FK_Container_Vehicles_VehicleID]
GO
USE [master]
GO
ALTER DATABASE [GarbageCollectDB] SET  READ_WRITE 
GO

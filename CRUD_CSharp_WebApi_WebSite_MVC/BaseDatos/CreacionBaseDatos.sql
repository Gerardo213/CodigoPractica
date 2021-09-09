USE [master]
GO

/****** Object:  Database [PruebaPractica]    Script Date: 08/09/2021 19:30:43 ******/
CREATE DATABASE [PruebaPractica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaPractica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MOTOR2014\MSSQL\DATA\PruebaPractica.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PruebaPractica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MOTOR2014\MSSQL\DATA\PruebaPractica_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaPractica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PruebaPractica] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PruebaPractica] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PruebaPractica] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PruebaPractica] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PruebaPractica] SET ARITHABORT OFF 
GO

ALTER DATABASE [PruebaPractica] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PruebaPractica] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PruebaPractica] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PruebaPractica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PruebaPractica] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PruebaPractica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PruebaPractica] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PruebaPractica] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PruebaPractica] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PruebaPractica] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PruebaPractica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PruebaPractica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PruebaPractica] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PruebaPractica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PruebaPractica] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PruebaPractica] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PruebaPractica] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PruebaPractica] SET RECOVERY FULL 
GO

ALTER DATABASE [PruebaPractica] SET  MULTI_USER 
GO

ALTER DATABASE [PruebaPractica] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PruebaPractica] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PruebaPractica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PruebaPractica] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [PruebaPractica] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PruebaPractica] SET  READ_WRITE 
GO


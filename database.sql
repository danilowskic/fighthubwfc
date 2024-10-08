USE [master]
GO
/****** Object:  Database [fighterHub]    Script Date: 16.06.2024 19:35:21 ******/
CREATE DATABASE [fighterHub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fighterHub', FILENAME = N'C:\Users\Czarek\fighterHub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'fighterHub_log', FILENAME = N'C:\Users\Czarek\fighterHub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [fighterHub] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fighterHub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [fighterHub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [fighterHub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [fighterHub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [fighterHub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [fighterHub] SET ARITHABORT OFF 
GO
ALTER DATABASE [fighterHub] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [fighterHub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [fighterHub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [fighterHub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [fighterHub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [fighterHub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [fighterHub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [fighterHub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [fighterHub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [fighterHub] SET  ENABLE_BROKER 
GO
ALTER DATABASE [fighterHub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [fighterHub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [fighterHub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [fighterHub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [fighterHub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [fighterHub] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [fighterHub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [fighterHub] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [fighterHub] SET  MULTI_USER 
GO
ALTER DATABASE [fighterHub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [fighterHub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [fighterHub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [fighterHub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [fighterHub] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [fighterHub] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [fighterHub] SET QUERY_STORE = OFF
GO
USE [fighterHub]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16.06.2024 19:35:21 ******/
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
/****** Object:  Table [dbo].[ContactDatas]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDatas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ContactDatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactDatasPhoneNumbers]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDatasPhoneNumbers](
	[ContactDatasId] [int] NOT NULL,
	[PhoneNumbersId] [int] NOT NULL,
 CONSTRAINT [PK_ContactDatasPhoneNumbers] PRIMARY KEY CLUSTERED 
(
	[ContactDatasId] ASC,
	[PhoneNumbersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[BuildingNumber] [int] NOT NULL,
	[ApartmentNumber] [int] NULL,
	[City] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](6) NOT NULL,
	[RegistrationEndDate] [date] NOT NULL,
	[MoneyPrize] [float] NOT NULL,
	[ReasonOfCancel] [nvarchar](512) NOT NULL,
	[AvailablePlaces] [int] NULL,
	[TicketPrice] [float] NULL,
	[AudienceType] [varchar](7) NOT NULL,
	[OrganizerId] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FanInvolvements]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FanInvolvements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [nvarchar](50) NOT NULL,
	[TicketBuyDate] [datetime2](7) NOT NULL,
	[FanId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
 CONSTRAINT [PK_FanInvolvements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FighterInvolvements]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FighterInvolvements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberID] [nvarchar](50) NOT NULL,
	[RegistrationDate] [datetime2](7) NOT NULL,
	[Points] [int] NULL,
	[EarnedPlace] [int] NULL,
	[Status] [varchar](8) NOT NULL,
	[FighterId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
 CONSTRAINT [PK_FighterInvolvements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fighters]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fighters](
	[Id] [int] NOT NULL,
	[Gender] [varchar](6) NOT NULL,
	[Weight] [float] NOT NULL,
	[Height] [float] NOT NULL,
 CONSTRAINT [PK_Fighters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinancialRaports]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinancialRaports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberId] [nvarchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Income] [float] NOT NULL,
	[Expenditure] [float] NOT NULL,
 CONSTRAINT [PK_FinancialRaports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[BuildingNumber] [int] NOT NULL,
	[ApartmentNumber] [int] NULL,
	[City] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](6) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[LessonSubject] [nvarchar](256) NOT NULL,
	[DurationInHours] [int] NOT NULL,
	[TrainingBootcampId] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MartialArts]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MartialArts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[CountryOfOrigin] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MartialArts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_MartialArts_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalCertificates]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalCertificates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberId] [nvarchar](50) NOT NULL,
	[IsAccepted] [bit] NOT NULL,
	[Description] [nvarchar](1024) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[FighterInvolvementId] [int] NOT NULL,
	[WorkerFanId] [int] NOT NULL,
	[FighterId] [int] NOT NULL,
 CONSTRAINT [PK_MedicalCertificates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Names]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Names](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Names] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NameUser]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NameUser](
	[NamesId] [int] NOT NULL,
	[UsersId] [int] NOT NULL,
 CONSTRAINT [PK_NameUser] PRIMARY KEY CLUSTERED 
(
	[NamesId] ASC,
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhoneNumbers]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneNumbers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[phoneNumber] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shows]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shows](
	[Id] [int] NOT NULL,
	[Certificate] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Shows] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkillLevelOfMartialArts]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillLevelOfMartialArts](
	[FighterId] [int] NOT NULL,
	[MartialArtId] [int] NOT NULL,
	[Belt] [varchar](11) NOT NULL,
 CONSTRAINT [PK_SkillLevelOfMartialArts] PRIMARY KEY CLUSTERED 
(
	[FighterId] ASC,
	[MartialArtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournaments]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournaments](
	[Id] [int] NOT NULL,
	[Belt] [varchar](11) NOT NULL,
 CONSTRAINT [PK_Tournaments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingBootcamps]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingBootcamps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Belt] [varchar](11) NOT NULL,
	[MartialArtName] [nvarchar](50) NOT NULL,
	[MasterId] [int] NOT NULL,
	[OrganizerId] [int] NOT NULL,
 CONSTRAINT [PK_TrainingBootcamps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingBootcampsStudents]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingBootcampsStudents](
	[StudentsId] [int] NOT NULL,
	[TrainingBootcampsAsStudentId] [int] NOT NULL,
 CONSTRAINT [PK_TrainingBootcampsStudents] PRIMARY KEY CLUSTERED 
(
	[StudentsId] ASC,
	[TrainingBootcampsAsStudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[PESEL] [nvarchar](11) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[BuildingNumber] [int] NOT NULL,
	[ApartmentNumber] [int] NULL,
	[City] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](6) NOT NULL,
	[ContactDataId] [int] NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[EncryptedPassword] [nvarchar](512) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkerFans]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerFans](
	[Id] [int] NOT NULL,
	[DateOfHirement] [date] NOT NULL,
	[Income] [float] NOT NULL,
	[Budget] [float] NOT NULL,
	[DoctorLicenceID] [nvarchar](50) NOT NULL,
	[FavouriteMartialArtName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkerFans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkerFanWorkerFanTypes]    Script Date: 16.06.2024 19:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkerFanWorkerFanTypes](
	[WorkerFanId] [int] NOT NULL,
	[WorkerFanType] [varchar](5) NOT NULL,
 CONSTRAINT [PK_WorkerFanWorkerFanTypes] PRIMARY KEY CLUSTERED 
(
	[WorkerFanId] ASC,
	[WorkerFanType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ContactDatas_Email]    Script Date: 16.06.2024 19:35:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ContactDatas_Email] ON [dbo].[ContactDatas]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactDatasPhoneNumbers_PhoneNumbersId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_ContactDatasPhoneNumbers_PhoneNumbersId] ON [dbo].[ContactDatasPhoneNumbers]
(
	[PhoneNumbersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Events_OrganizerId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_Events_OrganizerId] ON [dbo].[Events]
(
	[OrganizerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FanInvolvements_EventId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_FanInvolvements_EventId] ON [dbo].[FanInvolvements]
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FanInvolvements_FanId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_FanInvolvements_FanId] ON [dbo].[FanInvolvements]
(
	[FanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FighterInvolvements_EventId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_FighterInvolvements_EventId] ON [dbo].[FighterInvolvements]
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FighterInvolvements_FighterId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_FighterInvolvements_FighterId] ON [dbo].[FighterInvolvements]
(
	[FighterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lessons_TrainingBootcampId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_Lessons_TrainingBootcampId] ON [dbo].[Lessons]
(
	[TrainingBootcampId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedicalCertificates_FighterId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_MedicalCertificates_FighterId] ON [dbo].[MedicalCertificates]
(
	[FighterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedicalCertificates_FighterInvolvementId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_MedicalCertificates_FighterInvolvementId] ON [dbo].[MedicalCertificates]
(
	[FighterInvolvementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MedicalCertificates_WorkerFanId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_MedicalCertificates_WorkerFanId] ON [dbo].[MedicalCertificates]
(
	[WorkerFanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NameUser_UsersId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_NameUser_UsersId] ON [dbo].[NameUser]
(
	[UsersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SkillLevelOfMartialArts_FighterId_MartialArtId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SkillLevelOfMartialArts_FighterId_MartialArtId] ON [dbo].[SkillLevelOfMartialArts]
(
	[FighterId] ASC,
	[MartialArtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SkillLevelOfMartialArts_MartialArtId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_SkillLevelOfMartialArts_MartialArtId] ON [dbo].[SkillLevelOfMartialArts]
(
	[MartialArtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TrainingBootcamps_MartialArtName]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_TrainingBootcamps_MartialArtName] ON [dbo].[TrainingBootcamps]
(
	[MartialArtName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrainingBootcamps_MasterId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_TrainingBootcamps_MasterId] ON [dbo].[TrainingBootcamps]
(
	[MasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrainingBootcamps_OrganizerId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_TrainingBootcamps_OrganizerId] ON [dbo].[TrainingBootcamps]
(
	[OrganizerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrainingBootcampsStudents_TrainingBootcampsAsStudentId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_TrainingBootcampsStudents_TrainingBootcampsAsStudentId] ON [dbo].[TrainingBootcampsStudents]
(
	[TrainingBootcampsAsStudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_ContactDataId]    Script Date: 16.06.2024 19:35:21 ******/
CREATE NONCLUSTERED INDEX [IX_Users_ContactDataId] ON [dbo].[Users]
(
	[ContactDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_PESEL]    Script Date: 16.06.2024 19:35:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_PESEL] ON [dbo].[Users]
(
	[PESEL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FighterInvolvements] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[FighterInvolvements] ADD  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[FighterInvolvements] ADD  DEFAULT ((0)) FOR [EarnedPlace]
GO
ALTER TABLE [dbo].[ContactDatasPhoneNumbers]  WITH CHECK ADD  CONSTRAINT [FK_ContactDatasPhoneNumbers_ContactDatas_ContactDatasId] FOREIGN KEY([ContactDatasId])
REFERENCES [dbo].[ContactDatas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactDatasPhoneNumbers] CHECK CONSTRAINT [FK_ContactDatasPhoneNumbers_ContactDatas_ContactDatasId]
GO
ALTER TABLE [dbo].[ContactDatasPhoneNumbers]  WITH CHECK ADD  CONSTRAINT [FK_ContactDatasPhoneNumbers_PhoneNumbers_PhoneNumbersId] FOREIGN KEY([PhoneNumbersId])
REFERENCES [dbo].[PhoneNumbers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactDatasPhoneNumbers] CHECK CONSTRAINT [FK_ContactDatasPhoneNumbers_PhoneNumbers_PhoneNumbersId]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_WorkerFans_OrganizerId] FOREIGN KEY([OrganizerId])
REFERENCES [dbo].[WorkerFans] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_WorkerFans_OrganizerId]
GO
ALTER TABLE [dbo].[FanInvolvements]  WITH CHECK ADD  CONSTRAINT [FK_FanInvolvements_Events_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FanInvolvements] CHECK CONSTRAINT [FK_FanInvolvements_Events_EventId]
GO
ALTER TABLE [dbo].[FanInvolvements]  WITH CHECK ADD  CONSTRAINT [FK_FanInvolvements_WorkerFans_FanId] FOREIGN KEY([FanId])
REFERENCES [dbo].[WorkerFans] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FanInvolvements] CHECK CONSTRAINT [FK_FanInvolvements_WorkerFans_FanId]
GO
ALTER TABLE [dbo].[FighterInvolvements]  WITH CHECK ADD  CONSTRAINT [FK_FighterInvolvements_Events_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[FighterInvolvements] CHECK CONSTRAINT [FK_FighterInvolvements_Events_EventId]
GO
ALTER TABLE [dbo].[FighterInvolvements]  WITH CHECK ADD  CONSTRAINT [FK_FighterInvolvements_Fighters_FighterId] FOREIGN KEY([FighterId])
REFERENCES [dbo].[Fighters] ([Id])
GO
ALTER TABLE [dbo].[FighterInvolvements] CHECK CONSTRAINT [FK_FighterInvolvements_Fighters_FighterId]
GO
ALTER TABLE [dbo].[Fighters]  WITH CHECK ADD  CONSTRAINT [FK_Fighters_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fighters] CHECK CONSTRAINT [FK_Fighters_Users_Id]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_TrainingBootcamps_TrainingBootcampId] FOREIGN KEY([TrainingBootcampId])
REFERENCES [dbo].[TrainingBootcamps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_TrainingBootcamps_TrainingBootcampId]
GO
ALTER TABLE [dbo].[MedicalCertificates]  WITH CHECK ADD  CONSTRAINT [FK_MedicalCertificates_FighterInvolvements_FighterInvolvementId] FOREIGN KEY([FighterInvolvementId])
REFERENCES [dbo].[FighterInvolvements] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalCertificates] CHECK CONSTRAINT [FK_MedicalCertificates_FighterInvolvements_FighterInvolvementId]
GO
ALTER TABLE [dbo].[MedicalCertificates]  WITH CHECK ADD  CONSTRAINT [FK_MedicalCertificates_Fighters_FighterId] FOREIGN KEY([FighterId])
REFERENCES [dbo].[Fighters] ([Id])
GO
ALTER TABLE [dbo].[MedicalCertificates] CHECK CONSTRAINT [FK_MedicalCertificates_Fighters_FighterId]
GO
ALTER TABLE [dbo].[MedicalCertificates]  WITH CHECK ADD  CONSTRAINT [FK_MedicalCertificates_WorkerFans_WorkerFanId] FOREIGN KEY([WorkerFanId])
REFERENCES [dbo].[WorkerFans] ([Id])
GO
ALTER TABLE [dbo].[MedicalCertificates] CHECK CONSTRAINT [FK_MedicalCertificates_WorkerFans_WorkerFanId]
GO
ALTER TABLE [dbo].[NameUser]  WITH CHECK ADD  CONSTRAINT [FK_NameUser_Names_NamesId] FOREIGN KEY([NamesId])
REFERENCES [dbo].[Names] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NameUser] CHECK CONSTRAINT [FK_NameUser_Names_NamesId]
GO
ALTER TABLE [dbo].[NameUser]  WITH CHECK ADD  CONSTRAINT [FK_NameUser_Users_UsersId] FOREIGN KEY([UsersId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NameUser] CHECK CONSTRAINT [FK_NameUser_Users_UsersId]
GO
ALTER TABLE [dbo].[Shows]  WITH CHECK ADD  CONSTRAINT [FK_Shows_Events_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Events] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shows] CHECK CONSTRAINT [FK_Shows_Events_Id]
GO
ALTER TABLE [dbo].[SkillLevelOfMartialArts]  WITH CHECK ADD  CONSTRAINT [FK_SkillLevelOfMartialArts_Fighters_FighterId] FOREIGN KEY([FighterId])
REFERENCES [dbo].[Fighters] ([Id])
GO
ALTER TABLE [dbo].[SkillLevelOfMartialArts] CHECK CONSTRAINT [FK_SkillLevelOfMartialArts_Fighters_FighterId]
GO
ALTER TABLE [dbo].[SkillLevelOfMartialArts]  WITH CHECK ADD  CONSTRAINT [FK_SkillLevelOfMartialArts_MartialArts_MartialArtId] FOREIGN KEY([MartialArtId])
REFERENCES [dbo].[MartialArts] ([Id])
GO
ALTER TABLE [dbo].[SkillLevelOfMartialArts] CHECK CONSTRAINT [FK_SkillLevelOfMartialArts_MartialArts_MartialArtId]
GO
ALTER TABLE [dbo].[Tournaments]  WITH CHECK ADD  CONSTRAINT [FK_Tournaments_Events_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Events] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tournaments] CHECK CONSTRAINT [FK_Tournaments_Events_Id]
GO
ALTER TABLE [dbo].[TrainingBootcamps]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBootcamps_Fighters_MasterId] FOREIGN KEY([MasterId])
REFERENCES [dbo].[Fighters] ([Id])
GO
ALTER TABLE [dbo].[TrainingBootcamps] CHECK CONSTRAINT [FK_TrainingBootcamps_Fighters_MasterId]
GO
ALTER TABLE [dbo].[TrainingBootcamps]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBootcamps_MartialArts_MartialArtName] FOREIGN KEY([MartialArtName])
REFERENCES [dbo].[MartialArts] ([Name])
GO
ALTER TABLE [dbo].[TrainingBootcamps] CHECK CONSTRAINT [FK_TrainingBootcamps_MartialArts_MartialArtName]
GO
ALTER TABLE [dbo].[TrainingBootcamps]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBootcamps_WorkerFans_OrganizerId] FOREIGN KEY([OrganizerId])
REFERENCES [dbo].[WorkerFans] ([Id])
GO
ALTER TABLE [dbo].[TrainingBootcamps] CHECK CONSTRAINT [FK_TrainingBootcamps_WorkerFans_OrganizerId]
GO
ALTER TABLE [dbo].[TrainingBootcampsStudents]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBootcampsStudents_Fighters_StudentsId] FOREIGN KEY([StudentsId])
REFERENCES [dbo].[Fighters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrainingBootcampsStudents] CHECK CONSTRAINT [FK_TrainingBootcampsStudents_Fighters_StudentsId]
GO
ALTER TABLE [dbo].[TrainingBootcampsStudents]  WITH CHECK ADD  CONSTRAINT [FK_TrainingBootcampsStudents_TrainingBootcamps_TrainingBootcampsAsStudentId] FOREIGN KEY([TrainingBootcampsAsStudentId])
REFERENCES [dbo].[TrainingBootcamps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrainingBootcampsStudents] CHECK CONSTRAINT [FK_TrainingBootcampsStudents_TrainingBootcamps_TrainingBootcampsAsStudentId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_ContactDatas_ContactDataId] FOREIGN KEY([ContactDataId])
REFERENCES [dbo].[ContactDatas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_ContactDatas_ContactDataId]
GO
ALTER TABLE [dbo].[WorkerFans]  WITH CHECK ADD  CONSTRAINT [FK_WorkerFans_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkerFans] CHECK CONSTRAINT [FK_WorkerFans_Users_Id]
GO
ALTER TABLE [dbo].[WorkerFanWorkerFanTypes]  WITH CHECK ADD  CONSTRAINT [FK_WorkerFanWorkerFanTypes_WorkerFans_WorkerFanId] FOREIGN KEY([WorkerFanId])
REFERENCES [dbo].[WorkerFans] ([Id])
GO
ALTER TABLE [dbo].[WorkerFanWorkerFanTypes] CHECK CONSTRAINT [FK_WorkerFanWorkerFanTypes_WorkerFans_WorkerFanId]
GO
USE [master]
GO
ALTER DATABASE [fighterHub] SET  READ_WRITE 
GO

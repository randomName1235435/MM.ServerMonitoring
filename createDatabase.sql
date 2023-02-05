USE [master]
GO
/****** Object:  Database [MM.ServerMonitoring.Database]    ******/
CREATE DATABASE [MM.ServerMonitoring.Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MM.ServerMonitoring.Database', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MM.ServerMonitoring.Database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MM.ServerMonitoring.Database_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MM.ServerMonitoring.Database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MM.ServerMonitoring.Database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET ARITHABORT OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET  MULTI_USER 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET QUERY_STORE = OFF
GO
USE [MM.ServerMonitoring.Database]
GO
/****** Object:  User [reader]    ******/
CREATE USER [reader] FOR LOGIN [reader] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [reader]
GO
/****** Object:  Table [dbo].[Action]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action](
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [varchar](100) NOT NULL,
    [Description] [varchar](1000) NOT NULL,
    CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Monitor]    ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Monitor](
    [Id] [uniqueidentifier] NOT NULL,
    [ActionId] [uniqueidentifier] NOT NULL,
    [TargetId] [uniqueidentifier] NOT NULL,
    [Name] [varchar](100) NOT NULL,
    [Description] [varchar](1000) NOT NULL,
    CONSTRAINT [PK_Monitor] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[MonitorActionExecution]    ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[MonitorActionExecution](
    [Id] [uniqueidentifier] NOT NULL,
    [ActionId] [uniqueidentifier] NOT NULL,
    [MonitorId] [uniqueidentifier] NOT NULL,
    [TargetId] [uniqueidentifier] NOT NULL,
    [Success] [bit] NOT NULL,
    [Message] [nvarchar](1000) NOT NULL,
    [Start] [datetime] NOT NULL,
    [Finish] [datetime] NOT NULL,
    CONSTRAINT [PK_MonitorActionExecution] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Parameter]    ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Parameter](
    [Id] [uniqueidentifier] NOT NULL,
    [TargetId] [uniqueidentifier] NOT NULL,
    [ParameterTypId] [uniqueidentifier] NOT NULL,
    [Value] [varchar](1000) NOT NULL,
    CONSTRAINT [PK_Parameter] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[ParameterTyp]    ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[ParameterTyp](
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [varchar](100) NOT NULL,
    [Description] [varchar](1000) NOT NULL,
    CONSTRAINT [PK_ParameterTyp] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Target]    ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Target](
    [Id] [uniqueidentifier] NOT NULL,
    [TargetTypId] [uniqueidentifier] NOT NULL,
    [Name] [varchar](100) NOT NULL,
    CONSTRAINT [PK_Target] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[TargetTyp]    ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[TargetTyp](
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [varchar](100) NOT NULL,
    [Description] [varchar](1000) NOT NULL,
    CONSTRAINT [PK_TargetTyp] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
ALTER TABLE [dbo].[Monitor]  WITH CHECK ADD  CONSTRAINT [FK_Monitor_Action] FOREIGN KEY([ActionId])
    REFERENCES [dbo].[Action] ([Id])
    GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_Action]
    GO
ALTER TABLE [dbo].[Monitor]  WITH CHECK ADD  CONSTRAINT [FK_Monitor_Target] FOREIGN KEY([TargetId])
    REFERENCES [dbo].[Target] ([Id])
    GO
ALTER TABLE [dbo].[Monitor] CHECK CONSTRAINT [FK_Monitor_Target]
    GO
ALTER TABLE [dbo].[MonitorActionExecution]  WITH CHECK ADD  CONSTRAINT [FK_MonitorActionExecution_Action] FOREIGN KEY([ActionId])
    REFERENCES [dbo].[Action] ([Id])
    GO
ALTER TABLE [dbo].[MonitorActionExecution] CHECK CONSTRAINT [FK_MonitorActionExecution_Action]
    GO
ALTER TABLE [dbo].[MonitorActionExecution]  WITH CHECK ADD  CONSTRAINT [FK_MonitorActionExecution_Monitor] FOREIGN KEY([MonitorId])
    REFERENCES [dbo].[Monitor] ([Id])
    GO
ALTER TABLE [dbo].[MonitorActionExecution] CHECK CONSTRAINT [FK_MonitorActionExecution_Monitor]
    GO
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_ParameterTyp] FOREIGN KEY([ParameterTypId])
    REFERENCES [dbo].[ParameterTyp] ([Id])
    GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_ParameterTyp]
    GO
ALTER TABLE [dbo].[Parameter]  WITH CHECK ADD  CONSTRAINT [FK_Parameter_Target] FOREIGN KEY([TargetId])
    REFERENCES [dbo].[Target] ([Id])
    GO
ALTER TABLE [dbo].[Parameter] CHECK CONSTRAINT [FK_Parameter_Target]
    GO
ALTER TABLE [dbo].[Target]  WITH CHECK ADD  CONSTRAINT [FK_Target_Target] FOREIGN KEY([TargetTypId])
    REFERENCES [dbo].[TargetTyp] ([Id])
    GO
ALTER TABLE [dbo].[Target] CHECK CONSTRAINT [FK_Target_Target]
    GO
    USE [master]
    GO
ALTER DATABASE [MM.ServerMonitoring.Database] SET  READ_WRITE 
GO

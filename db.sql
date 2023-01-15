USE [master]
GO
/****** Object:  Database [CHOM.Data]    Script Date: 1/15/2023 2:41:05 AM ******/
CREATE DATABASE [CHOM.Data]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CHOM.Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER001\MSSQL\DATA\CHOM.Data.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CHOM.Data_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER001\MSSQL\DATA\CHOM.Data_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CHOM.Data] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CHOM.Data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CHOM.Data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CHOM.Data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CHOM.Data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CHOM.Data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CHOM.Data] SET ARITHABORT OFF 
GO
ALTER DATABASE [CHOM.Data] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CHOM.Data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CHOM.Data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CHOM.Data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CHOM.Data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CHOM.Data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CHOM.Data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CHOM.Data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CHOM.Data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CHOM.Data] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CHOM.Data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CHOM.Data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CHOM.Data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CHOM.Data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CHOM.Data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CHOM.Data] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CHOM.Data] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CHOM.Data] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CHOM.Data] SET  MULTI_USER 
GO
ALTER DATABASE [CHOM.Data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CHOM.Data] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CHOM.Data] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CHOM.Data] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CHOM.Data] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CHOM.Data] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CHOM.Data] SET QUERY_STORE = OFF
GO
USE [CHOM.Data]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/15/2023 2:41:05 AM ******/
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
/****** Object:  Table [dbo].[About]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](100) NOT NULL,
	[NoiDung] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoSuuTam]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoSuuTam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](100) NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[IDMucLuc] [int] NOT NULL,
 CONSTRAINT [PK_BoSuuTam] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoiNgus]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoiNgus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NOT NULL,
	[HinhAnh] [nvarchar](max) NOT NULL,
	[CongViec] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DoiNgus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DuAn]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuAn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](100) NOT NULL,
	[HinhGT] [nvarchar](max) NOT NULL,
	[NoiDung] [ntext] NULL,
	[Nam] [int] NOT NULL,
	[IDMucLuc] [int] NOT NULL,
 CONSTRAINT [PK_DuAn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HinhAnhs]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnhs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[TieuDe] [nvarchar](50) NULL,
	[IDDuAn] [int] NOT NULL,
 CONSTRAINT [PK_HinhAnhs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[PhuongThuc] [nvarchar](50) NOT NULL,
	[ThuTu] [int] NOT NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MucLuc]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MucLuc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[ThuTu] [int] NOT NULL,
	[Link] [nvarchar](max) NULL,
	[IDParent] [int] NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[Nam] [int] NULL,
 CONSTRAINT [PK_MucLuc] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/15/2023 2:41:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[UserName] [varchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230113165712_DbInitial', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230113173425_update-1', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230114102331_update-2', N'6.0.11')
GO
SET IDENTITY_INSERT [dbo].[About] ON 

INSERT [dbo].[About] ([ID], [TuaDe], [NoiDung]) VALUES (2, N'Creative Digital Studio', N'We are a digital experience design studio. We help connect brands with customers and drive growth by designing elegant, useful and engaging experiences.')
SET IDENTITY_INSERT [dbo].[About] OFF
GO
SET IDENTITY_INSERT [dbo].[BoSuuTam] ON 

INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (1, N'goldman-cover.jpg', CAST(N'2023-01-14T21:06:19.2607226' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (2, N'opulence01.jpg', CAST(N'2023-01-14T21:06:27.1054123' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (3, N'pulse02.jpg', CAST(N'2023-01-14T21:06:34.6568581' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (4, N'pulse05.jpg', CAST(N'2023-01-14T21:06:41.0070880' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (5, N'pulse06.jpg', CAST(N'2023-01-14T21:06:49.5770339' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (6, N'shirt03.jpg', CAST(N'2023-01-14T21:06:57.2832629' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (7, N'soundblaster04.jpg', CAST(N'2023-01-14T21:07:09.9532731' AS DateTime2), 4)
SET IDENTITY_INSERT [dbo].[BoSuuTam] OFF
GO
SET IDENTITY_INSERT [dbo].[DoiNgus] ON 

INSERT [dbo].[DoiNgus] ([ID], [Ten], [HinhAnh], [CongViec]) VALUES (2, N'Nhân viên a ', N'team1.jpg', N'Dev developer')
INSERT [dbo].[DoiNgus] ([ID], [Ten], [HinhAnh], [CongViec]) VALUES (3, N'Nhân viên B', N'team2.jpg', N'Dev developer')
INSERT [dbo].[DoiNgus] ([ID], [Ten], [HinhAnh], [CongViec]) VALUES (4, N'Nhân viên C', N'team3.jpg', N'Dev developer')
INSERT [dbo].[DoiNgus] ([ID], [Ten], [HinhAnh], [CongViec]) VALUES (5, N'Nhân viên D', N'team4.jpg', N'Dev developer')
SET IDENTITY_INSERT [dbo].[DoiNgus] OFF
GO
SET IDENTITY_INSERT [dbo].[DuAn] ON 

INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (9, N'Dự án e', N'cq2.jpg', NULL, 2022, 2)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (10, N'Dự án f', N'cq3.jpg', NULL, 2022, 2)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (11, N'Dự án G', N'cq5.jpg', NULL, 2022, 2)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (12, N'Dự án g', N'interior01.jpg', NULL, 2022, 3)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (13, N'Dự án h', N'interior03.jpg', NULL, 2022, 3)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (14, N'Dự án k', N'interior05.jpg', NULL, 2022, 3)
SET IDENTITY_INSERT [dbo].[DuAn] OFF
GO
SET IDENTITY_INSERT [dbo].[HinhAnhs] ON 

INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (25, N'cq1.jpg', NULL, 9)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (26, N'cq2.jpg', NULL, 9)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (27, N'cq3.jpg', NULL, 10)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (28, N'cq4.jpg', NULL, 10)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (29, N'cq5.jpg', NULL, 11)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (30, N'cq6.jpg', NULL, 11)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (31, N'06hero.jpg', NULL, 9)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (32, N'interior01.jpg', NULL, 12)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (33, N'interior02.jpg', NULL, 12)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (34, N'interior03.jpg', NULL, 13)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (35, N'interior04.jpg', NULL, 13)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (36, N'interior05.jpg', NULL, 14)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (37, N'interior06.jpg', NULL, 14)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (38, N'interior07.jpg', NULL, 14)
SET IDENTITY_INSERT [dbo].[HinhAnhs] OFF
GO
SET IDENTITY_INSERT [dbo].[LienHe] ON 

INSERT [dbo].[LienHe] ([ID], [Ten], [PhuongThuc], [ThuTu], [Link]) VALUES (2, N'admin@gmail.com', N'Email', 1, N'/abcxyz')
INSERT [dbo].[LienHe] ([ID], [Ten], [PhuongThuc], [ThuTu], [Link]) VALUES (3, N'28 Thảo Điền, Q2, HCM', N'Address', 2, NULL)
INSERT [dbo].[LienHe] ([ID], [Ten], [PhuongThuc], [ThuTu], [Link]) VALUES (4, N'093234213', N'Phone', 3, NULL)
SET IDENTITY_INSERT [dbo].[LienHe] OFF
GO
SET IDENTITY_INSERT [dbo].[MucLuc] ON 

INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (1, N'Project', 1, NULL, 0, NULL, NULL)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (2, N'Landscape', 1, N'/Project', 1, N'canhquanHome.jpg', 2022)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (3, N'Interior', 2, N'/Project', 1, N'noithatHome.jpg', 2022)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (4, N'Gallery', 2, N'/Gallery', 0, NULL, NULL)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (5, N'Contact', 3, N'/Contact', 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MucLuc] OFF
GO
INSERT [dbo].[TaiKhoan] ([UserName], [Password]) VALUES (N'admin', N'admin@123')
GO
/****** Object:  Index [IX_BoSuuTam_IDMucLuc]    Script Date: 1/15/2023 2:41:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_BoSuuTam_IDMucLuc] ON [dbo].[BoSuuTam]
(
	[IDMucLuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DuAn_IDMucLuc]    Script Date: 1/15/2023 2:41:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_DuAn_IDMucLuc] ON [dbo].[DuAn]
(
	[IDMucLuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HinhAnhs_IDDuAn]    Script Date: 1/15/2023 2:41:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_HinhAnhs_IDDuAn] ON [dbo].[HinhAnhs]
(
	[IDDuAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BoSuuTam]  WITH CHECK ADD  CONSTRAINT [FK_BoSuuTam_MucLuc_IDMucLuc] FOREIGN KEY([IDMucLuc])
REFERENCES [dbo].[MucLuc] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BoSuuTam] CHECK CONSTRAINT [FK_BoSuuTam_MucLuc_IDMucLuc]
GO
ALTER TABLE [dbo].[DuAn]  WITH CHECK ADD  CONSTRAINT [FK_DuAn_MucLuc_IDMucLuc] FOREIGN KEY([IDMucLuc])
REFERENCES [dbo].[MucLuc] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DuAn] CHECK CONSTRAINT [FK_DuAn_MucLuc_IDMucLuc]
GO
ALTER TABLE [dbo].[HinhAnhs]  WITH CHECK ADD  CONSTRAINT [FK_HinhAnhs_DuAn_IDDuAn] FOREIGN KEY([IDDuAn])
REFERENCES [dbo].[DuAn] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HinhAnhs] CHECK CONSTRAINT [FK_HinhAnhs_DuAn_IDDuAn]
GO
USE [master]
GO
ALTER DATABASE [CHOM.Data] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [mic67664_chom]    Script Date: 2/2/2023 8:50:35 PM ******/
CREATE DATABASE [mic67664_chom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CHOM.Data', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\mic67664_chom_8ac966f13b7649bb9b0f98a1c9489e0a.mdf' , SIZE = 8192KB , MAXSIZE = 1048576KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CHOM.Data_log', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL15.MSSQLSERVER2019\MSSQL\DATA\mic67664_chom_bdda3ed49be84741be9949cb76b29cda.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [mic67664_chom] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mic67664_chom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mic67664_chom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mic67664_chom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mic67664_chom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mic67664_chom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mic67664_chom] SET ARITHABORT OFF 
GO
ALTER DATABASE [mic67664_chom] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [mic67664_chom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mic67664_chom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mic67664_chom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mic67664_chom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mic67664_chom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mic67664_chom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mic67664_chom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mic67664_chom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mic67664_chom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mic67664_chom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mic67664_chom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mic67664_chom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mic67664_chom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mic67664_chom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mic67664_chom] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [mic67664_chom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mic67664_chom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [mic67664_chom] SET  MULTI_USER 
GO
ALTER DATABASE [mic67664_chom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mic67664_chom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mic67664_chom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mic67664_chom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mic67664_chom] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mic67664_chom] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [mic67664_chom] SET QUERY_STORE = OFF
GO
USE [mic67664_chom]
GO
/****** Object:  User [mic67664_chom]    Script Date: 2/2/2023 8:50:36 PM ******/
CREATE USER [mic67664_chom] FOR LOGIN [mic67664_chom] WITH DEFAULT_SCHEMA=[mic67664_chom]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [mic67664_chom]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [mic67664_chom]
GO
ALTER ROLE [db_datareader] ADD MEMBER [mic67664_chom]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [mic67664_chom]
GO
/****** Object:  Schema [mic67664_chom]    Script Date: 2/2/2023 8:50:36 PM ******/
CREATE SCHEMA [mic67664_chom]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/2/2023 8:50:36 PM ******/
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
/****** Object:  Table [dbo].[BoSuuTam]    Script Date: 2/2/2023 8:50:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoSuuTam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[IDMucLuc] [int] NOT NULL,
 CONSTRAINT [PK_BoSuuTam] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 2/2/2023 8:50:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[GioiThieu] [ntext] NOT NULL,
	[CotMoc] [ntext] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DuAn]    Script Date: 2/2/2023 8:50:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuAn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TuaDe] [nvarchar](50) NOT NULL,
	[HinhGT] [nvarchar](max) NULL,
	[NoiDung] [ntext] NULL,
	[Nam] [int] NOT NULL,
	[IDMucLuc] [int] NOT NULL,
 CONSTRAINT [PK_DuAn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HinhAnhs]    Script Date: 2/2/2023 8:50:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnhs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[TieuDe] [nvarchar](50) NULL,
	[IDDuAn] [int] NOT NULL,
 CONSTRAINT [PK_HinhAnhs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LienHe]    Script Date: 2/2/2023 8:50:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LienHe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[PhuongThuc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LienHe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MucLuc]    Script Date: 2/2/2023 8:50:36 PM ******/
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
/****** Object:  Table [dbo].[PhanHois]    Script Date: 2/2/2023 8:50:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHois](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](20) NOT NULL,
	[YeuCau] [nvarchar](100) NOT NULL,
	[NoiDung] [ntext] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PhanHois] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 2/2/2023 8:50:36 PM ******/
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
/****** Object:  Table [dbo].[Videos]    Script Date: 2/2/2023 8:50:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230113165712_DbInitial', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230113173425_update-1', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230114102331_update-2', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230119074826_update-3', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230119090224_update-4', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230119114341_update-5', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230119144230_update-6', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230119150030_update-7', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230127095737_update-8', N'6.0.11')
GO
SET IDENTITY_INSERT [dbo].[BoSuuTam] ON 

INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (9, N'pulse03.jpg', CAST(N'2023-01-19T18:20:26.4709851' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (11, N'01hero.jpg', CAST(N'2023-01-20T01:07:04.6585929' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (12, N'shirt04.jpg', CAST(N'2023-01-20T01:07:16.4625168' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (13, N'soundblaster01.jpg', CAST(N'2023-01-20T01:08:00.3278135' AS DateTime2), 4)
INSERT [dbo].[BoSuuTam] ([ID], [HinhAnh], [NgayTao], [IDMucLuc]) VALUES (16, N'pulse06.jpg', CAST(N'2023-01-20T01:09:58.0000000' AS DateTime2), 4)
SET IDENTITY_INSERT [dbo].[BoSuuTam] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ID], [HinhAnh], [Ten], [GioiThieu], [CotMoc]) VALUES (1, N'lienhe30a8fad7-12a6-4e48-a5c2-8972e93e04fa.jpg', N'Thien Pham', N'<p>Lorem ipsum dolor sit amet,<i><strong> consectetur adipiscing elit, sed do </strong></i>eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>', N'<p><strong>Lorem Ipsum</strong> is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[DuAn] ON 

INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (39, N'Dự án khách sạn', N'interior02.jpg', NULL, 2022, 3)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (40, N'Dự án hồ nước', N'Landscape-1280x640.jpg', NULL, 2022, 2)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (41, N'Dự án đồi núi', N'matterhorn-switzerland-landscape-120700ALP2085.jpg', NULL, 2022, 2)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (42, N'Dự án cầu bà nà', N'2866886.jpg', NULL, 2022, 2)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (43, N'Dự án nhà nghĩ', N'Nate-Berkus-in-his-New-York-City-apartment-870x520.jpg', NULL, 2022, 3)
INSERT [dbo].[DuAn] ([ID], [TuaDe], [HinhGT], [NoiDung], [Nam], [IDMucLuc]) VALUES (44, N'Dự án nhà hàng', N'civil-lines-gurgaon-s.jpg', NULL, 2022, 3)
SET IDENTITY_INSERT [dbo].[DuAn] OFF
GO
SET IDENTITY_INSERT [dbo].[HinhAnhs] ON 

INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (205, N'civil-lines-gurgaon-s.jpg', NULL, 44)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (206, N'02.jpg', NULL, 44)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (212, N'matterhorn-swiss-landscape-080800ALP0175.jpg', NULL, 41)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (213, N'night-landscape-photography-featured.jpg', NULL, 41)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (217, N'Landscape-1280x640.jpg', NULL, 40)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (218, N'Mountain-Landscape-870x522.jpg', NULL, 40)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (219, N'_S6A1420-Edit-Edit.jpg', NULL, 40)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (220, N'Modern-House-Interior-Designs-in-Sri-Lanka.jpg', NULL, 39)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (221, N'interior02.jpg', NULL, 39)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (222, N'2866886.jpg', NULL, 42)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (223, N'golden-bridge-bana-hillsvietnamgoldenbridge-8354.jpg', NULL, 42)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (227, N'Nate-Berkus-in-his-New-York-City-apartment-870x520.jpg', NULL, 43)
INSERT [dbo].[HinhAnhs] ([ID], [FileName], [TieuDe], [IDDuAn]) VALUES (228, N'PIC-1-27.jpg', NULL, 43)
SET IDENTITY_INSERT [dbo].[HinhAnhs] OFF
GO
SET IDENTITY_INSERT [dbo].[LienHe] ON 

INSERT [dbo].[LienHe] ([ID], [Ten], [PhuongThuc]) VALUES (3, N'30 Thảo Điền, Q2, HCM', N'Địa chỉ')
INSERT [dbo].[LienHe] ([ID], [Ten], [PhuongThuc]) VALUES (4, N'021321312', N'Số điện thoại')
INSERT [dbo].[LienHe] ([ID], [Ten], [PhuongThuc]) VALUES (5, N'admin@gmail.com', N'Email')
SET IDENTITY_INSERT [dbo].[LienHe] OFF
GO
SET IDENTITY_INSERT [dbo].[MucLuc] ON 

INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (1, N'Dự án', 1, NULL, 0, NULL, NULL)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (2, N'Cảnh quan', 1, N'/Project', 1, N'canhquanHome.jpg', 2022)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (3, N'Nội thất', 2, N'/Project', 1, N'noithatHome.jpg', 2022)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (4, N'Thư viện', 2, N'/Gallery', 0, NULL, NULL)
INSERT [dbo].[MucLuc] ([ID], [Ten], [ThuTu], [Link], [IDParent], [HinhAnh], [Nam]) VALUES (5, N'Liên hệ', 3, N'/Contact', 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MucLuc] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanHois] ON 

INSERT [dbo].[PhanHois] ([ID], [Ten], [Email], [SDT], [YeuCau], [NoiDung], [CreatedDate]) VALUES (7, N'Nguyễn Văn A', N'minhduong@gmail.com', N'050505252', N'Kiến trúc cảnh quan', N'asdsadsadsadsadsadsad', CAST(N'2023-01-24T22:38:18.1276786' AS DateTime2))
INSERT [dbo].[PhanHois] ([ID], [Ten], [Email], [SDT], [YeuCau], [NoiDung], [CreatedDate]) VALUES (9, N'nguyen van a', N'minhduong123@gmail.com', N'05151516', N'Kiến trúc thiết kế', N'abc xyzasdsadsadsad', CAST(N'2023-01-25T13:54:32.2473373' AS DateTime2))
SET IDENTITY_INSERT [dbo].[PhanHois] OFF
GO
INSERT [dbo].[TaiKhoan] ([UserName], [Password]) VALUES (N'admin', N'123')
GO
SET IDENTITY_INSERT [dbo].[Videos] ON 

INSERT [dbo].[Videos] ([ID], [FileName]) VALUES (1, N'videbg.mp4')
SET IDENTITY_INSERT [dbo].[Videos] OFF
GO
/****** Object:  Index [IX_BoSuuTam_IDMucLuc]    Script Date: 2/2/2023 8:50:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_BoSuuTam_IDMucLuc] ON [dbo].[BoSuuTam]
(
	[IDMucLuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DuAn_IDMucLuc]    Script Date: 2/2/2023 8:50:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_DuAn_IDMucLuc] ON [dbo].[DuAn]
(
	[IDMucLuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HinhAnhs_IDDuAn]    Script Date: 2/2/2023 8:50:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_HinhAnhs_IDDuAn] ON [dbo].[HinhAnhs]
(
	[IDDuAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PhanHois] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
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
ALTER DATABASE [mic67664_chom] SET  READ_WRITE 
GO

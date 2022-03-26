
CREATE DATABASE [VNR_InternShip];
Go
USE [VNR_InternShip]
GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 7/20/2021 11:29:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenKhoaHoc] [nvarchar](30) NULL,
 CONSTRAINT [PK_dbo.TheLoai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 7/20/2021 11:29:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenMonHoc] [nvarchar](100) NULL,
	[MoTa] [nvarchar](100) NULL,
	[KhoaHocID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BaiHat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KhoaHoc] ON 

INSERT [dbo].[KhoaHoc] ([ID], [TenKhoaHoc]) VALUES (1, N'Front End')
INSERT [dbo].[KhoaHoc] ([ID], [TenKhoaHoc]) VALUES (2, N'Back End')
INSERT [dbo].[KhoaHoc] ([ID], [TenKhoaHoc]) VALUES (3, N'Dotnet Core')
SET IDENTITY_INSERT [dbo].[KhoaHoc] OFF
GO
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([ID], [TenMonHoc], [MoTa], [KhoaHocID]) VALUES (1, N'Bootstrap', NULL, 1)
INSERT [dbo].[MonHoc] ([ID], [TenMonHoc], [MoTa], [KhoaHocID]) VALUES (3, N'Angular JS', NULL, 1)
INSERT [dbo].[MonHoc] ([ID], [TenMonHoc], [MoTa], [KhoaHocID]) VALUES (4, N'Angular', NULL, 1)
INSERT [dbo].[MonHoc] ([ID], [TenMonHoc], [MoTa], [KhoaHocID]) VALUES (5, N'React JS', NULL, 1)
INSERT [dbo].[MonHoc] ([ID], [TenMonHoc], [MoTa], [KhoaHocID]) VALUES (6, N'Dotnet', NULL, 2)
INSERT [dbo].[MonHoc] ([ID], [TenMonHoc], [MoTa], [KhoaHocID]) VALUES (7, N'ASP NET', NULL, 2)
INSERT [dbo].[MonHoc] ([ID], [TenMonHoc], [MoTa], [KhoaHocID]) VALUES (10, N'Net Core', NULL, 3)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BaiHat_dbo.TheLoai_TheLoaiID] FOREIGN KEY([KhoaHocID])
REFERENCES [dbo].[KhoaHoc] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK_dbo.BaiHat_dbo.TheLoai_TheLoaiID]
GO

USE [CMS]
GO
/****** Object:  Table [dbo].[tbl_Artist]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [varchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_tbl_Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_MasterMenu]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MasterMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[MenuOrder] [int] NULL,
 CONSTRAINT [PK_tbl_MasterMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Menu]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MasterMenuId] [int] NULL,
	[MenuName] [varchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[Is_Active] [bit] NULL,
	[Has_SubMenu] [bit] NULL,
	[Menu_Order] [int] NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_tbl_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Portal]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Portal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PortalName] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_tbl_Portal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](max) NULL,
	[Created_By] [varchar](max) NULL,
	[Updated_By] [varchar](max) NULL,
	[Created_Date] [datetime] NULL,
	[Update_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
 CONSTRAINT [PK_tbl_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_RolePermission]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RolePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MenuId] [int] NULL,
	[SubMenuId] [int] NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](50) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_tbl_RolePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SubMenu]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SubMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NULL,
	[SubMenuName] [varchar](max) NULL,
	[SubUrl] [nvarchar](max) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Update_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
	[Is_Active] [bit] NULL,
	[SubMenuOrder] [int] NULL,
 CONSTRAINT [PK_tbl_SubMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NULL,
	[Name] [varchar](50) NULL,
	[roleid] [int] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Update_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](13) NULL,
	[Designation] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblAlbum]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAlbum](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [varchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_tblAlbum] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblContentCategory]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblContentCategory](
	[ContentCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ContentCategoryName] [varchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_tblContentCategory] PRIMARY KEY CLUSTERED 
(
	[ContentCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblContentSubCategory]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblContentSubCategory](
	[ContentSubCatId] [int] IDENTITY(1,1) NOT NULL,
	[ConSubCatName] [varchar](250) NULL,
	[ContentCatId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_tblContentSubCategory] PRIMARY KEY CLUSTERED 
(
	[ContentSubCatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOwner]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOwner](
	[OwnerId] [int] IDENTITY(1,1) NOT NULL,
	[OwnerName] [varchar](250) NULL,
	[IsActive] [bit] NOT NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_tblOwner] PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUplodedContent]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUplodedContent](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ContentCategoryId] [int] NULL,
	[ConSubCatId] [int] NULL,
	[ArtistId] [int] NULL,
	[Portalid] [int] NULL,
	[OwnerId] [int] NULL,
	[AlbumId] [int] NULL,
	[Title] [varchar](250) NULL,
	[Info] [varchar](250) NULL,
	[Duration] [varchar](50) NULL,
	[ThumbnailUrl] [varchar](max) NULL,
	[FIleUrl] [varchar](max) NULL,
	[IsPublish] [bit] NOT NULL,
	[Created_By] [varchar](50) NULL,
	[Created_Date] [datetime] NULL,
	[Updated_By] [varchar](20) NULL,
	[Update_Date] [datetime] NULL,
	[IsOwner] [bit] NULL,
 CONSTRAINT [PK_tblUplodedContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_Artist] ON 

INSERT [dbo].[tbl_Artist] ([ArtistId], [ArtistName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (1, N'Artist 1', 1, NULL, CAST(N'2017-07-19T21:58:38.020' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_Artist] ([ArtistId], [ArtistName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (2, N'Artist 3', 1, NULL, CAST(N'2017-07-19T21:58:43.787' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Artist] OFF
SET IDENTITY_INSERT [dbo].[tbl_MasterMenu] ON 

INSERT [dbo].[tbl_MasterMenu] ([Id], [Name], [Created_By], [Created_Date], [Updated_By], [Update_Date], [Is_Active], [MenuOrder]) VALUES (1, N'Amirica', N'', CAST(N'2017-07-10T01:09:25.757' AS DateTime), N'', CAST(N'2017-07-10T01:09:25.757' AS DateTime), 1, 1)
INSERT [dbo].[tbl_MasterMenu] ([Id], [Name], [Created_By], [Created_Date], [Updated_By], [Update_Date], [Is_Active], [MenuOrder]) VALUES (2, N'Asia', N'', CAST(N'2017-07-10T01:11:27.833' AS DateTime), N'', CAST(N'2017-07-10T01:22:28.070' AS DateTime), 0, 2)
INSERT [dbo].[tbl_MasterMenu] ([Id], [Name], [Created_By], [Created_Date], [Updated_By], [Update_Date], [Is_Active], [MenuOrder]) VALUES (4, N'Europe', N'', CAST(N'2017-07-10T01:14:41.887' AS DateTime), N'', CAST(N'2017-07-10T01:14:41.887' AS DateTime), 1, 10)
INSERT [dbo].[tbl_MasterMenu] ([Id], [Name], [Created_By], [Created_Date], [Updated_By], [Update_Date], [Is_Active], [MenuOrder]) VALUES (5, N'Master menu test ', N'', CAST(N'2017-07-12T01:50:05.347' AS DateTime), N'', CAST(N'2017-07-12T01:50:05.347' AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[tbl_MasterMenu] OFF
SET IDENTITY_INSERT [dbo].[tbl_Menu] ON 

INSERT [dbo].[tbl_Menu] ([Id], [MasterMenuId], [MenuName], [Url], [Is_Active], [Has_SubMenu], [Menu_Order], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (3, 1, N'USA', NULL, 1, 1, 2, NULL, CAST(N'2017-07-10T22:56:03.153' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_Menu] ([Id], [MasterMenuId], [MenuName], [Url], [Is_Active], [Has_SubMenu], [Menu_Order], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (4, 2, N'India', N'Url1', 1, 1, 2, NULL, CAST(N'2017-07-10T22:56:03.153' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_Menu] ([Id], [MasterMenuId], [MenuName], [Url], [Is_Active], [Has_SubMenu], [Menu_Order], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (5, 4, N'UK', N'url2', 1, 0, 1, NULL, CAST(N'2017-07-10T22:56:03.153' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_Menu] ([Id], [MasterMenuId], [MenuName], [Url], [Is_Active], [Has_SubMenu], [Menu_Order], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (6, 4, N'Australia', N'url22', 1, 0, 2, NULL, CAST(N'2017-07-10T22:56:03.153' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_Menu] ([Id], [MasterMenuId], [MenuName], [Url], [Is_Active], [Has_SubMenu], [Menu_Order], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (7, 5, N'menu1', N'..', 1, 0, 1, N'', CAST(N'2017-07-12T01:51:06.540' AS DateTime), N'', CAST(N'2017-07-12T01:51:32.707' AS DateTime))
INSERT [dbo].[tbl_Menu] ([Id], [MasterMenuId], [MenuName], [Url], [Is_Active], [Has_SubMenu], [Menu_Order], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (8, 1, N'Brazil', NULL, 1, 0, 1, NULL, CAST(N'2017-07-10T22:56:03.153' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Menu] OFF
SET IDENTITY_INSERT [dbo].[tbl_Portal] ON 

INSERT [dbo].[tbl_Portal] ([Id], [PortalName], [IsActive], [TimeStamp]) VALUES (1, N'Portal A', 1, CAST(N'2017-07-18T22:00:40.583' AS DateTime))
INSERT [dbo].[tbl_Portal] ([Id], [PortalName], [IsActive], [TimeStamp]) VALUES (2, N'B', 1, CAST(N'2017-07-18T22:00:47.120' AS DateTime))
INSERT [dbo].[tbl_Portal] ([Id], [PortalName], [IsActive], [TimeStamp]) VALUES (3, N'C', 1, CAST(N'2017-07-18T22:00:49.273' AS DateTime))
INSERT [dbo].[tbl_Portal] ([Id], [PortalName], [IsActive], [TimeStamp]) VALUES (4, N'D', 1, CAST(N'2017-07-18T22:00:53.363' AS DateTime))
INSERT [dbo].[tbl_Portal] ([Id], [PortalName], [IsActive], [TimeStamp]) VALUES (5, N'E', 0, CAST(N'2017-07-18T22:01:16.480' AS DateTime))
INSERT [dbo].[tbl_Portal] ([Id], [PortalName], [IsActive], [TimeStamp]) VALUES (6, N'F', 0, CAST(N'2017-07-18T22:01:19.433' AS DateTime))
INSERT [dbo].[tbl_Portal] ([Id], [PortalName], [IsActive], [TimeStamp]) VALUES (7, N'G', 1, CAST(N'2017-07-18T22:01:22.437' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_Portal] OFF
SET IDENTITY_INSERT [dbo].[tbl_Role] ON 

INSERT [dbo].[tbl_Role] ([Id], [RoleName], [Created_By], [Updated_By], [Created_Date], [Update_Date], [Is_Active]) VALUES (1, N'Admin', N'', N'', CAST(N'2017-07-09T23:56:21.327' AS DateTime), CAST(N'2017-07-09T23:56:21.327' AS DateTime), 1)
INSERT [dbo].[tbl_Role] ([Id], [RoleName], [Created_By], [Updated_By], [Created_Date], [Update_Date], [Is_Active]) VALUES (2, N'Content', N'', N'', CAST(N'2017-07-09T23:57:21.717' AS DateTime), CAST(N'2017-07-09T23:57:21.717' AS DateTime), 0)
INSERT [dbo].[tbl_Role] ([Id], [RoleName], [Created_By], [Updated_By], [Created_Date], [Update_Date], [Is_Active]) VALUES (3, N'HR', N'', N'', CAST(N'2017-07-09T23:58:12.730' AS DateTime), CAST(N'2017-07-09T23:58:12.730' AS DateTime), 1)
INSERT [dbo].[tbl_Role] ([Id], [RoleName], [Created_By], [Updated_By], [Created_Date], [Update_Date], [Is_Active]) VALUES (4, N'CS', N'', N'', CAST(N'2017-07-09T23:59:40.677' AS DateTime), CAST(N'2017-07-09T23:59:40.677' AS DateTime), 1)
INSERT [dbo].[tbl_Role] ([Id], [RoleName], [Created_By], [Updated_By], [Created_Date], [Update_Date], [Is_Active]) VALUES (6, N'Finance', N'', N'', CAST(N'2017-07-10T00:31:23.490' AS DateTime), CAST(N'2017-07-10T00:31:58.010' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_Role] OFF
SET IDENTITY_INSERT [dbo].[tbl_RolePermission] ON 

INSERT [dbo].[tbl_RolePermission] ([Id], [RoleId], [MenuId], [SubMenuId], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (8, 1, 3, 1, NULL, CAST(N'2017-07-10T23:22:52.803' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_RolePermission] ([Id], [RoleId], [MenuId], [SubMenuId], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (9, 1, 4, 3, NULL, CAST(N'2017-07-10T23:23:43.280' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_RolePermission] ([Id], [RoleId], [MenuId], [SubMenuId], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (11, 1, 3, 2, NULL, CAST(N'2017-07-10T23:22:52.803' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_RolePermission] ([Id], [RoleId], [MenuId], [SubMenuId], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (12, 1, 4, 4, NULL, CAST(N'2017-07-10T23:23:43.280' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_RolePermission] ([Id], [RoleId], [MenuId], [SubMenuId], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (13, 1, 5, NULL, NULL, CAST(N'2017-07-11T00:32:29.443' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_RolePermission] ([Id], [RoleId], [MenuId], [SubMenuId], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (1012, 1, 7, NULL, NULL, CAST(N'2017-07-12T01:52:56.547' AS DateTime), NULL, NULL)
INSERT [dbo].[tbl_RolePermission] ([Id], [RoleId], [MenuId], [SubMenuId], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (1013, 1, 8, NULL, NULL, CAST(N'2017-07-12T02:25:43.463' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_RolePermission] OFF
SET IDENTITY_INSERT [dbo].[tbl_SubMenu] ON 

INSERT [dbo].[tbl_SubMenu] ([Id], [MenuId], [SubMenuName], [SubUrl], [CreatedBy], [CreatedDate], [Update_By], [Update_Date], [Is_Active], [SubMenuOrder]) VALUES (1, 3, N'Virginia', N'S url1', NULL, CAST(N'2017-07-10T23:26:12.560' AS DateTime), NULL, NULL, 1, 1)
INSERT [dbo].[tbl_SubMenu] ([Id], [MenuId], [SubMenuName], [SubUrl], [CreatedBy], [CreatedDate], [Update_By], [Update_Date], [Is_Active], [SubMenuOrder]) VALUES (2, 3, N'MaryLand', N'S url1', NULL, CAST(N'2017-07-10T23:26:12.560' AS DateTime), NULL, NULL, 1, 2)
INSERT [dbo].[tbl_SubMenu] ([Id], [MenuId], [SubMenuName], [SubUrl], [CreatedBy], [CreatedDate], [Update_By], [Update_Date], [Is_Active], [SubMenuOrder]) VALUES (3, 4, N'Bangalore', N'url2', NULL, CAST(N'2017-07-11T00:07:47.807' AS DateTime), NULL, NULL, 1, 1)
INSERT [dbo].[tbl_SubMenu] ([Id], [MenuId], [SubMenuName], [SubUrl], [CreatedBy], [CreatedDate], [Update_By], [Update_Date], [Is_Active], [SubMenuOrder]) VALUES (4, 4, N'Mumbai', N'url2', NULL, CAST(N'2017-07-11T00:07:47.807' AS DateTime), NULL, NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[tbl_SubMenu] OFF
SET IDENTITY_INSERT [dbo].[tblAlbum] ON 

INSERT [dbo].[tblAlbum] ([AlbumId], [AlbumName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (4, N'Album111', 1, NULL, CAST(N'2017-07-19T22:07:22.953' AS DateTime), NULL, NULL)
INSERT [dbo].[tblAlbum] ([AlbumId], [AlbumName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (5, N'aaaa', 1, NULL, CAST(N'2017-07-19T22:07:42.867' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblAlbum] OFF
SET IDENTITY_INSERT [dbo].[tblContentCategory] ON 

INSERT [dbo].[tblContentCategory] ([ContentCategoryId], [ContentCategoryName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (1, N'Category1', 1, N'aasa', CAST(N'2017-07-18T00:00:00.000' AS DateTime), N'dfgdfg', CAST(N'2017-07-18T00:00:00.000' AS DateTime))
INSERT [dbo].[tblContentCategory] ([ContentCategoryId], [ContentCategoryName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (2, N'Category 2', 1, NULL, CAST(N'2017-07-18T22:10:00.700' AS DateTime), NULL, NULL)
INSERT [dbo].[tblContentCategory] ([ContentCategoryId], [ContentCategoryName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (3, N'Wall paper', 1, NULL, CAST(N'2017-07-18T22:10:13.150' AS DateTime), NULL, NULL)
INSERT [dbo].[tblContentCategory] ([ContentCategoryId], [ContentCategoryName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (4, N'Sticker', 1, NULL, CAST(N'2017-07-18T22:10:16.447' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblContentCategory] OFF
SET IDENTITY_INSERT [dbo].[tblContentSubCategory] ON 

INSERT [dbo].[tblContentSubCategory] ([ContentSubCatId], [ConSubCatName], [ContentCatId], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (1, N'Sub 2', 1, 1, NULL, CAST(N'2017-07-18T22:21:29.987' AS DateTime), NULL, NULL)
INSERT [dbo].[tblContentSubCategory] ([ContentSubCatId], [ConSubCatName], [ContentCatId], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (2, N'Sub 1 ', 2, 1, NULL, CAST(N'2017-07-18T22:21:40.933' AS DateTime), NULL, NULL)
INSERT [dbo].[tblContentSubCategory] ([ContentSubCatId], [ConSubCatName], [ContentCatId], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (3, N'Sub 3', 2, 1, NULL, CAST(N'2017-07-18T22:21:47.003' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblContentSubCategory] OFF
SET IDENTITY_INSERT [dbo].[tblOwner] ON 

INSERT [dbo].[tblOwner] ([OwnerId], [OwnerName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (2, N'owner 2', 1, NULL, CAST(N'2017-07-19T21:56:06.437' AS DateTime), NULL, NULL)
INSERT [dbo].[tblOwner] ([OwnerId], [OwnerName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (4, N'owner 33', 1, NULL, CAST(N'2017-07-19T21:56:16.073' AS DateTime), NULL, NULL)
INSERT [dbo].[tblOwner] ([OwnerId], [OwnerName], [IsActive], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (5, N'Artist 1', 1, N'', CAST(N'2017-07-20T01:31:24.020' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tblOwner] OFF
SET IDENTITY_INSERT [dbo].[tblUplodedContent] ON 

INSERT [dbo].[tblUplodedContent] ([Id], [ContentCategoryId], [ConSubCatId], [ArtistId], [Portalid], [OwnerId], [AlbumId], [Title], [Info], [Duration], [ThumbnailUrl], [FIleUrl], [IsPublish], [Created_By], [Created_Date], [Updated_By], [Update_Date], [IsOwner]) VALUES (10004, 2, 2, 1, 2, 5, 5, N'2323', N'121', N'dfdf', N'~/UplodedFile/Thumbnail/20177200807SS.jpg', N'~/UplodedFile/Content/B/Category 2/Sub 1/2323_20177200807SS.jpg', 0, N'', CAST(N'2017-07-20T08:01:02.850' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[tblUplodedContent] ([Id], [ContentCategoryId], [ConSubCatId], [ArtistId], [Portalid], [OwnerId], [AlbumId], [Title], [Info], [Duration], [ThumbnailUrl], [FIleUrl], [IsPublish], [Created_By], [Created_Date], [Updated_By], [Update_Date], [IsOwner]) VALUES (10005, 2, 2, 1, 2, 5, 5, N'asddsa', N'dsfsdf', N'dsfsdf', N'~/UplodedFile/Thumbnail/20177200807SS.jpg', N'~/UplodedFile/Content/B/Category 2/Sub 1/asddsa_20177200807SS.jpg', 0, N'', CAST(N'2017-07-20T08:02:50.690' AS DateTime), NULL, NULL, 1)
INSERT [dbo].[tblUplodedContent] ([Id], [ContentCategoryId], [ConSubCatId], [ArtistId], [Portalid], [OwnerId], [AlbumId], [Title], [Info], [Duration], [ThumbnailUrl], [FIleUrl], [IsPublish], [Created_By], [Created_Date], [Updated_By], [Update_Date], [IsOwner]) VALUES (10006, 1, 1, 1, 2, 2, 4, N'asdas', N'asdasd', N'asdasd', N'~/UplodedFile/Thumbnail/20177200807SS.jpg', N'~/UplodedFile/Content/B/Category1/Sub 2/asdas_20177200807SS.jpg', 0, N'', CAST(N'2017-07-20T08:04:12.433' AS DateTime), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[tblUplodedContent] OFF
ALTER TABLE [dbo].[tbl_Artist] ADD  CONSTRAINT [DF_tbl_Artist_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Artist] ADD  CONSTRAINT [DF_tbl_Artist_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tbl_MasterMenu] ADD  CONSTRAINT [DF_tbl_MasterMenu_CreatedDate]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tbl_Menu] ADD  CONSTRAINT [DF_tbl_Menu_CreatedDate]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tbl_Portal] ADD  CONSTRAINT [DF_tbl_Portal_TimeStamp]  DEFAULT (getdate()) FOR [TimeStamp]
GO
ALTER TABLE [dbo].[tbl_RolePermission] ADD  CONSTRAINT [DF_tbl_RolePermission_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tbl_SubMenu] ADD  CONSTRAINT [DF_tbl_SubMenu_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tbl_User] ADD  CONSTRAINT [DF_Table_1_CreateDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblAlbum] ADD  CONSTRAINT [DF_tblAlbum_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblAlbum] ADD  CONSTRAINT [DF_tblAlbum_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tblContentCategory] ADD  CONSTRAINT [DF_tblContentCategory_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblContentCategory] ADD  CONSTRAINT [DF_tblContentCategory_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tblContentSubCategory] ADD  CONSTRAINT [DF_tblContentSubCategory_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblContentSubCategory] ADD  CONSTRAINT [DF_tblContentSubCategory_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tblOwner] ADD  CONSTRAINT [DF_tblOwner_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tblUplodedContent] ADD  CONSTRAINT [DF_Table_1_IsActive]  DEFAULT ((0)) FOR [IsPublish]
GO
ALTER TABLE [dbo].[tblUplodedContent] ADD  CONSTRAINT [DF_tblUplodedContent_Created_Date]  DEFAULT (getdate()) FOR [Created_Date]
GO
ALTER TABLE [dbo].[tbl_Menu]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Menu_tbl_MasterMenu] FOREIGN KEY([MasterMenuId])
REFERENCES [dbo].[tbl_MasterMenu] ([Id])
GO
ALTER TABLE [dbo].[tbl_Menu] CHECK CONSTRAINT [FK_tbl_Menu_tbl_MasterMenu]
GO
ALTER TABLE [dbo].[tbl_RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RolePermission_tbl_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[tbl_Menu] ([Id])
GO
ALTER TABLE [dbo].[tbl_RolePermission] CHECK CONSTRAINT [FK_tbl_RolePermission_tbl_Menu]
GO
ALTER TABLE [dbo].[tbl_RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RolePermission_tbl_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tbl_Role] ([Id])
GO
ALTER TABLE [dbo].[tbl_RolePermission] CHECK CONSTRAINT [FK_tbl_RolePermission_tbl_Role]
GO
ALTER TABLE [dbo].[tbl_RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RolePermission_tbl_SubMenu] FOREIGN KEY([SubMenuId])
REFERENCES [dbo].[tbl_SubMenu] ([Id])
GO
ALTER TABLE [dbo].[tbl_RolePermission] CHECK CONSTRAINT [FK_tbl_RolePermission_tbl_SubMenu]
GO
ALTER TABLE [dbo].[tbl_SubMenu]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SubMenu_tbl_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[tbl_Menu] ([Id])
GO
ALTER TABLE [dbo].[tbl_SubMenu] CHECK CONSTRAINT [FK_tbl_SubMenu_tbl_Menu]
GO
ALTER TABLE [dbo].[tblContentSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblContentSubCategory_tblContentCategory] FOREIGN KEY([ContentCatId])
REFERENCES [dbo].[tblContentCategory] ([ContentCategoryId])
GO
ALTER TABLE [dbo].[tblContentSubCategory] CHECK CONSTRAINT [FK_tblContentSubCategory_tblContentCategory]
GO
/****** Object:  StoredProcedure [dbo].[GetPortalList]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetPortalList]

as 

begin

Select PortalName,Id from tbl_Portal
where IsActive=1		
order BY PortalName

end
GO
/****** Object:  StoredProcedure [dbo].[RoleWiseMenu]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[RoleWiseMenu]
@RoleId int
as

begin 

Select x.Id,x.MenuText,x.ParentId,x.Url,x.MenuOrder from (
Select distinct MM.Id  ,MM.Name MenuText,NULL ParentId,M.Url,MM.MenuOrder FROM 
  [tbl_MasterMenu] MM
  left JOIN 
  [tbl_Menu] M
  on MM.Id = M.MasterMenuId
  left join 
[dbo].[tbl_RolePermission] RP
on 
RP.menuID = M.Id

where rp.roleid=@RoleId and M.Is_Active=1
UNION ALL
Select distinct M.Id*100  ,M.MenuName MenuText,MM.Id ParentId,M.Url,M.Menu_Order FROM 
  [tbl_MasterMenu] MM

  left JOIN 
  [tbl_Menu] M
  on MM.Id = M.MasterMenuId
  left join 
[dbo].[tbl_RolePermission] RP
on 
RP.menuID = M.Id

where rp.roleid=@RoleId and M.Is_Active=1

UNION ALL
 Select Distinct SM.Id*1000,SM.SubMenuName,SM.MenuId*100,SM.SubUrl,SM.SubMenuOrder FROM
 tbl_SubMenu SM
 left join
[dbo].[tbl_RolePermission] RP
on 
RP.menuID = SM.MenuId and SM.Id=Rp.SubmenuID

where rp.roleid=@RoleId and SM.Is_Active=1

)X
order by x.MenuOrder,x.MenuText
  END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetMenuNames]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetMenuNames] 
	-- Add the parameters for the stored procedure here
	@type varchar(50)=''
AS
BEGIN
	
	SET NOCOUNT ON;

   if(@type = 'master')
   begin

	select id,Name from [CMS].[dbo].[tbl_MasterMenu] 
   end
END

GO
/****** Object:  StoredProcedure [dbo].[sp_MasterMenuManagement]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,iftekhar>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec sp_RoleManagement 'select'
CREATE PROCEDURE [dbo].[sp_MasterMenuManagement] 
	-- Add the parameters for the stored procedure here
	@type varchar(50)='',
	@MasterMenuName varchar(50)='',	
	@CreatedBy varchar(50)='',
	@CreateDate datetime=null,
	@UpdatedBy varchar(50)='',	
	@UpdateDate datetime=null,
	@isActive bit=0,	
	@MenuOrder int='',
	@id int=0
AS
BEGIN
	

	if(@type='insert')
		begin

			insert into [CMS].[dbo].[tbl_MasterMenu] values 
			(
			
			
			@MasterMenuName,	
			@CreatedBy,
			@CreateDate,
			@UpdatedBy,	
			@UpdateDate,
			@isActive,	
			@MenuOrder
			
			)
		end
	else if(@type='update')
		begin
	     update	[CMS].[dbo].[tbl_MasterMenu] set Name=@MasterMenuName,Updated_By=@UpdatedBy,Update_Date=GETDATE(),Is_Active=@isActive,
		 MenuOrder=@MenuOrder
		 where Id=@id
		end
	else if(@type='delete')
		begin
	     delete from 	[CMS].[dbo].[tbl_MasterMenu] where Id=@id
		end
	else if(@type='select')
		begin
	     select * from	[CMS].[dbo].[tbl_MasterMenu]
		end
  
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Menu]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,iftekhar>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec sp_RoleManagement 'select'
CREATE PROCEDURE [dbo].[sp_Menu] 
	-- Add the parameters for the stored procedure here
	@type varchar(50)='',
	@MasterMenuId int='',	
	@MenuName varchar(50)='',	
	@Url varchar(50)='',	
	@IsActive bit=0,	
	@HasSubMenu bit=0,	
	@MenuOrder int='',
	@CreatedBy varchar(50)='',
	@CreateDate datetime=null,
	@UpdatedBy varchar(50)='',	
	@UpdateDate datetime=null,	
	@id int=0
AS
BEGIN
	

	if(@type='insert')
		begin

			insert into [CMS].[dbo].[tbl_Menu] values 
			(
			
			@MasterMenuId,	
			@MenuName,	
			@Url,	
			@IsActive,	
			@HasSubMenu,	
			@MenuOrder,
			@CreatedBy,
			@CreateDate,
			@UpdatedBy,	
			@UpdateDate
	
			
			)
		end
	else if(@type='update')
		begin
	     update	[CMS].[dbo].[tbl_Menu] set MasterMenuId=@MasterMenuId,MenuName=@MenuName,Url=@Url,Updated_By=@UpdatedBy,Update_Date=GETDATE(),Is_Active=@isActive,
		 Has_SubMenu=@HasSubMenu, Menu_Order=@MenuOrder
		 where Id=@id
		end
	else if(@type='delete')
		begin
	     delete from 	[CMS].[dbo].[tbl_Menu] where Id=@id
		end
	else if(@type='select')
		begin
	     select * from	[CMS].[dbo].[tbl_Menu]
		end
  
END

GO
/****** Object:  StoredProcedure [dbo].[sp_RoleManagement]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,iftekhar>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- exec sp_RoleManagement 'select'
CREATE PROCEDURE [dbo].[sp_RoleManagement] 
	-- Add the parameters for the stored procedure here
	@type varchar(50)='',
	@RoleName varchar(50)='',
	@CreatedBy varchar(50)='',
	@UpdatedBy varchar(50)='',
	@CreateDate datetime=null,
	@UpdateDate datetime=null,
	@isActive bit=0,	
	@id int=0
AS
BEGIN
	

	if(@type='insert')
		begin

			insert into [CMS].[dbo].[tbl_Role] values 
			(
			
			@RoleName, 
			@CreatedBy,
			@UpdatedBy,
			@CreateDate, 
			@UpdateDate,
			@isActive
			
			)
		end
	else if(@type='update')
		begin
	     update	[CMS].[dbo].[tbl_Role] set RoleName=@RoleName,Updated_By=@UpdatedBy,Update_Date=GETDATE(),Is_Active=@isActive
		 where Id=@id
		end
	else if(@type='delete')
		begin
	     delete from 	[CMS].[dbo].[tbl_Role] where Id=@id
		end
	else if(@type='select')
		begin
	     select * from	[CMS].[dbo].[tbl_Role] 
		end
  
END

GO
/****** Object:  StoredProcedure [dbo].[spDeleteUplodedContent]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spDeleteUplodedContent]
@Id int
as 

begin


Delete from tblUplodedContent
where IsPublish=0 and Id=@id


end
GO
/****** Object:  StoredProcedure [dbo].[spGetAlbumList]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGetAlbumList]

as

begin

Select AlbumId,AlbumName from tblAlbum
where isActive=1
order BY AlbumName

end
GO
/****** Object:  StoredProcedure [dbo].[SpGetArtistList]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SpGetArtistList]

as


begin

SELECT
	ArtistId,ArtistName
FROM tbl_Artist
where IsActive=1
order by ArtistName

end
GO
/****** Object:  StoredProcedure [dbo].[SpGetContentCategory]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SpGetContentCategory]
as 


begin

Select ContentCategoryId,ContentCategoryName from tblContentCategory
where isActive=1 
order by ContentCategoryName

end
GO
/****** Object:  StoredProcedure [dbo].[SpGetContentCategoryList]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SpGetContentCategoryList]
@catId int
as 


begin

Select ContentSubCatId,ConSubCatName from [dbo].[tblContentSubCategory]
WHERE isActive=1 and ContentCatId=@catId
order by ConSubCatName

end 
GO
/****** Object:  StoredProcedure [dbo].[SpGetOwnerList]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[SpGetOwnerList]

as


begin

SELECT
	OwnerId,OwnerName
FROM tblOwner
where IsActive=1
order by OwnerName

end
GO
/****** Object:  StoredProcedure [dbo].[spGetUplodedContent]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/

CREATE proc [dbo].[spGetUplodedContent]

as
 
 begin
SELECT UC.id,UC.Title,cat.ContentCategoryName,ConSub.ConSubCatName,Ar.ArtistName,P.PortalName,Ow.OwnerName,Al.AlbumName,UC.ThumbnailUrl,case when UC.IsPublish= 1  then 'Yes'ELSE 'No' end Publish
  FROM [CMS].[dbo].[tblUplodedContent] UC

  left JOIN tblContentCategory cat
  on 
  cat.ContentCategoryId = UC.ContentCategoryId
  

  left join tblContentSubCategory ConSub 
  on ConSub.ContentSubCatId = UC.ConSubCatId and 
  ConSub.ContentCatId = UC.ContentCategoryId  

  left JOIN tbl_Artist Ar on 
  Ar.ArtistId = UC.ArtistId


  left JOIN tbl_Portal P ON
  P.Id = UC.Portalid 

  left join tblOwner ow ON
  ow.OwnerId = UC.OwnerId 
  left join tblAlbum Al ON
  Al.AlbumId = UC.AlbumId


  where  cat.IsActive=1 and  ConSub.IsActive=1  and   ( AR.IsActive=1 or AR.IsActive is null)  
  and   (P.IsActive=1 or P.IsActive is null) and   (ow.IsActive=1  or ow.IsActive is null)   and AL.IsActive=1 or ( AL.IsActive is null)
  ORDER by UC.Created_Date DESC

  end
GO
/****** Object:  StoredProcedure [dbo].[SpSavetblUplodedContent]    Script Date: 7/20/2017 8:07:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SpSavetblUplodedContent]
@Id bigint,
@ContentCategoryId int,
@ConSubCatId int,
@ArtistId int,
@Portalid int,
@AlbumId int,
@OwnerId int,
@Title varchar(250),
@Info varchar(250),
@Duration varchar(250),
@ThumbnailUrl varchar(max),
@FIleUrl varchar(max),
@Created_By varchar(max),
@Updated_By varchar(max),
@ISOwner bit


as

begin

if @ISOwner =1

begin

declare @ownerName varchar(250)=(SELECT ArtistName from [dbo].[tbl_Artist] WHERE ArtistId=@ArtistId)

if not exists(SELECT * from tblOwner WHERE OwnerName=(@ownerName))
BEGIN

INSERT INTO [dbo].[tblOwner]([OwnerName],[IsActive],[Created_By],[Created_Date])VALUES(@ownerName,1,@Created_By,getdate())
set @ownerId = (select TOP 1 OwnerId from [dbo].[tblOwner]
order by OwnerId DESC)
END

end

if not exists (SELECT * from  [dbo].[tblUplodedContent] WHERE id =@id)
BEGIN
INSERT INTO [dbo].[tblUplodedContent]
           ([ContentCategoryId]
           ,[ConSubCatId]
           ,[ArtistId]
           ,[Portalid]
           ,[OwnerId]
           ,[AlbumId]
           ,[Title]
           ,[Info]
           ,[Duration]
           ,[ThumbnailUrl]
           ,[FIleUrl]
           ,[Created_By]
           ,[Created_Date]
		   ,IsOwner
)
     VALUES
           (@ContentCategoryId
           ,@ConSubCatId
           ,@ArtistId
           ,@Portalid
           ,@OwnerId
           ,@AlbumId
           ,@Title
           ,@Info
           ,@Duration
           ,@ThumbnailUrl
           ,@FIleUrl
           ,@Created_By
           ,getdate()
		   ,@isOwner)

		   end

ELSE
BEGIN


UPDATE [dbo].[tblUplodedContent]
   SET [ContentCategoryId] = @ContentCategoryId
      ,[ConSubCatId] = @ConSubCatId
      ,[ArtistId] = @ArtistId
      ,[Portalid] = @Portalid
      ,[OwnerId] = @OwnerId
      ,[AlbumId] = @AlbumId
      ,[Title] = @Title
      ,[Info] = @Info
      ,[Duration] = @Duration
      ,[ThumbnailUrl] = @ThumbnailUrl
      ,[FIleUrl] = @FIleUrl    
      ,[Updated_By] = @Updated_By
      ,[Update_Date] = getdate()
	  ,isOwner =@isOwner
	  where Id=@id
end 


END



GO

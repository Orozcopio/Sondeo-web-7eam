USE [Sondeo-web]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[ID_CATEGORIA] [int] IDENTITY(1,1) NOT NULL,
	[CATEGORIA] [varchar](25) NOT NULL,
	[DESCRIPCION_CAT] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CATEGORIA] PRIMARY KEY CLUSTERED 
(
	[ID_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOCALIZACION]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOCALIZACION](
	[ID_LOCAL] [int] NOT NULL,
	[LOCALIDAD] [varchar](50) NOT NULL,
	[DEPARTAMENTO] [varchar](25) NOT NULL,
	[MUNICIPIO] [varchar](50) NOT NULL,
	[AREA] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LOCALIZACION] PRIMARY KEY CLUSTERED 
(
	[ID_LOCAL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MARCA]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MARCA](
	[ID_MARCA] [int] IDENTITY(1,1) NOT NULL,
	[MARCA] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MARCA] PRIMARY KEY CLUSTERED 
(
	[ID_MARCA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MEDIDA]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MEDIDA](
	[ID_MEDIDA] [int] NOT NULL,
	[MEDIDA] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MEDIDA] PRIMARY KEY CLUSTERED 
(
	[ID_MEDIDA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[ID_PRODUCTO] [int] IDENTITY(1,1) NOT NULL,
	[ID_CATEGORIA] [int] NULL,
	[UNIDAD_MEDIDA] [int] NULL,
	[ID_MARCA] [int] NULL,
	[PRODUCTO] [varchar](50) NOT NULL,
	[PRESENTACION] [varchar](50) NOT NULL,
	[PRECIO_CONSULTA] [numeric](8, 2) NOT NULL,
	[TIPO] [varchar](50) NOT NULL,
	[ALPORMAYOR] [bit] NOT NULL CONSTRAINT [DF_PRODUCTO_ALPORMAYOR]  DEFAULT ((0)),
	[ID_SONDEO] [int] NOT NULL,
	[CANTIDAD_MEDIDA] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[ID_PRODUCTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[REPORTE]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[REPORTE](
	[_REPORTE] [varchar](25) NOT NULL,
	[ID_SONDEO] [int] NULL,
	[ID_USUARIO] [nvarchar](256) NULL,
	[FECHA_REPORTE] [datetime] NOT NULL,
 CONSTRAINT [PK_REPORTE] PRIMARY KEY CLUSTERED 
(
	[_REPORTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SONDEO]    Script Date: 26/11/2019 21:01:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SONDEO](
	[ID_SONDEO] [int] NOT NULL,
	[ID_LOCAL] [int] NOT NULL,
	[FECHA] [datetime] NOT NULL,
	[DESCRIPCION] [varchar](1024) NOT NULL,
	[FINALIZADO] [bit] NOT NULL CONSTRAINT [DF_SONDEO_ESTADO]  DEFAULT ((0)),
	[ID_USUARIO] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_SONDEO] PRIMARY KEY CLUSTERED 
(
	[ID_SONDEO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_MIDE_MEDIDA] FOREIGN KEY([UNIDAD_MEDIDA])
REFERENCES [dbo].[MEDIDA] ([ID_MEDIDA])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_MIDE_MEDIDA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_SE_CLASIF_CATEGORI] FOREIGN KEY([ID_CATEGORIA])
REFERENCES [dbo].[CATEGORIA] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_SE_CLASIF_CATEGORI]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_TIENE_MARCA] FOREIGN KEY([ID_MARCA])
REFERENCES [dbo].[MARCA] ([ID_MARCA])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_TIENE_MARCA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_SONDEO_SE_COMPON_PRODUCTO] FOREIGN KEY([ID_SONDEO])
REFERENCES [dbo].[SONDEO] ([ID_SONDEO])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_SONDEO_SE_COMPON_PRODUCTO]
GO
ALTER TABLE [dbo].[REPORTE]  WITH CHECK ADD  CONSTRAINT [FK_REPORTE_AspNetUsers] FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[AspNetUsers] ([UserName])
GO
ALTER TABLE [dbo].[REPORTE] CHECK CONSTRAINT [FK_REPORTE_AspNetUsers]
GO
ALTER TABLE [dbo].[REPORTE]  WITH CHECK ADD  CONSTRAINT [FK_REPORTE_GENERA_SONDEO] FOREIGN KEY([ID_SONDEO])
REFERENCES [dbo].[SONDEO] ([ID_SONDEO])
GO
ALTER TABLE [dbo].[REPORTE] CHECK CONSTRAINT [FK_REPORTE_GENERA_SONDEO]
GO
ALTER TABLE [dbo].[SONDEO]  WITH CHECK ADD  CONSTRAINT [FK_SONDEO_AspNetUsers] FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[AspNetUsers] ([UserName])
GO
ALTER TABLE [dbo].[SONDEO] CHECK CONSTRAINT [FK_SONDEO_AspNetUsers]
GO
ALTER TABLE [dbo].[SONDEO]  WITH CHECK ADD  CONSTRAINT [FK_SONDEO_SE_REALIZ_LOCALIZA] FOREIGN KEY([ID_LOCAL])
REFERENCES [dbo].[LOCALIZACION] ([ID_LOCAL])
GO
ALTER TABLE [dbo].[SONDEO] CHECK CONSTRAINT [FK_SONDEO_SE_REALIZ_LOCALIZA]
GO

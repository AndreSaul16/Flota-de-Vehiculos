USE [FlotaVehiculos2.0]
GO
/****** Object:  Table [dbo].[DepCarga]    Script Date: 02/03/2021 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepCarga](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NOT NULL,
	[cargaMax] [int] NOT NULL,
	[vehiculoID] [int] NOT NULL,
 CONSTRAINT [PK_DepCarga] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepTransporte]    Script Date: 02/03/2021 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepTransporte](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [int] NOT NULL,
	[maxPersonas] [int] NOT NULL,
	[vehiculoID] [int] NOT NULL,
 CONSTRAINT [PK_DepTransporte] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 02/03/2021 20:20:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[marca] [nvarchar](50) NOT NULL,
	[modelo] [nvarchar](50) NOT NULL,
	[matricula] [nvarchar](50) NOT NULL,
	[color] [nvarchar](50) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Vehiculos_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DepCarga]  WITH CHECK ADD  CONSTRAINT [FK_DepCarga_Vehiculos] FOREIGN KEY([vehiculoID])
REFERENCES [dbo].[Vehiculos] ([ID])
GO
ALTER TABLE [dbo].[DepCarga] CHECK CONSTRAINT [FK_DepCarga_Vehiculos]
GO
ALTER TABLE [dbo].[DepTransporte]  WITH CHECK ADD  CONSTRAINT [FK_DepTransporte_Vehiculos] FOREIGN KEY([vehiculoID])
REFERENCES [dbo].[Vehiculos] ([ID])
GO
ALTER TABLE [dbo].[DepTransporte] CHECK CONSTRAINT [FK_DepTransporte_Vehiculos]
GO

USE [PruebaPractica]
GO

/****** Object:  Table [dbo].[tb_Personas]    Script Date: 08/09/2021 19:33:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_Personas](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](50) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Apellido] [varchar](250) NOT NULL,
	[Edad] [int] NOT NULL,
	[Direccion] [varchar](500) NOT NULL,
	[OtrosDatos] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_tb_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tb_Personas] ADD  CONSTRAINT [DF_tb_Personas_Identificacion]  DEFAULT ('') FOR [Identificacion]
GO

ALTER TABLE [dbo].[tb_Personas] ADD  CONSTRAINT [DF_tb_Personas_Nombre]  DEFAULT ('') FOR [Nombre]
GO

ALTER TABLE [dbo].[tb_Personas] ADD  CONSTRAINT [DF_tb_Personas_Apellido]  DEFAULT ('') FOR [Apellido]
GO

ALTER TABLE [dbo].[tb_Personas] ADD  CONSTRAINT [DF_tb_Personas_Edad]  DEFAULT ((0)) FOR [Edad]
GO

ALTER TABLE [dbo].[tb_Personas] ADD  CONSTRAINT [DF_tb_Personas_Direccion]  DEFAULT ('') FOR [Direccion]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [PruebaPractica]
GO

/****** Object:  StoredProcedure [dbo].[sp_Delete_Persona]    Script Date: 08/09/2021 19:34:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Gerardo Rodriguez Suarez>
-- Create date: <Create Date,06/09/2021>
-- Description:	<Description,Elimina los datos de la tabla tb_Personas con filtro por id>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Delete_Persona]

	@Id as int
AS
BEGIN

	SET NOCOUNT ON;

	delete from  tb_Personas  WHERE Id = @Id 
END
GO

----------------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [PruebaPractica]
GO

/****** Object:  StoredProcedure [dbo].[sp_Update_Persona]    Script Date: 08/09/2021 19:34:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Gerardo Rodriguez Suarez>
-- Create date: <Create Date,06/09/2021>
-- Description:	<Description,Actualiza los datos de la tabla tb_Personas con filtro por id>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_Persona]

	@Id as int,@Identificacion as varchar(50), @Nombre  varchar(250),@Apellido as varchar(250),@Edad as int,@Direccion as varchar(500),@OtrosDatos as varchar(8000)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE tb_Personas
	   SET [Identificacion] = @Identificacion
		  ,[Nombre] = @Nombre
		  ,[Apellido] = @Apellido
		  ,[Edad] = @Edad
		  ,[Direccion] = @Direccion
		  ,[OtrosDatos] = @OtrosDatos
	   WHERE Id = @Id 
END
GO


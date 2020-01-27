CREATE PROC usp_SEL_TbLG_PuntoAtencion_Autocomplete
(
	@pDescripcion01 VARCHAR(20)
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT TOP 10 ID_Index, Descripcion01
	FROM dbo.TbLG_PuntoAtencion
	WHERE Descripcion01 LIKE @pDescripcion01 + '%'

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_UDP_PROGRAMACION_OrdenCorrectivo_Generacion
(
	@pCODI_PROGRAMACION VARCHAR(15),
	@pFechaGeneracion DATE,
	@pHoraGeneracion VARCHAR(10),
	@pUsuarioGeneracion VARCHAR(6),
	@pNumeroOrden VARCHAR(15),
	@pNumeroMantenimiento VARCHAR(15),
	@pKmt_Viaje NUMERIC(17,2),
	@pCODI_BUS VARCHAR(4)
)	
AS
BEGIN

	SET NOCOUNT ON

	UPDATE dbo.PROGRAMACION
	SET 
		FechaGeneracion = @pFechaGeneracion,
		HoraGeneracion = @pHoraGeneracion,
		UsuarioGeneracion = @pUsuarioGeneracion,
		NumeroOrden = @pNumeroOrden,
		NumeroMantenimiento = @pNumeroMantenimiento,
		Correctivo = '1',
		KMT_VIAJE = @pKmt_Viaje,
		CODI_BUS = @pCODI_BUS
	WHERE
		CODI_PROGRAMACION = @pCODI_PROGRAMACION

	SET NOCOUNT OFF
	
END
GO

CREATE PROC usp_UDP_PROGRAMACION_OrdenCorrectivo_Anulacion
(
	@pCODI_PROGRAMACION VARCHAR(15)
)	
AS
BEGIN

	SET NOCOUNT ON

	UPDATE dbo.PROGRAMACION
	SET 
		FechaGeneracion = NULL,
		HoraGeneracion = NULL,
		UsuarioGeneracion = NULL,
		NumeroOrden = NULL,
		NumeroMantenimiento = NULL,
		Correctivo = NULL
	WHERE
		CODI_PROGRAMACION = @pCODI_PROGRAMACION

	SET NOCOUNT OFF
	
END
GO

CREATE PROC usp_SEL_PROGRAMACION
(
	@pCODI_PROGRAMACION VARCHAR(15)
)	
AS
BEGIN

	SET NOCOUNT ON

	SELECT
		CODI_PROGRAMACION, FechaGeneracion, HoraGeneracion, UsuarioGeneracion, NumeroOrden, NumeroMantenimiento, Correctivo, KMT_VIAJE, CODI_BUS
	FROM
		dbo.PROGRAMACION
	WHERE
		CODI_PROGRAMACION = @pCODI_PROGRAMACION

	SET NOCOUNT OFF
	
END
GO 

CREATE PROC usp_SEL_tb_SolicitudRevisionTecnica_C_UltimoId
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		ISNULL((SELECT MAX(CONVERT(NUMERIC(18, 0), IdSolicitudRevision)) + 1), 1) AS NumSol
	FROM 
		tb_SolicitudRevisionTecnica_C 
	WHERE LEN(IdSolicitudRevision) <> '15'

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_UPD_tb_SolicitudRevisionTecnica_C_Correctivo
(
	@pIdSolicitudRevision VARCHAR(15),
	@pOdometro NUMERIC(18,2),
	@pIdInforme NUMERIC
)
AS
BEGIN

	SET NOCOUNT ON

	UPDATE dbo.tb_SolicitudRevisionTecnica_C 
	SET
		Odometro = @pOdometro,
		IdInforme = @pIdInforme
	FROM 
		tb_SolicitudRevisionTecnica_C 
	WHERE IdSolicitudRevision = @pIdSolicitudRevision

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_SEL_Are
(
	@pAre_Codigo VARCHAR(5)
)
AS
BEGIN

	SET NOCOUNT ON

	SELECT Are_Nombre, Are_Observacion, Klm_Acumulados
	FROM ARE
	WHERE 
		Are_Codigo = @pAre_Codigo

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_tb_Informe_ObtenerId
AS
BEGIN

	SET NOCOUNT ON

	SELECT ISNULL((SELECT MAX(NumeroInforme) + 1 ), 1) NumInf
	FROM tb_Informe 
	WHERE IdPlanEjecucionTarea<>'X'

	SET NOCOUNT OFF

END
GO


CREATE PROC usp_UPD_tb_Informe_NumInforme
(
	@pIdInforme INT,
	@pNumInforme DECIMAL
)
AS
BEGIN

	UPDATE tb_Informe
	SET
	NumeroInforme = @pNumInforme
	WHERE IdInforme = @pIdInforme

END
GO

CREATE PROC usp_DEL_tb_Informe_Anular
(
	@pNumInforme DECIMAL,
	@pTipo VARCHAR(1)
)
AS
BEGIN

	SET NOCOUNT ON

	DELETE FROM dbo.tb_Informe
	WHERE NumeroInforme = @pNumInforme
	AND TipoInforme = @pTipo

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_DEL_tb_SolicitudRevisionTecnica_C_Anular
(
	@pNumeroInforme DECIMAL
)
AS
BEGIN

	SET NOCOUNT ON

	DELETE FROM dbo.tb_SolicitudRevisionTecnica_C
	WHERE IdInforme = @pNumeroInforme

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_UDP_PROGRAMACION_OrdenPreventivo_Generacion
(
	@pCODI_PROGRAMACION VARCHAR(15),
	@pNumeroMantenimiento VARCHAR(15)
)	
AS
BEGIN

	SET NOCOUNT ON

	UPDATE dbo.PROGRAMACION
	SET 
		NumeroMantenimiento = @pNumeroMantenimiento,
		Preventivo = '1'
	WHERE
		CODI_PROGRAMACION = @pCODI_PROGRAMACION

	SET NOCOUNT OFF
	
END
GO

CREATE PROC usp_UDP_PROGRAMACION_OrdenPreventivo_Anulacion
(
	@pCODI_PROGRAMACION VARCHAR(15)
)	
AS
BEGIN

	SET NOCOUNT ON

	UPDATE dbo.PROGRAMACION
	SET 
		NumeroMantenimiento = NULL,
		Preventivo = NULL
	WHERE
		CODI_PROGRAMACION = @pCODI_PROGRAMACION

	SET NOCOUNT OFF
	
END
GO

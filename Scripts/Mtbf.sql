USE BDALM2019_NIC
GO


CREATE PROC usp_INS_tb_MTBF
(
	@pBam numeric(18, 2),
	@pViajeEnHoras smallint,
	@pHorasDia tinyint,
	@pAnio smallint,
	@pNumMes tinyint,
	@pDiasMes tinyint,
	@pViajes smallint,
	@pFallasMecanicas smallint,
	@pTotalHoras varchar(12),
	@pMTTR varchar(12),
	@pMetaMTBF smallint,
	@pMTBFHorasTotales smallint,
	@pMTBFDiario smallint,
	@pMTBFViajes smallint,
	@pKmPerdidos int,
	@pMeta numeric(18, 2),
	@pEficiencia numeric(18, 2),
	@pCambioTractos tinyint,
	@pDisponibilidadMecanica numeric(18, 2),
	@pDisponibilidadFlota numeric(18, 2),
	@pFechaHoraRegistro datetime,
	@pUsuarioRegistro varchar(10),
	@pIdMtbf int OUTPUT
)
AS
BEGIN

	SET NOCOUNT ON

	INSERT dbo.tb_MTBF 
	(
		Bam, ViajeEnHoras, HorasDia, Anio, NumMes, 
		DiasMes, Viajes, FallasMecanicas, TotalHoras, MTTR, 
		MetaMTBF, MTBFHorasTotales, MTBFDiario, MTBFViajes, KmPerdidos, 
		Meta, Eficiencia, CambioTractos, DisponibilidadMecanica, DisponibilidadFlota, 
		FechaHoraRegistro, UsuarioRegistro
	)
	VALUES
	(
		@pBam, @pViajeEnHoras, @pHorasDia, @pAnio, @pNumMes,
		@pDiasMes, @pViajes, @pFallasMecanicas, @pTotalHoras, @pMTTR,
		@pMetaMTBF, @pMTBFHorasTotales, @pMTBFDiario, @pMTBFViajes, @pKmPerdidos,
		@pMeta, @pEficiencia, @pCambioTractos, @pDisponibilidadMecanica, @pDisponibilidadFlota,
		@pFechaHoraRegistro, @pUsuarioRegistro
	)

	SET @pIdMtbf = IDENT_CURRENT('tb_MTBF')

	SET NOCOUNT OFF
END
GO



CREATE PROC usp_UPD_tb_MTBF
(
	@pIdMtbf int,
	@pBam numeric(18, 2),
	@pViajeEnHoras smallint,
	@pHorasDia tinyint,
	@pAnio smallint,
	@pNumMes tinyint,
	@pDiasMes tinyint,
	@pViajes smallint,
	@pFallasMecanicas smallint,
	@pTotalHoras varchar(12),
	@pMTTR varchar(12),
	@pMetaMTBF smallint,
	@pMTBFHorasTotales smallint,
	@pMTBFDiario smallint,
	@pMTBFViajes smallint,
	@pKmPerdidos int,
	@pMeta numeric(18, 2),
	@pEficiencia numeric(18, 2),
	@pCambioTractos tinyint,
	@pDisponibilidadMecanica numeric(18, 2),
	@pDisponibilidadFlota numeric(18, 2)
)
AS
BEGIN

	SET NOCOUNT ON

	UPDATE dbo.tb_MTBF 
	SET
		Bam	= @pBam, 
		ViajeEnHoras = @pViajeEnHoras, 
		HorasDia = @pHorasDia, 
		Anio = @pAnio, 
		NumMes = @pNumMes, 
		DiasMes = @pDiasMes, 
		Viajes = @pViajes, 
		FallasMecanicas = @pFallasMecanicas, 
		TotalHoras = @pTotalHoras, 
		MTTR = @pMTTR, 
		MetaMTBF = @pMetaMTBF, 
		MTBFHorasTotales = @pMTBFHorasTotales, 
		MTBFDiario = @pMTBFDiario, 
		MTBFViajes = @pMTBFViajes, 
		KmPerdidos = @pKmPerdidos, 
		Meta = @pMeta, 
		Eficiencia = @pEficiencia, 
		CambioTractos = @pCambioTractos, 
		DisponibilidadMecanica = @pDisponibilidadMecanica, 
		DisponibilidadFlota = @pDisponibilidadFlota 
		
	WHERE IdMtbf = @pIdMtbf

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_DEL_tb_MTBF
(
	@pIdMtbf int
)
AS
BEGIN

	SET NOCOUNT ON

	DELETE FROM dbo.tb_MTBF 	
	WHERE IdMtbf = @pIdMtbf

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_DEL_tb_MTBF_Anio
(
	@pAnio smallint
)
AS
BEGIN

	SET NOCOUNT ON

	DELETE FROM dbo.tb_MTBF 	
	WHERE Anio = @pAnio

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_LIST_tb_MTBF
(
	@pAnio int
)
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		IdMtbf, Bam, ViajeEnHoras, HorasDia, Anio, 
		NumMes, DiasMes, Viajes, FallasMecanicas, TotalHoras, 
		MTTR, MetaMTBF, MTBFHorasTotales, MTBFDiario, MTBFViajes, 
		KmPerdidos, Meta, Eficiencia, CambioTractos, DisponibilidadMecanica, 
		DisponibilidadFlota
	FROM 
		dbo.tb_MTBF
	WHERE 
		Anio = @pAnio

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_ObtenerPorMesAnio_Tb_AuxilioMecanico
(
	@pAnio SMALLINT,
	@pMes TINYINT
)
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		ID_Tb_AuxilioMecanico, Carga, Are_Codigo, Are_Codigo2, Kmt_unidad, 
		Kmt_recorrido, MMG, Fechahora_ini, Fechahora_fin, Controlable, 
		Id_plataforma, Idtarea_c, Falla, Ben_codigo, Servicio, 
		Kmt_Perdido, CambioTracto, Responsable, Atencion, Causa, 
		IdPlan
	FROM dbo.Tb_AuxilioMecanico WITH(NOLOCK)
	WHERE
		MONTH(Fechahora_ini) = @pMes AND
		YEAR(Fechahora_ini) = @pAnio

	SET NOCOUNT OFF

END
GO






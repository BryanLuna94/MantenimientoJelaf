CREATE PROC usp_Are_Listar_Autocomplete
(
	@pAre_Nombre VARCHAR(10)
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT TOP 10 Are_Nombre, Are_Codigo 
	FROM Are WITH(NOLOCK)
	WHERE Are_Nombre LIKE @pAre_Nombre + '%'
END
GO


CREATE PROC usp_TBLG_PLATAFORMA_Listar_Autocomplete
(
	@pDescripcion VARCHAR(10)
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT TOP 10 ID_Index, Descripcion
	FROM TBLG_PLATAFORMA WITH(NOLOCK)
	WHERE 
		Descripcion LIKE @pDescripcion + '%'
END
GO


CREATE PROC usp_Tb_Tareas_c_Listar_Autocomplete
(
	@pDescripcion VARCHAR(10)
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT TOP 10 IdTarea, Descripcion
	FROM Tb_Tareas_c WITH(NOLOCK)
	WHERE Descripcion LIKE @pDescripcion + '%'
END
GO


CREATE PROC usp_Ben_Listar_Autocomplete
(
	@pDescripcion VARCHAR(10)
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT TOP 10 Ben_Codigo, Ben_Nombre
	FROM Ben WITH(NOLOCK)
	WHERE Ben_Nombre LIKE @pDescripcion + '%'
END
GO

CREATE PROC usp_PlanAccion_Listar_Autocomplete
(
	@pDescripcion VARCHAR(10)
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT TOP 10 IdPlan, PlanAccion
	FROM tb_PlanAccionC WITH(NOLOCK)
	WHERE PlanAccion LIKE @pDescripcion + '%'
END
GO

CREATE PROC usp_PlanAccion_ObtenerPorId
(
	@pIdPlan INT
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT TOP 10 IdPlan, PlanAccion, fecha_inicio, fecha_fin, usr_codigo, estado, fecha_cierre
	FROM tb_PlanAccionC WITH(NOLOCK)
	WHERE IdPlan = @pIdPlan
END
GO


ALTER TABLE Tb_AuxilioMecanico ALTER COLUMN Fechahora_ini DATETIME
ALTER TABLE Tb_AuxilioMecanico ALTER COLUMN Fechahora_fin DATETIME
GO



CREATE PROC usp_INS_Tb_AuxilioMecanico_Insert
(
	@pCarga varchar(12),
	@pAre_Codigo varchar(6),
	@pAre_Codigo2 varchar(6),
	@pKmt_unidad numeric(18, 0),
	@pKmt_recorrido numeric(18, 0),
	@pMMG varchar(2),
	@pFechahora_ini datetime,
	@pFechahora_fin datetime,
	@pControlable varchar(1),
	@pId_plataforma numeric(35, 0),
	@pIdtarea_c smallint,
	@pFalla varchar(250),
	@pBen_codigo varchar(7),
	@pServicio varchar(250),
	@pKmt_Perdido numeric(18, 0),
	@pCambioTracto smallint,
	@pResponsable varchar(50),
	@pAtencion varchar(50),
	@pCausa varchar(250),
	@pIdPlan int,
	@pID_Tb_AuxilioMecanico int OUTPUT
)
AS
BEGIN

	INSERT [dbo].[Tb_AuxilioMecanico]
	(
		Carga, Are_Codigo, Are_Codigo2, Kmt_unidad, Kmt_recorrido, 
		MMG, Fechahora_ini, Fechahora_fin, Controlable, Id_plataforma, 
		Idtarea_c, Falla, Ben_codigo, Servicio, Kmt_Perdido, 
		CambioTracto, Responsable, Atencion, Causa, IdPlan
	)
	VALUES
	(
		@pCarga, @pAre_Codigo, @pAre_Codigo2, @pKmt_unidad, @pKmt_recorrido, 
		@pMMG, @pFechahora_ini, @pFechahora_fin, @pControlable, @pId_plataforma, 
		@pIdtarea_c, @pFalla, @pBen_codigo, @pServicio, @pKmt_Perdido, 
		@pCambioTracto, @pResponsable, @pAtencion, @pCausa, @pIdPlan
	)

	SET @pID_Tb_AuxilioMecanico = IDENT_CURRENT('Tb_AuxilioMecanico')

END
GO


CREATE PROC usp_UPD_Tb_AuxilioMecanico
(
	@pID_Tb_AuxilioMecanico int,
	@pCarga varchar(12),
	@pAre_Codigo varchar(6),
	@pAre_Codigo2 varchar(6),
	@pKmt_unidad numeric(18, 0),
	@pKmt_recorrido numeric(18, 0),
	@pMMG varchar(2),
	@pFechahora_ini datetime,
	@pFechahora_fin datetime,
	@pControlable varchar(1),
	@pId_plataforma numeric(35, 0),
	@pIdtarea_c smallint,
	@pFalla varchar(250),
	@pBen_codigo varchar(7),
	@pServicio varchar(250),
	@pKmt_Perdido numeric(18, 0),
	@pCambioTracto smallint,
	@pResponsable varchar(50),
	@pAtencion varchar(50),
	@pCausa varchar(250),
	@pIdPlan int
)
AS
BEGIN

	UPDATE [dbo].[Tb_AuxilioMecanico]
	SET
		Carga=@pCarga, 
		Are_Codigo=@pAre_Codigo, 
		Are_Codigo2=@pAre_Codigo2, 
		Kmt_unidad=@pKmt_unidad, 
		Kmt_recorrido=@pKmt_recorrido, 
		MMG=@pMMG, 
		Fechahora_ini=@pFechahora_ini, 
		Fechahora_fin=@pFechahora_fin, 
		Controlable=@pControlable, 
		Id_plataforma=@pId_plataforma, 
		Idtarea_c=@pIdtarea_c, 
		Falla=@pFalla, 
		Ben_codigo=@pBen_codigo, 
		Servicio=@pServicio, 
		Kmt_Perdido=@pKmt_Perdido, 
		CambioTracto=@pCambioTracto, 
		Responsable=@pResponsable, 
		Atencion=@pAtencion, 
		Causa=@pCausa, 
		IdPlan=@pIdPlan
	WHERE
		ID_Tb_AuxilioMecanico = @pID_Tb_AuxilioMecanico

END
GO


CREATE PROC usp_DEL_Tb_AuxilioMecanico
(
	@pID_Tb_AuxilioMecanico int
)
AS
BEGIN

	DELETE FROM [dbo].[Tb_AuxilioMecanico]
	WHERE
		ID_Tb_AuxilioMecanico = @pID_Tb_AuxilioMecanico

END
GO


CREATE PROC usp_SEL_Tb_AuxilioMecanico
(
	@pID_Tb_AuxilioMecanico int
)
AS
BEGIN

	SELECT 
		ID_Tb_AuxilioMecanico, Carga, Are_Codigo, Are_Codigo2, Kmt_unidad, 
		Kmt_recorrido, MMG, Fechahora_ini, Fechahora_fin, Controlable, 
		Id_plataforma, Idtarea_c, Falla, Ben_codigo, Servicio, 
		Kmt_Perdido, CambioTracto, Responsable, Atencion, Causa, 
		IdPlan
	FROM [dbo].[Tb_AuxilioMecanico]
	WHERE
		ID_Tb_AuxilioMecanico = @pID_Tb_AuxilioMecanico

END
GO


CREATE PROC usp_LIS_Tb_AuxilioMecanico
(
	@pFechahora_ini DATETIME,
	@pFechahora_fin DATETIME,
	@pAre_Codigo VARCHAR(10),
	@pBen_Codigo VARCHAR(10)
)
AS
BEGIN

	SET NOCOUNT ON
	
	SELECT 
		AME.ID_Tb_AuxilioMecanico, AME.Carga, PLA.Are_Nombre AS Bus, CAR.Are_Nombre AS Carreta, 
		Kmt_unidad, Kmt_recorrido, Fechahora_ini, Fechahora_fin,
		Ben_Nombre AS Mecanico
	FROM 
		dbo.Tb_AuxilioMecanico AME WITH(NOLOCK) INNER JOIN
		dbo.Are PLA WITH(NOLOCK) ON AME.Are_Codigo = PLA.Are_Codigo LEFT JOIN
		dbo.Ben WITH(NOLOCK) ON AME.Ben_codigo = Ben.Ben_Codigo LEFT JOIN
		dbo.Are CAR WITH(NOLOCK) ON AME.Are_Codigo2 = CAR.Are_Codigo 
	WHERE
		AME.Fechahora_ini >= @pFechahora_ini AND
		AME.Fechahora_fin <= @pFechahora_fin AND
		(AME.Are_Codigo = @pAre_Codigo OR @pAre_Codigo = '') AND
		(AME.Ben_codigo = @pBen_Codigo OR @pBen_Codigo = '')
		

END
GO

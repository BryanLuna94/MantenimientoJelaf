ALTER PROC LIS_Tb_Informe_Admin
	@TIPOU INT,
	@NINFORME int,
	@FECH_INI date,
	@FECH_FIN date,
	@ORDEN VARCHAR(1)
AS
SET NOCOUNT ON

BEGIN

	SELECT 
		I.IdInforme, 
		IsNull(I.NumeroInforme, 0) NumeroInforme, 
		A.Are_Observacion Interno,
		 A.Are_Nombre Placa, 
		I.ChoferEntrega CodChofer, 
		B.Ben_Nombre Chofer, 
		Ofi.Ofi_Nombre Oficina, 
		I.Fecha,
		U.Usr_Nombre, 
		(Case TipoInforme When 1 Then 'C' When 0 Then 'P' End) Tipo, ISNULL(I.FechaCierre, '') FechaCierre,P.TIPO TIPOU 
	FROM 
		tb_Informe I 
		INNER JOIN PROGRAMACION P  ON CAST(I.NumeroInforme AS VARCHAR(20)) = p.NumeroMantenimiento
		INNER JOIN Are A ON I.Are_Codigo = A.Are_Codigo
		INNER JOIN Ben B ON I.ChoferEntrega = B.Ben_Codigo
		INNER JOIN Usr U ON I.UsuarioRegistro = U.Usr_Codigo
		INNER JOIN Ofi ON  Cast(I.Ofi_Codigo AS int) = Ofi.Ofi_Codigo
	WHERE 
		TipoInforme = 1 And I.Estado <> 0 And P.TIPO <> @TIPOU And (IsNull(I.NumeroInforme, 0) = @NINFORME Or @NINFORME = 0)
		And (I.Fecha Between @FECH_INI And @FECH_FIN) 
	Order By Case @ORDEN When 'I' Then I.IdInforme When 'B' Then A.Are_Observacion WHEN 'F' then I.Fecha End

END
GO


ALTER PROC LIS_Tb_Informe_User
	@TIPOU INT,
	@NINFORME int,
	@FECH_INI date,
	@FECH_FIN date,
	@USR_CODIGO int,
	@ORDEN VARCHAR(1)
AS
SET NOCOUNT ON

BEGIN

	SELECT 
		I.IdInforme, IsNull(I.NumeroInforme, 0) NumeroInforme, A.Are_Observacion Interno, A.Are_Nombre Placa, 
		I.ChoferEntrega CodChofer, B.Ben_Nombre Chofer, Ofi.Ofi_Nombre Oficina, I.Fecha, U.Usr_Nombre, 
		(Case TipoInforme When 1 Then 'C' When 0 Then 'P' End) Tipo, ISNULL(I.FechaCierre, '') FechaCierre,P.TIPO TIPOU 
	FROM 
		tb_Informe I 
		INNER JOIN PROGRAMACION P  ON CAST(I.NumeroInforme AS VARCHAR(20)) = p.NumeroMantenimiento
		INNER JOIN Are A ON I.Are_Codigo = A.Are_Codigo
		INNER JOIN Ben B ON I.ChoferEntrega = B.Ben_Codigo
		INNER JOIN Usr U ON I.UsuarioRegistro = U.Usr_Codigo
		INNER JOIN Ofi ON  Cast(I.Ofi_Codigo AS int) = Ofi.Ofi_Codigo
	WHERE 
		TipoInforme = 1 And I.Estado <> 0 And P.TIPO <> @TIPOU And (IsNull(I.NumeroInforme, 0) = @NINFORME Or @NINFORME = 0)
		 And (I.Fecha Between @FECH_INI And @FECH_FIN) 
		  and UsuarioRegistro=@USR_CODIGO 

	Order By Case @ORDEN When 'I' Then I.IdInforme When 'B' Then A.Are_Observacion WHEN 'F' then I.Fecha End
END
GO


ALTER PROC LIS_Tb_Informe_Sucursal
	@TIPOU INT,
	@NINFORME int,
	@FECH_INI date,
	@FECH_FIN date, 
	@USR_CODIGO int,
	@ORDEN VARCHAR(1)
AS
SET NOCOUNT ON

BEGIN

	SELECT 
		I.IdInforme, IsNull(I.NumeroInforme, 0) NumeroInforme, A.Are_Observacion Interno, A.Are_Nombre Placa, 
		I.ChoferEntrega CodChofer, B.Ben_Nombre Chofer, Ofi.Ofi_Nombre Oficina, I.Fecha, U.Usr_Nombre, 
		(Case TipoInforme When 1 Then 'C' When 0 Then 'P' End) Tipo, ISNULL(I.FechaCierre, '') FechaCierre,P.TIPO TIPOU 
	FROM 
		tb_Informe I  
		INNER JOIN PROGRAMACION P  ON CAST(I.NumeroInforme AS VARCHAR(20)) = p.NumeroMantenimiento
		INNER JOIN Are A ON I.Are_Codigo = A.Are_Codigo
		INNER JOIN Ben B ON I.ChoferEntrega = B.Ben_Codigo
		INNER JOIN Usr U ON I.UsuarioRegistro = U.Usr_Codigo
		INNER JOIN Ofi ON  Cast(I.Ofi_Codigo AS int) = Ofi.Ofi_Codigo
	WHERE 
		TipoInforme = 1 And I.Estado <> 0 And P.TIPO <> @TIPOU And (IsNull(I.NumeroInforme, 0) = @NINFORME Or @NINFORME = 0)
		And (I.Fecha Between @FECH_INI And @FECH_FIN) 
		and UsuarioRegistro in (select usr_codigo from Usr where CODI_SUCURSAL in (select  codi_sucursal from usr where Usr_Codigo=@USR_CODIGO))

	Order By Case @ORDEN When 'I' Then I.IdInforme When 'B' Then A.Are_Observacion WHEN 'F' then I.Fecha End
END
GO

CREATE PROC usp_SEL_tb_SolicitudRevisionTecnica_C_DatosInforme
(
	@pIdInforme INT
)
AS
BEGIN

	SELECT 
		IdSolicitudRevision, KIlometraje 
	FROM tb_SolicitudRevisionTecnica_C 
	WHERE 
		IdInforme = @pIdInforme

END
GO

CREATE PROC usp_tb_ControlUnidadTipoMantenimiento_Anular
(
	@pIdTipMan INT,
	@pARE_CODIGO VARCHAR(10)
)
AS
BEGIN

Update 
	tb_ControlUnidadTipoMantenimiento 
Set 
	NumeroInforme = '', 
	FechaHora = '01/01/1900' 
Where 
	Cod_Unid = @pARE_CODIGO  
	And IdTipMan = @pIdTipMan

END
GO

CREATE PROC usp_Tb_Tareas_Listar_Autocomplete  
(  
 @pDescripcion VARCHAR(10)  
)  
AS  
BEGIN  
   
 SET NOCOUNT ON  
  
 SELECT TOP 10 IdTarea, Descripcion  
 FROM Tb_Tareas WITH(NOLOCK)  
 WHERE Descripcion LIKE @pDescripcion + '%'  
END 
GO

CREATE PROC usp_tb_tareamecanicos_ayudante_List
(
	@pIdTareaMecanicos INT,
	@pcodmecanico VARCHAR(10)
)
AS
select 
	idayudante,idtareamecanicos,codmecanico,observacion 
from 
	tb_tareamecanicos_ayudante
where 
	idtareamecanicos=@pIdTareaMecanicos AND
	(codmecanico = @pcodmecanico OR @pcodmecanico = '')
go

CREATE PROC usp_tb_tareamecanicos_ayudante_insert  
(  
	 @pidtareamecanicos INT,  
	 @pcodmecanico VARCHAR(10),  
	 @pobservacion VARCHAR(50)  
)  
AS  
BEGIN  
  
 insert into tb_tareamecanicos_ayudante  
 (idtareamecanicos, codmecanico, Observacion)   
 VALUES  
 (@pidtareamecanicos, @pcodmecanico, @pObservacion)   
  
END  
GO

CREATE PROC usp_tb_tareamecanicos_ayudante_delete
(
	@pidayudante INT
)
AS
BEGIN

	delete from tb_tareamecanicos_ayudante
	where idayudante = @pidayudante

END
GO

 CREATE PROC usp_Mecanicos_Listar_Autocomplete  
(  
	@pDescripcion VARCHAR(10)  
)  
AS  
BEGIN  
   
 SET NOCOUNT ON  
  
 SELECT TOP 10 COD_TIP, NOM_TIP
 FROM Tablas WITH(NOLOCK)  
 WHERE NOM_TIP LIKE @pDescripcion + '%'  AND
	Cod_Tab = '11'
END  
GO

 CREATE PROC usp_Almacenes_Listar_Autocomplete  
(  
	@pSucursal INT 
)  
AS  
BEGIN  
   
 SET NOCOUNT ON  
  
 SELECT Tbg_Codigo,Tbg_Descripcion 
 FROM Tbg WITH(NOLOCK)  
 WHERE Tbg_Tabla='17' 
	And Tbg_TbgEstado='00' 
	and CAST(tbg_codigo AS INT)=@pSucursal 
END  
GO

CREATE PROC usp_Mer_Buscar
(
	@pCodi_Empresa VARCHAR(2),
	@pidalmacen VARCHAR(2)
)
AS
BEGIN

	SET NOCOUNT ON

	SELECT
		m.MER_NOMBRE as Descripcion, 
		m.Mer_CodOriginal as Original, 
		CAST(MER_MARCA AS VARCHAR(50)) AS Marca,
		CAST(M.MER_CODIGO AS VARCHAR(18)) AS Codigo,
		UND_SIGLA as Abr,
		S.Sto_StockFinal as STOCK 
	FROM 
		mer M inner join 
		sto s on m.Mer_Codigo=s.Mer_Codigo inner join 
		Und U on M.Und_Codigo=U.Und_Codigo
	where 
		S.EMP_CODIGO=@pCodi_Empresa AND S.Sto_Almacen=@pidalmacen 
	ORDER BY m.MER_NOMBRE

	SET NOCOUNT OFF

END
GO

CREATE PROC usp_Tb_CtrlBolsaRepInforme_AgregarBolsa
(
	@idalmacen VARCHAR(2),
	@idtarea INT,
	@idinforme INT
)
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT 
	DISTINCT	
		Ta.idarttar,
		Mer_CodOriginal as Original, 
		MER_NOMBRE as Descripcion,
		CAST(MER_MARCA AS VARCHAR(50)) AS Marca,
		CAST(M.MER_CODIGO AS VARCHAR(18)) AS Codigo,
		UND_SIGLA as Abr,
		Ta.cantidad,
		isnull(Consumido,0) as consumo
	FROM 
		mer M inner join 
		sto s on m.Mer_Codigo=s.Mer_Codigo inner join 
		Und U on M.Und_Codigo=U.Und_Codigo inner Join 
		tb_ArticuloTareas Ta on M.MER_CODIGO=cod_mer left join 
		Tb_CtrlBolsaRepInforme Bolsa on Bolsa.Mer_codigo=M.Mer_codigo and bolsa.idTarea=@idtarea and bolsa.IdInforme=@idinforme 
	WHERE 
		S.Sto_Almacen=@idalmacen and 
		Ta.idTarea=@idtarea 
	ORDER BY MER_NOMBRE

	SET NOCOUNT OFF

END
GO


CREATE procedure [dbo].[Usp_Tb_Infome_Find_TraerCorrectivoPreventivoTractoCarreta]      
(
	@pNumeroInforme NUMERIC,
	@pTipoInforme VARCHAR(1),
	@pTipoU INT
)
AS
BEGIN

	SET NOCOUNT ON      
	    
	SELECT 
		IDINFORME,I.ARE_CODIGO,ARE_NOMBRE,I.Ofi_Codigo,Ofi_Nombre Oficina,Ben_Codigo,Ben_Nombre      
		Cocher,FECHA,hora,OBSERVACION,KMUNIDAD,EstCierre,TipoInforme,are_observacion,isnull(IdUndAlerta,0)as IdUndAlerta,  
		IsNull(NumeroInforme, 0) NumeroInforme, I.Solicitante, P.tipo AS TIPOU
	FROM 
		Tb_Informe I INNER JOIN 
		ARE A ON I.Are_Codigo= A.Are_Codigo INNER JOIN 
		OFI O ON O.Ofi_Codigo=right('000'+cast(I.Ofi_Codigo as varchar),3) INNER JOIN 
		ben ON Ben_Codigo=ChoferEntrega INNER JOIN 
		PROGRAMACION P ON CAST(I.NumeroInforme AS VARCHAR(20)) = p.NumeroOrden  
	WHERE      
		(I.Estado=1) and 
		(I.NumeroInforme=@pNumeroInforme) and
		(I.TipoInforme =@pTipoInforme) AND
		(P.tipo = @pTipoU)
END
GO   

USE [BDALM2019_NIC]
GO


CREATE TABLE [dbo].[tb_Configuracion_Mantenimientos](
	[Codigo] [int] NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[Valor] [varchar](300) NOT NULL,
 CONSTRAINT [PK_tb_Configuracion_Mantenimientos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT [dbo].[tb_Configuracion_Mantenimientos] ([Codigo], [Descripcion], [Valor]) VALUES (1, N'MAXIMO ODOMETRO EN REPORTE DE FALLAS', N'100')
GO
INSERT [dbo].[tb_Configuracion_Mantenimientos] ([Codigo], [Descripcion], [Valor]) VALUES (2, N'MINIMO ODOMETRO EN REPORTE DE FALLAS', N'100')
GO

CREATE PROC usp_SEL_tb_Configuracion_Mantenimientos
(
	@pCodigo INT
)
AS
BEGIN

	SELECT Valor
	FROM
		dbo.tb_Configuracion_Mantenimientos
	WHERE Codigo = @pCodigo

END
GO

CREATE PROC usp_UPD_Are_OdometroAcumulado
(
	@pOdometro NUMERIC,
	@pAre_Codigo VARCHAR(5)
)
AS
BEGIN

	Update Are 
	Set OdometroAcumulado = @pOdometro 
	Where Are_Codigo = @pAre_Codigo

END
GO

CREATE PROC usp_UPD_tb_SolicitudRevisionTecnica_C_CorrelativoInterno
(
	@pCorrelativoInterno VARCHAR(10),
	@pIdSolicitudRevision VARCHAR(5)
)
AS
BEGIN

	UPDATE tb_SolicitudRevisionTecnica_C 
	SET correlativo2=@pCorrelativoInterno  
	WHERE IdSolicitudRevision =   @pIdSolicitudRevision

END
GO


------------




create proc SEL_maxsolxChofer 
 @Ben_Codigo  VarChar(30)
  as
select max(IdSolicitudRevision) from tb_SolicitudRevisionTecnica_C where idchofer=@Ben_Codigo
 go

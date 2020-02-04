CREATE PROC usp_LIS_VW_ODMs
(
	@pnumeroinforme DECIMAL,
	@pben_codigo VARCHAR(10)
)
AS
BEGIN

	select 
		ODM_Codigo , ODMd_Codigo, Cod_Sistema, Cod_Componente, Ben_Codigo_Solicitante, 
		BenNombreSolicitante, ODM_FechMovimiento, Mer_Codigo, Mer_CodOriginal, 
		Mer_Nombre, ODMd_Cantidad, ODMd_Can_Atendida AS Atendida, Id_CtrlBolsaRepInforme 
	FROM 
		VW_ODMs 
	WHERE 
		ODM_INFORME=@pnumeroinforme AND 
		Ben_Codigo_Solicitante=@pben_codigo

END
GO


CREATE PROC usp_DEL_Tb_CtrlBolsaRepInforme
(
	@pidCtrlBolsaRepInforme INT
)
AS
BEGIN

	DELETE from Tb_CtrlBolsaRepInforme where Id_CtrlBolsaRepInforme=@pidCtrlBolsaRepInforme

END
GO



CREATE PROC usp_SEL_tb_ODM_ValidaExiste
(
	 @pBen_Codigo_Solicitante as varchar (015),  
	 @pODM_Informe            as decimal (18, 0)  
)
AS
BEGIN

	SELECT ODM_Codigo
	FROM dbo.tb_ODM
	WHERE 
		ODM_Informe = @pODM_Informe AND
		Ben_Codigo_Solicitante = @pBen_Codigo_Solicitante

END
GO

CREATE PROC usp_Mer_Listar_Autocomplete 
(  
	 @pCodi_Empresa VARCHAR(2),  
	 @pidalmacen VARCHAR(2),
	 @pfiltro VARCHAR(60)
)  
AS  
BEGIN  
  
	 SET NOCOUNT ON  
  
	 SELECT  TOP 15
		CAST(M.MER_CODIGO AS VARCHAR(18)) AS Codigo,  
		m.MER_NOMBRE + ' ' +  CAST(MER_MARCA AS VARCHAR(50)) + ' ' + UND_SIGLA + ' ' + m.Mer_CodOriginal as Descripcion   
	 FROM   
		mer M INNER JOIN  
		sto s on m.Mer_Codigo=s.Mer_Codigo INNER JOIN 
		Und U on M.Und_Codigo=U.Und_Codigo  
	 where   
		S.EMP_CODIGO=@pCodi_Empresa AND 
		S.Sto_Almacen=@pidalmacen   AND
		(m.MER_NOMBRE LIKE @pfiltro + '%' 
		OR m.Mer_CodOriginal LIKE @pfiltro + '%')
	 ORDER BY 
		m.MER_NOMBRE  
  
	 SET NOCOUNT OFF  
  
END  
GO

CREATE PROC usp_tb_SolicitudRevisionTecnica_C_Anular
(
	@pIdSolicitudRevision VARCHAR(20)
)
AS
BEGIN

	UPDATE tb_SolicitudRevisionTecnica_C SET ESTADO='9' WHERE IdSolicitudRevision=@pIdSolicitudRevision

END
GO


CREATE PROC usp_tb_Informe_Anular
(
	@pIdinforme INT
)
AS
BEGIN

	UPDATE TB_INFORME set Estado=0 WHERE IdInforme =@pIdinforme
	UPDATE XTEM set Tem_Estado=99 WHERE Tem_Codigo_2 =@pIdinforme
	UPDATE tb_ODM set ODM_Estado=99 WHERE ODM_Informe =@pIdinforme

END
GO

  



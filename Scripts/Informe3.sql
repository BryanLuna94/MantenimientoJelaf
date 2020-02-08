
CREATE PROC usp_SEL_tb_Informe_BuscarPorNumero
(
	@pNumeroInforme NUMERIC(18,0),
	@pTipo VARCHAR(1)
)
AS
BEGIN
	
	SELECT 
		IdInforme, Are_Codigo, ChoferEntrega, KmUnidad, Ofi_Codigo, 
		Fecha, CostoManoObra, ServicioTerceros, CostoRepuestos, Observacion, 
		UsuarioRegistro, FechaRegistro, Estado, EstCierre, TipoInforme, 
		IdUndAlerta, IdPlanEjecucionTarea, hora, NumeroInforme, 
		Solicitante, FechaCierre 
	FROM 
		tb_Informe WITH(NOLOCK)
	WHERE 
		NumeroInforme = @pNumeroInforme AND
		TipoInforme = @pTipo AND
		Estado = 1

END
GO

ALTER procedure [dbo].[Usp_Tb_Infome_Find_]      
@id int,      
@e int      
as      
set nocount on      
BEGIN      
 SELECT IDINFORME,I.ARE_CODIGO,ARE_NOMBRE,I.Ofi_Codigo,Ofi_Nombre Oficina,Ben_Codigo,Ben_Nombre      
 Cocher,FECHA,hora,OBSERVACION,KMUNIDAD,EstCierre,TipoInforme,are_observacion,isnull(IdUndAlerta,0)as IdUndAlerta,  
 IsNull(NumeroInforme, 0) NumeroInforme, I.Solicitante, P.TIPO TIPOU
 FROM Tb_Informe I 
 INNER JOIN ARE A ON I.Are_Codigo= A.Are_Codigo      
 INNER JOIN OFI O ON O.Ofi_Codigo=right('000'+cast(I.Ofi_Codigo as varchar),3) 
 inner join ben on Ben_Codigo=ChoferEntrega 
 INNER JOIN PROGRAMACION P ON CAST(I.NumeroInforme AS VARCHAR(20)) = p.NumeroOrden 
 where      
 (I.estado=@e or @e=99) and (IDINFORME=@id or @id=0)      
END
GO
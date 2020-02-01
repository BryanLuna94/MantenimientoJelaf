using System.Threading.Tasks;
using Mantenimiento.BusinessLayer;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Peticiones.Requests;
using Mantenimiento.Entities.Peticiones.Responses;
using Mantenimiento.Entities.Requests.Responses;

namespace Mantenimiento.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMantenimiento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceMantenimiento.svc or ServiceMantenimiento.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMantenimiento : IServiceMantenimiento
    {
        #region BASE

        public Response<BaseResponse> ListUsuariosAutocomplete(string value)
        {
            return BaseLogic.ListUsuariosAutocomplete(value);
        }
        public Response<BaseResponse> ListSistemasAutocomplete(string value)
        {
            return BaseLogic.ListSistemasAutocomplete(value);
        }

        public Response<BaseResponse> ListSubSistemasAutocomplete(string value)
        {
            return BaseLogic.ListSubSistemasAutocomplete(value);
        }

        public Response<BaseResponse> ListTipoMAutocomplete(string value)
        {
            return BaseLogic.ListTipoMAutocomplete(value);
        }
        public Response<BaseResponse> ListEmpresa()
        {
            return BaseLogic.ListEmpresa();
        }

        public Response<BaseResponse> ListFlotaAutocomplete(string value)
        {
            return BaseLogic.ListFlotaAutocomplete(value);
        }
        public Response<BaseResponse> ListPlataformaAutocomplete(string value)
        {
            return BaseLogic.ListPlataformaAutocomplete(value);
        }

        public Response<BaseResponse> ListTareasCAutocomplete(string value)
        {
            return BaseLogic.ListTareasCAutocomplete(value);
        }

        public Response<BaseResponse> ListTareasAutocomplete(string value)
        {
            return BaseLogic.ListTareasAutocomplete(value);
        }

        public Response<BaseResponse> ListBeneficiarioAutocomplete(string value)
        {
            return BaseLogic.ListBeneficiarioAutocomplete(value);
        }
        public Response<BaseResponse> ListPlanAccionAutocomplete(string value)
        {
            return BaseLogic.ListPlanAccionAutocomplete(value);
        }

        public Response<BaseResponse> ListPuntoAtencionAutocomplete(string value)
        {
            return BaseLogic.ListPuntoAtencionAutocomplete(value);
        }

        public Response<BaseResponse> ListMecanicosAutocomplete(string value)
        {
            return BaseLogic.ListMecanicosAutocomplete(value);
        }

        public Response<BaseResponse> ListAlmacenesAutocomplete(string value)
        {
            return BaseLogic.ListAlmacenesAutocomplete(value);
        }

        #endregion

        #region LOGIN

        public async Task<Response<LoginResponse>> Login(string codiUsuario, string Password)
        {
            return await LoginLogic.Login(codiUsuario, Password);
        }
        public Task<Response<PwdResponse>> Actualizapwd(string codiUsuario, string Password)
        {
            return ActualizapwdLogic.Actualizapwd(codiUsuario, Password);
        }

        #endregion

        #region SISTEMAS
        public async Task<Response<SistemasResponse>> ListSistemas(short ID_tb_Sistema_Mant)
        {
            return await SistemasLogic.ListSistemas(ID_tb_Sistema_Mant);
        }

        public async Task<Response<SistemasResponse>> DeleteSistemas(short ID_tb_Sistema_Mant)
        {
            return await SistemasLogic.DeleteSistemas(ID_tb_Sistema_Mant);
        }
        public Response<SistemasResponse> SelectSistemas()
        {
            return SistemasLogic.SelectSistemas();
        }

        public Response<SistemasResponse> IdSistemas()
        {
            return SistemasLogic.IdSistemas();
        }

        public async Task<Response<SistemasResponse>> InsertSistemas(short ID_tb_Sistema_Mant, string Descripcion)
        {
            return await SistemasLogic.InsertSistemas(ID_tb_Sistema_Mant, Descripcion);
        }

        public async Task<Response<SistemasResponse>> UpdateSistemas(short ID_tb_Sistema_Mant, string Descripcion)
        {
            return await SistemasLogic.UpdateSistemas(ID_tb_Sistema_Mant, Descripcion);
        }


        #endregion

        #region ClaseM
        public Response<ClaseMResponse> ListClaseM()
        {
            return ClaseMLogic.ListClaseM();
        }
        public Response<ClaseMResponse> ListClaseMP()
        {
            return ClaseMLogic.ListClaseMP();
        }
        public Response<ClaseMResponse> SelectClaseM(string IdClaseMantenimiento)
        {
            return ClaseMLogic.SelectClaseM(IdClaseMantenimiento);
        }



        public async Task<Response<ClaseMResponse>> DeleteClaseM(string IdClaseMantenimiento)
        {
            return await ClaseMLogic.DeleteClaseM(IdClaseMantenimiento);
        }


        public async Task<Response<ClaseMResponse>> InsertClaseM(string IdClaseMantenimiento, string Descripcion, short NroOrden)
        {
            return await ClaseMLogic.InsertClaseM(IdClaseMantenimiento, Descripcion, NroOrden);
        }

        public async Task<Response<ClaseMResponse>> UpdateClaseM(string IdClaseMantenimiento, string Descripcion, short NroOrden)
        {
            return await ClaseMLogic.UpdateClaseM(IdClaseMantenimiento, Descripcion, NroOrden);
        }


        #endregion


        #region SubSistemas
        public Response<SubSistemasResponse> ListSubSistemas()
        {
            return SubSistemasLogic.ListSubSistemas();
        }
        public Response<SubSistemasResponse> SelectSubSistemas(string ID_tb_SubSistema_Mant)
        {
            return SubSistemasLogic.SelectSubSistemas(ID_tb_SubSistema_Mant);
        }
        public Response<SubSistemasResponse> IdSubSistemas(short ID_tb_Sistema_Mant)
        {
            return SubSistemasLogic.IdSubSistemas(ID_tb_Sistema_Mant);
        }

        public async Task<Response<SubSistemasResponse>> DeleteSubSistemas(string ID_tb_SubSistema_Mant)
        {
            return await SubSistemasLogic.DeleteSubSistemas(ID_tb_SubSistema_Mant);
        }


        public async Task<Response<SubSistemasResponse>> InsertSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion)
        {
            return await SubSistemasLogic.InsertSubSistemas(ID_tb_SubSistema_Mant, ID_tb_Sistema_Mant, Descripcion);
        }

        public async Task<Response<SubSistemasResponse>> UpdateSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion)
        {
            return await SubSistemasLogic.UpdateSubSistemas(ID_tb_SubSistema_Mant, ID_tb_Sistema_Mant, Descripcion);
        }


        #endregion

        #region TIPOM
        public Response<TipoMResponse> ListTipoM()
        {
            return TipoMLogic.ListTipoM();
        }
        public Response<TipoMResponse> SelectTipoM(short IdTipMan)
        {
            return TipoMLogic.SelectTipoM(IdTipMan);
        }
        public Response<TipoMResponse> IdTipoM()
        {
            return TipoMLogic.IdTipoM();
        }

        public async Task<Response<TipoMResponse>> DeleteTipoM(short IdTipMan)
        {
            return await TipoMLogic.DeleteTipoM(IdTipMan);
        }


        public async Task<Response<TipoMResponse>> InsertTipoM(short IdTipMan, string Descripcion, short UsuarioRegistro, string FechaRegistro)
        {
            return await TipoMLogic.InsertTipoM(IdTipMan, Descripcion, UsuarioRegistro, FechaRegistro);
        }

        public async Task<Response<TipoMResponse>> UpdateTipoM(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso, short Dias,
            short DiasAviso, short Horas, short HorasAviso)
        {
            return await TipoMLogic.UpdateTipoM(IdTipMan, Descripcion, Kilometros, KilometrosAviso, Dias,
             DiasAviso, Horas, HorasAviso);
        }

        #endregion

        #region TIPOMP
        public Response<TipoMPResponse> ListTipoMP()
        {
            return TipoMPLogic.ListTipoMP();
        }
        public Response<TipoMPResponse> SelectTipoMP(short IdTipMan)
        {
            return TipoMPLogic.SelectTipoMP(IdTipMan);
        }
        public Response<TipoMPResponse> IdTipoMP()
        {
            return TipoMPLogic.IdTipoMP();
        }

        public async Task<Response<TipoMPResponse>> DeleteTipoMP(short IdTipMan)
        {
            return await TipoMPLogic.DeleteTipoMP(IdTipMan);
        }


        public async Task<Response<TipoMPResponse>> InsertTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso,
            short UsuarioRegistro, string FechaRegistro, short Dias, short DiasAviso, short Horas, short HorasAviso, string cod_marca, int cod_modelo)
        {
            return await TipoMPLogic.InsertTipoMP(IdTipMan, Descripcion, Kilometros, KilometrosAviso, UsuarioRegistro, FechaRegistro, Dias, DiasAviso, Horas, HorasAviso, cod_marca, cod_modelo);
        }

        public async Task<Response<TipoMPResponse>> UpdateTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso, short Dias,
            short DiasAviso, short Horas, short HorasAviso)
        {
            return await TipoMPLogic.UpdateTipoMP(IdTipMan, Descripcion, Kilometros, KilometrosAviso,
                    Dias, DiasAviso, Horas, HorasAviso);
        }

        #endregion

        #region TAREAM
        public Response<TareaMResponse> ListTareaM()
        {
            return TareaMLogic.ListTareaM();
        }
        public Response<TareaMResponse> SelectTareaM(short IdTarea)
        {
            return TareaMLogic.SelectTareaM(IdTarea);
        }
        public Response<TareaMResponse> IdTareaM()
        {
            return TareaMLogic.IdTareaM();
        }

        public async Task<Response<TareaMResponse>> DeleteTareaM(short IdTarea)
        {
            return await TareaMLogic.DeleteTareaM(IdTarea);
        }


        public async Task<Response<TareaMResponse>> InsertTareaM(short IdTarea, short IdTipMan, string Descripcion, short UsuarioRegistro, string FechaRegistro, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            return await TareaMLogic.InsertTareaM(IdTarea, IdTipMan, Descripcion, UsuarioRegistro, FechaRegistro, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);
        }

        public async Task<Response<TareaMResponse>> UpdateTareaM(short IdTarea, short IdTipMan, string Descripcion, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            return await TareaMLogic.UpdateTareaM(IdTarea, IdTipMan, Descripcion, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);
        }

        #endregion

        #region TAREAMP
        public Response<TareaMPResponse> ListTareaMP(short IdTipMan)
        {
            return TareaMPLogic.ListTareaMP(IdTipMan);
        }
        public Response<TareaMPResponse> SelectTareaMP(short IdTarea)
        {
            return TareaMPLogic.SelectTareaMP(IdTarea);
        }
        public Response<TareaMPResponse> IdTareaMP()
        {
            return TareaMPLogic.IdTareaMP();
        }

        public async Task<Response<TareaMPResponse>> DeleteTareaMP(short IdTarea)
        {
            return await TareaMPLogic.DeleteTareaMP(IdTarea);
        }


        public async Task<Response<TareaMPResponse>> InsertTareaMP(short IdTipMan,
            string Descripcion, short UsuarioRegistro, string FechaRegistro, int Flg_Revision,
            int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            return await TareaMPLogic.InsertTareaMP(IdTipMan, Descripcion, UsuarioRegistro,
                    FechaRegistro, Flg_Revision, ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);
        }

        public async Task<Response<TareaMPResponse>> UpdateTareaMP(short IdTarea, short IdTipMan,
            string Descripcion, int Flg_Revision, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant)
        {
            return await TareaMPLogic.UpdateTareaMP(IdTarea, IdTipMan, Descripcion, Flg_Revision,
                ID_tb_Sistema_Mant, ID_tb_SubSistema_Mant);

        }
        #endregion


        #region ARTICULOT
        public Response<ArticuloTResponse> ListArticuloT(short idTarea)
        {
            return ArticuloTLogic.ListArticuloT(idTarea);
        }
        public Response<ArticuloTResponse> SelectArticuloT(short IdArtTar)
        {
            return ArticuloTLogic.SelectArticuloT(IdArtTar);
        }
        public Response<ArticuloTResponse> IdArticuloT()
        {
            return ArticuloTLogic.IdArticuloT();
        }

        public async Task<Response<ArticuloTResponse>> DeleteArticuloT(short IdTarea)
        {
            return await ArticuloTLogic.DeleteArticuloT(IdTarea);
        }


        public async Task<Response<ArticuloTResponse>> InsertArticuloT(short IdTarea,
            short Cod_Mer, short Cantidad, short Orden)
        {
            return await ArticuloTLogic.InsertArticuloT(IdTarea, Cod_Mer, Cantidad, Orden);
        }

        public async Task<Response<ArticuloTResponse>> UpdateArticuloT(short IdArtTar, short IdTarea,
            short Cod_Mer, short Cantidad, short Orden)
        {
            return await ArticuloTLogic.UpdateArticuloT(IdArtTar, IdTarea, Cod_Mer, Cantidad, Orden);

        }
        #endregion

        #region PRODUCTO

        public Response<ProductoResponse> ListProducto(short Index_Compañia, string filtro)
        {
            return ProductoLogic.ListProducto(Index_Compañia, filtro);
        }

        #endregion


        #region MarcaModelo
        public Response<MarcaModeloResponse> ListMarcaModelo()
        {
            return MarcaModeloLogic.ListMarcaModelo();
        }
        #endregion

        #region FALLASD
        public Response<FallasDResponse> SelectFallasD(string ID)
        {
            return FallasDLogic.SelectFallasD(ID);
        }
        public Response<FallasDResponse> IdFallasD()
        {
            return FallasDLogic.IdFallasD();
        }

        public async Task<Response<FallasDResponse>> DeleteFallasD(string ID)
        {
            return await FallasDLogic.DeleteFallasD(ID);
        }


        public async Task<Response<FallasDResponse>> InsertFallasD(string IdSolicitudRevisionD, string IdSolicitudRevision,
            string Observacion, string UsuarioRegistro, string FechaRegistro, string HoraRegistro, int Estado, int IdSistema, int IdObservacion)
        {
            return await FallasDLogic.InsertFallasD(IdSolicitudRevisionD, IdSolicitudRevision, Observacion, UsuarioRegistro, FechaRegistro, HoraRegistro, Estado, IdSistema, IdObservacion);
        }


        public Response<FallasDResponse> SolicitudRevisionBusqueda(string NivelUsuario, string CodSucursal)
        {
            return FallasDLogic.SolicitudRevisionBusqueda(NivelUsuario, CodSucursal);
        }

        public Response<FallasDResponse> SelectSolicitudRevision(string IdsolicitudRevision)
        {
            return FallasDLogic.SelectSolicitudRevision(IdsolicitudRevision);
        }

        public async Task<Response<FallasDResponse>> UpdateSolicitudRevision(FallasDRequest request)
        {
            return await FallasDLogic.UpdateSolicitudRevision(request);
        }

        public Response<FallasDResponse> ObtenerUltimaRevisionChofer(string CodChofer)
        {
            return FallasDLogic.ObtenerUltimaRevisionChofer(CodChofer);
        }

        #endregion

        #region AUXLIOMECANICO


        public Response<AuxilioMecanicoResponse> ListAuxilioMecanico(AuxilioMecanicoRequest request)
        {
            return AuxilioMecanicoLogic.ListAuxilioMecanico(request);
        }
        public Response<AuxilioMecanicoResponse> SelectAuxilioMecanico(int IdAuxilioMecanico)
        {
            return AuxilioMecanicoLogic.SelectAuxilioMecanico(IdAuxilioMecanico);
        }

        public async Task<Response<AuxilioMecanicoResponse>> DeleteAuxilioMecanico(int IdAuxilioMecanico)
        {
            return await AuxilioMecanicoLogic.DeleteAuxilioMecanico(IdAuxilioMecanico);
        }

        public async Task<Response<AuxilioMecanicoResponse>> InsertAuxilioMecanico(AuxilioMecanicoRequest request)
        {
            return await AuxilioMecanicoLogic.InsertAuxilioMecanico(request);
        }

        public async Task<Response<AuxilioMecanicoResponse>> UpdateAuxilioMecanico(AuxilioMecanicoRequest request)
        {
            return await AuxilioMecanicoLogic.UpdateAuxilioMecanico(request);
        }


        #endregion

        #region Mtbf

        public Response<MtbfResponse> ListMtbf_AuxilioMecanico(short anio)
        {
            return MtbfLogic.ListMtbf_AuxilioMecanico(anio);
        }

        public Response<MtbfResponse> ListMtbf(short anio)
        {
            return MtbfLogic.ListMtbf(anio);
        }

        public async Task<Response<MtbfResponse>> InsertMtbf(MtbfRequest request)
        {
            return await MtbfLogic.InsertMtbf(request);
        }

        #endregion

        #region ORDEN MASIVA

        public Response<OrdenMasivaResponse> ListOrdenMasiva(OrdenMasivaRequest request)
        {
            return OrdenMasivaLogic.ListOrdenMasiva(request);
        }

        public async Task<Response<OrdenMasivaResponse>> InsertCorrectivo(OrdenMasivaRequest request)
        {
            return await OrdenMasivaLogic.InsertCorrectivo(request);
        }

        public async Task<Response<OrdenMasivaResponse>> AnularCorrectivo(OrdenMasivaRequest request)
        {
            return await OrdenMasivaLogic.AnularCorrectivo(request);
        }

        public async Task<Response<OrdenMasivaResponse>> InsertPreventivo(OrdenMasivaRequest request)
        {
            return await OrdenMasivaLogic.InsertPreventivo(request);
        }

        public async Task<Response<OrdenMasivaResponse>> AnularPreventivo(OrdenMasivaRequest request)
        {
            return await OrdenMasivaLogic.AnularPreventivo(request);
        }


        #endregion

        #region INFORME


        public Response<InformeResponse> ListInforme(InformeRequest request)
        {
            return InformeLogic.ListInforme(request);
        }
        public Response<InformeResponse> SelectInforme(int IdInforme)
        {
            return InformeLogic.SelectInforme(IdInforme);
        }

        public Response<InformeResponse> SelectInformeCorrectivoPreventivoTractoCarreta(decimal NumeroInforme, string TipoInforme, int TipoU)
        {
            return InformeLogic.SelectInformeCorrectivoPreventivoTractoCarreta(NumeroInforme, TipoInforme, TipoU);
        }

        public Response<InformeResponse> ListInformeTareas(int IdInforme)
        {
            return InformeLogic.ListInformeTareas(IdInforme);
        }

        public async Task<Response<InformeResponse>> DeleteInformeTareas(int IdInforme, int IdTarea)
        {
            return await InformeLogic.DeleteInformeTareas(IdInforme, IdTarea);
        }

        public async Task<Response<InformeResponse>> InsertInformeTareas(InformeRequest request)
        {
            return await InformeLogic.InsertInformeTareas(request);
        }

        public async Task<Response<InformeResponse>> UpdateInformeTareas(InformeRequest request)
        {
            return await InformeLogic.UpdateInformeTareas(request);
        }

        public Response<InformeResponse> ListTareaMecanico(int IdInforme, int IdTarea)
        {
            return InformeLogic.ListTareaMecanico(IdInforme, IdTarea);
        }

        public async Task<Response<InformeResponse>> DeleteTareaMecanico(int IdTareaMecanico)
        {
            return await InformeLogic.DeleteTareaMecanico(IdTareaMecanico);
        }

        public async Task<Response<InformeResponse>> InsertTareaMecanico(InformeRequest request)
        {
            return await InformeLogic.InsertTareaMecanico(request);
        }

        public async Task<Response<InformeResponse>> UpdateTareaMecanico(InformeRequest request)
        {
            return await InformeLogic.UpdateTareaMecanico(request);
        }

        public Response<InformeResponse> ListTareaMecanicosAyudante(int IdTareaMecanico)
        {
            return InformeLogic.ListTareaMecanicosAyudante(IdTareaMecanico);
        }

        public async Task<Response<InformeResponse>> DeleteTareaMecanicosAyudante(int IdAyudante)
        {
            return await InformeLogic.DeleteTareaMecanicosAyudante(IdAyudante);
        }

        public async Task<Response<InformeResponse>> InsertTareaMecanicosAyudante(InformeRequest request)
        {
            return await InformeLogic.InsertTareaMecanicosAyudante(request);
        }

        public Response<InformeResponse> BusquedaArticulo(string CodEmpresa, string CodAlmacen)
        {
            return InformeLogic.BusquedaArticulo(CodEmpresa, CodAlmacen);
        }

        public async Task<Response<InformeResponse>> InsertBolsas(InformeRequest request)
        {
            return await InformeLogic.InsertBolsas(request);
        }

        public Response<InformeResponse> AgregarBolsas(string CodAlmacen, int IdTarea, int IdInforme)
        {
            return InformeLogic.AgregarBolsas(CodAlmacen, IdTarea, IdInforme);
        }

        #endregion
    }
}

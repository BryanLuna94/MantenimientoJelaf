using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Peticiones.Requests;
using Mantenimiento.Entities.Peticiones.Responses;
using Mantenimiento.Entities.Requests.Responses;
using Mantenimiento.Utility;

namespace Mantenimiento.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceMantenimiento" in both code and config file together.
    [ServiceContract]
    public interface IServiceMantenimiento
    {
        #region BASE

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListUsuariosAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListUsuariosAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListSistemasAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListSistemasAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListSubSistemasAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListSubSistemasAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTipoMAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListTipoMAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListEmpresa", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListEmpresa();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListFlotaAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListFlotaAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListPlataformaAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListPlataformaAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareasCAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListTareasCAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareasAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListTareasAutocomplete(string cod_bus, string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareasPreventivoAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListTareasPreventivoAutocomplete(string cod_bus, string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListBeneficiarioAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListBeneficiarioAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListPlanAccionAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListPlanAccionAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListPuntoAtencionAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListPuntoAtencionAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListMecanicosAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListMecanicosAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListAlmacenesAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListAlmacenesAutocomplete(string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListArticulosAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListArticulosAutocomplete(string idEmpresa, string idAlmacen, string value);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTipoUnidadAutocomplete", ResponseFormat = WebMessageFormat.Json)]
        Response<BaseResponse> ListTipoUnidadAutocomplete(string value);

        #endregion

        #region LOGIN

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "Login", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<LoginResponse>> Login(string codiUsuario, string Password);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "Actualizapwd", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<PwdResponse>> Actualizapwd(string codiUsuario, string Password);
        #endregion

        #region SISTEMAS


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<SistemasResponse>> ListSistemas(short ID_tb_Sistema_Mant);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<SistemasResponse>> DeleteSistemas(short ID_tb_Sistema_Mant);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectSistemas", ResponseFormat = WebMessageFormat.Json)]
        Response<SistemasResponse> SelectSistemas();


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdSistemas", ResponseFormat = WebMessageFormat.Json)]
        Response<SistemasResponse> IdSistemas();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<SistemasResponse>> InsertSistemas(short ID_tb_Sistema_Mant,string Descripcion);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<SistemasResponse>> UpdateSistemas(short ID_tb_Sistema_Mant,string Descripcion);

        #endregion

        #region CLASEM


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListClaseM", ResponseFormat = WebMessageFormat.Json)]
        Response<ClaseMResponse> ListClaseM();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListClaseMP", ResponseFormat = WebMessageFormat.Json)]
        Response<ClaseMResponse> ListClaseMP();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListClaseMPFiltro", ResponseFormat = WebMessageFormat.Json)]
        Response<ClaseMResponse> ListClaseMPFiltro(ClaseMResponse request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectClaseM", ResponseFormat = WebMessageFormat.Json)]
        Response<ClaseMResponse> SelectClaseM(string IdClaseMantenimiento);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteClaseM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<ClaseMResponse>> DeleteClaseM(string IdClaseMantenimiento);

 
        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertClaseM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<ClaseMResponse>> InsertClaseM(string IdClaseMantenimiento, string Descripcion,short NroOrden);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateClaseM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<ClaseMResponse>> UpdateClaseM(string IdClaseMantenimiento, string Descripcion,short NroOrden);

        #endregion

        #region SUBSISTEMAS


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListSubSistemas", ResponseFormat = WebMessageFormat.Json)]
        Response<SubSistemasResponse> ListSubSistemas();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectSubSistemas", ResponseFormat = WebMessageFormat.Json)]
        Response<SubSistemasResponse> SelectSubSistemas(string ID_tb_SubSistema_Mant);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdSubSistemas", ResponseFormat = WebMessageFormat.Json)]
        Response<SubSistemasResponse> IdSubSistemas(short ID_tb_Sistema_Mant);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteSubSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<SubSistemasResponse>> DeleteSubSistemas(string ID_tb_SubSistema_Mant);


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertSubSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<SubSistemasResponse>> InsertSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateSubSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<SubSistemasResponse>> UpdateSubSistemas(string ID_tb_SubSistema_Mant, short ID_tb_Sistema_Mant, string Descripcion);

        #endregion

        #region TIPOM


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTipoM", ResponseFormat = WebMessageFormat.Json)]
        Response<TipoMResponse> ListTipoM();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectTipoM", ResponseFormat = WebMessageFormat.Json)]
        Response<TipoMResponse> SelectTipoM(short IdTipMan);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdTipoM", ResponseFormat = WebMessageFormat.Json)]
        Response<TipoMResponse> IdTipoM();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteTipoM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TipoMResponse>> DeleteTipoM(short IdTipMan);


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertTipoM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TipoMResponse>> InsertTipoM(short IdTipMan, string Descripcion, short UsuarioRegistro, string FechaRegistro);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateTipoM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TipoMResponse>> UpdateTipoM(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso, short Dias,
            short DiasAviso, short Horas, short HorasAviso);

        #endregion

        #region TipoMP


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdTipoMP", ResponseFormat = WebMessageFormat.Json)]
        Response<TipoMPResponse> IdTipoMP();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTipoMP", ResponseFormat = WebMessageFormat.Json)]
        Response<TipoMPResponse> ListTipoMP();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTipoMPFiltro", ResponseFormat = WebMessageFormat.Json)]
        Response<TipoMPResponse> ListTipoMPFiltro(TipoMPResponse request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectTipoMP", ResponseFormat = WebMessageFormat.Json)]
        Response<TipoMPResponse> SelectTipoMP(short IdTipMan);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteTipoMP", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TipoMPResponse>> DeleteTipoMP(short IdTipMan);


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertTipoMP", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TipoMPResponse>> InsertTipoMP(short IdTipMan, string Descripcion, decimal Kilometros,
            decimal KilometrosAviso, short UsuarioRegistro, string FechaRegistro, short Dias, short DiasAviso,
            short Horas, short HorasAviso, string cod_marca, int cod_modelo,short Meses, short MesesAviso);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateTipoMP", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TipoMPResponse>> UpdateTipoMP(short IdTipMan, string Descripcion, decimal Kilometros, decimal KilometrosAviso, short Dias,
            short DiasAviso, short Horas, short HorasAviso, short Meses, short MesesAviso);

        #endregion

        #region TAREAM

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareaM", ResponseFormat = WebMessageFormat.Json)]
        Response<TareaMResponse> ListTareaM();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareaSistema", ResponseFormat = WebMessageFormat.Json)]
        Response<TareaMResponse> ListTareaSistema(string AreCodigo, string IdClaseMantenimiento);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectTareaM", ResponseFormat = WebMessageFormat.Json)]
        Response<TareaMResponse> SelectTareaM(short IdTarea);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdTareaM", ResponseFormat = WebMessageFormat.Json)]
        Response<TareaMResponse> IdTareaM();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteTareaM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TareaMResponse>> DeleteTareaM(short IdTarea);


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertTareaM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TareaMResponse>> InsertTareaM(short IdTarea,short IdTipMan, string Descripcion, short UsuarioRegistro, string FechaRegistro, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateTareaM", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TareaMResponse>> UpdateTareaM(short IdTarea, short IdTipMan, string Descripcion, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant);

        #endregion

        #region TAREAMP

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdTareaMP", ResponseFormat = WebMessageFormat.Json)]
        Response<TareaMPResponse> IdTareaMP();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareaMP", ResponseFormat = WebMessageFormat.Json)]
        Response<TareaMPResponse> ListTareaMP(short IdTipMan);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectTareaMP", ResponseFormat = WebMessageFormat.Json)]
        Response<TareaMPResponse> SelectTareaMP(short IdTarea);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertTareaMP", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TareaMPResponse>> InsertTareaMP(short IdTipMan, string Descripcion, short UsuarioRegistro, string FechaRegistro, int Flg_Revision, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateTareaMP", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TareaMPResponse>> UpdateTareaMP(short IdTarea, short IdTipMan, string Descripcion, int Flg_Revision, int ID_tb_Sistema_Mant, string ID_tb_SubSistema_Mant);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteTareaMP", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<TareaMPResponse>> DeleteTareaMP(short IdTarea);

        #endregion

        #region ARTICULOT

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdArticuloT", ResponseFormat = WebMessageFormat.Json)]
        Response<ArticuloTResponse> IdArticuloT();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListArticuloT", ResponseFormat = WebMessageFormat.Json)]
        Response<ArticuloTResponse> ListArticuloT(short IdTarea);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectArticuloT", ResponseFormat = WebMessageFormat.Json)]
        Response<ArticuloTResponse> SelectArticuloT(short IdArtTar);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertArticuloT", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<ArticuloTResponse>> InsertArticuloT(short IdTarea, short Cod_Mer, short Cantidad, short Orden);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateArticuloT", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<ArticuloTResponse>> UpdateArticuloT(short IdArtTar, short IdTarea, short Cod_Mer, short Cantidad, short Orden);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteArticuloT", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<ArticuloTResponse>> DeleteArticuloT(short IdArtTar);

        #endregion

        #region PRODUCTO

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListProducto", ResponseFormat = WebMessageFormat.Json)]
        Response<ProductoResponse> ListProducto(short Index_Compañia, string filtro);


        #endregion

        #region MARCAMODELO

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListMarcaModelo", ResponseFormat = WebMessageFormat.Json)]
        Response<MarcaModeloResponse> ListMarcaModelo();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListMarcaModeloFiltro", ResponseFormat = WebMessageFormat.Json)]
        Response<MarcaModeloResponse> ListMarcaModeloFiltro(MarcaModeloResponse request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListModeloBuses", ResponseFormat = WebMessageFormat.Json)]
        Response<MarcaModeloResponse> ListModeloBuses();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListMarcaBuses", ResponseFormat = WebMessageFormat.Json)]
        Response<MarcaModeloResponse> ListMarcaBuses();

        #endregion

        #region FALLASD

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectFallasD", ResponseFormat = WebMessageFormat.Json)]
        Response<FallasDResponse> SelectFallasD(string ID);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectFallasPorInforme", ResponseFormat = WebMessageFormat.Json)]
        Response<FallasDResponse> SelectFallasPorInforme(decimal IdInforme);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "IdFallasD", ResponseFormat = WebMessageFormat.Json)]
        Response<FallasDResponse> IdFallasD();

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteFallasD", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<FallasDResponse>> DeleteFallasD(string ID);


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertFallasD", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<FallasDResponse>> InsertFallasD(string IdSolicitudRevisionD, string IdSolicitudRevision, string Observacion,
            string UsuarioRegistro, string FechaRegistro, string HoraRegistro, int Estado,int IdSistema, int IdObservacion);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SolicitudRevisionBusqueda", ResponseFormat = WebMessageFormat.Json)]
        Response<FallasDResponse> SolicitudRevisionBusqueda(string NivelUsuario, string CodSucursal);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectSolicitudRevision", ResponseFormat = WebMessageFormat.Json)]
        Response<FallasDResponse> SelectSolicitudRevision(string IdsolicitudRevision);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateSolicitudRevision", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<FallasDResponse>> UpdateSolicitudRevision(FallasDRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ObtenerUltimaRevisionChofer", ResponseFormat = WebMessageFormat.Json)]
        Response<FallasDResponse> ObtenerUltimaRevisionChofer(string CodChofer);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "AnularSolicitudRevision", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<FallasDResponse>> AnularSolicitudRevision(string IdSolicitudRevision);

        #endregion

        #region AUXILIOMECANICO


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListAuxilioMecanicoP", ResponseFormat = WebMessageFormat.Json)]
        Response<AuxilioMecanicoResponse> ListAuxilioMecanico(AuxilioMecanicoRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectAuxilioMecanico", ResponseFormat = WebMessageFormat.Json)]
        Response<AuxilioMecanicoResponse> SelectAuxilioMecanico(int IdAuxilioMecanico);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteAuxilioMecanico", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<AuxilioMecanicoResponse>> DeleteAuxilioMecanico(int IdAuxilioMecanico);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertAuxilioMecanico", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<AuxilioMecanicoResponse>> InsertAuxilioMecanico(AuxilioMecanicoRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateAuxilioMecanico", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<AuxilioMecanicoResponse>> UpdateAuxilioMecanico(AuxilioMecanicoRequest request);

        #endregion

        #region MTBF


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListMtbf_AuxilioMecanico", ResponseFormat = WebMessageFormat.Json)]
        Response<MtbfResponse> ListMtbf_AuxilioMecanico(short anio);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListMtbf", ResponseFormat = WebMessageFormat.Json)]
        Response<MtbfResponse> ListMtbf(short anio);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertMtbf", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<MtbfResponse>> InsertMtbf(MtbfRequest request);

        #endregion

        #region ORDEN MASIVA

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListOrdenMasiva", ResponseFormat = WebMessageFormat.Json)]
        Response<OrdenMasivaResponse> ListOrdenMasiva(OrdenMasivaRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareasPendientes", ResponseFormat = WebMessageFormat.Json)]
        Response<OrdenMasivaResponse> ListTareasPendientes(string are_codigo);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListAreBus", ResponseFormat = WebMessageFormat.Json)]
        Response<OrdenMasivaResponse> ListAreBus(string are_codigo,string codigo_programacion_real);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertCorrectivo", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<OrdenMasivaResponse>> InsertCorrectivo(OrdenMasivaRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertTareasSistemas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<OrdenMasivaResponse>> InsertTareasSistemas(TareaSistemaRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "AnularCorrectivo", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<OrdenMasivaResponse>> AnularCorrectivo(OrdenMasivaRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertPreventivo", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<OrdenMasivaResponse>> InsertPreventivo(OrdenMasivaRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "AnularPreventivo", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<OrdenMasivaResponse>> AnularPreventivo(OrdenMasivaRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectInformePorNumero", ResponseFormat = WebMessageFormat.Json)]
        Response<OrdenMasivaResponse> SelectInformePorNumero(decimal NumeroInforme, string Tipo);

        #endregion

        #region INFORME


        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListInforme", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListInforme(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListInformeTareasBackLog", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListInformeTareasBackLog(string IdUnidad, string Tipo);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectInforme", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> SelectInforme(int IdInforme);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "SelectInformeCorrectivoPreventivoTractoCarreta", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> SelectInformeCorrectivoPreventivoTractoCarreta(decimal NumeroInforme, string TipoInforme, int TipoU);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListInformeTareas", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListInformeTareas(int IdInforme);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListInformeOrdenMantenimiento", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListInformeOrdenMantenimiento(int IdInforme);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteInformeTareas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> DeleteInformeTareas(int IdInforme, int IdTarea, int IdTipMan, string AreCodigo);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "AnularInforme", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> AnularInforme(int IdInforme);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertInformeTareas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> InsertInformeTareas(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateInformeTareas", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> UpdateInformeTareas(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateInformeTareasEstado", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> UpdateInformeTareasEstado(int IdInforme, int IdTarea, int Estado);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateInformeTareasReasignarInforme", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> UpdateInformeTareasReasignarInforme(int IdInformeNuevo, int IdInformeAnterior, int IdTarea);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareaMecanico", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListTareaMecanico(int IdInforme, int IdTarea);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteTareaMecanico", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> DeleteTareaMecanico(int IdTareaMecanico);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertTareaMecanico", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> InsertTareaMecanico(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateTareaMecanico", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> UpdateTareaMecanico(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListTareaMecanicosAyudante", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListTareaMecanicosAyudante(int IdTareaMecanico);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteTareaMecanicosAyudante", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> DeleteTareaMecanicosAyudante(int IdAyudante);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertTareaMecanicosAyudante", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> InsertTareaMecanicosAyudante(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "BusquedaArticulo", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> BusquedaArticulo(string CodEmpresa, string CodAlmacen);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "InsertBolsa", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> InsertBolsa(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "AgregarBolsas", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> AgregarBolsas(InformeRequest request);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListBolsas", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListBolsas(decimal IdInforme, string Ben_Codigo);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "GET", UriTemplate = "ListBolsasPorInforme", ResponseFormat = WebMessageFormat.Json)]
        Response<InformeResponse> ListBolsasPorInforme(decimal IdInforme);

        [OperationContract, FaultContract(typeof(ServiceErrorResponse))]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteBolsa", ResponseFormat = WebMessageFormat.Json)]
        Task<Response<InformeResponse>> DeleteBolsa(InformeRequest request);

        #endregion
    }
}

using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Utility;
using Mantenimiento.Entities.Peticiones.Responses;
using Mantenimiento.Entities.Objects.Filters;
using Mantenimiento.Entities.Peticiones.Requests;
using Mantenimiento.Entities.Objects.Lists;
using System.Transactions;

namespace Mantenimiento.BusinessLayer
{
    public static class InformeLogic
    {
        public static Response<InformeResponse> ListInforme(InformeRequest request)
        {
            try
            {
                Response<InformeResponse> response;
                List<InformeList> List;
                InformeFilter objFiltro;

                objFiltro = request.Filtro;

                List = new List<InformeList>();

                if (objFiltro.SoloMiUsuario)
                {
                    List = InformeData.ListInformeSoloMiUsuario(objFiltro);
                }
                else
                {
                    if (objFiltro.NivelUsuario == "2")
                    {
                        List = InformeData.ListInformeAdmin(objFiltro);
                    }
                    else if (objFiltro.NivelUsuario == "1")
                    {
                        List = InformeData.ListInformeUsuario(objFiltro);
                    }
                }

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<InformeResponse> SelectInforme(int IdInforme)
        {
            try
            {
                Response<InformeResponse> response;
                InformeEntity List;
                SolicitudRevisionTecnica_CEntity objDatosInforme;

                List = InformeData.SelectInforme(IdInforme);
                objDatosInforme = SolicitudRevisionTecnicaData.SelectSolicitudRevisionTecnica_C_Informe(List.NumeroInforme);
                List.IdSolicitudRevision = objDatosInforme.IdSolicitudRevision;
                List.Kilometraje = objDatosInforme.Kilometraje;

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { Informe = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<InformeResponse> SelectInformeCorrectivoPreventivoTractoCarreta(decimal NumeroInforme, string TipoInforme, int TipoU)
        {
            try
            {
                Response<InformeResponse> response;
                InformeEntity List;
                SolicitudRevisionTecnica_CEntity objDatosInforme;

                List = InformeData.SelectInformeCorrectivoPreventivoTractoCarreta(NumeroInforme, TipoInforme, TipoU);
                if (List != null)
                {
                    objDatosInforme = SolicitudRevisionTecnicaData.SelectSolicitudRevisionTecnica_C_Informe(List.NumeroInforme);
                    List.IdSolicitudRevision = objDatosInforme.IdSolicitudRevision;
                    List.Kilometraje = objDatosInforme.Kilometraje;
                }

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { Informe = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> DeleteInforme(int IdInforme, int IdTarea, int IdTipMan, string AreCodigo)
        {
            Response<InformeResponse> response;

            try
            {
                await InformeTareasData.DeleteInformeTareas(IdInforme, IdTarea);
                await ControlUnidadTipoMantenimientoData.AnularControlUnidadMantenimiento(IdTipMan, AreCodigo);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> AnularInforme(int IdInforme)
        {
            Response<InformeResponse> response;
            InformeEntity objInforme;
            ProgramacionEntity objProgramacionCorrectivo;
            ProgramacionEntity objProgramacionPreventivo;
            string codProgramacion;

            try
            {
                objInforme = InformeData.SelectInforme(IdInforme);
                objProgramacionCorrectivo = ProgramacionData.SelectProgramacionPorInforme(objInforme.NumeroInforme.ToString(), Convert.ToInt32(Constants.TipoInforme.CORRECTIVO));
                objProgramacionPreventivo = ProgramacionData.SelectProgramacionPorInforme(objInforme.NumeroInforme.ToString(), Convert.ToInt32(Constants.TipoInforme.PREVENTIVO));
                codProgramacion = objProgramacionCorrectivo.CODI_PROGRAMACION;

                if (objInforme.TipoInforme == Constants.TipoInforme.CORRECTIVO && objProgramacionPreventivo != null)
                {
                    BusinessException.Generar(Constants.PRIMERO_DEBE_ANULAR_PREVENTIVO);
                }

                //using (TransactionScope tran = new TransactionScope())
                //{
                    if (objInforme.TipoInforme == Constants.TipoInforme.CORRECTIVO)
                    {
                        await ProgramacionData.UpdateProgramacionOrdenCorrectivoAnulacion(codProgramacion);
                    }
                    else if (objInforme.TipoInforme == Constants.TipoInforme.PREVENTIVO)
                    {
                        await ProgramacionData.UpdateProgramacionOrdenPreventivoAnulacion(codProgramacion);
                    }
                    await InformeData.AnularInforme(IdInforme);

                //    tran.Complete();
                //}

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        #region INFORME TAREAS

        public static Response<InformeResponse> ListInformeTareas(int IdInforme)
        {
            try
            {
                Response<InformeResponse> response;
                List<InformeTareasList> List;

                List = InformeTareasData.ListInformeTareas(IdInforme);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListInformeTareas = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<InformeResponse> ListInformeOrdenMantenimiento(int IdInforme)
        {
            try
            {
                Response<InformeResponse> response;
                List<InformeOrdenMantenimientoList> List;

                List = InformeTareasData.ListInformeOrdenMantenimiento(IdInforme);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListInformeOrdenMantenimiento = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<InformeResponse> ListInformeTareasBackLog(string IdUnidad, string Tipo)
        {
            try
            {
                Response<InformeResponse> response;
                List<InformeTareasList> List;

                List = new List<InformeTareasList>();

                if (Tipo == Constants.TipoInforme.CORRECTIVO)
                {
                    List = InformeTareasData.ListInformeTareasBackLogCorrectivo(IdUnidad);
                }
                else
                {
                    List = InformeTareasData.ListInformeTareasBackLogPreventivo(IdUnidad);
                }

                

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListInformeTareas = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> DeleteInformeTareas(int IdInforme, int IdTarea, int IdTipMan, string AreCodigo)
        {
            Response<InformeResponse> response;

            try
            {
                await InformeTareasData.DeleteInformeTareas(IdInforme, IdTarea);
                await ControlUnidadTipoMantenimientoData.AnularControlUnidadMantenimiento(IdTipMan, AreCodigo);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> InsertInformeTareas(InformeRequest request)
        {
            Response<InformeResponse> response;
            InformeTareasEntity objInformeTareas;
            List<InformeTareasList> objInformeTareasAnteriorActivo;
            List<InformeTareasList> objInformeTareasAnteriorInactivo;

            try
            {
                objInformeTareas = request.InformeTareas;
                objInformeTareasAnteriorActivo = InformeTareasData.ListInformeTareas(objInformeTareas.IdInforme, objInformeTareas.IdTarea);
                objInformeTareasAnteriorInactivo = InformeTareasData.ListInformeTareas(objInformeTareas.IdInforme, objInformeTareas.IdTarea, 0);

                if (objInformeTareasAnteriorActivo.Count > 0)
                {
                    BusinessException.Generar(Constants.YA_EXISTE);
                }
                else if (objInformeTareasAnteriorInactivo.Count > 0)
                {
                    await InformeTareasData.DeleteInformeTareas(objInformeTareas.IdInforme, objInformeTareas.IdTarea, 1, objInformeTareas.Observacion);
                }
                else
                {
                    await InformeTareasData.InsertInformeTareas(objInformeTareas);
                }

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<Response<InformeResponse>> UpdateInformeTareas(InformeRequest request)
        {
            Response<InformeResponse> response;

            try
            {
                //await InformeTareasData.UpdateInformeTareasEstado(IdInforme, IdTarea, Convert.ToByte(Estado));

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> UpdateInformeTareasEstado(int IdInforme, int IdTarea, int Estado)
        {
            Response<InformeResponse> response;

            try
            {
                await InformeTareasData.UpdateInformeTareasEstado(IdInforme, IdTarea, Convert.ToByte(Estado));
                if (Estado == Constants.EstadosInforme.ANULADO)
                {
                    var objInformeTarea = InformeTareasData.ListInformeTareas(IdInforme, IdTarea, 99)[0];
                    var objInforme = InformeData.SelectInforme(IdInforme);
                    await ControlUnidadTipoMantenimientoData.AnularControlUnidadMantenimiento(objInformeTarea.IdTipMan, objInforme.Are_Codigo);
                }

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> UpdateInformeTareasReasignarInforme(int IdInformeNuevo, int IdInformeAnterior, int IdTarea)
        {
            Response<InformeResponse> response;

            try
            {
                byte estadoActivo = Constants.EstadosInforme.ACTIVO;

                await InformeTareasData.UpdateInformeTareasReasignarInforme(IdInformeNuevo,IdInformeAnterior, IdTarea, estadoActivo);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        

        #endregion

        #region MECANICOS

        public static Response<InformeResponse> ListTareaMecanico(int IdInforme, int IdTarea)
        {
            try
            {
                Response<InformeResponse> response;
                List<TareaMecanicoList> List;

                List = TareaMecanicoData.ListTareaMecanico(IdInforme, IdTarea);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListTareaMecanico = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> DeleteTareaMecanico(int IdTareaMecanico)
        {
            Response<InformeResponse> response;

            try
            {
                await TareaMecanicoData.DeleteTareaMecanico(IdTareaMecanico);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> InsertTareaMecanico(InformeRequest request)
        {
            Response<InformeResponse> response;
            TareaMecanicosEntity objTareaMecanico;
            List<TareaMecanicoList> ListExiste;

            try
            {
                objTareaMecanico = request.TareaMecanico;

                ListExiste = TareaMecanicoData.ListTareaMecanico(objTareaMecanico.IdInforme, objTareaMecanico.IdTarea, objTareaMecanico.CodMecanico);

                if (ListExiste.Count > 0)
                {
                    BusinessException.Generar(Constants.YA_EXISTE);
                }

                var fechaInicio = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaInicio)).ToShortDateString();
                var fechaTermino = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaTermino)).ToShortDateString();
                var horaInicio = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaInicio)).ToShortTimeString();
                var horaTermino = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaTermino)).ToShortTimeString();

                objTareaMecanico.FechaTermino = fechaTermino;
                objTareaMecanico.FechaInicio = fechaTermino;
                objTareaMecanico.HoraInicio = horaInicio;
                objTareaMecanico.HoraTermino = horaTermino;

                await TareaMecanicoData.InsertTareaMecanico(objTareaMecanico);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> UpdateTareaMecanico(InformeRequest request)
        {
            Response<InformeResponse> response;
            TareaMecanicosEntity objTareaMecanico;

            try
            {
                objTareaMecanico = request.TareaMecanico;

                var fechaInicio = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaInicio)).ToShortDateString();
                var fechaTermino = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaTermino)).ToShortDateString();
                var horaInicio = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaInicio)).ToShortTimeString();
                var horaTermino = Convert.ToDateTime(Functions.ValidarDatetime(objTareaMecanico.FechaTermino)).ToShortTimeString();

                objTareaMecanico.FechaTermino = fechaTermino;
                objTareaMecanico.FechaInicio = fechaTermino;
                objTareaMecanico.HoraInicio = horaInicio;
                objTareaMecanico.HoraTermino = horaTermino;

                await TareaMecanicoData.UpdateTareaMecanico(objTareaMecanico);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        #endregion

        #region AYUDANTES

        public static Response<InformeResponse> ListTareaMecanicosAyudante(int IdTareaMecanico)
        {
            try
            {
                Response<InformeResponse> response;
                List<TareaMecanicosAyudanteList> List;

                List = TareaMecanicosAyudanteData.ListTareaMecanicosAyudante(IdTareaMecanico);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListTareaMecanicosAyudante = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> DeleteTareaMecanicosAyudante(int IdAyudante)
        {
            Response<InformeResponse> response;

            try
            {
                await TareaMecanicosAyudanteData.DeleteTareaMecanicosAyudante(IdAyudante);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (FaultException<ServiceError>)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static async Task<Response<InformeResponse>> InsertTareaMecanicosAyudante(InformeRequest request)
        {
            Response<InformeResponse> response;
            TareaMecanicosAyudanteEntity objTareaMecanicosAyudante;
            List<TareaMecanicosAyudanteList> ListTareaMecanicosAyudanteExiste;

            try
            {
                objTareaMecanicosAyudante = request.TareaMecanicosAyudante;
                ListTareaMecanicosAyudanteExiste = TareaMecanicosAyudanteData.ListTareaMecanicosAyudante(objTareaMecanicosAyudante.IdTareaMecanicos, objTareaMecanicosAyudante.CodMecanico);

                if (ListTareaMecanicosAyudanteExiste.Count > 0)
                {
                    BusinessException.Generar(Constants.YA_EXISTE);
                }

                await TareaMecanicosAyudanteData.InsertTareaMecanicosAyudante(objTareaMecanicosAyudante);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region REQUISICION

        public static Response<InformeResponse> BusquedaArticulo(string CodEmpresa, string CodAlmacen)
        {
            try
            {
                Response<InformeResponse> response;
                List<BusquedaArticuloList> List;

                List = ArticuloData.BusquedaArticulo(CodEmpresa, CodAlmacen);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListBusquedaArticulo = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<InformeResponse> AgregarBolsas(InformeRequest request)
        {
            Response<InformeResponse> response;
            List<Tb_CtrlBolsaRepInformeEntity> List;
            Tb_CtrlBolsaRepInformeEntity objBolsa;
            ODMEntity objODM;
            ODMdEntity objODMd;
            decimal codigoODM;
            int idBolsa;

            try
            {
                objBolsa = request.Bolsa;
                objODM = request.ODM;

                List = Tb_CtrlBolsaRepInformeData.AgregarBolsa(objBolsa.CodiAlmacen, objBolsa.IdTarea, Convert.ToInt32(objODM.ODM_Informe));

                if (List.Count == 0)
                {
                    BusinessException.Generar("No se encontrarón bolsas de repuestos para esta tarea");
                }

                codigoODM = ODMData.ValidaExiste(objODM.Ben_Codigo_Solicitante, objODM.ODM_Informe);

                if (codigoODM == 0)
                {
                    objODM.ODM_Fecha = DateTime.Now;
                    objODM.ODM_Hora = DateTime.Now.ToShortTimeString();
                    objODM.ODM_Incluye = "N";
                    objODM.ODM_Observacion = "Informe N°" + objODM.ODM_Informe;
                    objODM.ODM_Estado = "00";
                    codigoODM = ODMData.InsertODM(objODM);
                }

                foreach (var item in List)
                {
                    item.Consumo = 0;
                    item.Pendiente = 0;
                    item.Solicitado = 0;
                    item.FechaInicio = objBolsa.FechaInicio;
                    item.IdTipMan = objBolsa.IdTipMan;
                    idBolsa = Tb_CtrlBolsaRepInformeData.InsertBolsa(item);

                    objODMd = new ODMdEntity
                    {
                        Emp_Codigo = objODM.Emp_Codigo,
                        Are_Codigo = objODM.Are_Codigo,
                        Ben_Codigo = objODM.Ben_Codigo_Solicitante,
                        COD_OFI = objBolsa.CodiAlmacen,
                        Cod_Sistema = objBolsa.IdTipMan,
                        DTem_Destino = objBolsa.CodiAlmacen,
                        Cod_Componente = item.IdTarea.ToString(),
                        DTem_Informe = objODM.ODM_Informe.ToString(),
                        Id_CtrlBolsaRepInforme = idBolsa,
                        Mer_Codigo = item.Codigo,
                        ODMd_Cantidad = item.Cantidad,
                        ODMd_Observacion = "Informe N°" + objODM.ODM_Informe,
                        ODM_Codigo = codigoODM
                    };

                    ODMdData.InsertODMd(objODMd);
                }

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListBolsas = new List<ODMdList>() },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Response<InformeResponse> ListBolsas(decimal IdInforme, string Ben_Codigo)
        {
            try
            {
                Response<InformeResponse> response;
                List<ODMdList> List;

                List = ODMdData.ListBolsas(IdInforme, Ben_Codigo);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListBolsas = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<InformeResponse> ListBolsasPorInforme(decimal IdInforme)
        {
            try
            {
                Response<InformeResponse> response;
                List<ODMdList> List;

                List = ODMdData.ListBolsasPorInforme(IdInforme);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse { ListBolsasPorInforme = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<InformeResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<InformeResponse> InsertBolsa(InformeRequest request)
        {
            Response<InformeResponse> response;
            Tb_CtrlBolsaRepInformeEntity objBolsa;
            ODMEntity objODM;
            ODMdEntity objODMd;

            decimal codigoODM;
            int idBolsa;

            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    objBolsa = request.Bolsa;
                    objODM = request.ODM;

                    codigoODM = ODMData.ValidaExiste(objODM.Ben_Codigo_Solicitante, objODM.ODM_Informe);

                    if (codigoODM == 0)
                    {
                        objODM.ODM_Fecha = DateTime.Now;
                        objODM.ODM_Hora = DateTime.Now.ToShortTimeString();
                        objODM.ODM_Incluye = "N";
                        objODM.ODM_Observacion = "Informe N°" + objODM.ODM_Informe;
                        objODM.ODM_Estado = "00";
                        codigoODM = ODMData.InsertODM(objODM);
                    }

                    objBolsa.Consumo = 0;
                    objBolsa.Tipo = "LIBRE";
                    objBolsa.Pendiente = 0;
                    objBolsa.Solicitado = 0;

                    idBolsa = Tb_CtrlBolsaRepInformeData.InsertBolsa(objBolsa);

                    objODMd = new ODMdEntity
                    {
                        Emp_Codigo = objODM.Emp_Codigo,
                        Are_Codigo = objODM.Are_Codigo,
                        Ben_Codigo = objODM.Ben_Codigo_Solicitante,
                        COD_OFI = objBolsa.CodiAlmacen,
                        Cod_Sistema = objBolsa.IdTipMan,
                        DTem_Destino = objBolsa.CodiAlmacen,
                        Cod_Componente = objBolsa.IdTarea.ToString(),
                        DTem_Informe = objODM.ODM_Informe.ToString(),
                        Id_CtrlBolsaRepInforme = idBolsa,
                        Mer_Codigo = objBolsa.Codigo,
                        ODMd_Cantidad = objBolsa.Cantidad,
                        ODMd_Observacion = "Informe N°" + objODM.ODM_Informe,
                        ODM_Codigo = codigoODM
                    };

                    ODMdData.InsertODMd(objODMd);

                    tran.Complete();
                }

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static async Task<Response<InformeResponse>> DeleteBolsa(InformeRequest request)
        {
            Response<InformeResponse> response;
            ODMdEntity objODMd;

            objODMd = request.ODMd;

            try
            {
                await ODMdData.DeleteODMd(objODMd.ODMd_Codigo);
                await Tb_CtrlBolsaRepInformeData.DeleteBolsa(objODMd.Id_CtrlBolsaRepInforme);

                response = new Response<InformeResponse>
                {
                    EsCorrecto = true,
                    Valor = new InformeResponse
                    {
                        Informe = new InformeEntity()
                    },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}

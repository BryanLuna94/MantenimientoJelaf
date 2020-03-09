using System.Collections.Generic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Mantenimiento.DataAccess;
using Mantenimiento.Entities.Objects.Entities;
using Mantenimiento.Entities.Objects.Others;
using Mantenimiento.Entities.Requests.Responses;
using Mantenimiento.Utility;
using System.Linq;

namespace Mantenimiento.BusinessLayer
{
    public static class MarcaModeloLogic
    {

        public static Response<MarcaModeloResponse> ListMarcaModelo()
        {
            try
            {
                Response<MarcaModeloResponse> response;
                List<MarcaModeloEntity> List;

                List = MarcaModeloData.ListMarcaModelo();

                response = new Response<MarcaModeloResponse>
                {
                    EsCorrecto = true,
                    Valor = new MarcaModeloResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<MarcaModeloResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<MarcaModeloResponse> ListMarcaModelo(MarcaModeloResponse request)
        {
            try
            {
                Response<MarcaModeloResponse> response;
                List<MarcaModeloEntity> List;
                List<MarcaModeloEntity> ListRequestMarca;
                List<MarcaModeloEntity> ListRequestModelo;
                List<MarcaModeloEntity> ListFilter;
                List<MarcaModeloEntity> ListFilterT;
                List<MarcaModeloEntity> ListFilterTMP;
                List<MarcaModeloEntity> ListFilterTMP2;

                ListFilterT = new List<MarcaModeloEntity>();

                ListRequestMarca = request.FiltroMarca;
                ListRequestModelo = request.FiltroModelo;
                

                List = MarcaModeloData.ListMarcaModelo();

                if (ListRequestMarca.Count>0)
                {
                    ListFilterTMP = List
                                .Where(x => ListRequestMarca.Any(z => x.cod_marca == z.cod_marca))
                                .ToList();
                }
                else
                {
                    ListFilterTMP = List;
                }

                if (ListRequestModelo.Count>0)
                {
                    ListFilterTMP2 = ListFilterTMP
                                .Where(x => ListRequestModelo.Any(z => x.cod_modelo == z.cod_modelo))
                                .ToList();
                }
                else
                {
                    ListFilterTMP2 = ListFilterTMP;
                }

                ListFilter = (ListFilterTMP2.Count>0) ? ListFilterTMP2 : List;



                response = new Response<MarcaModeloResponse>
                {
                    EsCorrecto = true,
                    Valor = new MarcaModeloResponse { List = ListFilter },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<MarcaModeloResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<MarcaModeloResponse> ListModeloBuses()
        {
            try
            {
                Response<MarcaModeloResponse> response;
                List<MarcaModeloEntity> List;

                List = MarcaModeloData.ListModeloBuses();

                response = new Response<MarcaModeloResponse>
                {
                    EsCorrecto = true,
                    Valor = new MarcaModeloResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<MarcaModeloResponse>(false, null, Functions.MessageError(ex), false);
            }
        }

        public static Response<MarcaModeloResponse> ListMarcaBuses()
        {
            try
            {
                Response<MarcaModeloResponse> response;
                List<MarcaModeloEntity> List;

                List = MarcaModeloData.ListMarcaBuses();

                response = new Response<MarcaModeloResponse>
                {
                    EsCorrecto = true,
                    Valor = new MarcaModeloResponse { List = List },
                    Mensaje = "OK",
                    Estado = true,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<MarcaModeloResponse>(false, null, Functions.MessageError(ex), false);
            }
        }
    }

     


}

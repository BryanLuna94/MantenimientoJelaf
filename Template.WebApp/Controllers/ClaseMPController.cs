﻿using Mantenimiento.WebApp.Helpers;
using Mantenimiento.WebApp.ServiceMantenimiento;
using Newtonsoft.Json;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mantenimiento.WebApp.Controllers
{
    [RoutePrefix("ClaseMP")]
    [SessionExpire]
    public class ClaseMPController : Controller
    {
        // Servicio WCF
        ServiceMantenimientoClient _ServiceMantenimiento = new ServiceMantenimientoClient();

        [HttpGet]
        public async Task<ActionResult> ListClaseMP()
        {
            var res = await _ServiceMantenimiento.ListClaseMPAsync();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> ListClaseMPFiltro(string json)
        {
            var request = JsonConvert.DeserializeObject<ClaseMResponse>(json);

            var res = await _ServiceMantenimiento.ListClaseMPFiltroAsync(request);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

    }
}
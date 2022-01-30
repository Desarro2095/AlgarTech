using PedaleaBussiness;
using PedaleaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedaleaApi.Controllers
{
    public class CompraController : Controller
    {
        public JsonResult ObtenerCompras()
        {
            return Json(PedaleaOperation.GetCompraOperation().ObtenerCompras(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GuardarCompra(Cliente cliente)
        {
            return Json(PedaleaOperation.GetCompraOperation().GuardarCompra(cliente), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ActualizarCompra(Cliente cliente)
        {
            return Json(PedaleaOperation.GetCompraOperation().ActualizarCompra(cliente), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarCompra(int id)
        {
            return Json(PedaleaOperation.GetCompraOperation().EliminarCompra(id), JsonRequestBehavior.AllowGet);
        }
    }
}
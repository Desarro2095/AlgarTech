using PedaleaBussiness;
using PedaleaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PedaleaApi.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto

        public JsonResult ObtenerProductos()
        {
            return Json(PedaleaOperation.GetProductoOperation().ObtenerProductos(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerProducto(int id)
        {
            return Json(PedaleaOperation.GetProductoOperation().ObtenerProducto(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GuardarProductos(Producto producto)
        {
            return Json(PedaleaOperation.GetProductoOperation().GuardarProductos(producto), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ActualizarProductos(Producto producto)
        {
            return Json(PedaleaOperation.GetProductoOperation().ActualizarProductos(producto), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarProductos(int id)
        {
            return Json(PedaleaOperation.GetProductoOperation().EliminarProductos(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTallas()
        {
            return Json(PedaleaOperation.GetProductoOperation().ObtenerTallas(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerColores()
        {
            return Json(PedaleaOperation.GetProductoOperation().ObtenerColores(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerDepartamentos()
        {
            return Json(PedaleaOperation.GetProductoOperation().ObtenerDepartamentos(), JsonRequestBehavior.AllowGet);
        }

    }
}

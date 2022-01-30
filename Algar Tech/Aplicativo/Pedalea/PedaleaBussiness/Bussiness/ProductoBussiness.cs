using PedaleaDAO.DAO;
using PedaleaService;
using PedaleaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaBussiness.Bussiness
{
    internal class ProductoBussiness : IProducto
    {
        public Producto ActualizarProductos(Producto producto)
        {
            if (producto.Color != null && producto.Talla != null && producto.TipoDepartamento != null)
            {
                ProductoDAO productoDAO = new ProductoDAO();
                return productoDAO.ActualizarProductos(producto);
            }
            return null;
        }

        public bool EliminarProductos(int id)
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.EliminarProductos(id);
        }

        public Producto GuardarProductos(Producto producto)
        {
            if (producto.Color != null && producto.Talla != null && producto.TipoDepartamento != null)
            {
                ProductoDAO productoDAO = new ProductoDAO();
                return productoDAO.GuardarProductos(producto);
            }
            return null;
        }

        public List<Color> ObtenerColores()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.ObtenerColores();
        }

        public List<TipoDepartamento> ObtenerDepartamentos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.ObtenerDepartamentos();
        }

        public Producto ObtenerProducto(int id)
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.ObtenerProducto(id);
        }

        public List<Producto> ObtenerProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.ObtenerProductos();
        }

        public List<Talla> ObtenerTallas()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            return productoDAO.ObtenerTallas();
        }
    }
}

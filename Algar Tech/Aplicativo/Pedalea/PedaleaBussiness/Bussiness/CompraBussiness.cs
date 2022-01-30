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
    internal class CompraBussiness : ICompra
    {
        public Cliente ActualizarCompra(Cliente cliente)
        {
            if (cliente.Compra != null)
            {
                CompraDAO compraDAO = new CompraDAO();
                ProductoDAO productoDAO = new ProductoDAO();

                cliente.Compra.Valor = (productoDAO.ObtenerProducto(cliente.Compra.DetalleCompra.Producto.ProductoId).Precio * cliente.Compra.DetalleCompra.Cantidad);
                return compraDAO.ActualizarCompra(cliente);
            }
            return null;
        }

        public bool EliminarCompra(int id)
        {
            CompraDAO compraDAO = new CompraDAO();
            return compraDAO.EliminarCompra(id);
        }

        public Cliente GuardarCompra(Cliente cliente)
        {
            if (cliente.Compra != null)
            {
                CompraDAO compraDAO = new CompraDAO();
                ProductoDAO productoDAO = new ProductoDAO();

                cliente.Compra.Valor = (productoDAO.ObtenerProducto(cliente.Compra.DetalleCompra.Producto.ProductoId).Precio * cliente.Compra.DetalleCompra.Cantidad);
                return compraDAO.GuardarCompra(cliente);
            }
            return null;
        }

        public List<Cliente> ObtenerCompras()
        {
            CompraDAO compraDAO = new CompraDAO();
            return compraDAO.ObtenerCompras();
        }
    }
}

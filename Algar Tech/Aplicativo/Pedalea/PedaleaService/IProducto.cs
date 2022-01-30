using PedaleaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaService
{
    public interface IProducto
    {
        List<Producto> ObtenerProductos();
        Producto ObtenerProducto(int id);
        Producto GuardarProductos(Producto producto);
        Producto ActualizarProductos(Producto producto);
        bool EliminarProductos(int id);
        List<Talla> ObtenerTallas();
        List<Color> ObtenerColores();
        List<TipoDepartamento> ObtenerDepartamentos();
    }
}

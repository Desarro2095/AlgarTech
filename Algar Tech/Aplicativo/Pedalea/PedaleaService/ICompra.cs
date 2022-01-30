using PedaleaService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaService
{
    public interface ICompra
    {
        Cliente GuardarCompra(Cliente cliente);
        Cliente ActualizarCompra(Cliente cliente);
        List<Cliente> ObtenerCompras();
        bool EliminarCompra(int id);
    }
}

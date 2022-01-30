using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaService.Models
{
    public class DetalleCompra
    {
        public int DetalleCompraId { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
    }
}

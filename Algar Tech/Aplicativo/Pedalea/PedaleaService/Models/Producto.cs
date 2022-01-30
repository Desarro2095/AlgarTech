using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaService.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Talla Talla { get; set; }
        public Color Color { get; set; }
        public TipoDepartamento TipoDepartamento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaService.Models
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public PlanSepare PlanSepare { get; set; }
        public Promocion Promocion { get; set; }
        public DetalleCompra DetalleCompra { get; set; }
    }
}

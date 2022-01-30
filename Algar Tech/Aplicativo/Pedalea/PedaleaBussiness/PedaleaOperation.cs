using PedaleaBussiness.Bussiness;
using PedaleaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaBussiness
{
    public class PedaleaOperation
    {
        public static IProducto GetProductoOperation()
        {
            return new ProductoBussiness();
        }

        public static ICompra GetCompraOperation()
        {
            return new CompraBussiness();
        }
    }
}

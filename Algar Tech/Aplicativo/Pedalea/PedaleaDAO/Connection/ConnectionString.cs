using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaDAO.Connection
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=LAPTOP-BT5NAMU2; Initial Catalog=PEDALEA;User ID=carlos;Password=123";
        public static string CName
        {
            get => cName;
        }
    }
}

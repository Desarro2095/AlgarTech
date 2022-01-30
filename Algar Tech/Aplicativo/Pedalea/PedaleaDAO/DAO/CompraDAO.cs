using PedaleaDAO.Connection;
using PedaleaService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedaleaDAO.DAO
{
    public class CompraDAO
    {
        string connectionString = ConnectionString.CName;

        public Cliente GuardarCompra(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpCrearCompra", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_CLIENTE", 0);
                cmd.Parameters.AddWithValue("@ID_COMPRA", 0);
                cmd.Parameters.AddWithValue("@ID_PLAN_SEPARE", 0);
                cmd.Parameters.AddWithValue("@ID_PROMOCION", 0);
                cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
                cmd.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
                cmd.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
                cmd.Parameters.AddWithValue("@VALOR", cliente.Compra.Valor);
                cmd.Parameters.AddWithValue("@CANTIDAD", cliente.Compra.DetalleCompra.Cantidad);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", cliente.Compra.DetalleCompra.Producto.ProductoId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cliente;
        }

        public Cliente ActualizarCompra(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpCrearCompra", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_CLIENTE", cliente.ClienteId);
                cmd.Parameters.AddWithValue("@ID_COMPRA", cliente.Compra.CompraId);
                cmd.Parameters.AddWithValue("@ID_PLAN_SEPARE", cliente.Compra.PlanSepare.PlanSepareId);
                cmd.Parameters.AddWithValue("@ID_PROMOCION", cliente.Compra.Promocion.PromocionId);
                cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
                cmd.Parameters.AddWithValue("@NOMBRE", cliente.Nombre);
                cmd.Parameters.AddWithValue("@DIRECCION", cliente.Direccion);
                cmd.Parameters.AddWithValue("@VALOR", cliente.Compra.Valor);
                cmd.Parameters.AddWithValue("@CANTIDAD", cliente.Compra.DetalleCompra.Cantidad);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", cliente.Compra.DetalleCompra.Producto.ProductoId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return cliente;
        }

        public List<Cliente> ObtenerCompras()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpObtenerCompras", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Compra = new Compra();
                    cliente.Compra.PlanSepare = new PlanSepare();
                    cliente.Compra.Promocion = new Promocion();
                    cliente.Compra.DetalleCompra = new DetalleCompra();
                    cliente.Compra.DetalleCompra.Producto = new Producto();

                    cliente.ClienteId = Convert.ToInt32(rdr["ID_CLIENTE"]);
                    cliente.Nombre = rdr["NOMBRE_CLIENTE"].ToString();
                    cliente.Cedula = rdr["CEDULA"].ToString();
                    cliente.Direccion = rdr["DIRECCION"].ToString();
                    cliente.Compra.CompraId = Convert.ToInt32(rdr["ID_COMPRA"]);
                    cliente.Compra.Fecha = Convert.ToDateTime(rdr["FECHA"]);
                    cliente.Compra.Valor = Convert.ToDecimal(rdr["VALOR"]);
                    cliente.Compra.PlanSepare.PlanSepareId = Convert.ToInt32(rdr["ID_PLAN_SEPARE"]); 
                    cliente.Compra.PlanSepare.PlanSepareDescripcion = rdr["PLAN_SEPARE"].ToString();
                    cliente.Compra.Promocion.PromocionId = Convert.ToInt32(rdr["ID_PROMOCION"]);
                    cliente.Compra.Promocion.Porcentaje = Convert.ToDecimal(rdr["PORCENTAJE"]);
                    cliente.Compra.DetalleCompra.DetalleCompraId = Convert.ToInt32(rdr["ID_DETALLE_COMPRA"]);
                    cliente.Compra.DetalleCompra.Cantidad = Convert.ToInt32(rdr["CANTIDAD"]);
                    cliente.Compra.DetalleCompra.Producto.ProductoId = Convert.ToInt32(rdr["ID_PRODUCTO"]);
                    cliente.Compra.DetalleCompra.Producto.Nombre = rdr["NOMBRE_PRODUCTO"].ToString();
                    clientes.Add(cliente);
                }
                con.Close();
            }
            return clientes;
        }

        public bool EliminarCompra(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpEliminarCompra", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
    }
}

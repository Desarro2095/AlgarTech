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
    public class ProductoDAO
    {
        string connectionString = ConnectionString.CName;
        public Producto GuardarProductos(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpCrearProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_PRODUCTO", 0);
                cmd.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
                cmd.Parameters.AddWithValue("@PRECIO", producto.Precio);
                cmd.Parameters.AddWithValue("@ID_TALLA", producto.Talla.TallaId);
                cmd.Parameters.AddWithValue("@ID_COLOR", producto.Color.ColorId);
                cmd.Parameters.AddWithValue("@ID_TIPO_DEPARTAMENTO", producto.TipoDepartamento.TipoDepartamentoId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return producto;
        }

        public Producto ActualizarProductos(Producto producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpCrearProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_PRODUCTO", producto.ProductoId);
                cmd.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
                cmd.Parameters.AddWithValue("@PRECIO", producto.Precio);
                cmd.Parameters.AddWithValue("@ID_TALLA", producto.Talla.TallaId);
                cmd.Parameters.AddWithValue("@ID_COLOR", producto.Color.ColorId);
                cmd.Parameters.AddWithValue("@ID_TIPO_DEPARTAMENTO", producto.TipoDepartamento.TipoDepartamentoId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return producto;
        }

        public Producto ObtenerProducto(int id)
        {
            Producto producto = new Producto();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpObtenerProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    producto.Talla = new Talla();
                    producto.Color = new Color();
                    producto.TipoDepartamento = new TipoDepartamento();

                    producto.ProductoId = Convert.ToInt32(rdr["ID_PRODUCTO"]);
                    producto.Nombre = rdr["NOMBRE_PRODUCTO"].ToString();
                    producto.Precio = Convert.ToDecimal(rdr["PRECIO_PRODUCTO"]);
                    producto.Talla.TallaId = Convert.ToInt32(rdr["ID_TALLA"]);
                    producto.Talla.TallaDescripcion = rdr["TALLA"].ToString();
                    producto.Color.ColorId = Convert.ToInt32(rdr["ID_COLOR"]);
                    producto.Color.ColorDescripcion = rdr["COLOR"].ToString();
                    producto.TipoDepartamento.TipoDepartamentoId = Convert.ToInt32(rdr["ID_TIPO_DEPARTAMENTO"]);
                    producto.TipoDepartamento.TipoDepartamentoDescripcion = rdr["DEPARTAMENTO"].ToString();
                }
                con.Close();
            }
            return producto;
        }

        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpObtenerProductos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Producto producto = new Producto();
                    producto.Talla = new Talla();
                    producto.Color = new Color();
                    producto.TipoDepartamento = new TipoDepartamento();

                    producto.ProductoId = Convert.ToInt32(rdr["ID_PRODUCTO"]);
                    producto.Nombre = rdr["NOMBRE_PRODUCTO"].ToString();
                    producto.Precio = Convert.ToDecimal(rdr["PRECIO_PRODUCTO"]);
                    producto.Talla.TallaId = Convert.ToInt32(rdr["ID_TALLA"]);
                    producto.Talla.TallaDescripcion = rdr["TALLA"].ToString();
                    producto.Color.ColorId = Convert.ToInt32(rdr["ID_COLOR"]);
                    producto.Color.ColorDescripcion = rdr["COLOR"].ToString();
                    producto.TipoDepartamento.TipoDepartamentoId = Convert.ToInt32(rdr["ID_TIPO_DEPARTAMENTO"]);
                    producto.TipoDepartamento.TipoDepartamentoDescripcion = rdr["DEPARTAMENTO"].ToString();

                    productos.Add(producto);
                }
                con.Close();
            }
            return productos;
        }

        public bool EliminarProductos(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpEliminarProducto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public List<Talla> ObtenerTallas()
        {
            List<Talla> tallas = new List<Talla>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpObtenerTallas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Talla talla = new Talla();
                    talla.TallaId = Convert.ToInt32(rdr["ID_TALLA"]);
                    talla.TallaDescripcion = rdr["TALLA"].ToString();
                    tallas.Add(talla);
                }
                con.Close();
            }
            return tallas;
        }

        public List<Color> ObtenerColores()
        {
            List<Color> colores = new List<Color>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpObtenerColores", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Color color = new Color();
                    color.ColorId = Convert.ToInt32(rdr["ID_COLOR"]);
                    color.ColorDescripcion = rdr["COLOR"].ToString();
                    colores.Add(color);
                }
                con.Close();
            }
            return colores;
        }

        public List<TipoDepartamento> ObtenerDepartamentos()
        {
            List<TipoDepartamento> tipoDepartamentos = new List<TipoDepartamento>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("scpObtenerDepartamento", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TipoDepartamento tipoDepartamento = new TipoDepartamento();
                    tipoDepartamento.TipoDepartamentoId = Convert.ToInt32(rdr["ID_TIPO_DEPARTAMENTO"]);
                    tipoDepartamento.TipoDepartamentoDescripcion = rdr["DEPARTAMENTO"].ToString();
                    tipoDepartamentos.Add(tipoDepartamento);
                }
                con.Close();
            }
            return tipoDepartamentos;
        }
    }
}

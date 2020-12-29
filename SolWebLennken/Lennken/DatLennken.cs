using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lennken
{
    public class DatLennken
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        DataTable dt = new DataTable();
        DataRow dr;
        SqlCommand com = new SqlCommand();

        public DataTable Obtener()
        {
            com = new SqlCommand("spObtenerLista", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int Agregar(string name, Decimal Price, DateTime Creation,DateTime Modification)
        {
            int filasAfectadas = 0;
            
            com = new SqlCommand("SpAgregarElemento", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@Price", Price);
            com.Parameters.AddWithValue("@Creation", Creation);
            com.Parameters.AddWithValue("@Modificaction", Modification);
            try
            {
                con.Open();
                filasAfectadas = com.ExecuteNonQuery();
                con.Close();
                return filasAfectadas;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }

        public DataRow ObtenerProducto(int id)
        {
            com = new SqlCommand("spObtenerProducto", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            return dr;
        }
        public int EditarProducto(string name, Decimal Price, DateTime Creation, DateTime Modification)
        {
            int filasAfectadas = 0;

            com = new SqlCommand("SpEditar  Elemento", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", name);
            com.Parameters.AddWithValue("@Price", Price);
            com.Parameters.AddWithValue("@Creation", Creation);
            com.Parameters.AddWithValue("@Modificaction", Modification);
            try
            {
                con.Open();
                filasAfectadas = com.ExecuteNonQuery();
                con.Close();
                return filasAfectadas;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
        public int BorrarElemento(int id)
        {
            int filasAfectadas = 0;

            com = new SqlCommand("SpBorrarElemento", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
         
            try
            {
                con.Open();
                filasAfectadas = com.ExecuteNonQuery();
                con.Close();
                return filasAfectadas;
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace back_platos.Models
{
    public class GestorPlatos
    {
        public List<Platos> getPlatos()
        {
            // definimos la conección a la base de datos
            List<Platos> Lista= new List<Platos>();
            string strConn = ConfigurationManager.ConnectionStrings["BDlocal"].ToString();

            //conectamos a la base de datos
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Platos_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string categoria = dr.GetString(2).Trim();
                    string descripcion = dr.GetString(3).Trim();

                    Platos plato = new Platos(id, nombre, categoria, descripcion);

                    Lista.Add(plato);

                }
                dr.Close();
                conn.Close();
            }

            return Lista;

        }

        public bool addPlato(Platos plato)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["BDlocal"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.CommandText = "Platos_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", plato.nombre);
                cmd.Parameters.AddWithValue("@categoria", plato.categoria);
                cmd.Parameters.AddWithValue("@desc", plato.descripcion);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
            }
            return res;
        }
        public bool updatePlato(int id, Platos plato)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["BDlocal"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.CommandText = "Platos_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", plato.nombre);
                cmd.Parameters.AddWithValue("@categoria", plato.categoria);
                cmd.Parameters.AddWithValue("@desc", plato.descripcion);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
            }
            return res;
        }
        public bool deletePlato(int id)
        {
            bool res = false;
            string strConn = ConfigurationManager.ConnectionStrings["BDlocal"].ToString();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                cmd.CommandText = "Platos_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
            }
            return res;
        }
    }
}
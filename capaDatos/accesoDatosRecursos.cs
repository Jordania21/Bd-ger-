using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatosRecursos
    {
        SqlConnection cnx;
       Recursos s = new Recursos();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Recursos> listaRecursos = null;

        public int insertarRecursos(Recursos Re)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Recurso", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@nombrer", Re.nombrer);
                cm.Parameters.AddWithValue("@codigo", Re.codigo);
                cm.Parameters.AddWithValue("@descripcion", Re.descripcion);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public List<Recursos> listarRecursos()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Recurso", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@nombrer", "");
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaRecursos = new List<Recursos>();
                while (dr.Read())
                {
                    Recursos r = new Recursos();
                    r.idrecursos = Convert.ToInt32(dr["idrecursos"].ToString());
                    r.nombrer = dr["nombrer"].ToString();
                    r.codigo = dr["codigo"].ToString();
                    r.descripcion = dr["descripcion"].ToString();
                    
                    listaRecursos.Add(r);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaRecursos = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaRecursos;
        }
        public int eliminarRecursos(int idrecur)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("recuso", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idrecursos", idrecur);
                cm.Parameters.AddWithValue("@nombrer", "");
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = -1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public int EditarRecursos(Recursos Re)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("recurso", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idrecursos", Re.idrecursos);
                cm.Parameters.AddWithValue("@nombrer", "");
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");
                
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;

            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public List<Recursos> BuscarRecursos(String dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("recurso", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@nombrer", dato);
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaRecursos = new List<Recursos>();
                while (dr.Read())
                {
                    Recursos r = new Recursos();
                    r.idrecursos= Convert.ToInt32(dr["idrecursos"].ToString());
                    r.nombrer = dr["nombrer"].ToString();
                    r.codigo = dr["codigo"].ToString();
                    r.descripcion = dr["descripcion"].ToString();
                    listaRecursos.Add(r);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaRecursos = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaRecursos;
        }
    }
}

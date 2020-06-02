using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatosUsuarios
    {
        SqlConnection cnx;
        Usuarios u = new Usuarios();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Usuarios> listaUsuarios = null;

        public int insertarUsuarios(Usuarios us)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idusuario", "");
                cm.Parameters.AddWithValue("@cedula", us.cedula);
                cm.Parameters.AddWithValue("@nombres", us.nombres);
                cm.Parameters.AddWithValue("@apellidos", us.apellidos);
                cm.Parameters.AddWithValue("@email", us.email);
                cm.Parameters.AddWithValue("@telefono", us.telefono);

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
        public List<Usuarios> listarUsuarios()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idusuario", "");
                cm.Parameters.AddWithValue("@cedula", "");
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@email", "");
                cm.Parameters.AddWithValue("@telefono", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaUsuarios = new List<Usuarios>();
                while (dr.Read())
                {
                    Usuarios u = new Usuarios();
                    u.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    u.cedula = dr["cedula"].ToString();
                    u.nombres = dr["nombres"].ToString();
                    u.apellidos = dr["apellidos"].ToString();
                    u.email = dr["email"].ToString();
                    u.telefono = dr["telefono"].ToString();
                    listaUsuarios.Add(u);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaUsuarios = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaUsuarios;
        }
        public int eliminarUsuarios(int idusu)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idusuario", idusu);
                cm.Parameters.AddWithValue("@cedula", "");
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@email", "");
                cm.Parameters.AddWithValue("@telefono", "");

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
        public int EditarUsuarios(Usuarios us)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idusuario", us.idusuario);
                cm.Parameters.AddWithValue("@cedula", "");
                cm.Parameters.AddWithValue("@nombres", "");
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@email", "");
                cm.Parameters.AddWithValue("@telefono", "");

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
        public List<Usuarios> BuscarUsuarios(String dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idusuario", "");
                cm.Parameters.AddWithValue("@cedula", "");
                cm.Parameters.AddWithValue("@nombres", dato);
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@email", "");
                cm.Parameters.AddWithValue("@telefono", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaUsuarios = new List<Usuarios>();
                while (dr.Read())
                {
                    Usuarios u = new Usuarios();
                    u.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    u.cedula = dr["cedula"].ToString();
                    u.nombres = dr["nombres"].ToString();
                    u.apellidos = dr["apellidos"].ToString();
                    u.email = dr["email"].ToString();
                    u.telefono = dr["telefono"].ToString();
                    listaUsuarios.Add(u);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaUsuarios = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaUsuarios;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatosCuentas
    {
        SqlConnection cnx;
        Cuentas C = new Cuentas();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Cuentas> listaCuentas = null;

        public int insertarCuentas(Cuentas cu)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Cuenta", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idcuenta", "");
                cm.Parameters.AddWithValue("@nombreuser", cu.nombreuser);
                cm.Parameters.AddWithValue("@clave", cu.clave);
                cm.Parameters.AddWithValue("@rol", cu.rol);
                cm.Parameters.AddWithValue("@idusuario", cu.idusuario);

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
        public List<Cuentas> listarCuentas()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Cuenta", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idcuenta", "");
                cm.Parameters.AddWithValue("@nombreuser", "");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@idusuario", "");


                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaCuentas = new List<Cuentas>();
                while (dr.Read())
                {
                    Cuentas C = new Cuentas();
                    C.idcuenta = Convert.ToInt32(dr["idcuenta"].ToString());
                    C.nombreuser = dr["nombreuser"].ToString();
                    C.clave = dr["clave"].ToString();
                    C.rol = dr["rol"].ToString();
                    C.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    listaCuentas.Add(C);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
               listaCuentas= null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaCuentas;
        }
        public int eliminarCuentas(int idcuent)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Cuenta", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idcuenta", idcuent);
                cm.Parameters.AddWithValue("@nombreuser", "");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                m.Parameters.AddWithValue("@idusuario", "");

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
        public int EditarCuentas(Cuentas cu)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Cuenta", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idcuenta", cu.idcuenta);
                cm.Parameters.AddWithValue("@nombreuser", "");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@idusuario", "");

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
        public List<Cuentas> BuscarCuentas(String dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Cuenta", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idcuenta", "");
                cm.Parameters.AddWithValue("@nombreuser", dato);
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@idusuario", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaCuentas = new List<Cuentas>();
                while (dr.Read())
                {
                    Cuentas C = new Cuentas();
                    C.idcuenta = Convert.ToInt32(dr["idcuenta"].ToString());
                    C.nombreuser = dr["nombreuser"].ToString();
                    C.clave = dr["clave"].ToString();
                    C.rol = dr["rol"].ToString();
                    C.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    listaCuentas.Add(C);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaCuentas = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaCuentas;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;


namespace capaNegocio
{
    public class logicaNegocioUsuarios
    {
        accesoDatosUsuarios usu = new accesoDatosUsuarios();

        public int insertarUsuarios(Usuarios us)
        {
            return usu.insertarUsuarios(us);
        }
        public List<Usuarios> listarUsuarios()
        {
            return usu.listarUsuarios();
        }
        public int eliminarUsuarios(int idusu)
        {
            return usu.eliminarUsuarios(idusu);
        }
        public int EditarUsuarios(Usuarios us)
        {
            return usu.EditarUsuarios(us);
        }
        public List<Usuarios> BuscarUsuarios(string dato)
        {
            return usu.BuscarUsuarios(dato);
        }
    }
}

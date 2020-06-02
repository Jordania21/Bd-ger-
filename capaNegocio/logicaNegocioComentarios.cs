using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioComentarios
    {
        accesoDatosComentarios ac = new accesoDatosComentarios();

        public int insertarComentarios(Comentarios co)
        {
            return ac.insertarComentarios(co);
        }
        public List<Comentarios> listarComentarios()
        {
            return ac.listarComentarios();
        }
        public int eliminarComentarios(int idcoment)
        {
            return ac.eliminarComentarios(idcoment);
        }
        public int EditarComentarios(Comentarios co)
        {
            return ac.EditarComentarios(co);
        }
        public List<Comentarios> BuscarComentarios(string dato)
        {
            return ac.BuscarComentarios(dato);
        }
    }

}

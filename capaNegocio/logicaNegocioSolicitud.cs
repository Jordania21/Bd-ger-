using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioSolicitud
    {
        accesoDatosSolicitud so = new accesoDatosSolicitud();

        public int insertarSolicitud(Solicitud os)
        {
            return so.insertarSolicitud(os);
        }
        public List<Solicitud> listarSolicitud()
        {
            return so.listarSolicitud();
        }
        public int eliminarSolicitud(int idsolic)
        {
            return so.eliminarSolicitud(idsolic);
        }
        public int EditarSolicitud(Solicitud os)
        {
            return so.EditarSolicitud(os);
        }
        public List<Solicitud> BuscarSolicitud(string dato)
        {
            return so.BuscarSolicitud(dato);
        }
    }
}

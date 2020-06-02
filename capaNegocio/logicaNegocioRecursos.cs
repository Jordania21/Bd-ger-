using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
     public class logicaNegocioRecursos
    {
        accesoDatosRecursos rec = new accesoDatosRecursos();
        public int insertarRecursos(Recursos Re)
        {
            return rec.insertarRecursos(Re);
        }
        public List<Recursos> listarRecursos()
        {
            return rec.listarRecursos();
        }
        public int eliminarRecursos(int idrecur)
        {
            return rec.eliminarRecursos(idrecur);
        }
        public int EditarRecursos(Recursos Re)
        {
            return rec.EditarRecursos(Re);
        }
        public List<Recursos> BuscarRecursos(string dato)
        {
            return rec.BuscarRecursos(dato);
        }
    }
}

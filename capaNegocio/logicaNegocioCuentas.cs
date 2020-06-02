using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioCuentas
    {
        accesoDatosCuentas cue = new accesoDatosCuentas();

        public int insertarCuentas(Cuentas cu)
        {
            return cue.insertarCuentas(cu);
        }
        public List<Cuentas> listarCuentas()
        {
            return cue.listarCuentas();
        }
        public int eliminarCuentas(int idcuent)
        {
            return cue.eliminarCuentas(idcuent);
        }
        public int EditarCuentas(Cuentas cu)
        {
            return cue.EditarCuentas(cu);
        }
        public List<Cuentas> BuscarCuentas(string dato)
        {
            return cue.BuscarCuentas(dato);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev2Model.DAL
{
    public class MedidoresDAL : IMedidoresDAL
    {
        private MedidoresDAL()
        {

        }

        private static MedidoresDAL instancia;

        public static IMedidoresDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new MedidoresDAL();
            }
            return instancia;
        }
        public List<Medidor> ObtenerMedidores()
        {
            List<Medidor> listaMedidores = new List<Medidor>()
           {
                new Medidor() { Id = 1 },
                new Medidor() { Id = 2 },
                new Medidor() { Id = 3 },
                new Medidor() { Id = 4 },
           };
            return listaMedidores;
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev2Model
{
    public class Lectura
    {
        private int medidorId;
        private DateTime fecha;
        private double valor;

        public int MedidorId { get => medidorId; set => medidorId=value; }
        public DateTime Fecha { get => fecha; set => fecha=value; }
        public double Valor { get => valor; set => valor=value; }
    }
}

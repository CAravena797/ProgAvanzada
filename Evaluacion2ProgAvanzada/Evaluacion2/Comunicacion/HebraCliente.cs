using Ev2Model;
using Ev2Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea1Biblioteca;

namespace Evaluacion2.Comunicacion
{
    class HebraCliente
    {
        private ILecturasDAL lecturasDAL = LecturasDAL.GetInstancia();
        private IMedidoresDAL medidoresDAL = MedidoresDAL.GetInstancia();
        private ClienteCom clienteCom;

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Ingrese medidor: ");
            string medidorId = clienteCom.Leer();
            clienteCom.Escribir("Ingrese fecha (AAA-MM-DD hh:mm:ss): ");
            string fecha = clienteCom.Leer();
            clienteCom.Escribir("Ingrese lectura: ");
            string valor = clienteCom.Leer();
            if (medidorId != null && fecha != null && valor != null)
            {
                List<Medidor> medidoresValidos = medidoresDAL.ObtenerMedidores();
                foreach (Medidor medidor in medidoresValidos)
                {
                    if (medidor.Id == Convert.ToInt32(medidorId))
                    {
                        try
                        {
                            Lectura lectura = new Lectura()
                            {
                                MedidorId = Convert.ToInt32(medidorId),
                                Fecha = DateTime.Parse(fecha),
                                Valor = Convert.ToDouble(valor),
                            };
                            lock (lecturasDAL)
                            {
                                lecturasDAL.IngresarLectura(lectura);
                            }
                            clienteCom.Escribir("OK");
                        }catch (Exception ex)
                        {
                            clienteCom.Escribir("Error en formato");
                        }
                        
                    }
                    else
                    {
                        clienteCom.Escribir("Id del medidor no valida");
                    }
                }
                
            }            
            clienteCom.Desconectar();
        }
    }
}

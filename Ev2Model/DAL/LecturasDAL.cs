using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ev2Model.DAL
{
    public class LecturasDAL : ILecturasDAL
    {

        private LecturasDAL()
        {

        }

        private static LecturasDAL instancia;

        public static ILecturasDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new LecturasDAL();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";
        public void IngresarLectura(Lectura lectura)
        {
            string fechaString = lectura.Fecha.ToString();
            fechaString = fechaString.Replace(" ", "-");
            fechaString = fechaString.Replace(":", "-");
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(lectura.MedidorId + "|" + fechaString + "|" + lectura.Valor);
                    writer.Flush();
                }
            }catch (Exception ex)
            {

            }
        }

        public List<Lectura> ObtenerLecturas()
        {
            List<Lectura> lista = new List<Lectura>();
            try
            {
                using(StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split('|');
                            string [] arrFecha = arr[1].Split('-');
                            DateTime fecha = new DateTime(Convert.ToInt32(arrFecha[2]), Convert.ToInt32(arrFecha[1]), Convert.ToInt32(arrFecha[0]), Convert.ToInt32(arrFecha[3]), Convert.ToInt32(arrFecha[4]), Convert.ToInt32(arrFecha[5]));
                            Lectura lectura = new Lectura()
                            {
                                MedidorId = Convert.ToInt32(arr[0]),
                                Fecha = fecha,
                                Valor = Convert.ToDouble(arr[2]),
                            };
                            lista.Add(lectura);
                        }
                    } while (texto != null);
                }
            }catch(Exception ex)
            {
                lista = null;
            }
            return lista;
        }
    }
}

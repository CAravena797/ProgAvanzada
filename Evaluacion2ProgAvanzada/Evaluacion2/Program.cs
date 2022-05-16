using Ev2Model;
using Ev2Model.DAL;
using Evaluacion2.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluacion2
{
    internal class Program
    {
        private static ILecturasDAL lecturasDAL = LecturasDAL.GetInstancia();

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("¿Que quiere hacer?");
            Console.WriteLine("1. Mostrar \n 2. Salir ");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Mostrar();
                    break;
                case "2":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }

        static void Main(string[] args)
        {
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.Start();

            while (Menu()) ;

        }

        static void Mostrar()
        {
            List<Lectura> lecturas = null;
            lock (lecturasDAL)
            {
                lecturas = lecturasDAL.ObtenerLecturas();
            }
            foreach (Lectura lectura in lecturas)
            {
                Console.WriteLine("id medidor: "+lectura.MedidorId);
                Console.WriteLine("fecha: "+lectura.Fecha);
                Console.WriteLine("lectura: "+lectura.Valor);
                Console.WriteLine("----------");
            }
        }
    }
}

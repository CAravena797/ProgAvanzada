using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tarea1Biblioteca;

namespace Tarea1Server
{
    internal class Program
    {
        static void chatServer(ServerSocket servidor)
        {
            Socket socketCliente = servidor.ObtenerCliente();
            //Construir el mecanismo para escribir y leer
            ClienteCom cliente = new ClienteCom(socketCliente);
            //aqui esta el protocolo de comuncacion, ambos deben conocerlo

            Console.WriteLine("Cliente conectado");

            string mensaje = "";
            string respuesta = "";

            while (true)
            { 
                mensaje = Console.ReadLine();
                cliente.Escribir(mensaje);
                respuesta = cliente.Leer();
                Console.WriteLine("cliente: {0}", respuesta);

                
                if (respuesta == "chao"|mensaje == "chao")
                {
                    Console.WriteLine("Cliente desconectado.");
                    cliente.Desconectar();
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.WriteLine("Inicinado Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                //OK puede conectar
                Console.WriteLine("Servidor Iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Cliente...");

                    chatServer(servidor);
                    
                }



            }
            else
            {
                Console.WriteLine("Errror, el puerto {0} esta en uso", puerto);
            }
        }
    }
}

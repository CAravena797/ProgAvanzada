using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea1Biblioteca;

namespace Evaluacion2Cliente
{
    internal class Program
    {
        static void Chat(ClienteSocket clienteSocket)
        {
            string mensaje = "";
            string respuesta = "";

            while (true)
            {
                mensaje = clienteSocket.Leer();
                Console.WriteLine("server: {0}", mensaje);
                respuesta = Console.ReadLine().Trim();
                clienteSocket.Escribir(respuesta);
                if (mensaje == "OK" | mensaje == "Id del medidor no valida" | mensaje == "Error en formato")
                {
                    clienteSocket.Desconectar();
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            string servidor = "127.0.0.1";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conectado a Servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);

            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado...");
                Chat(clienteSocket);
            }
            else
            {
                Console.WriteLine("Error de Comunicacion");
            }
        }
    }
}

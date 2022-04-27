using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea1Biblioteca;

namespace Tarea1Cliente
{
    internal class Program
    {
        static void Chat(ClienteSocket clienteSocket)
        {
            string mensaje = "";
            string respuesta = "";

            while(true)
            {
                mensaje = clienteSocket.Leer();
                Console.WriteLine("server: {0}", mensaje);
                respuesta = Console.ReadLine().Trim();
                clienteSocket.Escribir(respuesta);
                if(respuesta == "chao"|mensaje == "chao")
                {
                    clienteSocket.Desconectar();
                    break;
                }         
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese ip: ");
            string servidor = Console.ReadLine();

            Console.WriteLine("Ingrese puerto: ");
            int puerto = Convert.ToInt32(Console.ReadLine());

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

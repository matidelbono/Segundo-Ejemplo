using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace SegundoEjemploParcial
{
    class Program
    {
        static bool LOG_ARCHIVO = true;
        public delegate void ImprimirDelegado(String mensaje);
        static void Main ( string [] args)
        {

            ImprimirDelegado imprimirDelegado;
            imprimirDelegado = LOG_ARCHIVO ? new ImprimirDelegado(Archivo) : new ImprimirDelegado(Consola);
        }
        public static void Archivo(string mensaje)
        {
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "archivo.txt"))
            {
                writer.WriteLine(mensaje);


            }
        }
        public static void Consola(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
        public static int RestaDeNumeros(int a, int b, ImprimirDelegado delegado)
        {
            int resultado = a - b;
            delegado("$ el resultado es:" + resultado);
            return resultado;
                
        }
    }
}
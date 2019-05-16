using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2ControlModels.DAL;

namespace AppControl2
{
    class Program
    {
        static void Main(string[] args)
        {
            while(Menu()){};
        }

        private static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("Skynet 0.1 alpha");
            Console.WriteLine("================");
            Console.WriteLine("Ingrese una opción:");
            Console.WriteLine("1) Ingresar terminator");
            Console.WriteLine("2) Buscar terminator");
            Console.WriteLine("3) Listar terminators");
            Console.WriteLine("");
            Console.WriteLine("0) Salir");

            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {
                case "1":
                    TerminatorDAL.Ingresar();
                    break;
                case "2":
                    TerminatorDAL.Buscar();
                    break;
                case "3":
                    TerminatorDAL.Listar();
                    break;
                case "0":
                    return false;
                    break;
            }
            
            return true; // temp
        }
    }
}

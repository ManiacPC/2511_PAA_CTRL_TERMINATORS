using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2ControlModels.DTO;

namespace App2ControlModels.DAL
{
    public class TerminatorDAL
    {
        public static List<TerminatorDTO> terminators = new List<TerminatorDTO>();

        public static readonly List<Tipo> tipos = new List<Tipo>()
        {
            new Tipo() { Codigo = "T-1", PrioridadBase = 1},
            new Tipo() { Codigo = "T-800", PrioridadBase = 100},
            new Tipo() { Codigo = "T-1000", PrioridadBase = 200},
            new Tipo() { Codigo = "T-3000", PrioridadBase = 300}
        };

        public static bool Ingresar()
        {
            Tipo tipo = new Tipo();
            bool validacion, vSerie, vTipo, vAño, vObjetivo;
            validacion = vSerie = vTipo = vAño = vObjetivo = false;
            string nserie = null;
            int prioridad = 0;
            int año = 0;
            string objetivo = null;

            while (!validacion)
            {

                // Serie
                Console.WriteLine("Ingrese número de serie: ");
     
                vSerie = ValidarSerie(Console.ReadLine(), ref nserie);

                // Tipo
                tipo = ValidarTipo();
                prioridad = tipo.PrioridadBase;
                vTipo = true;

                // Objetivo
                ValidarObjetivo(ref vObjetivo, ref prioridad, ref objetivo);
                
                // Año
                ValidarAño(ref vAño, ref año);

                validacion = vSerie && vAño && vObjetivo;

                if (!validacion)
                {
                    Console.Clear();
                    if(!vSerie) Console.WriteLine("Verifique que la serie no se encuentre repetida y tenga al menos 7 caracteres");
                    if(!vAño) Console.WriteLine("Verifique el año ingresado sea correcto y se encuentre entre 1997 y 3000");
                    if(!vObjetivo) Console.WriteLine("Verifique que el objetivo escrito sea válido");
                    Console.ReadKey();
                }
            }

            terminators.Add(
                new TerminatorDTO()
                {
                    Tipo = tipo,
                    NumeroSerie = nserie,
                    AñoDestino = año,
                    Objetivo = objetivo,
                    Prioridad = prioridad
                }
            );
            Console.WriteLine("Ha sido agregado un nuevo terminator");
            Console.ReadLine();
            return true;
        }

        private static void ValidarAño(ref bool vAño, ref int nAño)
        {
            Console.WriteLine("Ingrese año de destino:");

            try
            {
                int año = Convert.ToInt32(Console.ReadLine()?.Trim());
                if (año >= 1997 && año < 3000)
                {
                    vAño = true;
                    nAño = año;
                }
            }
            catch (Exception e)
            {
                vAño = false;
            }

        }

        private static void ValidarObjetivo(ref bool vObjetivo, ref int prioridad, ref string objet)
        {
            Console.WriteLine("Ingrese un objetivo:");
            string objetivo = Console.ReadLine()?.Trim();
           
            if (objetivo.ToUpper().Equals("SARAH CONNOR"))
                prioridad = 999;

            if (String.IsNullOrEmpty(objetivo))
                vObjetivo = false;
            else
            {
                objet = objetivo;
                vObjetivo = true;
            }
        }

        private static Tipo ValidarTipo()
        {
            bool vTipo = false;

            while (!vTipo)
            {
                Console.WriteLine("Ingrese tipo:");
                Console.Write("(");
                foreach (Tipo t in tipos)
                {
                    Console.Write(t.Codigo);
                    Console.Write(", ");
                }
                Console.Write(")");

                string tipo = Console.ReadLine();

                foreach (Tipo t in tipos)
                {
                    if (t.Codigo == tipo.ToUpper())
                    {
                        vTipo = true;
                        return t;
                    }

                }
            }

            return new Tipo();
        }

        private static bool ValidarSerie(string entrada, ref string serie)
        {
            // Buscar repetidos
            foreach (TerminatorDTO t in terminators)
            {
                if (t.NumeroSerie == entrada) return false;
            }

            // Validar serie y largo
            if (entrada.Length == 7)
            {
                serie = entrada;
                return true;
            }
            else return false;
        }

        public static void Buscar()
        {
            Console.Clear();
            Console.WriteLine("Escriba modelo de terminator a buscar:");
            string modelo = Console.ReadLine().Trim().ToUpper();
            Console.WriteLine("Escriba año de terminator a buscar:");
            int año = Convert.ToInt32(Console.ReadLine().Trim());

           // List<TerminatorDTO> encontrados =
           //     terminators.Where(x => x.Tipo.Codigo == modelo && x.AñoDestino == año).ToList();

           //foreach (TerminatorDTO t in terminators.Where(x => x.Tipo.Codigo == modelo && x.AñoDestino == año).ToList())
           // {
           //         Console.WriteLine($"R:{t.ToString()}");
           // }

            foreach (TerminatorDTO t in terminators)
            {
                if(t.Tipo.Codigo == modelo && t.AñoDestino == año)
                    Console.WriteLine($"R:{t.ToString()}");
            }

            Console.ReadLine(); // Pause

        }

        public static void Listar()
        {
            Console.Clear();
            Console.WriteLine("Listado de terminators");
            foreach (TerminatorDTO t in terminators)
            {
                Console.WriteLine($"R:{t.ToString()}");
            }

            Console.ReadLine();

        }
    }
}

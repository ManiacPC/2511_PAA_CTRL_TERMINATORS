using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2ControlModels.DTO
{
    public struct Tipo
    {
        private string codigo;
        private int prioridadBase;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public int PrioridadBase
        {
            get { return prioridadBase; }
            set { prioridadBase = value; }
        }
    }
    public class TerminatorDTO
    {
        private string numeroSerie;
        private Tipo tipo;
        private string objetivo;
        private int añoDestino;

        public string NumeroSerie
        {
            get { return numeroSerie; }
            set { numeroSerie = value; }
        }

        public Tipo Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Objetivo
        {
            get { return objetivo; }
            set { objetivo = value; }
        }

        public int AñoDestino
        {
            get { return añoDestino; }
            set { añoDestino = value; }
        }
    }
}

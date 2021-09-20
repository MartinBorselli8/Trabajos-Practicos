using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
    class Descuento
    {
        private string codigo;
        private double porcentaje;

        public Descuento(string codigo, double porcentaje)
        {
            this.Codigo = codigo;
            this.Porcentaje = porcentaje;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public double Porcentaje { get => porcentaje; set => porcentaje = value; }
    }
}

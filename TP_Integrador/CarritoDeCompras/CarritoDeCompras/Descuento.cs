using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
    public class Descuento
    {
        private string codigo;
        private int porcentaje;

        public Descuento(string codigo, int porcentaje)
        {
            this.Codigo = codigo;
            this.Porcentaje = porcentaje;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public int Porcentaje { get => porcentaje; set => porcentaje = value; }
    }
}

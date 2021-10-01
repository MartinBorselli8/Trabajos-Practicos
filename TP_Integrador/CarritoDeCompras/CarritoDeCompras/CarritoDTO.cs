using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
    class CarritoDTO
    {
        private string fecha;
        private decimal importeTotal;

        public string Fecha { get => fecha; set => fecha = value; }
        public decimal ImporteTotal { get => importeTotal; set => importeTotal = value; }
    }
}

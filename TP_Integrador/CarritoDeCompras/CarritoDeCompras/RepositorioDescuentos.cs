using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
    class RepositorioDescuentos
    {
        private List<Descuento> listadoDescuentos = new List<Descuento>();

        public List<Descuento> ListadoDescuentos { get => listadoDescuentos; set => listadoDescuentos = value; }

        public void agregarDescuento(Descuento descuento)
        {
            ListadoDescuentos.Add(descuento);
        }
    }
}

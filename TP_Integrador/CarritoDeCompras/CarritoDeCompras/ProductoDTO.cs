using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CarritoDeCompras
{
    class ProductoDTO
    {
        public int codigoProducto;
        public string descripcion;
        public decimal precioUnitario;
        public int cantidadActual;
        public bool disponible;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
    class ItemProducto
    {
        private int cantidad;
        private decimal precioPorCantidad;
        private Producto producto;

        public ItemProducto(int cantidad, decimal precioPorCantidad, Producto producto)
        {
            this.Cantidad = cantidad;
            this.PrecioPorCantidad = precioPorCantidad;
            this.Producto = producto;
        }

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioPorCantidad { get => precioPorCantidad; set => precioPorCantidad = value; }
        internal Producto Producto { get => producto; set => producto = value; }
    }

    
}

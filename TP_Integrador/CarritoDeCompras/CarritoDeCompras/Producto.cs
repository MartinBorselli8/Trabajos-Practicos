using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
     public class Producto
    {
        private int codigoProducto;
        private string descripcion;
        private decimal precioUnitario;
        private int cantidadActual;
        private bool disponible;
        

        public Producto(int codigoProducto, string descripcion, decimal precioUnitario, int cantidadActual, bool disponible)
        {
            this.codigoProducto = codigoProducto;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            this.cantidadActual = cantidadActual;
            this.disponible = disponible;
        }

        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
       
        public string Descripcion { get => descripcion; set => descripcion = value; }
       
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int CantidadActual { get => cantidadActual; set => cantidadActual = value; }
        public bool Disponible { get => disponible; set => disponible = value; }


        public void getDatos()
        {
            Console.WriteLine("Codigo de producto: "+ codigoProducto + "\n Producto:" + Descripcion + "\n" + "Precio unitario: " + PrecioUnitario
                + "\n" + "Stock restante: " + cantidadActual );
            if (Disponible)
            {
                Console.WriteLine("Estado: Disponible. \n \n");
            }
            else
            {
                Console.WriteLine("Estado: No disponible. \n \n");
            }
        }

        public void setEstado()
        {
            if (cantidadActual < 1)
            {
                Disponible = false;
            }
        }
    }
}

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
        private DateTime? fechaInicioOferta;
        private DateTime? fechaCierreOferta;
        private bool estaEnOferta;
        private decimal? descuentoPorOferta;
        private decimal? descuentoEntreDosYCincoUnidades;
        private decimal? descuentoEntreSeisYDiezUnidades;
        private decimal? descuentoMasDeDiezUnidades;

        public Producto(int codigoProducto, string descripcion, decimal precioUnitario, int cantidadActual, bool disponible, DateTime? fechaInicioOferta, DateTime? fechaCierreOferta, bool estaEnOferta, 
            decimal? descuentoPorOferta, decimal? descuentoEntreDosYCincoUnidades, decimal? descuentoEntreSeisYDiezUnidades, decimal? descuentoMasDeDiezUnidades)
        {
            this.codigoProducto = codigoProducto;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            this.cantidadActual = cantidadActual;
            this.disponible = disponible;
            this.fechaInicioOferta = fechaInicioOferta;
            this.fechaCierreOferta = fechaCierreOferta;
            this.estaEnOferta = estaEnOferta;
            this.descuentoPorOferta = descuentoPorOferta;
            this.descuentoEntreDosYCincoUnidades = descuentoEntreDosYCincoUnidades;
            this.descuentoEntreSeisYDiezUnidades = descuentoEntreSeisYDiezUnidades;
            this.descuentoMasDeDiezUnidades = descuentoMasDeDiezUnidades;
        }

        

        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
       
        public string Descripcion { get => descripcion; set => descripcion = value; }
       
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int CantidadActual { get => cantidadActual; set => cantidadActual = value; }
        public bool Disponible { get => disponible; set => disponible = value; }
        public DateTime? FechaInicioOferta { get => fechaInicioOferta; set => fechaInicioOferta = value; }
        public DateTime? FechaCierreOferta { get => fechaCierreOferta; set => fechaCierreOferta = value; }
        public bool EstaEnOferta { get => estaEnOferta; set => estaEnOferta = value; }
        public decimal? DescuentoPorOferta { get => descuentoPorOferta; set => descuentoPorOferta = value; }
        public decimal? DescuentoEntreDosYCincoUnidades { get => descuentoEntreDosYCincoUnidades; set => descuentoEntreDosYCincoUnidades = value; }
        public decimal? DescuentoEntreSeisYDiezUnidades { get => descuentoEntreSeisYDiezUnidades; set => descuentoEntreSeisYDiezUnidades = value; }
        public decimal? DescuentoMasDeDiezUnidades { get => descuentoMasDeDiezUnidades; set => descuentoMasDeDiezUnidades = value; }

        public void getDatos()
        {
            Console.WriteLine("Codigo de producto: "+ codigoProducto + "\nProducto:" + Descripcion + "\n" + "Precio unitario: " + PrecioUnitario
                + "\n" + "Stock restante: " + cantidadActual );
            if (estaEnOferta)
            {
                Console.WriteLine("Oferta del " + descuentoPorOferta * 100 + "%. \n \n");
            }
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

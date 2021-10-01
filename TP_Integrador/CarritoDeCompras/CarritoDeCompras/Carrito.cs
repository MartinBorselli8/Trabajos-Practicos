using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CarritoDeCompras
{
    class Carrito
    {
        private int nroOrden;
        private DateTime fechaOrden;
        private decimal importeTotal;
        private List<ItemProducto> listadoProductosSeleccionados = new List<ItemProducto>();
        private int cantidadDeProductos;

        public int NroOrden { get => nroOrden; set => nroOrden = value; }
        public DateTime FechaOrden { get => fechaOrden; set => fechaOrden = value; }
        public decimal ImporteTotal { get => importeTotal; set => importeTotal = value; }
        public int CantidadDeProductos { get => cantidadDeProductos; set => cantidadDeProductos = value; }
        internal List<ItemProducto> ListadoProductosSeleccionados { get => listadoProductosSeleccionados; set => listadoProductosSeleccionados = value; }

        public void calcularMontoTotal(int porcentaje)
        {
            decimal total = 0;

            foreach (ItemProducto i in ListadoProductosSeleccionados)
            {
                total = total + i.PrecioPorCantidad;
            }

            if (porcentaje != 0)
            {
                ImporteTotal = total - ((total * porcentaje) / 100);
            }
            else
            {
                ImporteTotal = total;
            }
        }

        public void agregarProductoAlCarro(Producto producto, int cantidad)
        {
            decimal TotalPorProducto;
            if (producto.CantidadActual >= cantidad)
            {
                if (producto.Disponible == true)
                {
                    TotalPorProducto = producto.PrecioUnitario * cantidad;
                    ItemProducto newItem = new ItemProducto(cantidad, TotalPorProducto, producto);
                    CantidadDeProductos = CantidadDeProductos + cantidad;
                    ListadoProductosSeleccionados.Add(newItem);
                    producto.CantidadActual = producto.CantidadActual - cantidad;
                    producto.setEstado();
                }
                else
                {
                    Console.WriteLine("El producto no esta disponible");
                }
            }
            else
            {
                Console.WriteLine("No hay stock suficiente, cantidad restante:" + producto.CantidadActual);
                Console.ReadKey();
            }
        }

        public bool quitarProductoDelCarro(ItemProducto item, int cantidad)
        {
            
            bool ban = false;
            foreach (ItemProducto i in listadoProductosSeleccionados)
            {
                if (i == item)
                {
                    i.Cantidad = i.Cantidad - cantidad;
                    i.PrecioPorCantidad = i.Producto.PrecioUnitario * i.Cantidad;
                    cantidadDeProductos = cantidadDeProductos - cantidad;
                    if (i.Cantidad == 0)
                    {
                        ban = true;
                    }
                }
            }
            

            Console.WriteLine("¡Carrito Actualizado!");
            Console.ReadKey();
            Console.Clear();
            return (ban);
        }
        
        public void mostrarProductosSeleccionados()
        {
            
            foreach(ItemProducto i in listadoProductosSeleccionados)
            {
                i.Producto.getDatos();
                Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                Console.WriteLine("Precio: $" + i.PrecioPorCantidad);
                Console.WriteLine("---------------------\n");
            }

        }

    }
}
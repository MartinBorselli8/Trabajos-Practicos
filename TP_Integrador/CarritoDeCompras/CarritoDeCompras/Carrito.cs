using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CarritoDeCompras
{
    public class Carrito
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

        public void calcularImporteTotal(int porcentaje)
        {
            decimal? total = 0;

            foreach (ItemProducto i in ListadoProductosSeleccionados)
            {
                total = total + i.PrecioPorCantidad;
            }

            if (porcentaje != 0)
            {
                ImporteTotal = Convert.ToDecimal(total - ((total * porcentaje) / 100));
            }
            else
            {
                ImporteTotal = Convert.ToDecimal(total);
            }
        }

        public void agregarProductoAlCarro(Producto producto, int cantidad)
        {
            bool bandera = false;
            ItemProducto itemAUX = new ItemProducto(0, 0, null);
           
            if (producto.CantidadActual >= cantidad)
            {
                if (producto.Disponible == true)
                {
                    foreach (ItemProducto i in ListadoProductosSeleccionados)
                    {
                        if (i.Producto == producto)
                        {
                            bandera = true;
                            itemAUX=i;
                        }
                    }

                    if (bandera)
                    {
                        itemAUX.Cantidad = itemAUX.Cantidad + cantidad;
                        itemAUX.PrecioPorCantidad = PrecioDeVenta(producto, itemAUX.Cantidad);
                        CantidadDeProductos = CantidadDeProductos + cantidad;
                        producto.CantidadActual = producto.CantidadActual - cantidad;
                        producto.setEstado();
                    }
                    else
                    {
                        ItemProducto newItem = new ItemProducto(cantidad, PrecioDeVenta(producto, cantidad), producto);
                        CantidadDeProductos = CantidadDeProductos + cantidad;
                        ListadoProductosSeleccionados.Add(newItem);
                        producto.CantidadActual = producto.CantidadActual - cantidad;
                        producto.setEstado();
                    }
    
                }else
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
                    i.PrecioPorCantidad = PrecioDeVenta(i.Producto, i.Cantidad);
                    cantidadDeProductos = cantidadDeProductos - cantidad;
                    if (i.Cantidad <= 0)
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
        
        public decimal PrecioDeVenta(Producto producto, int cantidad)
        {
            if (cantidad == 1)
            {
                if (producto.EstaEnOferta)
                {
                    return Convert.ToDecimal(((producto.PrecioUnitario) - (producto.PrecioUnitario * producto.DescuentoPorOferta)) * cantidad);
                }
                else
                {
                    return producto.PrecioUnitario * cantidad;
                }
            }
            else if (2 <= cantidad && cantidad <= 5)
            {
                decimal precioRangoDosACinco = Convert.ToDecimal(producto.PrecioUnitario - (producto.PrecioUnitario * producto.DescuentoEntreDosYCincoUnidades));
                if (producto.EstaEnOferta)
                {
                    return Convert.ToDecimal((precioRangoDosACinco - (precioRangoDosACinco * producto.DescuentoPorOferta)) * cantidad);
                }
                else
                {
                    return Convert.ToDecimal(precioRangoDosACinco * cantidad);
                }
            }
            else if (6 <= cantidad && cantidad <= 10)
            {
                decimal? precioRangoSeisADiez = producto.PrecioUnitario - (producto.PrecioUnitario * producto.DescuentoEntreSeisYDiezUnidades);
                if (producto.EstaEnOferta)
                {
                    return Convert.ToDecimal((precioRangoSeisADiez - (precioRangoSeisADiez * producto.DescuentoPorOferta)) * cantidad);
                }
                else
                {
                    return Convert.ToDecimal(precioRangoSeisADiez * cantidad);
                }
            }
            else if (10 <= cantidad)
            {
                decimal? precioRangoDiezOMas = producto.PrecioUnitario - (producto.PrecioUnitario * producto.DescuentoEntreSeisYDiezUnidades);
                if (producto.EstaEnOferta)
                {
                    return Convert.ToDecimal((precioRangoDiezOMas - (precioRangoDiezOMas * producto.DescuentoPorOferta)) * cantidad);
                }
                else
                {
                    return Convert.ToDecimal(precioRangoDiezOMas * cantidad);
                }
            }
            else
            {
                return 0;
            }
        }

        public void mostrarProductosSeleccionados()
        {
            
            foreach(ItemProducto i in listadoProductosSeleccionados)
            {
                i.Producto.getDatos();
                if (i.Producto.EstaEnOferta)
                {
                    if (i.Cantidad == 1) {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Porcentaje de descuento por Oferta: " + (i.Producto.DescuentoPorOferta * 100) + "%.");
                        Console.WriteLine("Precio por unidad: $" + i.PrecioPorCantidad);
                        Console.WriteLine("---------------------\n");
                    }else if (2 <= i.Cantidad && i.Cantidad <= 5)
                    {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Porcentaje de descuento por Oferta: " + (i.Producto.DescuentoPorOferta * 100) + "%.");
                        Console.WriteLine("Porcentaje de descuento por cantidad seleccionada: " + (i.Producto.DescuentoEntreDosYCincoUnidades * 100) + "%.");
                        Console.WriteLine("Precio por unidad: " + i.PrecioPorCantidad / i.Cantidad);
                        Console.WriteLine("---------------------\n");
                    }else if (6 <= i.Cantidad && i.Cantidad < 10)
                    {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Porcentaje de descuento por Oferta: " + (i.Producto.DescuentoPorOferta * 100) + "%.");
                        Console.WriteLine("Porcentaje de descuento por cantidad seleccionada: " + (i.Producto.DescuentoEntreSeisYDiezUnidades * 100)  + "%.");
                        Console.WriteLine("Precio por unidad: " + i.PrecioPorCantidad / i.Cantidad);
                        Console.WriteLine("---------------------\n");
                    }
                    else
                    {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Porcentaje de descuento por Oferta: " + (i.Producto.DescuentoPorOferta * 100) + "%.");
                        Console.WriteLine("Porcentaje de descuento por cantidad seleccionada: " + (i.Producto.DescuentoMasDeDiezUnidades * 100) + "%.");
                        Console.WriteLine("Precio por unidad: " + i.PrecioPorCantidad / i.Cantidad);
                        Console.WriteLine("---------------------\n");
                    }

                }
                else
                {
                    
                    if (i.Cantidad == 1)
                    {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Precio por unidad: $" + i.PrecioPorCantidad);
                        Console.WriteLine("---------------------\n");
                    }
                    else if (2 <= i.Cantidad && i.Cantidad <= 5)
                    {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Porcentaje de descuento por cantidad seleccionada: " + (i.Producto.DescuentoEntreDosYCincoUnidades * 100) + "%.");
                        Console.WriteLine("Precio por unidad: " + i.PrecioPorCantidad / i.Cantidad);
                        Console.WriteLine("---------------------\n");
                    }
                    else if (6 <= i.Cantidad && i.Cantidad < 10)
                    {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Porcentaje de descuento por cantidad seleccionada: " + (i.Producto.DescuentoEntreSeisYDiezUnidades * 100) + "%.");
                        Console.WriteLine("Precio por unidad: " + i.PrecioPorCantidad / i.Cantidad);
                        Console.WriteLine("---------------------\n");
                    }
                    else
                    {
                        Console.WriteLine("Cantidad seleccionada: " + i.Cantidad);
                        Console.WriteLine("Porcentaje de descuento por cantidad seleccionada: " + (i.Producto.DescuentoMasDeDiezUnidades * 100) + "%.");
                        Console.WriteLine("Precio por unidad: " + i.PrecioPorCantidad / i.Cantidad);
                        Console.WriteLine("---------------------\n");
                    }
                }
                
            }

        }

    }
}
using System;
using System.IO;
using System.Text.Json;

namespace CarritoDeCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            int op, cantidadDeseada, cod;
            Random random = new Random();
            //string _path = @"C:\Users\Usuario\Documents\GitHub\Trabajos-Practicos\TP_Integrador"; 
            RepositorioProductos repositorioProductos = new RepositorioProductos();
            RepositorioDescuentos repositorioDescuentos = new RepositorioDescuentos();
            Carrito carrito1 = new Carrito();
            carrito1.FechaOrden = DateTime.Now;
            carrito1.CantidadDeProductos = 0;
            carrito1.NroOrden = random.Next(1, 100);

            InstanciasPrevias();

            Console.Clear();
            Console.WriteLine("********CARRITO DE COMPRAS********");
            Console.WriteLine("*********TIENDA MATEAR************\n");
            if (carrito1.CantidadDeProductos == 0)
            {

                Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
                Console.WriteLine("Ingrese 0 si quiere ver la lista de productos: ");
                op = Convert.ToInt32(Console.ReadLine());

                if (op == 0)
                {
                    Console.Clear();
                    Console.WriteLine("********CARRITO DE COMPRAS********");
                    Console.WriteLine("*********TIENDA MATEAR************\n");
                    Console.WriteLine("A continuacion te mostramos el listado de productos: ");
                    repositorioProductos.mostrarTodosLosProductos();
                }

            }


            Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");

            Console.WriteLine("Ingrese 0 para ver el listado de productos.");
            Console.WriteLine("Ingrese 1 para agregar un producto.");
            Console.WriteLine("Ingrese 2 para quitar un producto.");
            Console.WriteLine("Ingrese 3 para aplicar el codigo de descuento.");
            Console.WriteLine("Ingrese 5 para confirmar la compra.");
            op = Convert.ToInt32(Console.ReadLine());

            while (op != 5)
            {
                switch (op)
                {
                    case 0:
                        repositorioProductos.mostrarTodosLosProductos();
                        break;
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        QuitarProducto();
                        break;
                    //case 3:
                    //    AplicarDescuento();
                    //   break;
                    //case 4:

                    //    break;
                    default:
                        Console.WriteLine("¡Opcion Incorrecta!");
                        break;
                }//fin switch
                Console.WriteLine("Ingrese 0 para ver el listado de productos.");
                Console.WriteLine("Ingrese 1 para agregar un producto.");
                Console.WriteLine("Ingrese 2 para quitar un producto.");
                Console.WriteLine("Ingrese 3 para aplicar el codigo de descuento.");
                Console.WriteLine("Ingrese 5 para confirmar la compra.");
                op = Convert.ToInt32(Console.ReadLine());
            }//fin while

            Console.Clear();
            Console.WriteLine("********CARRITO DE COMPRAS********");
            Console.WriteLine("*********TIENDA MATEAR************\n");
            carrito1.mostrarProductosSeleccionados();
            Console.WriteLine("Total de la compra: " + carrito1.ImporteTotal);
            Console.WriteLine("¡Gracias por confiar en nosotros!");

            //CarritoDTO carritoDTO = new CarritoDTO();
            //carritoDTO.Fecha = carrito1.FechaOrden;
            //carritoDTO.ImporteTotal = carrito1.ImporteTotal;
            //File.WriteAllText(_path, JsonSerializer.Serialize(carritoDTO));
            

            //Esta funcion se encarga de hacer instancias a varias clases para probar el codigo.
            void InstanciasPrevias()
            {

                Producto producto1 = new Producto(1, "Yerba Mate", 800.2m, 15, true);
                Producto producto2 = new Producto(2, "Mate torpedo", 2500.3m, 12, true);
                Producto producto3 = new Producto(3, "Bombilla Pico Loro", 1200.00m, 22, true);
                Producto producto4 = new Producto(4, "Yerbera", 700.5m, 15, true);

                Descuento descuento1 = new Descuento("LeoMATEoli", 10);
                Descuento descuento2 = new Descuento("MateAmargo", 15);

                repositorioDescuentos.agregarDescuento(descuento1);
                repositorioDescuentos.agregarDescuento(descuento2);

                repositorioProductos.agregarProductoAListado(producto1);
                repositorioProductos.agregarProductoAListado(producto2);
                repositorioProductos.agregarProductoAListado(producto3);
                repositorioProductos.agregarProductoAListado(producto4);
            }
            //Esta funcion se encarga del caso de uso "Agregar producto".
            void AgregarProducto()
            {
                Console.Clear();
                Console.WriteLine("********CARRITO DE COMPRAS********");
                Console.WriteLine("*********TIENDA MATEAR************\n");
                repositorioProductos.mostrarTodosLosProductos();
                Console.WriteLine("\nIngrese el codigo del producto que desea: ");
                cod = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nIngrese la cantidad que desea: ");
                cantidadDeseada = Convert.ToInt32(Console.ReadLine());

                foreach (Producto a in repositorioProductos.ListadoDeProductos)
                {

                    if (a.CodigoProducto == cod)
                    {
                        carrito1.agregarProductoAlCarro(a, cantidadDeseada);
                    }
                }

                Console.Clear();
                Console.WriteLine("********CARRITO DE COMPRAS********");
                Console.WriteLine("*********TIENDA MATEAR************\n");
                Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
                carrito1.mostrarProductosSeleccionados();
                carrito1.calcularMontoTotal();
                Console.WriteLine("TOTAL: $" + carrito1.ImporteTotal);

            }

            //Esta funcion se encarga del caso de uso "Quitar producto".
            void QuitarProducto()
            {
                bool bandera=false;
                int indice=0, contador=-1;
                
                Console.Clear();
                Console.WriteLine("********CARRITO DE COMPRAS********");
                Console.WriteLine("*********TIENDA MATEAR************\n");
                carrito1.mostrarProductosSeleccionados();
                Console.WriteLine("\nIngrese el codigo del producto que desea quitar: ");
                cod = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nIngrese la cantidad que desea quitar: ");
                cantidadDeseada = Convert.ToInt32(Console.ReadLine());

                foreach (ItemProducto a in carrito1.ListadoProductosSeleccionados)
                {
                    contador++;
                    if (a.Producto.CodigoProducto == cod)
                    {
                        bandera=carrito1.quitarProductoDelCarro(a, cantidadDeseada);
                        indice = contador;
                    }
                    
                }

                if (bandera)
                {
                    carrito1.ListadoProductosSeleccionados.RemoveAt(indice);
                }
                Console.Clear();
                Console.WriteLine("********CARRITO DE COMPRAS********");
                Console.WriteLine("*********TIENDA MATEAR************\n");
                Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
                carrito1.mostrarProductosSeleccionados();
                carrito1.calcularMontoTotal();
                Console.WriteLine("TOTAL: $" + carrito1.ImporteTotal);

            }

            //void AplicarDescuento()
            //{
            //    double auxImporte=0;
            //    bool ban=true;
            //    string codigo = " ";
            //    Console.WriteLine("Ingrese el codigo de descuento: ");
            //    codigo = Console.ReadLine();
            //    Console.Clear();
            //    Console.WriteLine("********CARRITO DE COMPRAS********");
            //    Console.WriteLine("*********TIENDA MATEAR************\n");
            //    Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
            //    carrito1.mostrarProductosSeleccionados();
            //    carrito1.calcularMontoTotal();
            //    Console.WriteLine("TOTAL: $" + carrito1.ImporteTotal);
            //    foreach (Descuento i in repositorioDescuentos.ListadoDescuentos)
            //    {
            //        if (codigo == i.Codigo)
            //        {
            //            auxImporte = (carrito1.ImporteTotal - ((i.Porcentaje * carrito1.ImporteTotal) / 100));
            //            //carrito1.ImporteTotal = (carrito1.ImporteTotal - ((i.Porcentaje * carrito1.ImporteTotal)/100));
            //            carrito1.ImporteTotal = auxImporte;
            //            ban = false;
            //        }

            //    }
            //    if (ban)
            //    {
            //        Console.WriteLine("El codigo de descuento ingresado es incorrecto.");
            //    }

            //    Console.Clear();
            //    Console.WriteLine("********CARRITO DE COMPRAS********");
            //    Console.WriteLine("*********TIENDA MATEAR************\n");
            //    Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
            //    carrito1.mostrarProductosSeleccionados();
            //    carrito1.calcularMontoTotal();
            //    Console.WriteLine("TOTAL: $" + carrito1.ImporteTotal);

            //}
        }
    }
}


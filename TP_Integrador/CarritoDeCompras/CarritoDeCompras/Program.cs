using System;
using System.Collections.Generic;
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
             
            RepositorioProductos repositorioProductos = new RepositorioProductos();
            RepositorioDescuentos repositorioDescuentos = new RepositorioDescuentos();
            Carrito carrito1 = new Carrito();
            carrito1.FechaOrden = DateTime.Now;
            carrito1.CantidadDeProductos = 0;
            carrito1.NroOrden = random.Next(1, 100);

            InstanciasPrevias();
            CargarProductosAlSistema();

            Console.Clear();
            MostrarEncabezado();
            if (carrito1.CantidadDeProductos == 0)
            {

                Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
                Console.WriteLine("Ingrese 0 si quiere ver la lista de productos: ");
                op = Convert.ToInt32(Console.ReadLine());

                if (op == 0)
                {
                    Console.Clear();
                    MostrarEncabezado();
                    Console.WriteLine("A continuacion te mostramos el listado de productos: ");
                    repositorioProductos.mostrarTodosLosProductos();
                }

            }


            Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");

            Console.WriteLine("Ingrese 0 para ver el listado de productos.");
            Console.WriteLine("Ingrese 1 para agregar un producto.");
            Console.WriteLine("Ingrese 2 para quitar un producto.");
            Console.WriteLine("Ingrese 3 para confirmar los productos");
            op = Convert.ToInt32(Console.ReadLine());

            while (op != 3)
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
                    default:
                        Console.WriteLine("¡Opcion Incorrecta!");
                        break;
                }//fin switch
                Console.WriteLine("\nIngrese 0 para ver el listado de productos.");
                Console.WriteLine("Ingrese 1 para agregar un producto.");
                Console.WriteLine("Ingrese 2 para quitar un producto.");
                Console.WriteLine("Ingrese 3 para confirmar los productos.");
                op = Convert.ToInt32(Console.ReadLine());
            }//fin while

            Console.Clear();
            MostrarEncabezado();
            carrito1.mostrarProductosSeleccionados();
            Console.WriteLine("Si desea ingresar un codigo de descuento, presione 0.");
            Console.WriteLine("Si no, ingrese cualquier otro numero.");
            op = Convert.ToInt32(Console.ReadLine());
            if (op == 0)
            {
                AplicarDescuento();
            }  
            Console.Clear();
            MostrarEncabezado();
            carrito1.mostrarProductosSeleccionados();
            Console.WriteLine("Total de la compra: " + carrito1.ImporteTotal);
            Console.WriteLine("¡Gracias por confiar en nosotros!");

            SerializarCarrito();

            void MostrarEncabezado()
            {
                Console.WriteLine("********CARRITO DE COMPRAS********");
                Console.WriteLine("*********TIENDA MATEAR************\n");
            }

            void CargarProductosAlSistema()
            {
                string listaSerializada;
                TextReader ListaDeProductos = new StreamReader("ListadoProductos");
                listaSerializada = ListaDeProductos.ReadLine();
                repositorioProductos.ListadoDeProductos = JsonSerializer.Deserialize<List<Producto>>(listaSerializada);
            }

            //Esta funcion se encarga de hacer instancias a varias clases para probar el codigo.
            void InstanciasPrevias()
            {
            
                Descuento descuento1 = new Descuento("LeoMATEoli", 10);
                Descuento descuento2 = new Descuento("MateAmargo", 15);

                repositorioDescuentos.agregarDescuento(descuento1);
                repositorioDescuentos.agregarDescuento(descuento2);
            }
            //Esta funcion se encarga del caso de uso "Agregar producto".
            void AgregarProducto()
            {
                Console.Clear();
                MostrarEncabezado();
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
                MostrarEncabezado();
                Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
                carrito1.mostrarProductosSeleccionados();
                carrito1.calcularImporteTotal(0);
                Console.WriteLine("TOTAL: $" + carrito1.ImporteTotal);

            }

            //Esta funcion se encarga del caso de uso "Quitar producto".
            void QuitarProducto()
            {
                bool bandera=false;
                int indice=0, contador=-1;
                
                Console.Clear();
                MostrarEncabezado();
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
                MostrarEncabezado();
                Console.WriteLine("Cantidad de articulos seleccionados (" + carrito1.CantidadDeProductos + ") \n");
                carrito1.mostrarProductosSeleccionados();
                carrito1.calcularImporteTotal(0);
                Console.WriteLine("TOTAL: $" + carrito1.ImporteTotal);

            }

            void AplicarDescuento()
            {
                string codigoDescuento = " ";
                bool ban=false;
                int porcentaje=0;

                Console.Clear();
                MostrarEncabezado();
                Console.WriteLine("Ingrese el codigo de descuento: ");
                codigoDescuento = Console.ReadLine();

                foreach(Descuento i in repositorioDescuentos.ListadoDescuentos)
                {
                    if(codigoDescuento == i.Codigo)
                    {
                        ban = true;
                        porcentaje = i.Porcentaje;
                    }
                }

                if (ban)
                {
                    carrito1.calcularImporteTotal(porcentaje);
                }
                else
                {
                    Console.WriteLine("El codigo de descuento no es correcto.");
                }
            }

            void SerializarCarrito()
            {
                CarritoDTO carritoDTO = new CarritoDTO();
                carritoDTO.Fecha = Convert.ToString(carrito1.FechaOrden);
                carritoDTO.ImporteTotal = carrito1.ImporteTotal;
                TextWriter CarritoSerializado = new StreamWriter("carrito.txt");
                CarritoSerializado.WriteLine(JsonSerializer.Serialize(carritoDTO));
                CarritoSerializado.Close();
            }
        }
    }
}


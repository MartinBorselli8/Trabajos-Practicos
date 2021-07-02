using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;



namespace TP_4_BorselliMartin8
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int op;
            string dni;

            InstaciasPrevias();


            /* "Interfaz grafica" */

            Console.WriteLine("Elija una de las dos opciones: ");
            Console.WriteLine("Registrar Persona ------ 1");
            Console.WriteLine("Autorizar ingreso ------ 2");
            Console.WriteLine("Registrar Empresa ------ 3");
            Console.WriteLine("Dar de alta a un empleado ------ 4");
            Console.WriteLine("Dar de baja una persona ------ 5");
            Console.WriteLine("Registrar salida ------ 6");
            

            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    RegistrarPersona();
                    break;
                case 2:
                    AutorizarIngreso();
                    break;
                case 3:
                    RegistrarEmpresa();
                    break;
                case 4:
                    AsociarEmpleado();
                    break;
                case 5:
                    RegistrarBajaPersona();
                    break;
                case 6:
                    RegistrarSalida();
                    break;
             
            }
            static void InstaciasPrevias()
            {
                /* Intancias de actividades */
                Actividad actividad1 = new Actividad("Flete", true);
                Actividad actividad2 = new Actividad("Visita medica", true);
                Actividad actividad3 = new Actividad("Trabajo", true);

                RepositorioActividades.agregarActividad(actividad1);
                RepositorioActividades.agregarActividad(actividad2);
                RepositorioActividades.agregarActividad(actividad3);

                /* Instancias de Personas */
                Persona persona1 = new Persona();

                persona1.Dni = "42890804";
                persona1.NombreApellido = "Martin Borselli";
                persona1.Domicilio = "Juan XXIII 87";
                persona1.EMail = "martin.borselli@gmail.com";
                persona1.Telefono = "3564-131419";
                persona1.ActividadRealizada = actividad3;
                persona1.FechaDesde = new DateTime(2021, 01, 15);
                persona1.FechaHasta = new DateTime(2021, 10, 15);
                
                generarQR(persona1);

                Persona persona2 = new Persona();
                persona2.Dni = "17800971";
                persona2.NombreApellido = "Maria celia";
                persona2.Domicilio = "Juan 13";
                persona2.EMail = "mary@gmail.com";
                persona2.Telefono = "3564-12323";
                persona2.ActividadRealizada = actividad1;
                persona2.FechaDesde = new DateTime(2021, 04, 20);
                persona2.FechaHasta = new DateTime(2021, 10, 20);
                
                generarQR(persona2);

                Persona persona3 = new Persona();
                persona3.Dni = "13425032";
                persona3.NombreApellido = "Nicolas borselli";
                persona3.Domicilio = "Cura brochero 32";
                persona3.EMail = "nico.borselli@gmail.com";
                persona3.Telefono = "3564-647782";
                persona3.ActividadRealizada = actividad3;
                persona3.FechaDesde = new DateTime(2021, 03, 03);
                persona3.FechaHasta = new DateTime(2021, 09, 03);
               
                generarQR(persona3);

                Persona persona4 = new Persona();
                persona4.Dni = "16731823";
                persona4.NombreApellido = "Oscar borselli";
                persona4.Domicilio = "Gutierrez sur";
                persona4.EMail = "Oscar.borselli@gmail.com";
                persona4.Telefono = "3564-3232382";
                persona4.ActividadRealizada = actividad3;
                persona4.FechaDesde = new DateTime(2021, 03, 03);
                persona4.FechaHasta = new DateTime(2021, 09, 03);
               
                generarQR(persona4);

                RepositorioPersonas.agregarPersona(persona1);
                RepositorioPersonas.agregarPersona(persona2);
                RepositorioPersonas.agregarPersona(persona3);
                RepositorioPersonas.agregarPersona(persona4);

                /* Instancias de Empresas preexistente */
                Empresa empresa1 = new Empresa();
                empresa1.razonSocial = "Empresa A S.A.";
                empresa1.cuit1 = "12-14124132-2";
                empresa1.domicilio = "Domicilio de empresa A";
                empresa1.localidad = "Freyre";
                empresa1.EMail = "EmpresaA@gmail.com";
                empresa1.telefono = "3564-778342";
                empresa1.actividad = "Ganaderia";

                Empresa empresa2 = new Empresa();
                empresa2.razonSocial = "Empresa DOS S.A.";
                empresa2.cuit1 = "12-14232452-2";
                empresa2.domicilio = "Domicilio de empresa DOS";
                empresa2.localidad = "San Francisco";
                empresa2.EMail = "EmpresaDOS@gmail.com";
                empresa2.telefono = "3564-123498";
                empresa2.actividad = "Panaderia";

                RepositorioEmpresas.agregarEmpresa(empresa1);
                RepositorioEmpresas.agregarEmpresa(empresa2);

                Empresa.agregarEmpleado(empresa2, persona3);
                Empresa.agregarEmpleado(empresa2, persona4);
                Empresa.agregarEmpleado(empresa1, persona2);
                
            }

            static void RegistrarPersona()
            {
                int cont = 1, act;
                string fechadesde, fechahasta, opcion;
                DateTime fdesde, fhasta;

                Persona personaN = new Persona();
                Console.WriteLine("Ingrese el nombre y apellido: ");
                personaN.NombreApellido = Console.ReadLine();
                Console.WriteLine("Ingrese el DNI: ");
                personaN.Dni = Console.ReadLine();
                Console.WriteLine("Ingrese el Domicilio: ");
                personaN.Domicilio = Console.ReadLine();
                Console.WriteLine("Ingrese el Telefono: ");
                personaN.Telefono = Console.ReadLine();
                Console.WriteLine("Ingrese el e-Mail: ");
                personaN.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha desde: (AAAA, MM, DD");
                fechadesde = Console.ReadLine();
                DateTime.TryParse(fechadesde, out fdesde);
                personaN.FechaDesde = fdesde;
                Console.WriteLine("Ingrese la fecha hasta: (AAAA, MM, DD");
                fechahasta = Console.ReadLine();
                DateTime.TryParse(fechahasta, out fhasta);
                personaN.FechaDesde = fhasta;

               
                Console.WriteLine("Seleccione una de las actividades autorizadas: ");

                foreach (Actividad i in RepositorioActividades.ListadoActividades1)
                {
                    Console.WriteLine(cont + "--" + i.getNombre());
                    cont++;
                }
                Console.WriteLine("Opcion: ");
                act = Convert.ToInt32(Console.ReadLine());
                cont = 0;
                foreach (Actividad i in RepositorioActividades.ListadoActividades1)
                {

                    if (act == cont)
                    {

                        personaN.ActividadRealizada = i;
                    }
                    else if (act == cont)
                    {
                        personaN.ActividadRealizada = i;
                    }
                    else
                    {
                        personaN.ActividadRealizada = i;
                    }
                    cont++;
                }
                
                generarQR(personaN);
                RepositorioPersonas.agregarPersona(personaN);
                Console.WriteLine("Persona Registrada correctamente");
                
            }

            static void AutorizarIngreso()
            {
                string DniAutorizacion;
                char opcion;
                int ban;
                

                Console.WriteLine("Ingrese el DNI: ");
                DniAutorizacion = Console.ReadLine();
                ban = 0;
                Ingreso ingresoNuevo = new Ingreso();
                foreach (Persona p in RepositorioPersonas.ListadoPersonas1)
                {
                    if (p.Dni == DniAutorizacion)
                    {
                        
                        Console.WriteLine("Ingrese la temperatura corporal de la persona: ");
                        ingresoNuevo.TemperaturaCorporal1 = Convert.ToDouble(Console.ReadLine());
                        
                        if (ingresoNuevo.TemperaturaCorporal1 <= 37)
                        {
                            if (p.FechaDesde < DateTime.Now && DateTime.Now < p.FechaHasta)
                            {
                                ban = 1;
                                
                                ingresoNuevo.PersonaIngresante = p;
                            }

                        }
                        else
                        {
                            Console.WriteLine("ATENCION, LA PERSONA TIENE MAS DE 37°C, NO TIENE PERMISO A INGRESAR.");
                        }
                    }
                    
                }
                if (ban == 1)
                {
                    Console.WriteLine("\n");
                    ingresoNuevo.FechaIngreso = DateTime.Now;
                    Console.WriteLine("¿La persona esta por ingresar en un vehiculo? (S / N) ");
                    opcion = Convert.ToChar(Console.ReadLine());

                    if (opcion == 'S' || opcion == 's')
                    {
                        Console.WriteLine("Ingrese la patente del vehiculo: ");
                        ingresoNuevo.PatenteAuto = Console.ReadLine();
                    }

                    Console.WriteLine("Ingrese el destino al que se dirije: ");
                    ingresoNuevo.Destino1 = Console.ReadLine();
                    Persona.agregarIngreso(ingresoNuevo, ingresoNuevo.PersonaIngresante);

                    ingresoNuevo.Datos();

                    Console.WriteLine("\n\nESTA AUTORIZADO/A PARA CIRCULAR.");
                }
                else
                {
                    Console.WriteLine("\n\nLa persona no esta autorizada o bien no se encuentra registrada.");
                }
            }

            static void RegistrarEmpresa()
            {
                Empresa Nueva = new Empresa();
                Console.WriteLine("Ingrese la Razon Social: ");
                Nueva.razonSocial = Console.ReadLine();
                Console.WriteLine("Ingrese el cuit: ");
                Nueva.cuit1 = Console.ReadLine();
                Console.WriteLine("Ingrese el domicilio: ");
                Nueva.domicilio = Console.ReadLine();
                Console.WriteLine("Ingrese la localidad: ");
                Nueva.localidad = Console.ReadLine();
                Console.WriteLine("Ingrese el e-mail: ");
                Nueva.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese el telefono: ");
                Nueva.telefono = Console.ReadLine();
                Console.WriteLine("Ingrese la actividad: ");
                Nueva.actividad = Console.ReadLine();

                RepositorioEmpresas.agregarEmpresa(Nueva);
            }

            static void AsociarEmpleado()
            {
                string razonSocial, dni, fechadesde, fechahasta;
                DateTime fdesde, fhasta;

                Console.WriteLine("Ingrese la razon social de la empresa: ");
                razonSocial = Console.ReadLine();
                foreach (Empresa i in RepositorioEmpresas.ListadoEmpresa1)
                {
                    if (i.razonSocial == razonSocial)
                    {
                        Console.WriteLine("Ingrese el DNI de la persona a asociar: ");
                        dni = Console.ReadLine();
                        foreach (Persona j in RepositorioPersonas.ListadoPersonas1)
                        {
                            if (j.Dni == dni)
                            {
                                Console.WriteLine("autorizado desde (AAAA, MM, DD): ");
                                fechadesde = Console.ReadLine();
                                DateTime.TryParse(fechadesde, out fdesde);
                                j.FechaDesde = fdesde;
                                Console.WriteLine("autorizado hasta (AAAA, MM, DD): ");
                                fechahasta = Console.ReadLine();
                                DateTime.TryParse(fechahasta, out fhasta);
                                j.FechaHasta = fhasta;
                                Empresa.agregarEmpleado(i, j);

                                Console.WriteLine("\n El empleado " + j.NombreApellido + " Esta autorizado desde el " + j.FechaDesde + " Hasta el " + j.FechaHasta);

                            }
                        }
                        Console.WriteLine("Los empleados autorizados de la empresa " + i.razonSocial + " son: \n \n");
                        Empresa.getEmpleados(i);
                    }
                    
                    

                }
            }

            static void RegistrarBajaPersona()
            {
                string razonSocial, dni;


                Console.WriteLine("Ingrese la razon social de la empresa: ");
                razonSocial = Console.ReadLine();
                foreach (Empresa i in RepositorioEmpresas.ListadoEmpresa1)
                {
                    if (i.razonSocial == razonSocial)
                    {
                        Console.WriteLine("Estos son los empleados de la empreza: " + razonSocial + ": \n \n");
                        Empresa.getEmpleados(i);
                        Console.WriteLine("\nIngrese el DNI de la persona a dar de baja: ");
                        dni = Console.ReadLine();
                        foreach (Persona j in RepositorioPersonas.ListadoPersonas1)
                        {
                            if (j.Dni == dni)
                            {
                                Empresa.quitarEmpleado(i, j);

                                Console.WriteLine("\nEl empleado " + j.NombreApellido + " Ha sido dado de baja de la empresa " + i.razonSocial);
                                Console.WriteLine(" Estos son ahora empleados de la empreza " + razonSocial + ": \n \n");
                                Empresa.getEmpleados(i);
                            }
                        }

                    }
                   
                }
            }

            static void RegistrarSalida()
            {
                string dni;
                Console.WriteLine("Ingrese el DNI: ");
                dni = Console.ReadLine();
                Egreso egresonuevo = new Egreso();
                foreach (Persona p in RepositorioPersonas.ListadoPersonas1)
                {
                    if (p.Dni == dni)
                    {
                        egresonuevo.FechaEgreso = DateTime.Now;
                        egresonuevo.Persona1 = p;
                        Console.WriteLine("La persona " + egresonuevo.Persona1.NombreApellido + " se retiro de la zona el dia " + egresonuevo.FechaEgreso.ToString());
                    }
                }
            }

            static void generarQR(Persona personaqr)
            {
                
                BarcodeWriter qrcodeWriter = new BarcodeWriter();

                qrcodeWriter.Format = BarcodeFormat.QR_CODE;

                qrcodeWriter.Write(personaqr.NombreApellido + " Esta Autorizado para circular")
                            .Save(@"C:\Users\Usuario\Desktop\" + personaqr.NombreApellido + ".bmp");
                personaqr.QrAcceso = qrcodeWriter;
                
                
            }

            
            
            
        }
    }
}

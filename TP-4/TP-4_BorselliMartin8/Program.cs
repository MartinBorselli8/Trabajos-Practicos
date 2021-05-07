using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class Program
    {
        static void Main(string[] args)
        {
            int op, cont = 0, act, ban;
            string DniAutorizacion;
            Persona personaAutorizacion = null;

            List<Persona> personasAutorizadas = new List<Persona>();
            List<Actividad> actividadAutorizadas = new List<Actividad>();


            /* Intancias de actividades */
            Actividad actividad1 = new Actividad("Compra", true);
            Actividad actividad2 = new Actividad("Visita medica", true);
            Actividad actividad3 = new Actividad("Trabajo", true);

            actividadAutorizadas.Add(actividad1);
            actividadAutorizadas.Add(actividad2);
            actividadAutorizadas.Add(actividad3);

            /* Instancias de Personas */
            Persona persona1 = new Persona();
            persona1.Dni = "42890804";
            persona1.NombreApellido = "Martin Borselli";
            persona1.Domicilio = "Juan XXIII 87";
            persona1.EMail = "martin.borselli@gmail.com";
            persona1.Telefono = "3564-131419";
            persona1.ActividadRealizada = actividad3;

            Persona persona2 = new Persona();
            persona2.Dni = "17800971";
            persona2.NombreApellido = "Maria celia";
            persona2.Domicilio = "Juan 13";
            persona2.EMail = "mary@gmail.com";
            persona2.Telefono = "3564-12323";
            persona2.ActividadRealizada = actividad1;

            Persona persona3 = new Persona();
            persona3.Dni = "13425032";
            persona3.NombreApellido = "Nicolas borselli";
            persona3.Domicilio = "Cura brochero 32";
            persona3.EMail = "nico.borselli@gmail.com";
            persona3.Telefono = "3564-647782";
            persona3.ActividadRealizada = actividad3;

            personasAutorizadas.Add(persona1);
            personasAutorizadas.Add(persona2);
            personasAutorizadas.Add(persona3);
            /* Resto del programa */

            Console.WriteLine("Elija una de las dos opciones: ");
            Console.WriteLine("Registrar Persona ------ 1");
            Console.WriteLine("Autorizar ingreso ------ 2");
            op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
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

                    Console.WriteLine("Seleccione una de las actividades autorizadas: ");

                    foreach (Actividad i in actividadAutorizadas)
                    {
                        Console.WriteLine(cont + "-----" + i.getNombre());
                        cont++;
                    }
                    Console.WriteLine("Opcion: ");
                    act = Convert.ToInt32(Console.ReadLine());

                    if (act == 0)
                    {
                        personaN.ActividadRealizada = actividad1;
                    }
                    else if (act == 1)
                    {
                        personaN.ActividadRealizada = actividad2;
                    }
                    else
                    {
                        personaN.ActividadRealizada = actividad3;
                    }
                    personasAutorizadas.Add(personaN);
                    Console.WriteLine("Persona Registrada correctamente");
                    break;
                case 2:
                    Console.WriteLine("Ingrese el DNI: ");
                    DniAutorizacion = Console.ReadLine();
                    ban = 0;
                    foreach (Persona p in personasAutorizadas)
                    {
                        if (p.Dni == DniAutorizacion)
                        {
                            ban = 1;
                            personaAutorizacion = p;
                        }
                    }
                    if (ban == 1)
                    {
                        Console.WriteLine("\n");
                        personaAutorizacion.Datos();

                        Console.WriteLine("\n\nESTA AUTORIZADO/A PARA CIRCULAR.");
                    }
                    else
                    {
                        Console.WriteLine("La persona no esta autorizada o bien no se encuentra registrada");
                    }
                    break;
            }
        }
    }
}


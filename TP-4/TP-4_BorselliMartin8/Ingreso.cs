using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class Ingreso
    {
        private DateTime fechaIngreso;
        private Persona personaIngresante;
        private string patenteAuto;
        private string Destino;
        private double TemperaturaCorporal;

        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string PatenteAuto { get => patenteAuto; set => patenteAuto = value; }
        public string Destino1 { get => Destino; set => Destino = value; }
        public double TemperaturaCorporal1 { get => TemperaturaCorporal; set => TemperaturaCorporal = value; }
        internal Persona PersonaIngresante { get => personaIngresante; set => personaIngresante = value; }

        public void Datos()
        {
            Console.WriteLine("\n \n Los datos del ingreso son: \n \n");
            Console.WriteLine("Nombre y apellido: " + PersonaIngresante.NombreApellido);
            Console.WriteLine("Fecha y hora de ingreso: " + FechaIngreso);
            Console.WriteLine("Patente: " + PatenteAuto);
            Console.WriteLine("Destino: " + Destino1);
            Console.WriteLine("Temperatura Corporal: " + TemperaturaCorporal1);
          
            Console.WriteLine("\n\n");

        }
    }
}

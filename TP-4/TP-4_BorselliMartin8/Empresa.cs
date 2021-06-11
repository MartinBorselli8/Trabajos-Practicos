using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class Empresa
    {
        private string RazonSocial;
        private string Cuit;
        private string Domicilio;
        private string Localidad;
        private string eMail;
        private string Telefono;
        private string Actividad;
        private List<Persona> Empleados;

        public string razonSocial { get => RazonSocial; set => RazonSocial = value; }
        public string cuit1 { get => Cuit; set => Cuit = value; }
        public string domicilio { get => Domicilio; set => Domicilio = value; }
        public string localidad { get => Localidad; set => Localidad = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public string telefono { get => Telefono; set => Telefono = value; }
        public string actividad { get => Actividad; set => Actividad = value; }
        internal List<Persona> empleados { get => Empleados; set => Empleados = value; }

        List<Persona> empleados1 = new List<Persona>();
        public static void getEmpleados(Empresa j)
        {
            foreach(Persona i in j.empleados1)
            {
                i.Datos();
            }
        }

        public static void agregarEmpleado(Empresa i, Persona nueva)
        {
            i.empleados1.Add(nueva);
        }

        public static void quitarEmpleado(Empresa i, Persona j)
        {
            i.empleados1.Remove(j);
        }
    }
}

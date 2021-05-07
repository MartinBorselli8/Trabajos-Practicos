using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class Persona
    {
        private string nombreApellido;
        private string dni;
        private string domicilio;
        private string telefono;
        private string eMail;
        private Actividad actividadRealizada;

        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public Actividad ActividadRealizada { get => actividadRealizada; set => actividadRealizada = value; }


        public void Datos()
        {
            Console.WriteLine("Nombre y apellido: " + NombreApellido);
            Console.WriteLine("DNI: " + Dni);
            Console.WriteLine("Domicilio: " + Domicilio);
            Console.WriteLine("eMail: " + EMail);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Actividad que realiza: " + actividadRealizada.getNombre());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace TP_4_BorselliMartin8
{
    class Persona
    {
        private string nombreApellido;
        private string dni;
        private string domicilio;
        private string telefono;
        private string eMail;
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        private BarcodeWriter qrAcceso;
        private List<Ingreso> ingresos = new List<Ingreso>();
        private Actividad actividadRealizada;
      
        

        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public Actividad ActividadRealizada { get => actividadRealizada; set => actividadRealizada = value; }
        public DateTime FechaDesde { get => fechaDesde; set => fechaDesde = value; }
        public DateTime FechaHasta { get => fechaHasta; set => fechaHasta = value; }
        public BarcodeWriter QrAcceso { get => qrAcceso; set => qrAcceso = value; }
        internal List<Ingreso> Ingresos { get => ingresos; set => ingresos = value; }

        
        public void Datos()
        {
            Console.WriteLine("Nombre y apellido: " + NombreApellido);
            Console.WriteLine("DNI: " + Dni);
            Console.WriteLine("Domicilio: " + Domicilio);
            Console.WriteLine("eMail: " + EMail);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Actividad que realiza: " + actividadRealizada.getNombre());
            Console.WriteLine("Autorizado desde: " + FechaDesde);
            Console.WriteLine("Autorizado hasta: " + FechaHasta);
            
         

            Console.WriteLine("\n\n");

        }
        public static void agregarIngreso(Ingreso i, Persona j)
        {
            j.Ingresos.Add(i);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class Actividad
    {
        private string Nombre;
        private Boolean Autorizacion;
        private List<Persona> personas;
        public Actividad(string nombre, bool autorizacion)
        {
            Nombre = nombre;
            Autorizacion = autorizacion;
        }

        public string getNombre()
        {
            return (Nombre);
        }
        internal List<Persona> Personas { get => personas; set => personas = value; }
    }
}

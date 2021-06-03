using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class RepositorioPersonas
    {
        private static List<Persona> ListadoPersonas = new List<Persona>();

        internal static List<Persona> ListadoPersonas1 { get => ListadoPersonas; set => ListadoPersonas = value; }

        public static void agregarPersona(Persona nueva)
        {
            ListadoPersonas.Add(nueva);
        }
    }
}

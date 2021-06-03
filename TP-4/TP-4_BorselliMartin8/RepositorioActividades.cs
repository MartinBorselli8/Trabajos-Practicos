using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class RepositorioActividades
    {
        private static List<Actividad> ListadoActividades = new List<Actividad>();

        internal static List<Actividad> ListadoActividades1 { get => ListadoActividades; set => ListadoActividades = value; }

        public static void agregarActividad(Actividad nueva)
        {
            ListadoActividades.Add(nueva);
        }
    }
}

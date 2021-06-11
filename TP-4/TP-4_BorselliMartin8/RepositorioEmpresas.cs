using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class RepositorioEmpresas
    {
        private static List<Empresa> ListadoEmpresa = new List<Empresa>();

        internal static List<Empresa> ListadoEmpresa1 { get => ListadoEmpresa; set => ListadoEmpresa = value; }

        public static void agregarEmpresa(Empresa nueva)
        {
            ListadoEmpresa.Add(nueva);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_4_BorselliMartin8
{
    class Egreso
    {
        private DateTime fechaEgreso;
        private Persona Persona;

        public DateTime FechaEgreso { get => fechaEgreso; set => fechaEgreso = value; }
        internal Persona Persona1 { get => Persona; set => Persona = value; }
    }
}

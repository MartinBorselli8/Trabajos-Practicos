using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeCompras
{
    class RepositorioProductos
    {
        private List<Producto> listadoDeProductos= new List<Producto>();
        
        internal List<Producto> ListadoDeProductos { get => listadoDeProductos; set => listadoDeProductos = value; }

        public void agregarProductoAListado(Producto producto)
        {
            ListadoDeProductos.Add(producto);
        }

        public void mostrarTodosLosProductos()
        {
            foreach(Producto i in ListadoDeProductos)
            {
                i.getDatos();
            }
        }
    }
}

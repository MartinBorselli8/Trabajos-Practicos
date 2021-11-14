using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarritoDeCompras.Tests
{
    public class PrecioDeProductoEnOferta
    {
        [Fact]
        public void CalcularPrecioDeProductoEnOferta()
        {
            //Arrange
            Producto producto6 = new Producto(6, "Mate", 500m, 5, true, new DateTime(2021, 5, 10), new DateTime(2021, 12, 10), true, 0.10m, 0.02m, 0.03m, 0.05m);
            Carrito carro3 = new Carrito();

            //Act
            carro3.agregarProductoAlCarro(producto6, 1);
            carro3.calcularImporteTotal(0);
            bool isValid = carro3.ImporteTotal == 450m;

            //Assert
            Assert.True(isValid);

        }
        

    }
}

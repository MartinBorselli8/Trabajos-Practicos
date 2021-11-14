using System;
using Xunit;

namespace CarritoDeCompras.Tests
{
     public class AplicarDescuento
    {
        [Fact]
        public void CalcularImporteConDescuento()
        {
            //Arrange
            Producto producto4 = new Producto(4, "Mate", 500m, 5, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);
            Producto producto5 = new Producto(5, "Bombilla", 200m, 5, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);
            

            Descuento descuento = new Descuento("Descuento", 5);

            Carrito carro2 = new Carrito();
            


            //Act
            carro2.agregarProductoAlCarro(producto4, 1);
            carro2.agregarProductoAlCarro(producto5, 1);
            carro2.calcularImporteTotal(descuento.Porcentaje);
            bool isValid = carro2.ImporteTotal == 665m;

            //Assert
            Assert.True(isValid);
        }
    }
}

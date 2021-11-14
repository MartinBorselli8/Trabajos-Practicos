using System;
using Xunit;

namespace CarritoDeCompras.Tests
{
    public class ImporteTotalCarrito
    {
        [Fact]
        public void CalcularImporteTotalCarrito(){
            //Arrange
            Producto producto2 = new Producto(2, "Mate", 500m, 23, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);
            Producto producto3 = new Producto(3, "Bombilla", 200m, 5, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);

            Carrito carro1 = new Carrito();

            carro1.agregarProductoAlCarro(producto2, 1);
            carro1.agregarProductoAlCarro(producto3, 1);

            //Act
            carro1.calcularImporteTotal(0);
            bool isValid = carro1.ImporteTotal == 700m;

            //Assert
            Assert.True(isValid);
        }


    }
}

using Xunit;

namespace CarritoDeCompras.Tests
{
     public class AplicarDescuento
    {
        [Fact]
        public void CalcularImporteConDescuento()
        {
            //Arrange
            Producto producto4 = new Producto(4, "Mate", 500m, 5, true);
            Producto producto5 = new Producto(5, "Bombilla", 200m, 50, true);

            Descuento descuento = new Descuento("Descuento", 5);

            Carrito carro = new Carrito();
            


            //Act
            carro.agregarProductoAlCarro(producto4, 2);
            carro.agregarProductoAlCarro(producto5, 3);
            carro.calcularImporteTotal(descuento.Porcentaje);
            bool isValid = carro.ImporteTotal == 1520m;

            //Assert
            Assert.True(isValid);
        }
    }
}

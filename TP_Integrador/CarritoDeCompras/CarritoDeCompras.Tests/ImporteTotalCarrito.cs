using Xunit;

namespace CarritoDeCompras.Tests
{
    public class ImporteTotalCarrito
    {
        [Fact]
        public void CalcularImporteTotalCarrito(){
            //Arrange
            Producto producto2 = new Producto(2, "Mate", 500m, 23, true);
            Producto producto3 = new Producto(3, "Bombilla", 200m, 5, true);

            Carrito carro = new Carrito();

            carro.agregarProductoAlCarro(producto2, 2);
            carro.agregarProductoAlCarro(producto3, 3);

            //Act
            carro.calcularImporteTotal(0);
            bool isValid = carro.ImporteTotal == 1600m;

            //Assert
            Assert.True(isValid);
        }


    }
}

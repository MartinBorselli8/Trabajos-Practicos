using Xunit;


namespace CarritoDeCompras.Tests
{
    public class DisponibilidadDeProducto
    {
        [Fact]
        public void ValidarStock()
        {
            //Arrange
            Producto producto1 = new Producto(1, "Mate", 500m, 0, true);

            //Act
            producto1.setEstado();
            bool isValid = producto1.Disponible;

            //Assert
            Assert.False(isValid);
        }
    }
}

using System;
using Xunit;


namespace CarritoDeCompras.Tests
{
    public class DisponibilidadDeProducto
    {
        [Fact]
        public void ValidarDisponibilidadDeProducto()
        {
            //Arrange
            Producto producto1 = new Producto(1, "Mate", 500m, 0, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);
            //Act
            producto1.setEstado();
            bool isValid = producto1.Disponible;

            //Assert
            Assert.False(isValid);
        }
    }
}

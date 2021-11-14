using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarritoDeCompras.Tests
{
    public class PrecioDeProductoSegunCantidad
    {
        [Fact]
        public void PrecioDeProductoEnRangoDeDosACinco()
        {
            //Arrange
            Producto producto7 = new Producto(7, "Mate", 500m, 23, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);
            Carrito carro4 = new Carrito();
            //Act
            carro4.agregarProductoAlCarro(producto7, 3);
            carro4.calcularImporteTotal(0);
            bool isValid = carro4.ImporteTotal == 1470m;
            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void PrecioDeProductoEnRangoDeSeisADiez()
        {
            //Arrange
            Producto producto8 = new Producto(8, "Mate", 500m, 23, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);
            Carrito carro5 = new Carrito();
            //Act
            carro5.agregarProductoAlCarro(producto8, 7);
            carro5.calcularImporteTotal(0);
            bool isValid = carro5.ImporteTotal == 3395m;
            //Assert
            Assert.True(isValid);
        }
        [Fact]
        public void PrecioDeProductoEnRangoMasDeDiez()
        {
            //Arrange
            Producto producto9 = new Producto(9, "Mate", 500m, 23, true, new DateTime(2012, 5, 10), new DateTime(2012, 12, 10), false, 0.10m, 0.02m, 0.03m, 0.05m);
            Carrito carro6 = new Carrito();
            //Act
            carro6.agregarProductoAlCarro(producto9, 3);
            carro6.calcularImporteTotal(0);
            bool isValid = carro6.ImporteTotal == 1470m;
            //Assert
            Assert.True(isValid);
        }
    }
}

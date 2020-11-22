using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP4;
using TpExceptions;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstanciarRemera()
        {
            //Arange & Act
            Remera r1 = new Remera("RE0001", "El padrino frase", 1590f, @"\re0001\estampa.ai");

            //Assert
            Assert.IsNotNull(r1);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductoInvalidoException))]
        public void ValidarEstampaException()
        {
            //Arange & Act
            Remera r1 = new Remera("RE0001", "El padrino frase", 1590f, @"\re0001\estampa");

            //Assert
            //Assert.IsNotNull(r1);
        }
    }
}

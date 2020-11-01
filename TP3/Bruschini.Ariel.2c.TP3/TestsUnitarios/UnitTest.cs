using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(Excepciones.DniInvalidoException))]
        public void ValidarDni()
        {
            //Arrange
            string dni = "2a8986231";
            Profesor p1;
            //Act
            p1 = new Profesor(0, "Jorge", "Perez", dni, Persona.ENacionalidad.Extranjero);
        }

        [TestMethod]
        [ExpectedException (typeof(Excepciones.NacionalidadInvalidaException))]
        public void ValidarNacionalidad()
        {
            //Arrange
            string dni = "28986231";
            Profesor p1;
            //Act
            p1 = new Profesor(0, "Jorge", "Perez", dni, Persona.ENacionalidad.Extranjero);
        }

        [TestMethod]
        public void ValidarListaAlumnos()
        {
            //Arange
            Jornada j;
            Profesor p = new Profesor(4, "Pedro", "Sanchez", "28986231", Persona.ENacionalidad.Argentino);
            //Act
            j = new Jornada(Universidad.EClases.Laboratorio,p);
            //Assert
            Assert.IsNotNull(j.Alumnos);
        }

    }
}

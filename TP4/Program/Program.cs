using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4;
using TpExceptions;
using DAOs;
using Archivos;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //INSTANCIO UN NUEVO NEGOCIO Y LE AGREGO DOS VENTAS ACTUALES
            Negocio n1 = new Negocio("Quality Artworks");
            Venta v1 = new Venta("Federico", "Davila");
            Venta v2 = new Venta("Ariel", "Bruschini");
            n1.Ventas.Add(v1);
            n1.Ventas.Add(v2);

            // GENERO ALGUNOS PRODUCTOS DE STOCK (O SEA, LOS PRODUCTOS QUE ESTAN EN EL CATALOGO PARA QUE EL CLIENTE ELIJA)
            // EXISTEN CUADROS Y REMERAS, QUE AMBOS HERREDAN DE PRODUCTOS.
            Remera r1 = new Remera("RE0001", "El Padrino", 1590, "RE0001.ai");
            Remera r2 = new Remera("RE0002", "Bataman", 1590, "RE0002.ai");
            Remera r3 = new Remera("RE0003", "El Hombre arana", 1590, "RE0003.ai");
            Remera r4 = new Remera("RE0004", "Programador fracasado", 1590, "RE0004.ai");
            Cuadro c1 = new Cuadro("CU0001", "Beatles a Hard Days Night", 2800, "CU0001.jpg","50x40");
            Cuadro c2 = new Cuadro("CU0002", "La noche de los muertos vivos", 2800, "CU0002.jpg","50x40");
            Cuadro c3 = new Cuadro("CU0003", "Pink Floyd", 2800, "CU0003.jpg","50x40");
            bool rta = false;
            try
            {
                //// AGREGO PRODUCTOS AL NEGOCIO (EN LA VERSION FINAL SE AGREGARIAN DESDE LA DB)
                rta = n1 + r1;
                rta = n1 + r2;
                rta = n1 + r3;
                rta = n1 + r4;
                rta = n1 + r1; // NO DEBE CARGARLO
                rta = n1 + c1; 
                rta = n1 + c2;
                rta = n1 + c3;
                rta = n1 + c1; // NO DEBE CARGARLO

                // SE REALIZA LA VENTA AGREGANDO PRODUCTOS A CADA VENTA INSTANCIADA
                // SE DEBE INSTANCIAR UNA NUEVA REMERA PQ SE NECESITA SI O SI ESPECIFICAR TALLE Y COLOR EN LA VENTA
                // PORQUE EN EL CATALOGO DE REMERAS NO ES NECESARIO TENER TALLE Y COLOR YA QUE SE HACEN A PEDIDO
                rta = v1 + new Remera(r1,Remera.ETalle.L,Remera.EColor.Blanco); 
                rta = v1 + new Remera(r2, Remera.ETalle.M, Remera.EColor.Rojo);
                rta = v1 + new Remera(r4, Remera.ETalle.XL, Remera.EColor.Azul);
                rta = v1 + c1;
                rta = v1 + c2;

                rta = v2 + new Remera(r2, Remera.ETalle.M, Remera.EColor.Rojo);
                rta = v2 + new Remera(r4, Remera.ETalle.XL, Remera.EColor.Azul);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // ESTO GENERA UN INFORME INTERNO PARA QUE LOS EMPLEADOS SEPAN QUE PRODUCTOS DEBEN HACER (SIN CONOCER PRECIO DE VENTA).
            // ES SOLO PARA ESO INTERNO DE LA EMPRESA.
            InformeProduccion informe = new InformeProduccion();
            informe.GenerarInformeDeProduccion(@"D:\informe.txt",n1.Ventas);

            // EXISTE UN METODO PARA GENERAR LA FACTURA QUE USA LA SOBRECARGA DEL TOSTRING DE CADA VENTA.
            Console.WriteLine(n1.Ventas[0].ToString());
            Console.ReadKey();

        }
    }
}

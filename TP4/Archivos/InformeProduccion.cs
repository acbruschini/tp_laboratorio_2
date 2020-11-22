using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4;

namespace Archivos
{
    public class InformeProduccion
    {
        /// <summary>
        /// Genera un informe con todos los podructos que hay que confeccionar/armar para cumplir con las ventas
        /// </summary>
        /// <param name="archivo">Donde deja el archivo y el nombre</param>
        /// <param name="listaDeVentas">Lista de ventas a armar confeccionar</param>
        /// <returns></returns>
        public bool GenerarInformeDeProduccion(string archivo, List<Venta> listaDeVentas)
        {
            bool retorno = false;
            if(!(listaDeVentas is null) && !(archivo is null) && listaDeVentas.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ARCHIVO DE INFORME PARA PRODUCCION");
                sb.AppendLine("------------------------------------------------\n");
                List<Cuadro> cuadros = new List<Cuadro>();
                List<Remera> remeras = new List<Remera>();

                foreach (Venta venta in listaDeVentas)
                {
                    cuadros.Clear();
                    remeras.Clear();

                    sb.AppendLine($"COMPRADOR: {venta.Nombre} {venta.Apellido} \n");
                                        
                    foreach (Producto p in venta.ProductosAFacturar)
                    {
                        if(p is Remera)
                        {
                            remeras.Add((Remera)p);
                        }
                        else if (p is Cuadro)
                        {
                            cuadros.Add((Cuadro)p);
                        }
                    }

                    if(remeras.Count() > 0)
                    {
                        sb.AppendLine($"CANTIDAD DE REMERAS A FABRICAR: {remeras.Count()}\n");
                        foreach (Remera r in remeras)
                        {
                            sb.AppendLine($"SKU: {r.Sku} - NOMBRE: {r.Nombre} - TALLE: {r.Talle.ToString()} - COLOR: {r.Color.ToString()} - ARCHIVO DE ESTAMPA: {r.UbicacionEstampa}");
                        }
                        sb.AppendLine($"------------------------------------------------\n");
                    }

                    if (cuadros.Count() > 0)
                    {
                        sb.AppendLine($"CANTIDAD DE CUADROS A FABRICAR: {cuadros.Count()}\n");
                        foreach (Cuadro c in cuadros)
                        {
                            sb.AppendLine($"SKU: {c.Sku} - NOMBRE: {c.Nombre} - ARCHIVO DE ARTE A IMPRIMIR: {c.UbicacionArte}");
                        }
                        sb.AppendLine($"------------------------------------------------\n");
                    }

                }

                StreamWriter sw = new StreamWriter(archivo, false);
                try
                {
                    sw.WriteLine(sb.ToString()); ;
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception("No se pudo generar el archivo", e);
                }
                finally
                {
                    sw.Close();
                }
            }
            return retorno;

        }
    }
}

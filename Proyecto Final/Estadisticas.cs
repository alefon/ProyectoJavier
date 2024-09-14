using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal class Estadisticas
    {
        // Atributos
        private List<Producto> productosVendidos;

        // Constructor
        public Estadisticas()
        {
            productosVendidos = new List<Producto>();
        }

        // Método para agregar productos vendidos
        public void AgregarProductoVendido(Producto producto)
        {
            productosVendidos.Add(producto);
        }

        // Método para generar el reporte de ventas
        public void GenerarReporteVentas()
        {
            if (productosVendidos.Count > 0)
            {
                Console.WriteLine("=== Reporte de Ventas del Día ===");
                var productosAgrupados = productosVendidos.GroupBy(p => p.Codigo)
                                                          .Select(grupo => new
                                                          {
                                                              Producto = grupo.First(),
                                                              CantidadTotal = grupo.Sum(p => p.Unidades)
                                                          });

                foreach (var item in productosAgrupados)
                {
                    Console.WriteLine($"Producto: {item.Producto.Nombre}");
                    Console.WriteLine($"Unidades Vendidas: {item.CantidadTotal}");
                    Console.WriteLine($"Total Generado: {(item.CantidadTotal * item.Producto.Precio):C}");
                    Console.WriteLine("----------------------------");
                }

                Console.WriteLine($"Total Generado en el Día: {CalcularTotalVentas():C}");
            }
            else
            {
                Console.WriteLine("No se registraron ventas en el día.");
            }
        }

        // Método para calcular el total generado en el día
        private decimal CalcularTotalVentas()
        {
            return productosVendidos.Sum(p => p.Unidades * p.Precio);
        }

        // Método para limpiar las estadísticas
        public void Limpiar()
        {
            productosVendidos.Clear();
            Console.WriteLine("Estadísticas limpiadas.");
        }
    }
}

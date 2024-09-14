using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_Final
{
    public class Consultas
    {
        // Método para consultar productos por nombre
        public void ConsultarProductoPorNombre(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine().ToLower();

            var productosEncontrados = inventario.listarProductos().Where(p => p.Nombre.ToLower().Contains(nombre)).ToList();

            if (productosEncontrados.Count > 0)
            {
                Console.WriteLine($"Se encontraron {productosEncontrados.Count} productos:");
                foreach (var producto in productosEncontrados)
                {
                    MostrarProducto(producto);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron productos con ese nombre.");
            }
        }

        // Método para consultar productos por código
        public void ConsultarProductoPorCodigo(Inventario inventario)
        {
            Console.Write("Ingrese el código del producto: ");
            string codigo = Console.ReadLine();

            Producto producto = inventario.listarProductos().Find(p => p.Codigo == codigo);

            if (producto != null)
            {
                MostrarProducto(producto);
            }
            else
            {
                Console.WriteLine("No se encontró ningún producto con ese código.");
            }
        }

        // Método para mostrar la información de un producto
        private string MostrarProducto(Producto producto)
        {
            string info_producto = producto.ToString();
            return info_producto;            
        }
    }
}

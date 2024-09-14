using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Proyecto_Final
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        // Cargar inventario desde un archivo
        public void CargarInventario()
        {
            try
            {
                string[] lineas = File.ReadAllLines("inventario.txt");
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    Producto producto = new Producto
                    {
                        Proveedor = datos[0],
                        Nombre = datos[1],
                        Descripcion = datos[2],
                        Codigo = datos[3],
                        Unidades = int.Parse(datos[4]),
                        Precio = decimal.Parse(datos[5])
                    };
                    productos.Add(producto);
                }
                Console.WriteLine("Inventario cargado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el inventario: " + ex.Message);
            }
        }

        // Agregar un nuevo producto
        public void AgregarProducto()
        {
            Producto nuevoProducto = new Producto();

            Console.Write("Ingrese el Proveedor: ");
            nuevoProducto.Proveedor = Console.ReadLine();
            Console.Write("Ingrese el Nombre del Producto: ");
            nuevoProducto.Nombre = Console.ReadLine();
            Console.Write("Ingrese la Descripción: ");
            nuevoProducto.Descripcion = Console.ReadLine();
            Console.Write("Ingrese el Código del Producto: ");
            nuevoProducto.Codigo = Console.ReadLine();
            Console.Write("Ingrese las Unidades: ");
            nuevoProducto.Unidades = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el Precio: ");
            nuevoProducto.Precio = decimal.Parse(Console.ReadLine());

            productos.Add(nuevoProducto);
            GuardarInventario();
            Console.WriteLine("Producto agregado correctamente.");
        }

        // Modificar un producto existente
        public void ModificarProducto()
        {
            Console.Write("Ingrese el Código del Producto a modificar: ");
            string codigo = Console.ReadLine();
            Producto producto = productos.Find(p => p.Codigo == codigo);

            if (producto != null)
            {
                Console.Write("Ingrese el nuevo Nombre del Producto: ");
                producto.Nombre = Console.ReadLine();
                Console.Write("Ingrese la nueva Descripción: ");
                producto.Descripcion = Console.ReadLine();
                Console.Write("Ingrese las nuevas Unidades: ");
                producto.Unidades = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el nuevo Precio: ");
                producto.Precio = decimal.Parse(Console.ReadLine());

                GuardarInventario();
                Console.WriteLine("Producto modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Eliminar un producto
        public void EliminarProducto()
        {
            Console.Write("Ingrese el Código del Producto a eliminar: ");
            string codigo = Console.ReadLine();
            Producto producto = productos.Find(p => p.Codigo == codigo);

            if (producto != null)
            {
                productos.Remove(producto);
                GuardarInventario();
                Console.WriteLine("Producto eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Consultar producto por nombre
        public void ConsultarProductoPorNombre()
        {
            Console.Write("Ingrese el Nombre del Producto: ");
            string nombre = Console.ReadLine();
            Producto producto = productos.Find(p => p.Nombre.ToLower() == nombre.ToLower());

            if (producto != null)
            {
                MostrarProducto(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Consultar producto por código
        public void ConsultarProductoPorCodigo()
        {
            Console.Write("Ingrese el Código del Producto: ");
            string codigo = Console.ReadLine();
            Producto producto = productos.Find(p => p.Codigo == codigo);

            if (producto != null)
            {
                MostrarProducto(producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Mostrar detalles del producto
        private void MostrarProducto(Producto producto)
        {
            Console.WriteLine("Proveedor: " + producto.Proveedor);
            Console.WriteLine("Nombre: " + producto.Nombre);
            Console.WriteLine("Descripción: " + producto.Descripcion);
            Console.WriteLine("Código: " + producto.Codigo);
            Console.WriteLine("Unidades: " + producto.Unidades);
            Console.WriteLine("Precio: " + producto.Precio);
        }

        // Guardar inventario en archivo
        private void GuardarInventario()
        {
            try
            {
                List<string> lineas = new List<string>();
                foreach (Producto producto in productos)
                {
                    lineas.Add($"{producto.Proveedor},{producto.Nombre},{producto.Descripcion},{producto.Codigo},{producto.Unidades},{producto.Precio}");
                }
                File.WriteAllLines("inventario.txt", lineas);
                Console.WriteLine("Inventario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el inventario: " + ex.Message);
            }
        }

        // Limpiar el inventario (vaciar la lista de productos)
        public void Limpiar()
        {
            productos.Clear();
            Console.WriteLine("Inventario limpiado.");
        }
    }
}

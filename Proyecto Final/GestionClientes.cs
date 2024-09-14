using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    public class GestionClientes
    {
        // Atributos
        private Queue<Cliente> colaClientes;
        private List<Cliente> clientesAtendidos;

        // Constructor
        public GestionClientes()
        {
            colaClientes = new Queue<Cliente>();
            clientesAtendidos = new List<Cliente>();
        }

        // Método para agregar un cliente a la cola
        public void AgregarCliente()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombreCliente = Console.ReadLine();
            Cliente nuevoCliente = new Cliente(nombreCliente);
            colaClientes.Enqueue(nuevoCliente);
            Console.WriteLine($"Cliente {nombreCliente} agregado a la cola.");
        }

        // Método para atender un cliente
        public void AtenderCliente(Inventario inventario)
        {
            if (colaClientes.Count > 0)
            {
                Cliente clienteAtendido = colaClientes.Dequeue();
                Console.WriteLine($"Atendiendo a {clienteAtendido.Nombre}...");

                // El cliente selecciona productos
                while (true)
                {
                    Console.Write("Ingrese el código del producto a comprar (o 'salir' para finalizar): ");
                    string codigo = Console.ReadLine();
                    if (codigo.ToLower() == "salir")
                        break;

                    Producto producto = inventario.ConsultarProductoPorCodigo(codigo);
                    if (producto != null)
                    {
                        Console.Write($"Ingrese la cantidad de {producto.Nombre} a comprar: ");
                        int cantidad = int.Parse(Console.ReadLine());

                        if (cantidad <= producto.Unidades)
                        {
                            Producto productoComprado = new Producto(producto.Proveedor, producto.Nombre, producto.Descripcion, producto.Codigo, cantidad, producto.Precio);
                            clienteAtendido.AgregarProducto(productoComprado);
                            producto.Unidades -= cantidad; // Actualiza el inventario
                            Console.WriteLine($"Producto {producto.Nombre} agregado a la compra de {clienteAtendido.Nombre}.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad no disponible en el inventario.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                }

                // Agregar cliente a la lista de clientes atendidos
                clientesAtendidos.Add(clienteAtendido);

                Console.WriteLine($"Compra de {clienteAtendido.Nombre} completada. Total: {clienteAtendido.CalcularTotal():C}");
            }
            else
            {
                Console.WriteLine("No hay clientes en la cola.");
            }
        }

        // Método para generar un reporte de ventas
        public void GenerarReporteVentas()
        {
            if (clientesAtendidos.Count > 0)
            {
                Console.WriteLine("=== Reporte de Ventas ===");
                foreach (Cliente cliente in clientesAtendidos)
                {
                    Console.WriteLine(cliente.ToString());
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                Console.WriteLine("No se han atendido clientes aún.");
            }
        }

        // Método para limpiar las estructuras de memoria
        public void Limpiar()
        {
            colaClientes.Clear();
            clientesAtendidos.Clear();
            Console.WriteLine("Memoria de gestión de clientes limpiada.");
        }
    }
}

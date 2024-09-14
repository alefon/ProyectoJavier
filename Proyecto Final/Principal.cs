/////////////////////////////////////////////////////////////////////////////////////////////////
///   Tema: Proyecto Final 
///   Descripción: 
///   Dev: Javier Lara y Nathan Rojas 
///   Fechas: 
/////////////////////////////////////////////////////////////////////////////////////////////////   

using System;
using System.Collections.Generic;


namespace Proyecto_Final
{
   public class Principal
   {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            GestionClientes gestionClientes = new GestionClientes();
            bool salir = false;

            // Cargar inventario inicial desde un archivo
            inventario.CargarInventario();

            while (!salir)
            {
                Console.WriteLine("==== Bienvenido al Sistema de Inventario del Supermercado ====");
                Console.WriteLine("1. Gestionar Inventario");
                Console.WriteLine("2. Gestionar Clientes");
                Console.WriteLine("3. Consultas de Productos");
                Console.WriteLine("4. Reporte de Ventas");
                Console.WriteLine("5. Limpiar Memoria");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        GestionarInventario(inventario);
                        break;
                    case 2:
                        GestionarClientes(gestionClientes, inventario);
                        break;
                    case 3:
                        ConsultarProductos(inventario);
                        break;
                    case 4:
                        GenerarReporte(gestionClientes);
                        break;
                    case 5:
                        LimpiarMemoria(inventario, gestionClientes);
                        break;
                    case 6:
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void GestionarInventario(Inventario inventario)
        {
            Console.WriteLine("=== Gestión de Inventario ===");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Modificar Producto");
            Console.WriteLine("3. Eliminar Producto");
            Console.Write("Seleccione una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    inventario.AgregarProducto();
                    break;
                case 2:
                    inventario.ModificarProducto();
                    break;
                case 3:
                    inventario.EliminarProducto();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void GestionarClientes(GestionClientes gestionClientes, Inventario inventario)
        {
            Console.WriteLine("=== Gestión de Clientes ===");
            Console.WriteLine("1. Agregar Cliente a la cola");
            Console.WriteLine("2. Atender Cliente");
            Console.Write("Seleccione una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    gestionClientes.AgregarCliente();
                    break;
                case 2:
                    gestionClientes.AtenderCliente(inventario);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void ConsultarProductos(Inventario inventario)
        {
            Console.WriteLine("=== Consultas de Productos ===");
            Console.WriteLine("1. Consultar por Nombre");
            Console.WriteLine("2. Consultar por Código");
            Console.Write("Seleccione una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());
            Producto producto = new Producto();
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el nombre del producto:");
                    string nombre = Console.ReadLine();
                    producto = inventario.ConsultarProductoPorNombre(nombre);
                                        if (producto != null)
                    {
                        Console.Write(producto);
                    }
                    else
                    {
                        Console.Write("El nombre suministrado no correspnde a ningún producto");
                    }
                    break;
                case 2:
                    Console.Write("Ingrese el código del producto:");
                    string codigo = Console.ReadLine();
                    producto = inventario.ConsultarProductoPorCodigo(codigo);

                    if (producto != null)
                    {
                        Console.Write(producto);
                    }
                    else
                    {
                        Console.Write("El código suministrado no correspnde a ningún producto");
                    }

                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        static void GenerarReporte(GestionClientes gestionClientes)
        {
            Console.WriteLine("=== Reporte de Ventas ===");
            gestionClientes.GenerarReporteVentas();
        }

        static void LimpiarMemoria(Inventario inventario, GestionClientes gestionClientes)
        {
            Console.WriteLine("=== Limpieza de Memoria ===");
            inventario.Limpiar();
            gestionClientes.Limpiar();
        }
    }
}

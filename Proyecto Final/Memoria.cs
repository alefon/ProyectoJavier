using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class Memoria
    {
        // Método para limpiar la memoria del inventario y la gestión de clientes
        public void LimpiarMemoria(Inventario inventario, GestionClientes gestionClientes, Estadisticas estadisticas)
        {
            Console.WriteLine("=== Limpieza de Memoria ===");

            // Limpiar el inventario
            inventario.Limpiar();
            Console.WriteLine("Inventario limpiado.");

            // Limpiar la gestión de clientes
            gestionClientes.Limpiar();
            Console.WriteLine("Gestión de clientes limpiada.");

            // Limpiar las estadísticas
            estadisticas.Limpiar();
            Console.WriteLine("Estadísticas limpiadas.");

            // Otras limpiezas, si fueran necesarias, se pueden añadir aquí

            Console.WriteLine("Memoria de las estructuras limpiada correctamente.");
        }
    }
}

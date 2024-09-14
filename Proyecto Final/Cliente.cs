using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Final
{
    public class Cliente
    {
        // Atributos del cliente
        public string Nombre { get; set; }
        public List<Producto> ProductosComprados { get; set; }

        // Constructor vacío
        public Cliente()
        {
            ProductosComprados = new List<Producto>();
        }

        // Constructor con parámetros para inicializar un cliente con nombre
        public Cliente(string nombre)
        {
            Nombre = nombre;
            ProductosComprados = new List<Producto>();
        }

        // Método para agregar un producto a la lista de compras
        public void AgregarProducto(Producto producto)
        {
            ProductosComprados.Add(producto);
        }

        // Método para calcular el total de la compra
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (Producto producto in ProductosComprados)
            {
                total += producto.Precio * producto.Unidades;
            }
            return total;
        }

        // Método para mostrar los detalles de la compra del cliente
        public override string ToString()
        {
            string detalles = $"Cliente: {Nombre}\nProductos Comprados:\n";
            foreach (Producto producto in ProductosComprados)
            {
                detalles += $"{producto.Nombre} - {producto.Unidades} unidades - {producto.Precio:C} cada una\n";
            }
            detalles += $"Total: {CalcularTotal():C}";
            return detalles;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Final
{
    public class Producto
    {
        // Atributos del producto
        public string Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int Unidades { get; set; }
        public decimal Precio { get; set; }

        // Constructor vacío
        public Producto() { }

        // Constructor con parámetros para inicializar un producto
        public Producto(string proveedor, string nombre, string descripcion, string codigo, int unidades, decimal precio)
        {
            Proveedor = proveedor;
            Nombre = nombre;
            Descripcion = descripcion;
            Codigo = codigo;
            Unidades = unidades;
            Precio = precio;
        }

        // Método para obtener la información del producto como un string
        public override string ToString()
        {
            return $"Proveedor: {Proveedor}, Nombre: {Nombre}, Descripción: {Descripcion}, Código: {Codigo}, Unidades: {Unidades}, Precio: {Precio:C}";
        }
    }
}

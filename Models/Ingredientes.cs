using Hamburguesas.Models;

namespace Hamburguesas.Models
{
    public class Ingrediente
    {
        public string Nombre { get; set; } = "";
        public Ingrediente(string nombre)
        {
            Nombre = nombre;
        }
    }
}
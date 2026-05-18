using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Hamburguesas.interfaces;

namespace Hamburguesas.Models
{
  public class Hamburguesa : IVerificable
    {
        private List<Ingrediente> _ingredientes = new ();

        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
            Console.WriteLine($"+ {ingrediente.Nombre} agregado");
        }

        public bool Verificar (List<string> receta)
        {
            if (_ingredientes.Count != receta.Count) return false;

            for (int i = 0; i < receta.Count; i++)
            {
                if (_ingredientes[i].Nombre.ToLower() != receta[i].ToLower())
                return false;
            }
            return true;
        }
        public int Count => _ingredientes.Count;
    }
}
using Hamburguesas.interfaces;

namespace Hamburguesas.Models
{
  public class Hamburguesa : IVerificable
    {
       protected List<Ingrediente> _ingredientes = new ();

        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
            Console.WriteLine($"+ {ingrediente.Nombre} agregado");
        }

        public virtual bool Verificar (List<string> receta)
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
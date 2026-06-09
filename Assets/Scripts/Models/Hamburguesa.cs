using System.Collections.Generic;
 public abstract class Hamburguesa : IVerificable
    {
       protected List<Ingrediente> _ingredientes = new ();

        public void AgregarIngrediente(Ingrediente ingrediente)
        {
            _ingredientes.Add(ingrediente);
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
   using System.Collections.Generic;
    public class HamburguesaVegana : Hamburguesa
    {
        public override bool Verificar(List<string> receta)
        {
            foreach (var ing in _ingredientes)
            {
                string n = ing.Nombre.ToLower();
                if (n == "carne" || n == "tocino" || n == "huevo")
                {
                  return false;
                }
               
            }
             if (!receta.Contains("tomate") || !receta.Contains("lechuga"))
                {
                    return false;
                }
        return base.Verificar(receta);
        }
    }
namespace Hamburguesas.Models
{
    public class HamburguesaVegana : Hamburguesa
    {
        public override bool Verificar(List<string> receta)
        {
            foreach (var ing in _ingredientes)
            {
                string n = ing.Nombre.ToLower();
                if (n == "carne" || n == "tocino" || n == "huevo")
                {
                    Console.WriteLine("ERROR, una hamburguesa vegana no puede llevar productos animales! ");
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
}
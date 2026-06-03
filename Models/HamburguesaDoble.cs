namespace Hamburguesas.Models
{
    public class HamburguesaDoble : Hamburguesa
    {
        public override bool Verificar(List<string> receta)
        {
            if (receta.Count < 5) return false;

            // Verificar que el segundo ingrediente sea "doble"
            if (receta[1].ToLower() != "doble") return false;

            return base.Verificar(receta);
        }
    }
}
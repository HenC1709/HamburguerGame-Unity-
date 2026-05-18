namespace Hamburguesas.Services;

public class RecetaService
{
    public List<string> RecetaCorrecta { get; } = new()
    {
       "pan", "carne", "queso", "lechuga", "pan"
    };
    public HashSet<string> IngredientesValidos { get; } = new()
    {
        "pan", "carne", "queso", "lechuga", "tomate", "cebolla"
    };
    public bool EsValido(string ingrediente) =>
    IngredientesValidos.Contains(ingrediente.ToLower());

    public void MostrarReceta()
    {
        Console.WriteLine("\nReceta a seguir:");
        for (int i = 0; i < RecetaCorrecta.Count; i++)
        Console.WriteLine($" {i + 1}. {RecetaCorrecta[i]}");
    }
    public void MostrarIngredientesValidos()
    {
        Console.WriteLine($"Ingredientes Disponibles: {string.Join(",", IngredientesValidos)}");
    }
}
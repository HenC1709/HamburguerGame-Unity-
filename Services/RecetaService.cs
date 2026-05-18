namespace Hamburguesas.Services;

public class RecetaService
{
    public List<string> RecetaCorrecta { get; } = new()
    {
       "pan", "carne", "queso", "lechuga", "pan"
    };

    public void MostrarReceta()
    {
        Console.WriteLine("\nReceta a seguir:");
        for (int i = 0; i < RecetaCorrecta.Count; i++)
        Console.WriteLine($" {i + 1}. {RecetaCorrecta[i]}");
    }
}
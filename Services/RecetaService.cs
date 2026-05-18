namespace Hamburguesas.Services;

public class RecetaService
{
  private readonly List<List<string>> _niveles = new()
  {
     new() { "pan", "carne", "pan" },
     new() { "pan", "carne", "queso", "pan" },
     new() { "pan", "carne", "queso", "lechuga", "pan" },
     new() { "pan", "carne", "queso", "lechuga", "tomate", "cebolla", "pan" }
  };
  private int _niveActual = 0;
  public List<string> RecetaCorrecta => _niveles[_niveActual];
  public bool HayMasNiveles => _niveActual < _niveles.Count - 1;
  public void SiguienteNivel() => _niveActual++;
  public int NivelActual => _niveActual + 1;

    public HashSet<string> IngredientesValidos { get; } = new()
    {
        "pan", "carne", "queso", "lechuga", "tomate", "cebolla"
    };
    public bool EsValido(string ingrediente) =>
    IngredientesValidos.Contains(ingrediente.ToLower());

    public void MostrarIngredientesValidos()
    {
        Console.WriteLine($"Ingredientes Disponibles: {string.Join(",", IngredientesValidos)}");
    }
}
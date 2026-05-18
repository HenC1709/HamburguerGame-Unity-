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

  private readonly List<string> _Pistas = new()
  {
    "",
    "",
    "Pista: Empieza y termina igual 👀",
    "Pista: el primer ingrediente es 'pan' y lleva 7 capas 🧅"  
  };
  private int _niveActual = 0;
  public List<string> RecetaCorrecta => _niveles[_niveActual];
  public bool HayMasNiveles => _niveActual < _niveles.Count - 1;
  public int NivelActual => _niveActual + 1;

  public void SetNivel(int nivel) => _niveActual = Math.Clamp(nivel, 0, _niveles.Count - 1);
 public void SiguienteNivel() => _niveActual++;
 public string ObtenerPista() => _Pistas[_niveActual];
  

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
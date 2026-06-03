using System;
using System.Collections.Generic;
using System.Linq;
namespace Hamburguesas.Services;

public class RecetaService
{
 private readonly List<List<string>> _niveles = new()
{
    // Nivel 1: La Clásica (3 ingredientes)
    new() { "pan", "carne", "pan" },

    // Nivel 2: Cheeseburger estándar (4 ingredientes)
    new() { "pan", "carne", "queso", "pan" },

    // Nivel 3: Bacon Burger (5 ingredientes)
    new() { "pan", "carne", "queso", "tocino", "pan" },

    // Nivel 4: Pollo Picante (5 ingredientes)
    new() { "pan", "pollo", "lechuga", "picante", "pan" },

    // Nivel 5: La Veggie Completa (6 ingredientes)
    new() { "pan", "vegana", "Aguacate", "tomate", "lechuga", "pan" },

    // Nivel 6: Breakfast Burger (6 ingredientes)
    new() { "pan", "carne", "queso", "huevo", "tocino", "pan" },

    // Nivel 7: BBQ Especial (7 ingredientes)
    new() { "pan", "doble", "queso", "tocino", "bbq", "cebolla", "pan" },

    // Nivel 8: La "Todo Terreno" (8 ingredientes)
    new() { "pan", "carne", "queso", "tocino", "huevo", "pepinillo", "jalapeño", "pan" },

    // Nivel 9: El Desafío del Chef (10 ingredientes)
    new() { "pan", "doble", "queso", "tocino", "lechuga", "tomate", "cebolla", "mayonesa", "mostaza", "pan" }
};

  private readonly List<string> _Pistas = new()
  {
        "Pista: Un inicio y un final esponjoso.",
        "Pista: El queso va sobre la carne.",
        "Pista: ¡El tocino es la clave!",
        "Pista: Cuidado, ¡pica un poco!",
        "Pista: Mucho verde y nada de carne.",
        "Pista: ¿Un huevo en una hamburguesa?",
        "Pista: La salsa BBQ es la protagonista.",
        "Pista: Son 8 capas de puro sabor.",
        "Pista: Lleva absolutamente de todo."
  };

private readonly List<string> _nombres = new()
{
    "La Clásica",
    "Cheeseburger",
    "Bacon Burger",
    "Pollo Picante",
    "Veggie Completa",
    "Breakfast Burger",
    "BBQ Especial",
    "Todo Terreno",
    "Desafío del Chef"
};
  public string NombreNivel => _nombres[_niveActual];
  private int _niveActual = 0;
  private static readonly Random _rng = new();
  public List<string> RecetaCorrecta => _niveles[_niveActual];
  public bool HayMasNiveles => _niveActual < _niveles.Count - 1;
  public int NivelActual => _niveActual + 1;

  public void SetNivel(int nivel) => _niveActual = Math.Clamp(nivel, 0, _niveles.Count - 1);
 public void SiguienteNivel() => _niveActual++;
 public string ObtenerPista() => _niveActual < _Pistas.Count ? _Pistas[_niveActual] : "";
 public List<string> IngredientesAleatorios()
    {
        var lista = new List<string>(RecetaCorrecta.Distinct());
        return lista.OrderBy(_ => _rng.Next()).ToList();
    }
  
    public HashSet<string> IngredientesValidos { get; } = new(StringComparer.OrdinalIgnoreCase)
{
    // Básicos
    "pan", "carne", "queso", "lechuga", "tomate", "cebolla",
    
    // Extras clásicos
    "tocino", "huevo", "pepinillo", "jalapeño", "champiñones", "Aguacate",
    
    // Salsas
    "ketchup", "mayonesa", "mostaza", "bbq", "picante",
    
    // Otras opciones / Proteínas
    "pollo", "pescado", "vegana", "doble"
};
    public bool EsValido(string ingrediente) =>
    IngredientesValidos.Contains(ingrediente.ToLower());

}
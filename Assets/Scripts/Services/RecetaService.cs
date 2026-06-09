using System;
using System.Collections.Generic;
using System.Linq;
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
    new() { "pan", "vegana", "aguacate", "tomate", "lechuga", "pan" },

    // Nivel 6: Breakfast Burger (6 ingredientes)
    new() { "pan", "carne", "queso", "huevo", "tocino", "pan" },

    // Nivel 7: BBQ Especial (7 ingredientes)
    new() { "pan", "doble", "queso", "tocino", "bbq", "cebolla", "pan" },

    // Nivel 8: La Todo Terreno (8 ingredientes)
    new() { "pan", "carne", "queso", "tocino", "huevo", "pepinillo", "jalapeño", "pan" },

    // Nivel 9: El Desafío del Chef (10 ingredientes)
    new() { "pan", "doble", "queso", "tocino", "lechuga", "tomate", "cebolla", "mayonesa", "mostaza", "pan" },

    // Nivel 10: La Tex-Mex (9 ingredientes)
    new() { "pan", "pollo", "queso", "jalapeño", "tomate", "cebolla", "picante", "bbq", "pan" },

    // Nivel 11: La Doble Infernal (10 ingredientes)
    new() { "pan", "doble", "queso", "tocino", "jalapeño", "picante", "bbq", "cebolla", "huevo", "pan" },

    // Nivel 12: La Chef Secreta (10 ingredientes)
    new() { "pan", "carne", "queso", "huevo", "tocino", "champiñones", "cebolla", "mayonesa", "pepinillo", "pan" },

    // Nivel 13: El Monstruo (12 ingredientes)
    new() { "pan", "doble", "queso", "tocino", "huevo", "champiñones", "jalapeño", "tomate", "lechuga", "cebolla", "bbq", "pan" },

    // Nivel 14: La Última Cena (13 ingredientes)
    new() { "pan", "doble", "queso", "tocino", "huevo", "pollo", "champiñones", "jalapeño", "tomate", "lechuga", "cebolla", "bbq", "pan" }
};

  private readonly List<string> _pistas = new()
{
    "",
    "",
    "Pista: El queso va antes del tocino 🧀",
    "Pista: El pollo manda aquí 🍗",
    "Pista: Sin carne, pura verdura 🥬",
    "Pista: Empieza el día bien 🍳",
    "Pista: El doble es el segundo 👀",
    "Pista: 8 capas, sin piedad 🌶️",
    "Pista: Dos dobles, muchas salsas 🔥",
    "Pista: Pollo con bbq y jalapeño 🌮",
    "Pista: Doble infernal, todo pica 💀",
    "Pista: Champiñones y mayonesa son clave 🍄",
    "Pista: 12 capas, doble primero 👹",
    "Pista: Todo entra, buena suerte 💀🔥"
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
    "Desafío del Chef",
    "La Tex-Mex",
    "La Doble Infernal",
    "La Chef Secreta",
    "El Monstruo",
    "La Última Cena"
};
  public string NombreNivel => _nombres[_niveActual];
  private int _niveActual = 0;
  private static readonly Random _rng = new();
  public List<string> RecetaCorrecta => _niveles[_niveActual];
  public bool HayMasNiveles => _niveActual < _niveles.Count - 1;
  public int NivelActual => _niveActual + 1;

  public void SetNivel(int nivel) => _niveActual = Math.Clamp(nivel, 0, _niveles.Count - 1);
 public void SiguienteNivel() => _niveActual++;
 public string ObtenerPista() => _niveActual < _pistas.Count ? _pistas[_niveActual] : "";
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
    "tocino", "huevo", "pepinillo", "jalapeño", "champiñones", "aguacate",
    
    // Salsas
    "ketchup", "mayonesa", "mostaza", "bbq", "picante",
    
    // Otras opciones / Proteínas
    "pollo", "pescado", "vegana", "doble"
};

public TipoHamburguesa ObtenerTipo(List<string> receta)
    {
        if (receta.Count > 1 && receta[1].ToLower() == "doble")
          return TipoHamburguesa.Doble;

          if (receta.Contains("vegana"))
          return TipoHamburguesa.Vegana;

          return TipoHamburguesa.Normal;
        
    }
    public bool EsValido(string ingrediente) =>
    IngredientesValidos.Contains(ingrediente.ToLower());

}
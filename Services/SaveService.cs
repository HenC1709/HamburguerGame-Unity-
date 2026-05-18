using System.Text.Json;
using Hamburguesas.Models;

namespace Hamburguesas.Services;

public class SaveService
{
    private static readonly string CARPETA = "Data";

    private string RutaJugador(string nombre) =>
        Path.Combine(CARPETA, $"{nombre.ToLower()}.json");

    public void Guardar(Jugador jugador)
    {
        Directory.CreateDirectory(CARPETA);
        var json = JsonSerializer.Serialize(jugador, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(RutaJugador(jugador.Nombre), json);
        Console.WriteLine("💾 Progreso guardado.");
    }

    public Jugador? Cargar(string nombre)
    {
        var ruta = RutaJugador(nombre);
        if (!File.Exists(ruta)) return null;
        return JsonSerializer.Deserialize<Jugador>(File.ReadAllText(ruta));
    }

    public List<string> ObtenerJugadores()
    {
        if (!Directory.Exists(CARPETA)) return new();
        return Directory.GetFiles(CARPETA, "*.json")
            .Select(f => Path.GetFileNameWithoutExtension(f))
            .ToList();
    }
}
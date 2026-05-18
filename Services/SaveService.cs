using System.Text.Json;
using Hamburguesas.Models;

namespace Hamburguesas.Services
{
    public class SaveService
    {
    private static readonly string PATH = Path.Combine("Data", "progreso.json");

        public void Guardar(Jugador jugador)
        {
            var json = JsonSerializer.Serialize(jugador, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PATH, json);
            Console.WriteLine("💾 Progeso guardado.");
        }
        public Jugador? Cargar()
        {
            if (!File.Exists(PATH)) return null;
            var json = File.ReadAllText(PATH);
            return JsonSerializer.Deserialize<Jugador>(json);
        }
    } 
}
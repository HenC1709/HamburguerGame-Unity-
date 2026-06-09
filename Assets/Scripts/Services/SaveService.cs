using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using UnityEngine;

public class SaveService
{
    private string RutaJugador(string nombre) =>
        Path.Combine(Application.persistentDataPath, $"{nombre.ToLower()}.json");

    public void Guardar(Jugador jugador)
    {
        var json = JsonConvert.SerializeObject(jugador, Formatting.Indented);
        File.WriteAllText(RutaJugador(jugador.Nombre), json);
        Debug.Log("💾 Progreso guardado.");
    }

    public Jugador? Cargar(string nombre)
    {
        var ruta = RutaJugador(nombre);
        if (!File.Exists(ruta)) return null;
        return JsonConvert.DeserializeObject<Jugador>(File.ReadAllText(ruta));
    }

    public List<string> ObtenerJugadores()
    {
        if (!Directory.Exists(Application.persistentDataPath)) return new();
        return Directory.GetFiles(Application.persistentDataPath, "*.json")
            .Select(f => Path.GetFileNameWithoutExtension(f))
            .ToList();
    }
}
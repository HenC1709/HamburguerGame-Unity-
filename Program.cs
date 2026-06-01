using Hamburguesas.Models;
using Hamburguesas.Services;
using System;
using System.Diagnostics;
using System.Threading;

var SaveService = new SaveService();
var RecetaService = new RecetaService();
var LoginManager = new LoginManager(saveService); 


//login o nuevo jugador 
var jugadores = SaveService.ObtenerJugadores();
Jugador jugador;

if (jugadores.Count == 0)
{
    Console.Write("Nombre de jugador: ");
    var nombre = Console.ReadLine()?.Trim() ?? "Jugador";
    jugador = new Jugador { Nombre = nombre };
    SaveService.Guardar(jugador);
}
else
{
    Console.WriteLine("=== JUGADORES ===");
    for (int i = 0; i < jugadores.Count; i++)
        Console.WriteLine($"  {i + 1}. {jugadores[i]}");
    Console.WriteLine($"  {jugadores.Count + 1}. Nuevo jugador");

    Console.Write("\nElegí un número: ");
    var opcion = int.TryParse(Console.ReadLine(), out int idx) ? idx : 1;

    if (opcion == jugadores.Count + 1)
    {
        Console.Write("Nombre: ");
        var nombre = Console.ReadLine()?.Trim() ?? "Jugador";
        jugador = new Jugador { Nombre = nombre };
        SaveService.Guardar(jugador);
    }
    else
    {
        var nombre = jugadores[Math.Clamp(opcion - 1, 0, jugadores.Count - 1)];
        jugador = SaveService.Cargar(nombre) ?? new Jugador { Nombre = nombre };
        Console.WriteLine($"\nBienvenido de vuelta, {jugador.Nombre}! | Nivel {jugador.NivelActual + 1} | Mejor puntaje: {jugador.MejorPuntaje}");
        Console.WriteLine("Enter para continuar...");
        Console.ReadLine();
    }
}
RecetaService.SetNivel(jugador.NivelActual);
int vidas = 3;
while (vidas > 0)
{
    Console.Clear();
    Console.WriteLine($"=== {jugador.Nombre} | NIVEL {RecetaService.NivelActual} ===");
    RecetaService.MostrarIngredientesValidos();
   Console.WriteLine($"\nVidas: {new string('❤', vidas)}");
   Console.WriteLine($"La hamburguesa tiene {RecetaService.RecetaCorrecta.Count} ingredientes. ¡ADIVINA EL ORDEN!\n");

var pista = RecetaService.ObtenerPista();
if (!string.IsNullOrEmpty(pista))
Console.WriteLine(pista + "\n");

foreach (var n in new[] { "3", "2", "1", "¡GO! 🍔 "})
    {
        Console.Write($"\r{n} ");
        Thread.Sleep(700);
    }
    Console.WriteLine("\n");

var stopwatch = Stopwatch.StartNew();
var hamburguesa = new Hamburguesa();

while (hamburguesa.Count < RecetaService.RecetaCorrecta.Count)
{
    var input = Console.ReadLine()?.Trim().ToLower();
    if (input == "rendirse") break; // salida manual
    if (string.IsNullOrEmpty(input)) continue;

    if (!RecetaService.EsValido(input))
    {
     Console.WriteLine($"{input}' no es un ingrediente valido.");
     continue;
    }
    hamburguesa.AgregarIngrediente(new Ingrediente(input));
}

stopwatch.Stop();
int segundos = (int)stopwatch.Elapsed.TotalSeconds;
int puntaje = Math.Max(0, 1000 - (segundos * 10));

if (hamburguesa.Verificar(RecetaService.RecetaCorrecta))
    {
        Console.WriteLine($"\n✅ ¡CORRECTO! 🍔");
        Console.WriteLine($"⏱  Tiempo: {segundos}s");
        Console.WriteLine($"⭐ Puntaje: {puntaje} pts");
        jugador.PartidasJugadas++;

        if (puntaje > jugador.MejorPuntaje)
        {
            jugador.MejorPuntaje = puntaje;
            Console.WriteLine("🏅 ¡NUEVO MEJOR PUNTAJE!");
        }

        if (!RecetaService.HayMasNiveles)
        {
            Console.WriteLine("¡Completaste todos los niveles! 🏆");
            SaveService.Guardar(jugador);
            break;
        }
        RecetaService.SiguienteNivel();
        jugador.NivelActual = RecetaService.NivelActual - 1;
        jugador.MejorNivel = Math.Max(jugador.MejorNivel, jugador.NivelActual);
        SaveService.Guardar(jugador);

        vidas = 3;
        Console.WriteLine("siguiente nivel.. Enter para continuar.");
    }
    else
    {
        vidas--;
        Console.WriteLine(vidas > 0
        ? $"\nIncorrecto. te quedan {vidas} vida(s). enter para reintentar."
        : "\nGame Over. 💀");

        jugador.PartidasJugadas++;
        SaveService.Guardar(jugador);
    }
    Console.ReadLine();

}

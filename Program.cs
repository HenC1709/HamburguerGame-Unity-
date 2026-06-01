using Hamburguesas.Models;
using Hamburguesas.Services;
using System;
using System.Diagnostics;
using System.Threading;

var saveService = new SaveService();
var recetaService = new RecetaService();
var loginManager = new LoginManager(saveService); 


//login o nuevo jugador 
Jugador jugador = loginManager.InicarSesion();
// Inicamos el jueggo
recetaService.SetNivel(jugador.NivelActual);
int vidas = 3;
while (vidas > 0)
{
    Console.Clear();
    Console.WriteLine($"=== {jugador.Nombre} | NIVEL {recetaService.NivelActual} ===");
    recetaService.MostrarIngredientesValidos();
   Console.WriteLine($"\nVidas: {new string('❤', vidas)}");
   Console.WriteLine($"La hamburguesa tiene {recetaService.RecetaCorrecta.Count} ingredientes. ¡ADIVINA EL ORDEN!\n");

var pista = recetaService.ObtenerPista();
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

while (hamburguesa.Count < recetaService.RecetaCorrecta.Count)
{
    var input = Console.ReadLine()?.Trim().ToLower();
    if (input == "rendirse") break; // salida manual
    if (string.IsNullOrEmpty(input)) continue;

    if (!recetaService.EsValido(input))
    {
     Console.WriteLine($"{input}' no es un ingrediente valido.");
     continue;
    }
    hamburguesa.AgregarIngrediente(new Ingrediente(input));
}

stopwatch.Stop();
int segundos = (int)stopwatch.Elapsed.TotalSeconds;
int puntaje = Math.Max(0, 1000 - (segundos * 10));

if (hamburguesa.Verificar(recetaService.RecetaCorrecta))
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

        if (!recetaService.HayMasNiveles)
        {
            Console.WriteLine("¡Completaste todos los niveles! 🏆");
            saveService.Guardar(jugador);
            break;
        }
        recetaService.SiguienteNivel();
        jugador.NivelActual = recetaService.NivelActual - 1;
        jugador.MejorNivel = Math.Max(jugador.MejorNivel, jugador.NivelActual);
        saveService.Guardar(jugador);

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
        saveService.Guardar(jugador);
    }
    Console.ReadLine();
}

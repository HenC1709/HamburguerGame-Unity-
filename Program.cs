using Hamburguesas.Models;
using Hamburguesas.Services;

var SaveService = new SaveService();
var RecetaService = new RecetaService();


//login o nuevo jugador 
var jugador = SaveService.Cargar();
if (jugador == null)
{
    Console.Write("Nombre de jugador: ");
    var nombre = Console.ReadLine()?.Trim() ?? "Jugador";
    jugador = new Jugador { Nombre = nombre};
    SaveService.Guardar(jugador);
}
else
{
    Console.WriteLine($"Bienvenido de vuelta, {jugador.Nombre}! (Nivel {jugador.NivelActual + 1}, mejor nivel: {jugador.MejorNivel + 1})");
    Console.WriteLine("Enter para continuar...");
    Console.ReadLine();
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
Console.WriteLine(pista);
Console.WriteLine();

var hamburguesa = new Hamburguesa();

while (true)
{
    var input = Console.ReadLine()?.Trim().ToLower();
    if (input == "listo") break;

    if (string.IsNullOrEmpty(input)) continue;

    if (!RecetaService.EsValido(input!))
    {
     Console.WriteLine($"{input}' no es un ingrediente valido.");
     continue;
    }
    hamburguesa.AgregarIngrediente(new Ingrediente(input!));
}
if (hamburguesa.Verificar(RecetaService.RecetaCorrecta))
    {
        Console.WriteLine("\n!CORRECTO! 🍔");
        jugador.PartidasJugadas++;

        if (!RecetaService.HayMasNiveles)
        {
            Console.WriteLine("¡Completaste todos los niveles! 🏆");
            jugador.MejorNivel = RecetaService.NivelActual - 1;
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








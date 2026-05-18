using Hamburguesas.Models;
using Hamburguesas.Services;

var RecetaService = new RecetaService();
int vidas = 3;
while (vidas > 0)
{
    Console.Clear();
    Console.WriteLine($"=== NIVEL {RecetaService.NivelActual} ===");
    RecetaService.MostrarIngredientesValidos();
   Console.WriteLine($"\nVidas: {new string('❤', vidas)}");
   Console.WriteLine($"La hamburguesa tiene {RecetaService.RecetaCorrecta.Count} ingredientes. ¡ADIVINA EL ORDEN!\n");

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
        if (!RecetaService.HayMasNiveles)
        {
            Console.WriteLine("¡Completaste todos los niveles! 🏆");
            break;
        }
        RecetaService.SiguienteNivel();
        vidas = 3;
        Console.WriteLine("siguiente nivel.. Enter para continuar.");
    }
    else
    {
        vidas--;
        Console.WriteLine(vidas > 0
        ? $"\nIncorrecto. te quedan {vidas} vida(s). enter para reintentar."
        : "\nGame Over. 💀");
    }
    Console.ReadLine();

}








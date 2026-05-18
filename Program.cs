using Hamburguesas.Models;
using Hamburguesas.Services;

var RecetaService = new RecetaService();
int vidas = 3;
while (vidas > 0)
{
    Console.Clear();
    RecetaService.MostrarReceta();
    RecetaService.MostrarIngredientesValidos();
   Console.WriteLine($"\nVidas: {new string('❤', vidas)}");
   Console.WriteLine("\nAgregá ingredientes en orden. Escribe 'listo' cuando termines\n");

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
        Console.WriteLine("\nHAMBURGUESA PERFECTA!!!! 🍔 ");
        break;
    }
    vidas--;
    Console.WriteLine(vidas > 0
    ? $"\nOrden incorrecto. te quedan {vidas} vida(s). Enter para reintentar. "
    : "\nGame Over. 💀");
    Console.ReadLine();



}








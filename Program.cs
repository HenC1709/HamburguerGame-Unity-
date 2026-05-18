using Hamburguesas.Models;
using Hamburguesas.Services;

var RecetaService = new RecetaService();
RecetaService.MostrarReceta();

var hamburguesa = new Hamburguesa();
Console.WriteLine("\nAgregá ingredientes en orden (escribe el orden):");
Console.WriteLine("Escribe 'listo' cuando termines\n");

while (true)
{
    var input = Console.ReadLine()?.Trim().ToLower();
    if (input == "listo") break;
    if (!string.IsNullOrEmpty(input))
    hamburguesa.AgregarIngrediente(new Ingrediente(input));
}

bool resultado = hamburguesa.Verificar(RecetaService.RecetaCorrecta);
Console.WriteLine(resultado ? "\nHamburguesa perfecta! 🍔" : "\nOrden Incorrecto, intenta de nuevo." );
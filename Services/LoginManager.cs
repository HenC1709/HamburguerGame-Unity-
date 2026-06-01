using Hamburguesas.Models;

namespace Hamburguesas.Services
{
    public class LoginManager
    {
        private readonly SaveService _saveService;

        public LoginManager (SaveService saveService)
        {
           _saveService = saveService;
        }

        public Jugador InicarSesion()
        {
            var jugadores = _saveService.ObtenerJugadores();
            Jugador jugador;

            if (jugadores.Count == 0)
            {
               Console.Write("Nombre de jugador: ");
               var nombre = Console.ReadLine()?.Trim() ?? "Jugador";
              jugador = new Jugador { Nombre = nombre };
              _saveService.Guardar(jugador);
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
           _saveService.Guardar(jugador);
          }
              else
              {
             var nombre = jugadores[Math.Clamp(opcion - 1, 0, jugadores.Count - 1)];
             jugador = _saveService.Cargar(nombre) ?? new Jugador { Nombre = nombre };
             Console.WriteLine($"\nBienvenido de vuelta, {jugador.Nombre}! | Nivel {jugador.NivelActual + 1} | Mejor puntaje: {jugador.MejorPuntaje}");
             Console.WriteLine("Enter para continuar...");
             Console.ReadLine();
              }
            }
            return jugador;
        }
    }
}
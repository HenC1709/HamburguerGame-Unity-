using Hamburguesas.Models;
using System.Diagnostics;
namespace Hamburguesas.Services
{
    public class GameLoop
    {
        private readonly RecetaService _recetaService;
        private readonly SaveService _saveService;
        private Jugador _jugador;
        private int _vidas;

        public GameLoop(RecetaService recetaService, SaveService saveService, Jugador jugador)
        {
            _recetaService = recetaService;
            _saveService = saveService;
            _jugador = jugador;
            _vidas = 3;
        }
        public void Iniciar()
        {
            _recetaService.SetNivel(_jugador.NivelActual);
            while (_vidas > 0 )
            {
                MostrarEstado();
                JugarRonda();
            }
            Console.WriteLine("\nPresione Cualquier tecla para salir...");
            Console.ReadKey();
        }

        private void MostrarEstado()
        {
            Console.Clear();
            Console.WriteLine($"=== {_jugador.Nombre} | NIVEL {_recetaService.NivelActual}: {_recetaService.NombreNivel} ===");
           var ingredientes = _recetaService.IngredientesAleatorios();
           Console.WriteLine($"Ingredientes disponibles: {string.Join(", ", ingredientes)}");
           Console.WriteLine($"\nVidas: {new string('❤', _vidas)}");
          Console.WriteLine($"La hamburguesa tiene {_recetaService.RecetaCorrecta.Count} ingredientes. ¡ADIVINA EL ORDEN!\n");

          var pista = _recetaService.ObtenerPista();
          if (!string.IsNullOrEmpty(pista)) Console.WriteLine(pista + "\n");

         foreach (var n in new[] { "3", "2", "1", "¡GO! 🍔 "})
           {
               Console.Write($"\r{n} ");
               Thread.Sleep(700);
           }
            Console.WriteLine("\n");
        }

        private void JugarRonda() 
        {
            var stopwatch = Stopwatch.StartNew();
            var recetaActual = _recetaService.RecetaCorrecta;
            var hamburguesa = CrearHamburguesa(recetaActual);

          while (hamburguesa.Count < recetaActual.Count)
            {
                var input = Console.ReadLine()?.Trim().ToLower();
                if (input == "rendirse") break; // salida manual
                if (string.IsNullOrEmpty(input)) continue;

                if (!_recetaService.EsValido(input))
                {
                    Console.WriteLine($"{input}' no es un ingrediente valido.");
                    continue;
                }
                hamburguesa.AgregarIngrediente(new Ingrediente(input));
            }
            stopwatch.Stop();
            ProcesarResultado(hamburguesa, (int)stopwatch.Elapsed.TotalSeconds);
        }
        private Hamburguesa CrearHamburguesa(List<string> receta)
        {
            if (receta.Count > 1 && receta[1].ToLower() == "doble")
            {
               return new HamburguesaDoble(); 
            }
            if (receta.Contains("vegana"))
            {
                return new HamburguesaVegana();
            }
            
            return new Hamburguesa();
        }

        private void ProcesarResultado(Hamburguesa hamburguesa, int segundos)
        {
            if (hamburguesa.Verificar(_recetaService.RecetaCorrecta))
            {
                int puntaje = Math.Max(0, 1000 - (segundos * 10));
                Console.WriteLine($"\n✅ ¡CORRECTO! | ⏱ {segundos}s | ⭐ {puntaje} pts");

                _jugador.PartidasJugadas++;
                if (puntaje > _jugador.MejorPuntaje) _jugador.MejorPuntaje = puntaje;

                if (!_recetaService.HayMasNiveles)
                {
                    Console.WriteLine("¡Completaste todos los niveles! 🏆");
                    _vidas = 0;
                }
                else
                {
                    _recetaService.SiguienteNivel();
                    _jugador.NivelActual = _recetaService.NivelActual - 1;
                    _jugador.MejorNivel = Math.Max(_jugador.MejorNivel, _jugador.NivelActual);
                    _vidas = 3;
                    Console.WriteLine("Siguiente nive... ");
                }
            }
            else
            {
                _vidas--;
                _jugador.PartidasJugadas++;
                Console.WriteLine(_vidas > 0 ? $"\n❌ Incorrecto. Vidas: {_vidas}. Enter para reintentar." : "\n💀 Game Over.");
            }
            _saveService.Guardar(_jugador);
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private RecetaService _recetaService;
    private SaveService _saveService;
    private Jugador _jugador;
    private int _vidas;
    private Hamburguesa _hamburguesa;
    private float _tiempoInicio;

    public event Action OnNivelCompletado;
    public event Action OnJuegoCompletado;
    public event Action OnGameOver;

    private void Awake()
    {
        _recetaService = new RecetaService();
        _saveService = new SaveService();
    }

    public void InciarJuego(Jugador jugador)
    {
        _jugador = jugador;
        _vidas = 3;
        _recetaService.SetNivel(jugador.NivelActual);
         IniciarRonda();
    }
    private Hamburguesa CrearHamburguesa(List<string> receta)
    {
         return _recetaService.ObtenerTipo(receta) switch
            {
               TipoHamburguesa.Doble => new HamburguesaDoble(),
               TipoHamburguesa.Vegana => new HamburguesaVegana(),
                _                     => new HamburguesaNormal()
            };
    }
    private void IniciarRonda()
    {
        _hamburguesa = CrearHamburguesa(_recetaService.RecetaCorrecta);
        _tiempoInicio = Time.time;
    }

    public void AgregarIngrediente(string ingrediente)
      {
        if (!_recetaService.EsValido(ingrediente)) return;
    
       _hamburguesa.AgregarIngrediente(new Ingrediente(ingrediente));
    
        if (_hamburguesa.Count >= _recetaService.RecetaCorrecta.Count)
         {
           ProcesarResultado();
         }
      }
    private void ProcesarResultado()
{
    // Reemplaza el Stopwatch
    int segundos = (int)(Time.time - _tiempoInicio);

    if (_hamburguesa.Verificar(_recetaService.RecetaCorrecta))
    {
        int puntaje = Math.Max(0, 1000 - (segundos * 10));

        _jugador.PartidasJugadas++;
        if (puntaje > _jugador.MejorPuntaje) _jugador.MejorPuntaje = puntaje;

        if (!_recetaService.HayMasNiveles)
        {
            OnJuegoCompletado?.Invoke();
        }
        else
        {
            _recetaService.SiguienteNivel();
            _jugador.NivelActual = _recetaService.NivelActual - 1;
            _jugador.MejorNivel = Math.Max(_jugador.MejorNivel, _jugador.NivelActual);
            _vidas = 3;
            OnNivelCompletado?.Invoke();
            IniciarRonda(); // ← empieza la siguiente ronda sola
        }
    }
    else
    {
        _vidas--;
        _jugador.PartidasJugadas++;
        if (_vidas <= 0)
            OnGameOver?.Invoke();
    }

    _saveService.Guardar(_jugador); // ← siempre guarda al final
}
}
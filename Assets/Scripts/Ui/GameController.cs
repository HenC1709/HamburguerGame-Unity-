using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _ingredientButtonPrefab;
    [SerializeField] private Transform _ingredientsPanel;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        _gameManager.OnNivelCompletado += OnNivelCompletado;
        _gameManager.OnGameOver += OnGameOver;
        // Por ahora solo generamos los botones
        var jugador = new Jugador { Nombre = "Test" };
        _gameManager.InciarJuego(jugador);
        GenerarBotones();
        ActualizarUI();
    }
    private void OnNivelCompletado()
    {
        ActualizarUI();
        GenerarBotones();
    }
    private void OnGameOver()
    {
        ActualizarUI();
        SceneManager.LoadScene("GameOverScene");
    }

    private void GenerarBotones()
    {
        // Limpia botones anteriores
        foreach (Transform child in _ingredientsPanel)
            Destroy(child.gameObject);

        var ingredientes = _gameManager.ObtenerIngredientes();

        foreach (var ing in ingredientes)
        {
            var btn = Instantiate(_ingredientButtonPrefab, _ingredientsPanel);
            btn.GetComponentInChildren<TMP_Text>().text = ing;
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                _gameManager.AgregarIngrediente(ing);
                ActualizarUI();
            });
        }
    }
    public void ActualizarUI()
    {
        _levelText.text = $"Nivel {_gameManager.NivelActual}: {_gameManager.NombreNivel}";
        _livesText.text = $"Vidas: {_gameManager.Vidas}";
    }
}
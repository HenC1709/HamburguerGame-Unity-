using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;

    public void OnPlayButtonClick()
    {
        string playerName = _nameInput.text;
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("El nombre del jugador no puede estar vacío.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        SceneManager.LoadScene("GameScene");
    }

    public void OnExitButtonClick()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

}

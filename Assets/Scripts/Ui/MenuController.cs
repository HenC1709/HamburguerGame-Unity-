using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;

    public void OnPlayButtonClick()
    {
        Debug.Log("Botón presionado!");
        if (string.IsNullOrEmpty(_nameInput.text)) return;
        SceneManager.LoadScene("GameScene");
    }

}

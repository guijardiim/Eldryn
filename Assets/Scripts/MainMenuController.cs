
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject creditsPanel;

    // Iniciar o jogo.
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Abrir os créditos
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    // Fechar os créditos
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    // Sair do jogo
    public void QuitGame()
    {
        Application.Quit();
    }
}


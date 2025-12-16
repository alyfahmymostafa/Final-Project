using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject descriptionPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void ShowDescription()
    {
        descriptionPanel.SetActive(true);
    }

    public void HideDescription()
    {
        descriptionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

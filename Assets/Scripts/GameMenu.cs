using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject back;

    public void StartNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowHideElementsMenu(bool state)
    {
        back.SetActive(state);
        DisplayMenu(state);
    }
    public void PressedButtonBack()
    {
        back.SetActive(false);
        DisplayMenu(true);
    }

    public void DisplayMenu(bool stateMenu)
    {
        menu.SetActive(stateMenu);
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

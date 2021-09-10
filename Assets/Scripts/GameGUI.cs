using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    [SerializeField] private GameObject[] elementsControls;
    [SerializeField] private GameObject gui;
    [SerializeField] private Image imageStatusGame;
    [SerializeField] private Sprite[] imageForStatusGame;
    
    public void DisplayPauseMenu()
    {
        Time.timeScale = 0;
        ShowOrHideGUIElements(true);
        imageStatusGame.sprite = imageForStatusGame[2];
        ShowOrHideControlElements(false);
    }

    private void Update()
    {
        if (MobsSpawn.AliveTanks <= 0)
        {
            GameMechanic.PlayerWin = true;
            DisplayEndGame();
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        ShowOrHideGUIElements(false);
        ShowOrHideControlElements(true);
    }

    public void DisplayEndGame()
    {
        if(GameMechanic.PlayerWin == true)
            imageStatusGame.sprite = imageForStatusGame[1];
        else
            imageStatusGame.sprite = imageForStatusGame[0];
        ShowOrHideControlElements(false);
        ShowOrHideGUIElements(true);
        GameMechanic.PlayerWin = false;
    }

    public void ShowOrHideGUIElements(bool stateForGUI)
    {
        gui.SetActive(stateForGUI);
    }
    
    private void ShowOrHideControlElements(bool stateForControls)
    {
        foreach (var elementsControl in elementsControls)
        {
            elementsControl.SetActive(stateForControls);
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        ShowOrHideGUIElements(false);
        ShowOrHideControlElements(true);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}

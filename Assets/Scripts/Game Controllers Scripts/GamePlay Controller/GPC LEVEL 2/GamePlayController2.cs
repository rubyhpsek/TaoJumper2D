using UnityEngine;
using UnityEngine.UI;

public class GamePlayController2 : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button resumeGame;

    public void PauseGame()
    {
        Time.timeScale = 0f;   // NEED TO STOP THE GAME
        pausePanel.SetActive(true);  // To make the pause panel to be visible
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;   // reset GAME to 1f
        pausePanel.SetActive(false);  // To make the pause panel to be deactivated in order to resume the game
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;   // restart  GAME to 1f
        Application.LoadLevel("MyMainMenu");  //  go back to main menu  ;   http://docs.unity3d.com/ScriptReference/Application.LoadLevel.html
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;   // restart  GAME to 1f
        Application.LoadLevel("GamePlay2A");  // http://docs.unity3d.com/ScriptReference/Application.LoadLevel.html
    }

    public void PlayerDiedOut()
    {
        Time.timeScale = 0f;   // NEED TO STOP THE GAME
        pausePanel.SetActive(true);  // To make the pause panel to be visible
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => RestartGame());   // Restart the game
    }
}   //  GamePlayController2  CLASS
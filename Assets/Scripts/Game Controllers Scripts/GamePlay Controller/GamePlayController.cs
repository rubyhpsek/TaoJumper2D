using UnityEngine;
using UnityEngine.UI;
public class GamePlayController : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject gameoverPanel;

    [SerializeField]
    private Button resumeGame;

    //[SerializeField]
    //private Button restartGame;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumeGame());
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame()
    {

        Time.timeScale = 1f;
        //Vector3 temporary = transform.localScale;
        //transform.localScale = temporary;

        pausePanel.SetActive(false);
    }


    //    private IEnumerator Pause(int p) { 
    //    {
    //        Time.timeScale = 0.1f;

    //        float pauseEndTime = Time.realtimeSinceStartup + 1;

    //        while (Time.realtimeSinceStartup < pauseEndTime)
    //            yield return 0;

    //        Time.timeScale = 1;
    //    }

    //}


    public void GoToMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MyMainMenu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("GamePlay");
    }
    public void RestartGameP()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("GamePlay");
    }


    public void PlayerDied()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => RestartGame());
    }
    public void PlayerDiedResetPlayer()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => RestartGameP());
    }
    public void PlayerDiedOut()
    {
        Time.timeScale = 0f;
        gameoverPanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => RestartGame());
    }










    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}

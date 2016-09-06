using UnityEngine;

public class LevelCtrller : MonoBehaviour
{

    public void StartGame()
    {

        Application.LoadLevel("GamePlay");  // http://docs.unity3d.com/ScriptReference/Application.LoadLevel.html
    }

    public void BackToMenu()
    {

        Application.LoadLevel("MyMainMenu");  // http://docs.unity3d.com/ScriptReference/Application.LoadLevel.html
    }
}   // LevelCtrller  Class

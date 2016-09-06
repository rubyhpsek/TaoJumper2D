using UnityEngine;

public class LevelCtrller2A : MonoBehaviour
{

    public void StartGame()
    {

        Application.LoadLevel("GamePlay2A");  // http://docs.unity3d.com/ScriptReference/Application.LoadLevel.html
    }

    public void BackToMenu()
    {

        Application.LoadLevel("MyMainMenu");  // http://docs.unity3d.com/ScriptReference/Application.LoadLevel.html
    }
}   // LevelCtrller  Class

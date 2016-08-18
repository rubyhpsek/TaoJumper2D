using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public int score = 0;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int point)
    {
        score += point;
    }
    public void SubtractScore(int point)
    {
        score -= point;
    }
}

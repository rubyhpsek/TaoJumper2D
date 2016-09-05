using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeLevel : MonoBehaviour {

    private Slider TimerSlider;  //  referenced to Slider

    private float timeLeft = 1f;

    public float time = 15f;



    private GameObject player;  //  Need to Destroy the player when robotlife indicator drop to 0 

    // Use this for initialization
    void Awake()
    {
        GetRef();   //  Call the Function 
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;

        if (time > 0)
        {
            time -= timeLeft * Time.deltaTime;
            TimerSlider.value = time;
        }
        else
        {

            Destroy(player);
        }
    }

    void GetRef()
    {
        player = GameObject.Find("Player");
        TimerSlider = GameObject.Find("TimerSlider").GetComponent<Slider>();

        TimerSlider.minValue = 0f;
        TimerSlider.maxValue = time;
        TimerSlider.value = TimerSlider.maxValue;   //  Start with the current value


    }
}

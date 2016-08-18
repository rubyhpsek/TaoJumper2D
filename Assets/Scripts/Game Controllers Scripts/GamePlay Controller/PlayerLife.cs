using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    private Slider PlayerLifeSlider;  //  referenced to Slider

    private float lifeLeft = 1f;

    public float life = 15f;



    private GameObject player;  //  Need to Destroy the player when robotlife indicator drop to 0 

    // Use this for initialization
    void Awake()
    {
        GetRef();   //  Call the Function created down in line 27
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;

        if (life > 0)
        {
            life -= lifeLeft * Time.deltaTime;
            PlayerLifeSlider.value = life;
        }
        else
        {
            GetComponent<GamePlayController>().PlayerDiedOut();
            Destroy(player);
        }
    }

    void GetRef()
    {
        player = GameObject.Find("Player");
        PlayerLifeSlider = GameObject.Find("LIFESLIDER").GetComponent<Slider>();

        PlayerLifeSlider.minValue = 0f;
        PlayerLifeSlider.maxValue = life;
        PlayerLifeSlider.value = PlayerLifeSlider.maxValue;   //  Start with the current value


    }
}   // PlayerLife class 

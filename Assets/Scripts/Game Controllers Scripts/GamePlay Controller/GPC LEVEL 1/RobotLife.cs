using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RobotLife : MonoBehaviour {

    private Slider RobotLifeSlider;  //  referenced to Slider

    private float lifeLeft = 1f;

    public float life = 15f;
    
    

    private GameObject player;  //  Need to Destroy the player when robotlife indicator drop to 0 

	// Use this for initialization
	void Awake () {
        GetRef();   //  Call the Function created down in line 27
    }
	
	// Update is called once per frame
	void Update () {
        if (!player)
            return;

        if (life > 0) {
            life -= lifeLeft * Time.deltaTime;
            RobotLifeSlider.value = life;
        }else {

            Destroy(player);
        }
	}
      
    void GetRef() {
        player = GameObject.Find("Player");
        RobotLifeSlider = GameObject.Find("RobotLifeSlider").GetComponent<Slider>();

        RobotLifeSlider.minValue = 0f;
        RobotLifeSlider.maxValue = life;
        RobotLifeSlider.value = RobotLifeSlider.maxValue;   //  Start with the current value


    }
}   // RobotLife class 

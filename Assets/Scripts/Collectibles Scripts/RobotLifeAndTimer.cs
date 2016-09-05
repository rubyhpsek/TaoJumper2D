using UnityEngine;

public class RobotLifeAndTimer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (gameObject.name == "Timer")
            {
                GameObject.Find("GamePlayController").GetComponent<TimeLevel>().time += 25f;


            }
            if (gameObject.name == "RobotC")
            {
                GameObject.Find("GamePlayController").GetComponent<RobotLife>().life += 25f;


            }
            Destroy(gameObject);


        }


    }


}

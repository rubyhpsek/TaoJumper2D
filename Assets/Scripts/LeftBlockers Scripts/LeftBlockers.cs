using UnityEngine;

public class LeftBlockers : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Train" || target.tag == "Player")
        {
            //Destroy(target.gameObject);
            GameObject.Find("GamePlayController").GetComponent<GamePlayController>().PlayerDied();
        }
    }
}

using UnityEngine;

public class RightBlockers : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            GameObject.Find("GamePlayController").GetComponent<GamePlayController>().PlayerDiedOut();
            Destroy(target.gameObject);
        }
    }
}

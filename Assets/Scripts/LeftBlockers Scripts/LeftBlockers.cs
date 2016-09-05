using UnityEngine;

public class LeftBlockers : MonoBehaviour
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

using UnityEngine;

public class GemsScript : MonoBehaviour
{


    public AudioClip impact;
    AudioSource pickupGemSound;

    // Use this for initialization
    void Start()
    {
        if (Door1.instance != null)
        {

            Door1.instance.collectiblesCount++;
        }
    }


    void OnTriggerEnter2D(Collider2D target)
    {                     //  http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
        if (target.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(gameObject);
            if (Door1.instance != null)
            {
                Door1.instance.DecreaseCollectibles();
            }

        }
    }
}

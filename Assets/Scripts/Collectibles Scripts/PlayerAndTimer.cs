using UnityEngine;

public class PlayerAndTimer : MonoBehaviour
{
    public AudioClip impact;
    AudioSource pickupHudSound;



    void Start()
    {

        pickupHudSound = GetComponent<AudioSource>();

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")

        {

            if (gameObject.name == "Timerc")
            {
                GameObject.Find("GamePlayController").GetComponent<TimeLevel>().time += 250f;


            }


            if (gameObject.name == "Lifec")
            {
                GameObject.Find("GamePlayController").GetComponent<PlayerLife>().life += 250f;


            }
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(impact, transform.position);



        }



    }


}

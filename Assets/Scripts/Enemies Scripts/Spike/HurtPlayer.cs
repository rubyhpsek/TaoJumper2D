using UnityEngine;

public class HurtPlayer : MonoBehaviour
{


    public LevelManager mylevelManager;

    public int damageToGive;

    public AudioClip impact;
    //AudioSource movingTrainSound;

    // Use this for initialization
    void Start()
    {
        mylevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            mylevelManager.HurtPlayer(damageToGive);
            AudioSource.PlayClipAtPoint(impact, transform.position);
        }
    }
}

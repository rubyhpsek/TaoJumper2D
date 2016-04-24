using UnityEngine;

public class EnemyParachuteBomb : MonoBehaviour
{

    public AudioClip impact;
    public AudioClip impact2;
    AudioSource bombExplodeSound;

    void Start()
    {
        bombExplodeSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D target)
    {            //  http://docs.unity3d.com/ScriptReference/Collider2D.OnTriggerEnter2D.html :   Set Trigger 
        if (target.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(target.gameObject);   // When hit Player or target Destroy Player
            GameObject.Find("GamePlayController").GetComponent<GamePlayController>().PlayerDied();
            Destroy(gameObject);     // When hit target, destroy the Bomb itself as well

        }  // use if conditional statement to check if Bullet would collide with the Player

        if (target.tag == "ground")
        {
            AudioSource.PlayClipAtPoint(impact2, transform.position);
            // Destroy(target.gameObject);   // When hit Player or target Destroy Player
            // GameObject.Find("GamePlayController").GetComponent<GamePlayController>().PlayerDied();
            Destroy(gameObject);     // When hit target, destroy the Bomb itself as well

        }  // use if conditional statement to check if Bullet hit the Ground
    }

}  //  EnemyLaser class in Level 1 

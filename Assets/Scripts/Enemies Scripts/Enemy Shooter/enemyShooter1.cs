using System.Collections;
using UnityEngine;

public class enemyShooter1 : MonoBehaviour
{

    [SerializeField]      //   http://docs.unity3d.com/ScriptReference/SerializeField.html
    private GameObject laser;

    AudioSource laserExplodeSound;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Shoot());   // Call the method here, so that the Enemy1 would be shooting immediately when the game start
                                   // laserExplodeSound = GetComponent<AudioSource>();
    }


    IEnumerator Shoot()
    {

        yield return new WaitForSeconds(Random.Range(1, 8));   // Shoot lasers in random between 3 to 8 seconds 

        Instantiate(laser, transform.position, Quaternion.identity);  //  shoot from position of EnemyShooter1  from Tutorial: http://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147

        StartCoroutine(Shoot());
        //laserExplodeSound.Play();


    }   // Create a Coroutine or Timer for Auto Shooting of Bullets towards the Player

    void OnTriggerEnter2D(Collider2D target)
    {       //  http://docs.unity3d.com/ScriptReference/Collider2D.OnTriggerEnter2D.html :   Set Trigger
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);   // When  Player collide with the Enemy1 or target it will Destroy Player
            laserExplodeSound = GetComponent<AudioSource>();
            laserExplodeSound.Play();

        }  // use if conditional statement to check if Enemy1  would collide with the Player; the Player would be destroyed

    }

}

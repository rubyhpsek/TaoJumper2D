using UnityEngine;
using System.Collections;

public class enemyLaser1 : MonoBehaviour {
 
    void OnTriggerEnter2D(Collider2D target) {            //  http://docs.unity3d.com/ScriptReference/Collider2D.OnTriggerEnter2D.html :   Set Trigger 
        if (target.tag == "Player") {
            Destroy(target.gameObject);   // When hit Player or target Destroy Player
            Destroy(gameObject);     // When hit target, destroy the Bullet itself as well

        }  // use if conditional statement to check if Bullet would collide with the Player

        if (target.tag == "Ground")   {
            Destroy(gameObject);     // When hit the ground, destroy the Bullet itself as well

        }  // use if conditional statement to check if Bullet hit the Ground
    }
       
}  //  EnemyLaser class in Level 1 

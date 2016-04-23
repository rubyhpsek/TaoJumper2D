using UnityEngine;
using System.Collections;

public class cubesRotator : MonoBehaviour {

    public float jumpforceY = 350f;  // Declare a force for the cube 
    
    private Rigidbody2D cubeBody;   //  http://docs.unity3d.com/ScriptReference/Rigidbody2D.html  :  private variables for component Rigidbody2D
    private Animator anim;        //   http://docs.unity3d.com/ScriptReference/Animator.html :   private variables for component Animator

 //   [SerializeField]      //   http://docs.unity3d.com/ScriptReference/SerializeField.html
   // private GameObject bullet;



    void Awake() {
        cubeBody = GetComponent<Rigidbody2D>();      // Getting the component of Rigidbody2D in Unity Engine
        anim = GetComponent<Animator>();   // Getting the component of Animator in Unity Engine
    }  //  /  Create an  Awake function which get Reference from the 2 private variables (myBody and anim) above


    // Use this for initialization
    void Start () {
        StartCoroutine(JumpAttack());   // Start the Coroutine function 
    }

    IEnumerator JumpAttack() {

        yield return new WaitForSeconds(Random.Range(2, 6));      //  http://docs.unity3d.com/ScriptReference/WaitForSeconds.html ;  http://docs.unity3d.com/ScriptReference/Coroutine.html ;http://docs.unity3d.com/ScriptReference/Random.Range.html 

      //  Instantiate(bullet, transform.position, Quaternion.identity);  //  shoot from postion of EnemyShooter1


        jumpforceY = Random.Range(200, 800);    //  Set forceY to a random time between 200 and 600 in force

        cubeBody.AddForce(new Vector2(0, jumpforceY));                                //  http://docs.unity3d.com/ScriptReference/Rigidbody2D.AddForce.html
        anim.SetBool("Attack", true);                  // http://docs.unity3d.com/ScriptReference/Animator.SetBool.html Set our Attack animator and set the Bool to True  

         yield return new WaitForSeconds(0.8f);  // Wait for 0.8 of a second
        StartCoroutine(JumpAttack());                          // http://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html  Start couroutine and pass the Attack function again
    }  //  Using Coroutine Function to SET The Cube to Attack  


    void OnTriggerEnter2D(Collider2D target)    {       //  http://docs.unity3d.com/ScriptReference/Collider2D.OnTriggerEnter2D.html :   Set Trigger

        if (target.tag == "Ground")        {
            anim.SetBool("Attack", false);
        }  //  Check if cube is in Idle on the ground
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);   // When  Player collide with the Enemy1 or target it will Destroy Player


        }  // use if conditional statement to check if Enemy1  would collide with the Player; the Player would be destroyed

    }



} // The Obstacle number one:  cubeRotator class












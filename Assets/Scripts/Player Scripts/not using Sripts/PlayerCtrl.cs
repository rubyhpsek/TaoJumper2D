//using UnityEngine;
//using System.Collections;


//// IN LINE 29 :    I USED FixedUpdate INSTEAD OF Update because of RigidBody REF:http://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html

//public class PlayerCtrl : MonoBehaviour {

//    public float moveSpeed = 25f;  // variable for  player's moveSpeed (Moving Speed)
//    public float jumpForce = 720f;   // variable for  player's jumpForce (Jumping Force)
//    public float maxSpeed = 8f;  // variable for  player's  maxSpeed(Maximum Speed) ;  All variables set to Public in order to be manipulated in the Inspector Panel

//    private Rigidbody2D myBody;
//    private Animator anim;   // Need this to move or animate my Player

//    private bool grounded = true ;   // This variable is check if our player is on the ground and determine if the player can jump or not

//    void Awake () {
//        InitializedVariables();       // Set this function from line 28 in the Awake function

//    }   //  Create an  Awake function which get Reference from the 2 private variables (myBody and anim) above

//    // Use this for initialization
//    void Start () {
	
//	}
	
//	// Update is called once per frame
//	void FixedUpdate () {
//        PlayerRunKeyBoard();     //  Call our function here to move or make our Player run
        
//    }  // Refer to Line5 for References

//        void InitializedVariables() {
//        myBody = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//    } // Initialize the 2 private variables and get components of the 2 variables from the Unity Engine

//    void PlayerRunKeyBoard() {
//        float forceX = 0f;
//        float forceY = 0f;

//        float vel = Mathf.Abs(myBody.velocity.x);            // Get absolute Velocity (+ number always) of our Rigidbody2D(http://docs.unity3d.com/ScriptReference/Mathf.Abs.html) and because i am going to use maxSpeed in Line 11 for our velocity to control the velocity of our player.

//        float hz = Input.GetAxisRaw("Horizontal");            // http://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html  :  GetAxisRaw gives us -1, 0 , 1 (3 numbers)Eg: -1 is left arrow key or A keyboard key and +1 is right arrow key or D keyboard key

//        if (hz > 0 ) {

//            if (vel < maxSpeed) {
//                if (grounded) {
//                        forceX = moveSpeed;
//                       }else {
//                    forceX = moveSpeed * 1.1f;
//                    }

//                }
                

//            Vector3 scale = transform.localScale;    // http://docs.unity3d.com/ScriptReference/Transform-localScale.html :  Control our Player to face Right (if Scale +1) or face Left (if Scale -1)
//            scale.x = 1f;   // Player facing right side
//            transform.localScale = scale;

//            anim.SetBool("Run", true);     // We are moving using the animation ; Animate moving the Player
//        }  // Conditional Loops (nested) : if --->  used for if Player is moving to the Right side
//        else if (hz < 0) {
//            if (vel < maxSpeed)
//            {
//                if (grounded)
//            {
//                forceX = -moveSpeed;
//            }
//            else
//            {
//                forceX = -moveSpeed * 1.1f;
//            }

//        }


//        Vector3 scale = transform.localScale;    // http://docs.unity3d.com/ScriptReference/Transform-localScale.html :  Control our Player to face Left (if Scale +1) or face Left (if Scale -1)
//            scale.x = -1f;   // Player facing Left side
//            transform.localScale = scale;

//            anim.SetBool("Run", true);     // We are moving using the animation ; Animate moving the Player

//        }  // Conditional Loops (nested) : if --->  used for if Player is moving to the Left side
//        else if (hz == 0) {
//            anim.SetBool("Run", false);   // To indicate the Player is not running or moving

//        }  // Conditional Loops (nested) : if --->  used for if Player is stationary , idle or not moving

//        if (Input.GetKeyDown(KeyCode.Space)) {
//            if (grounded) {
//                grounded = false;
//                forceY = jumpForce;
//            }    // To check if the Player on the ground, then the Player can jump now
//        }   // http://docs.unity3d.com/ScriptReference/Input.html ;  http://docs.unity3d.com/ScriptReference/Input.GetKey.html  ;  http://docs.unity3d.com/ScriptReference/KeyCode.Space.html

//        myBody.AddForce(new Vector2(0, forceY));      //  http://docs.unity3d.com/ScriptReference/Rigidbody2D.AddForce.html : To apply force so that the Player can move

//    } 

//    void onCollisionEnter2D(Collision2D target) {
//        if (target.gameObject.tag == "Ground") {
//            grounded = true;
//        }    //  http://docs.unity3d.com/ScriptReference/GameObject-tag.html

                
//    }  //   http://docs.unity3d.com/ScriptReference/Collider2D.OnCollisionEnter2D.html
//} // PlayerCtrl Class

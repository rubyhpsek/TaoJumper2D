using UnityEngine;
using System.Collections;

public class handCursorGrabbing : MonoBehaviour {

    [SerializeField]        //    http://docs.unity3d.com/ScriptReference/SerializeField.html
    private Transform startPosition, endPosition ;   // set a start and end position 
    

  //  private bool collision;     //  private variable to detect collision

    public float speed = -1f;   // Declare the speed i would move the bird

    private Rigidbody2D myhandCursorBody;

    private bool grounded;
   public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;
   

    void Awake()
    {
        myhandCursorBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();                  // Call the function created
        ChgDirection();
       // TempChgDirection();

    }


    

    void ChgDirection()
    {
        // collision = Physics2D.Linecast(startPosition.position, endPosition.position, 1 <<LayerMask.NameToLayer("Ground"));  // to detect if colliding with the layer with specific name like "Ground"
        grounded = Physics2D.OverlapCircle(endPosition.position,  groundRadius, whatIsGround);     // to detect if the endPosition is grounded on the ground
        Debug.DrawLine(startPosition.position, endPosition.position, Color.blue);

        if (!grounded)
        {
            
            Vector3 temporary = transform.localScale;     //  http://docs.unity3d.com/ScriptReference/Transform-localScale.html

            if (temporary.x == -1f)
            {
                temporary.x = 1f;
            }
            else
            {
                temporary.x = -1f;
            }

            transform.localScale = temporary; // reset the position of object again
        }    // this if statement check if the HandCursor-Grabbing is not colliding with the Ground , it will change the opposite direction

    }

    void Move()
    {

        myhandCursorBody.velocity = new Vector2(-transform.localScale.x, 0) * speed;       // The Hand is walking towards the left when start game  :   http://docs.unity3d.com/ScriptReference/Transform-localScale.html ;  http://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html
                                                                                           // myBody.velocity = new Vector2( -1, 0) * speed;
    }

    //void TempChgDirection() {
    //    Vector3 temporary = transform.localScale;     //  http://docs.unity3d.com/ScriptReference/Transform-localScale.html

    //    if (temporary.x == -1f)
    //    {
    //        temporary.x = 1f;
    //    }
    //    else
    //    {
    //        temporary.x = -1f;
    //    }           // it is a if-else conditional checking if Hand collide with cube so Hand would not be destroyed but change direction only

    //    transform.localScale = temporary; // reset the position of object again

    //}



    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            Destroy(target.gameObject);   // When Player collide with hand Player would be destroyed or die
        }

        if (target.gameObject.tag == "Door" || target.gameObject.tag == "CubeRotator" || target.gameObject.tag == "Hand" )
        {
            Vector3 temporary = transform.localScale;     //  http://docs.unity3d.com/ScriptReference/Transform-localScale.html

            if (temporary.x == -1f)
            {
                temporary.x = 1f;
            }
            else
            {
                temporary.x = -1f;
            }

            transform.localScale = temporary; // reset the position of object again
        }    // this if statement check if the HandCursor-Grabbing is not colliding with the Ground , it will change the opposite direction

    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "SpringBoard")
        {
            Vector3 temporary = transform.localScale;     //  http://docs.unity3d.com/ScriptReference/Transform-localScale.html

            if (temporary.x == -1f)
            {
                temporary.x = 1f;
            }
            else
            {
                temporary.x = -1f;
            }

            transform.localScale = temporary; // reset the position of object again
        }    // this if statement check if the HandCursor-Grabbing is not colliding with the Ground , it will change the opposite direction

    }






}// handcursorGrabbing  class

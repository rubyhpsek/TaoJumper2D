using UnityEngine;
using System.Collections;

public class cardinalBirdFlying : MonoBehaviour {

    [SerializeField]
    private Transform startPosition, endPosition;

 //   private bool collision;   // Detect collision

    public float speed = 0.8f;   // Declare the speed i would move the bird
    private Rigidbody2D cardinalBirdBody;      //  http://docs.unity3d.com/ScriptReference/Rigidbody2D.html  :  private variables for component Rigidbody2D
    private bool grounded;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;
    bool faceRight = true;

    void Awake() {
        cardinalBirdBody = GetComponent<Rigidbody2D>();
    }   //  Call the Awake function to reference our cardinalBirdBody



    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        Move();                    // Call the function created in line 19 here
        ChgDirection();
        if (move > 0 && !faceRight)
            Flip();
        else if (move < 0 && faceRight)
            Flip();
    }     //   http://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html


    void ChgDirection() {
        // collision = Physics2D.Linecast (startPosition.position, endPosition.position, 1 << LayerMask.NameToLayer("Ground"));
        grounded = Physics2D.OverlapCircle(endPosition.position, groundRadius, whatIsGround);     // to detect if the endPosition is grounded on the ground
        Debug.DrawLine (startPosition.position, endPosition.position, Color.magenta);

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

    void Move() {

        cardinalBirdBody.velocity = new Vector2 (transform.localScale.x, 1) * speed;             // http://docs.unity3d.com/ScriptReference/Transform-localScale.html ;  http://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html


    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            Destroy(target.gameObject);
        }
    }
}

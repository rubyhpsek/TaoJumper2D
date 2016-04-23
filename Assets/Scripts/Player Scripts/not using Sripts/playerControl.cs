using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

    public float maxSpeed = 12f;
    Rigidbody2D myrbBody;
    bool grounded;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask IsItGround;
    public float jumpForce = 700f;
    private Animator anim;
    bool faceRgt = true;





    // Use this for initialization
    void Start()
    {
        myrbBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float move = Input.GetAxis("Horizontal");  // http://docs.unity3d.com/ScriptReference/Input.GetAxis.html
        myrbBody.velocity = new Vector2(move * maxSpeed, myrbBody.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move * maxSpeed));

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, IsItGround); // http://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircle.html

        if (move > 0 && !faceRgt)
            Flip();
        else if (move < 0 && faceRgt)
            Flip();

    }


    void Update() {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            myrbBody.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void SpringPlayerWSpringy(float force) {
        if (grounded) {
            grounded = false;
            myrbBody.AddForce(new Vector2(0, force));
        }
    }

    //void onCollisionEnter2D(Collision2D target)
    //{
    //    if (target.gameObject.tag == "Ground") {
    //        grounded = true;
    //    }    //  http://docs.unity3d.com/ScriptReference/GameObject-tag.html

        void Flip()    {
            faceRgt = !faceRgt;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }

    }


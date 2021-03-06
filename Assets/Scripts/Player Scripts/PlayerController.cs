﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 12f;
    Rigidbody2D myrbBody;
    bool grounded;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask IsItGround;
    public float jumpForce = 700f;
    private Animator anim;
    bool faceRgt = true;

    public Vector3 respawnPosition;

    public LevelManager mylevelManager;


    public AudioClip impact1;
    public AudioClip impact2;
    // AudioSource Explosion;

    // AudioSource flipSound;








    // Use this for initialization
    void Start()
    {
        //ResetPlayerObject();
        myrbBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        mylevelManager = FindObjectOfType<LevelManager>();

        // jumpSound = GetComponent<AudioSource>();
        //   flipSound = GetComponent<AudioSource>();
        // laserHitTargetSound = GetComponent<AudioSource>();
        //  pickupGemSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");  // http://docs.unity3d.com/ScriptReference/Input.GetAxis.html       
        myrbBody.velocity = new Vector2(move * maxSpeed, myrbBody.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move * maxSpeed));

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, IsItGround); // http://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircle.html

        if (move > 0 && !faceRgt)
            Flip();

        else if (move < 0 && faceRgt)
            Flip();


    }


    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            myrbBody.AddForce(new Vector2(0, jumpForce));
            //jumpSound.Play();
            AudioSource.PlayClipAtPoint(impact2, transform.position);

        }


    }

    public void SpringPlayerWSpringy(float force)
    {
        if (grounded)
        {
            grounded = false;
            myrbBody.AddForce(new Vector2(0, force));
        }
    }

    //void onCollisionEnter2D(Collision2D target)
    //{
    //    if (target.gameObject.tag == "Ground") {
    //        grounded = true;
    //    }    //  http://docs.unity3d.com/ScriptReference/GameObject-tag.html

    void Flip()
    {
        faceRgt = !faceRgt;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        //flipSound.Play();
    }

    //void OnTriggerEnter2D(Collider2D target)
    //{       //  http://docs.unity3d.com/ScriptReference/Collider2D.OnTriggerEnter2D.html :   Set Trigger
    //    if (target.tag == "Player" || target.tag == "SpaceShip" || target.tag == "Bomb")
    //    {
    //        //   laserHitTargetSound.Play();
    //        Destroy(target.gameObject);   // When  Player collide with the Enemy1 or target it will Destroy Player
    //                                      // GameObject.Find("BG-MUSIC").audio.Stop();
    //                                      //  GetComponent<AudioSource>("BG-MUSIC").audio.Stop();
    //                                      //ResetPlayerObject();
    //    }


    //}



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "DeathPlane")
        {
            AudioSource.PlayClipAtPoint(impact1, transform.position);
            mylevelManager.Respawn();
        }

        if (other.tag == "CheckPoint")
        {
            respawnPosition = other.transform.position;
        }
    }


}


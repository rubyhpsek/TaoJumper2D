﻿using System.Collections;
using UnityEngine;

public class Springy : MonoBehaviour
{

    public float force = 580f;

    private Animator anim;

    AudioSource springJumpSound;

    void Awake()
    {
        anim = GetComponent<Animator>();
        springJumpSound = GetComponent<AudioSource>();

    }

    IEnumerator AnimateSpringy()
    {

        anim.Play("SpringUp");
        yield return new WaitForSeconds(0.5f);
        anim.Play("SpringDown");
        springJumpSound.Play();

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            target.gameObject.GetComponent<PlayerController>().SpringPlayerWSpringy(force);
            StartCoroutine(AnimateSpringy());
        }
    } // Check if the springBoard collide with the Player, it will springUp the Player

    // Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}
﻿using UnityEngine;

public class PlayerAndTimer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")

        {

            if (gameObject.name == "Timerc")
            {
                GameObject.Find("GamePlayController").GetComponent<TimeLevel>().time += 250f;


            }


            if (gameObject.name == "Lifec")
            {
                GameObject.Find("GamePlayController").GetComponent<PlayerLife>().life += 250f;


            }

            Destroy(gameObject);



        }



    }


}

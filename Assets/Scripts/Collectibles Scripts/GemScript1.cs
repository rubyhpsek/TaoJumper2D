using UnityEngine;
using System.Collections;

public class GemScript1 : MonoBehaviour { 

    // Use this for initialization
    void Start () {
        if(Door1.instance != null) {

            Door1.instance.collectiblesCount++;
        }
	}
	

    void OnTriggerEnter2D(Collider2D target)
{                     //  http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
    if (target.tag == "Player")
    {
        Destroy(gameObject);
        if (Door1.instance != null)
        {
            Door1.instance.DecreaseCollectibles();
        }

    }
}
}
































//{

//    public AudioClip impact;
//    AudioSource pickupGemSound;

//    // bool isPlaying=true;

//    // Use this for initialization
//    void Start()
//    {
//        //playPickClip();


//        if (Door1.instance != null)
//        {

//            Door1.instance.collectiblesCount++;
//        }

//    }

//    //void playPickClip(){
//    //     GetComponent<AudioSource>().PlayOneShot(impact, 1f);


//    //}


//    //  void OnCollisionEnter2D(Collision2D other)
//    void OnTriggerEnter2D(Collider2D target)
//    {                     //  http://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html


//        if (target.tag == "Player")
//        {
//            //AudioSource.PlayClipAtPoint(impact, transform.position);
//            Destroy(gameObject); // this destroys the collider as well
            
//            if (Door1.instance != null)
//            {
//                Door1.instance.DecreaseCollectibles();
//            }

//        }

//    }
//}

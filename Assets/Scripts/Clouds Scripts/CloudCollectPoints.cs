using UnityEngine;
using System.Collections;

public class CloudCollectPoints : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){
        if( target.tag == "Cloud" || target.tag == "Dead") {
            target.gameObject.SetActive(false);    //  Deactivate the game object in the scene
        }
    }
}

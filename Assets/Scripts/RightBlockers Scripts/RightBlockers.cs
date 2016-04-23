using UnityEngine;
using System.Collections;

public class RightBlockers : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
        }
    }
}

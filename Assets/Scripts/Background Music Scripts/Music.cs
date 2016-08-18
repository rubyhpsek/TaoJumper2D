using UnityEngine;

public class Music : MonoBehaviour
{
    //GetComponent AudioSource<audio>();


    // Update is called once per frame
    void Update()
    {
        GameObject soundObject = GameObject.Find("BG-MUSIC");

        AudioSource audioSource = soundObject.GetComponent<AudioSource>();


    }


}

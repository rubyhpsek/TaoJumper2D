using System.Collections;
using UnityEngine;

public class Door2 : MonoBehaviour
{

    public static Door2 instance;

    private BoxCollider2D myBox;
    private Animator anim;

    [HideInInspector]                    //http://docs.unity3d.com/ScriptReference/HideInInspector.html
    public int collectiblesCount;


    void Awake()
    {
        CreateInstance();
        anim = GetComponent<Animator>();
        myBox = GetComponent<BoxCollider2D>();
    }

    void CreateInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void DecreaseCollectibles()
    {

        collectiblesCount--;

        if (collectiblesCount == 0)
        {
            StartCoroutine(OpenDoor());  // if this condition is true , it will open the door
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(0.5f);     // wait for 0.5 seconds before open
        myBox.isTrigger = true;

    }


    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {
            Debug.Log("Game is Finished now");
        }

    }





}//  Door1  class

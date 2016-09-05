using UnityEngine;

public class CheckPointController : MonoBehaviour
{

    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer mySpriteRenderer;

    public bool checkpointActive;



    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            mySpriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }

    }
}

using UnityEngine;

public class ExtraLife : MonoBehaviour
{

    public int livesToGive;

    private LevelManager mylevelManager;

    // Use this for initialization
    void Start()
    {
        mylevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            mylevelManager.AddLives(livesToGive);
            gameObject.SetActive(false);
        }
    }
}

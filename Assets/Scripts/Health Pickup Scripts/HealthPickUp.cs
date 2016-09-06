using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    public int healthToGive;

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
            mylevelManager.GiveHealth(healthToGive);
            gameObject.SetActive(false);
        }
    }
}

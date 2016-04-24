using UnityEngine;

public class MovingBlocks : MonoBehaviour
{

    private float movingBlockSpeed;
    AudioSource explodeSound;

    GameManager gm;

    // Use this for initialization
    void Start()
    {
        ResetEnemyObject();
        explodeSound = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * movingBlockSpeed * Time.deltaTime);
        if (transform.position.x <= -9.4f)
        {
            ResetEnemyObject();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingBlock")
        {
            explodeSound.Play();
            gm.AddScore(1);
            ResetEnemyObject();
            Destroy(other.gameObject);
        }

        //if (gameObject.tag == "Player")
        //{
        //    explodeSound.Play();
        //    Destroy(other.gameObject);
        //    gm.SubtractScore(1);
        //    ResetEnemyObject();
        //    other.transform.position = new Vector2(-8.0f, -0.0f);
        //}

        if (other.transform.tag == "Player")
        {
            // Application.LoadLevel("GamePlay");
            explodeSound.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameObject.Find("GamePlayController").GetComponent<GamePlayController>().PlayerDied();
        }
    }

    void ResetEnemyObject()
    {
        movingBlockSpeed = Random.Range(5f, 10f);
        transform.position = new Vector2(Random.Range(11.0f, 20.0f), Random.Range(4.2f, -4.2f));
    }

    void ResetPlayer()
    {
        //resumeGame.onClick.AddListener(() => RestartGame());
    }

}

using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    // public float waitToRespawn;

    public PlayerController myPlayer;


    // public GameObject deathExplosion;
    //public AudioClip impact;
    //AudioSource Explosion;






    public int ballCount;
    private int ballBonusLifeCount;

    public Text ballText;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;


    public int maxHealth;
    public int healthCount;

    private bool respawning;


    public Text livesText;
    public int startingLives;
    public int currentLives;

    public GameObject gameOverScreen;

    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    //public AudioClip impact3;

    // Use this for initialization
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerController>();

        ballText.text = "Balls:  " + ballCount;

        healthCount = maxHealth;
        currentLives = startingLives;
        livesText.text = "Lives x " + currentLives;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Respawn()
    {
        //levelMusic.Stop();
        //levelMusic.Play();

        currentLives -= 1;
        livesText.text = "Lives x " + currentLives;
        if (currentLives > 0)
        {
            myPlayer.gameObject.SetActive(false);
            healthCount = maxHealth;
            respawning = false;
            UpdateHeartMeter();
            myPlayer.transform.position = myPlayer.respawnPosition;
            myPlayer.gameObject.SetActive(true);
        }
        else
        {
            myPlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameOverMusic.Play();

            //levelMusic.volume = levelMusic.volume / 2f;
        }
    }

    public void AddBalls(int ballsToAdd)
    {
        ballCount += ballsToAdd;
        ballBonusLifeCount += ballsToAdd;

        ballText.text = "Balls:  " + ballCount;
    }

    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        UpdateHeartMeter();

        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;

        }

        if (ballBonusLifeCount >= 100)
        {
            currentLives += 1;
            livesText.text = "Lives x " + currentLives;
            ballBonusLifeCount -= 100;
        }
    }

    public void GiveHealth(int healthToGive)
    {
        healthCount += healthToGive;

        if (healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }
        UpdateHeartMeter();
    }

    public void UpdateHeartMeter()
    {
        switch (healthCount)
        {
            case 12:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;

            case 11:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;

            case 10:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;

            case 9:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;

            case 8:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            case 7:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            case 6:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;

            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;

            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;

            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            case 0:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;



            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
        }
    }

    public void AddLives(int livesToAdd)
    {
        currentLives += livesToAdd;
        livesText.text = "Lives x " + currentLives;

    }


}





//public IEnumerator RespawnCo()
//{
//    myPlayer.gameObject.SetActive(false);
//    Instantiate(dieExplosion, myPlayer.transform.position, myPlayer.transform.rotation);
//    yield return new WaitForSeconds(waitToRespawn);
//    myPlayer.transform.position = myPlayer.respawnPosition;
//    myPlayer.gameObject.SetActive(true);

//}


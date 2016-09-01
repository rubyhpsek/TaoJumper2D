using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]    // Visible in inspector but do not want any other classes assess it
    private GameObject[] clouds;


    private float distanceBetweenClouds = 7.5f;

    private float minY, maxY;

    private float lastCloudPositionX;

    private float controlY;


    [SerializeField]
    private GameObject[] collectibles;

    private GameObject player;


	
	void Awake () {
        controlY = 0;
        SetMinAndMaxY();
        CreateClouds();
        player = GameObject.Find("Player");
    }

    void Start() {
        PostionThePlayer();
    }

    void SetMinAndMaxY() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxY = bounds.y - 2.5f;
        minY = -bounds.y + 14.5f;
    }

    void Shuffle(GameObject[] arrayShuffle) {
        for (int j = 0; j<arrayShuffle.Length; j++) {
            GameObject temp = arrayShuffle[j];
            int random = Random.Range(j, arrayShuffle.Length);
            arrayShuffle[j] = arrayShuffle[random];
            arrayShuffle[random] = temp;

            
        }
    }   // Randomize the arrays of the GameObjects

    void CreateClouds() {
        Shuffle(clouds);

        float positionX = 45f;

        for (int j=0; j < clouds.Length; j++) {
            Vector3 temp = clouds[j].transform.position;

            temp.x = positionX;
            //temp.y = Random.Range(minY, maxY);



            if (controlY == 0)
            {
                temp.y = Random.Range(0.5f, maxY);
                controlY = 1;
            }
            else if (controlY == 1)
            {
                temp.y = Random.Range(0.5f, minY);
                controlY = 2;
            }
            else if (controlY == 2)
            {
                temp.y = Random.Range(1.5f, maxY);
                controlY = 3;
            }
            else if (controlY == 3)
            {
                temp.y = Random.Range(-1.5f, minY);
                controlY = 0;
            }

            lastCloudPositionX = positionX;

            clouds[j].transform.position = temp;

            positionX -= distanceBetweenClouds;

        }
    }

    void PostionThePlayer() {
        GameObject[] angryClouds = GameObject.FindGameObjectsWithTag("Dead");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int j = 0; j < angryClouds.Length; j++)
        {
            if (angryClouds[j].transform.position.x == 45f) {
                Vector3 t = angryClouds[j].transform.position;
                angryClouds[j].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                                cloudsInGame[0].transform.position.y,
                                                                cloudsInGame[0].transform.position.z);

                cloudsInGame[0].transform.position = t;

            }
           


        }
        Vector3 temp = cloudsInGame[0].transform.position;

        for (int j = 1; j < cloudsInGame.Length; j++)
        {
             if(temp.x < cloudsInGame[j].transform.position.x) {
                temp = cloudsInGame[j].transform.position;
            }
        }

        temp.x += -10f;

        player.transform.position = temp;


    }


}   // CloudSpawner

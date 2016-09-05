using UnityEngine;

public class CameraFollowControl : MonoBehaviour
{
    private Transform player;

    public float minX, maxX;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {  // To check when player is killed (destroyed) ; the player would be null then
            Vector3 temporary = transform.position; // Getting position of Camera saving to a variable call temporary
            temporary.x = player.position.x;    // getting x position of the player setting to the position of temporary

            if (temporary.x < minX)
                temporary.x = minX;

            if (temporary.x > maxX)
                temporary.x = maxX;


            temporary.y = player.position.y + 2.8f;    // getting y position of the player setting to the position of temporary ; To follow our player when he jumps

            transform.position = temporary;  //  Reassigning the position of x to the temporary's position to the Camera.
        }
    }
}  //  CameraFollowControl   Class

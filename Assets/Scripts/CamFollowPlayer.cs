using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{


    private GameObject player;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    Vector3 tagetPosition;
    Vector3 smoothposition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Follow();
        

    }


    void Follow()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //transform.position = new Vector3(player.transform.position.x, 0, 0);
         tagetPosition = new Vector3(player.transform.position.x, 0, 0) + offset;
         smoothposition = Vector3.Lerp(transform.position, tagetPosition,smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothposition;
    }
}
    

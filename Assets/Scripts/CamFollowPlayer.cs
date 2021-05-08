using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CamFollowPlayer : MonoBehaviour
{


    private GameObject player;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    Vector3 tagetPosition;
    Vector3 smoothposition;
    // Start is called before the first frame update
     bool stopMoveCamera = false;
    public GameObject fire;
    public static CamFollowPlayer instance;
    bool timeON = false;
    public TMP_Text tx;

    void Start()
    {
        tx.GetComponent<TMP_Text>();
        tx.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        if(instance == null)
        {
            instance = this;
        }
        stopMoveCamera = true;
        StartCoroutine(FirstState());
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
        if (!stopMoveCamera)
        {
            tagetPosition = new Vector3(player.transform.position.x, 0, 0) + offset;
            smoothposition = Vector3.Lerp(transform.position, tagetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothposition;
        }
    }

    public void StopCam()
    {
        stopMoveCamera = true;
    }

    IEnumerator FirstState()
    {
        tx.gameObject.SetActive(true);
        player.GetComponent<PlayerMovment>().speed = 0;
        player.GetComponent<PlayerMovment>().canChangeSpeed = true;
        player.GetComponent<PlayerMovment>().canJump = false;
        tx.text = "3";
        yield return new WaitForSeconds(1f);
        tx.text = "2";
        yield return new WaitForSeconds(1f);
        tx.text = "1";
        yield return new WaitForSeconds(1f);
        tx.text = "GO";
        yield return new WaitForSeconds(0.5f);
        stopMoveCamera = false;
       player.GetComponent<PlayerMovment>().RestarSpeed();
        fire.GetComponent<MovmentCamera>().canMove = true;
        tx.gameObject.SetActive(false);


    }

}


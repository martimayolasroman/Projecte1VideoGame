using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;

public class DistFoc : MonoBehaviour
{

    public GameObject player;
    public GameObject fire;
    int dist;
    TMP_Text distNum;


    // Start is called before the first frame update
    void Start()
    {
        distNum = gameObject.GetComponent<TMP_Text>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

        dist = CalculateDist();

        if(dist <= 0)
        {
            distNum.text = " ";

        }
        else {
            distNum.text = dist + "m";
        }
        

        

        
    }

    public int CalculateDist()
    {

        Vector3 distancia;

        distancia.x = (player.transform.position.x - fire.transform.position.x);

        


        return (int)distancia.x;

    }


}

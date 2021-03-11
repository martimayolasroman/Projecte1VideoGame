using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointCounter : MonoBehaviour
{

    public GameObject Coins1;
    public GameObject Coins2;
    public GameObject Coins3;
    public static CointCounter instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }


    }

    // Update is called once per frame
    void Update()
    {


        
    }


    public void ChangeScore(string coin)
    {
        switch (coin)
        {
              case "coins1":
                 Coins1.SetActive(true);
                 break;
               case "coins2":
                 Coins2.SetActive(true);
                 break;
               case "coins3":
                 Coins3.SetActive(true);
                 break;

            default:
                break;
        }



    }
}

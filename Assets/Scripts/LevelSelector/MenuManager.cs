using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{

    public GameObject[] coinsObject;
    public GameObject[] cantplayLevel;
    Coins_Saved coinss;

    void Start()
    {
        cantplayLevel = new GameObject[3];
        WakeUp();
        coinss = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Coins_Saved>();

    }

    void Update()
    {


         if (coinss.coins[1])
        {
            coinsObject[1].SetActive(true);

        }
        if (coinss.coins[2])
        {
            coinsObject[2].SetActive(true);

        }
        if (coinss.coins[3])
        {
            coinsObject[3].SetActive(true);

        }
        if (coinss.coins[5])
        {
            coinsObject[5].SetActive(true);

        }
        if (coinss.coins[6])
        {
            coinsObject[6].SetActive(true);

        }
        if (coinss.coins[7])
        {
            coinsObject[7].SetActive(true);

        }
        if (coinss.coins[9])
        {
            coinsObject[9].SetActive(true);

        }
        if (coinss.coins[10])
        {
            coinsObject[10].SetActive(true);

        }
        if (coinss.coins[11])
        {
            coinsObject[11].SetActive(true);

        }
        if (coinss.coins[13])
        {
            coinsObject[13].SetActive(true);

        }
        if (coinss.coins[14])
        {
            coinsObject[14].SetActive(true);

        }
        if (coinss.coins[15])
        {
            coinsObject[15].SetActive(true);

        }

    }






    private void WakeUp()
    {
        coinsObject[0].SetActive(true);
        coinsObject[1].SetActive(false);
        coinsObject[2].SetActive(false);
        coinsObject[3].SetActive(false);

        coinsObject[4].SetActive(true);
        coinsObject[5].SetActive(false);
        coinsObject[6].SetActive(false);
        coinsObject[7].SetActive(false);

        coinsObject[8].SetActive(true);
        coinsObject[9].SetActive(false);
        coinsObject[10].SetActive(false);
        coinsObject[11].SetActive(false);

        coinsObject[12].SetActive(true);
        coinsObject[13].SetActive(false);
        coinsObject[14].SetActive(false);
        coinsObject[15].SetActive(false);



    }    
   
}

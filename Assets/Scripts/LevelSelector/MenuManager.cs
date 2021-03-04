using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public  bool[] coins;
    public GameObject[] coinsObject;
    public GameObject[] cantplayLevel;


    void Start()
    {
        coins = new bool[16];
        cantplayLevel = new GameObject[3];
        DontDestroyOnLoad(this.gameObject);
        WakeUp();
        coinsObject[15].SetActive(true);
    }

    void Update()
    {

        //Anar coomprovant monedes per nivell Primer mires el nivell, al final dell mira cuantes a aconseguit si > a lanterior setea depenen de les monedes conseguides
        if (/*Scene == LevelSelector*/0==0)
        {
            UpdateLvl1();
            UpdateLvl2();
            UpdateLvl3();
            UpdateLvl4();
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

        coins[0] = true;
        coins[1] = false;
        coins[2] = false;
        coins[3] = false;

        coins[4] = true;
        coins[5] = false;
        coins[6] = false;
        coins[7] = false;

        coins[8] = true;
        coins[9] = false;
        coins[10] = false;
        coins[11] = false;

        coins[12] = true;
        coins[13] = false;
        coins[14] = false;
        coins[15] = false;

    }
    private void UpdateLvl1()
    {

        if (/*Level1TotalCoins*/0 >/*actualCoins*/0)
        {

            if (coins[1])
            {
                coinsObject[1].SetActive(true);

            }
            if (coins[2])
            {
                coinsObject[2].SetActive(true);

            }
            if (coins[3])
            {
                coinsObject[3].SetActive(true);

            }
        }
    }
    private void UpdateLvl2()
    {
        if (/*Level1TotalCoins*/0 >/*actualCoins*/0)
        {

            if (coins[5])
            {
                coinsObject[5].SetActive(true);

            }
            if (coins[6])
            {
                coinsObject[6].SetActive(true);

            }
            if (coins[7])
            {
                coinsObject[7].SetActive(true);

            }
        }
    }
    private void UpdateLvl3()
    {
        if (/*Level1TotalCoins*/0 >/*actualCoins*/0)
        {

            if (coins[9])
            {
                coinsObject[9].SetActive(true);

            }
            if (coins[10])
            {
                coinsObject[10].SetActive(true);

            }
            if (coins[11])
            {
                coinsObject[11].SetActive(true);

            }
        }
    }
    private void UpdateLvl4()
    {
        if (/*Level1TotalCoins*/0 >/*actualCoins*/0)
        {

            if (coins[13])
            {
                coinsObject[13].SetActive(true);

            }
            if (coins[14])
            {
                coinsObject[14].SetActive(true);

            }
            if (coins[15])
            {
                coinsObject[15].SetActive(true);

            }
        }
    }
}

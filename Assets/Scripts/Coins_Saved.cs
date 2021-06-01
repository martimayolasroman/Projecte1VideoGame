using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Coins_Saved : MonoBehaviour
{

    public bool[] coins;
    void Start()
    {

        coins = new bool[16];
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }




    private void WakeUp()
    {

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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{

    public int coinValue = 1;
    public GameObject CoinEffect;
    Coins_Saved menuManager;
    CointCounter CoinCounter;

    private void Start()
    {
        CoinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<CointCounter>();
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Coins_Saved>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "PrototypLevel")
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                if (gameObject.CompareTag("coin1"))
                {
                    CointCounter.instance.ChangeScore("coins1");
                    menuManager.coins[1] = true;
                }
                if (gameObject.CompareTag("coin2"))
                {
                    CointCounter.instance.ChangeScore("coins2");
                    menuManager.coins[2] = true;

                }
                if (gameObject.CompareTag("coin3"))
                {
                    CointCounter.instance.ChangeScore("coins3");
                    menuManager.coins[3] = true;

                }

                Destroy(gameObject);

            }
        }

        if (SceneManager.GetActiveScene().name == "LEVEL2F")
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                if (gameObject.CompareTag("coin1"))
                {
                    CointCounter.instance.ChangeScore("coins1");
                    menuManager.coins[5] = true;
                }
                if (gameObject.CompareTag("coin2"))
                {
                    CointCounter.instance.ChangeScore("coins2");
                    menuManager.coins[6] = true;

                }
                if (gameObject.CompareTag("coin3"))
                {
                    CointCounter.instance.ChangeScore("coins3");
                    menuManager.coins[7] = true;

                }

                Destroy(gameObject);

            }
        }

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                if (gameObject.CompareTag("coin1"))
                {
                    CointCounter.instance.ChangeScore("coins1");
                    menuManager.coins[9] = true;
                }
                if (gameObject.CompareTag("coin2"))
                {
                    CointCounter.instance.ChangeScore("coins2");
                    menuManager.coins[10] = true;

                }
                if (gameObject.CompareTag("coin3"))
                {
                    CointCounter.instance.ChangeScore("coins3");
                    menuManager.coins[11] = true;

                }

                Destroy(gameObject);

            }
        }

        if (SceneManager.GetActiveScene().name == "PrototypLevelBoss")
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                if (gameObject.CompareTag("coin1"))
                {
                    CointCounter.instance.ChangeScore("coins1");
                    menuManager.coins[13] = true;
                }
                if (gameObject.CompareTag("coin2"))
                {
                    CointCounter.instance.ChangeScore("coins2");
                    menuManager.coins[14] = true;

                }
                if (gameObject.CompareTag("coin3"))
                {
                    CointCounter.instance.ChangeScore("coins3");
                    menuManager.coins[15] = true;

                }

                Destroy(gameObject);

            }
        }
    }

}

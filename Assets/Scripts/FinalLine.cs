using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victoryMenu;
    Coins_Saved menuManager;

    void Start()
    {
        victoryMenu.SetActive(false);
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Coins_Saved>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            victoryMenu.SetActive(true);
            Time.timeScale =0;

            if (SceneManager.GetActiveScene().name == "PrototypLevel")
            {
               if(menuManager.coinValue == 1)
                {
                    if (menuManager.coins[2] == false && menuManager.coins[3] == false)
                    {
                        menuManager.coins[1] = true;
                    }
                }
                if (menuManager.coinValue == 2)
                {
                    if (menuManager.coins[3] == false)
                    {
                        menuManager.coins[2] = true;
                    }

                }
                if (menuManager.coinValue == 3)
                {
                    menuManager.coins[3] = true;

                }

                Destroy(gameObject);

                
            }

            if (SceneManager.GetActiveScene().name == "LEVEL2F")
            {

                if (menuManager.coinValue == 1)
                {
                    if (menuManager.coins[6] == false && menuManager.coins[7] == false)
                    {
                        menuManager.coins[5] = true;
                    }
                }
                if (menuManager.coinValue == 2)
                {
                    if (menuManager.coins[7] == false)
                    {
                        menuManager.coins[6] = true;
                    }

                }
                if (menuManager.coinValue == 3)
                {
                    menuManager.coins[7] = true;

                }

                Destroy(gameObject);

                
            }

            if (SceneManager.GetActiveScene().name == "Level3")
            {



                if (menuManager.coinValue == 1)
                {
                    if (menuManager.coins[10] == false && menuManager.coins[11] == false)
                    {
                        menuManager.coins[9] = true;
                    }
                }
                if (menuManager.coinValue == 2)
                {
                    if (menuManager.coins[11] == false)
                    {
                        menuManager.coins[10] = true;
                    }

                }
                if (menuManager.coinValue == 3)
                {
                    menuManager.coins[11] = true;

                }

                Destroy(gameObject);


                
            }

            if (SceneManager.GetActiveScene().name == "PrototypLevelBoss")
            {


                if (menuManager.coinValue == 1)
                {
                    if (menuManager.coins[14] == false && menuManager.coins[15] == false)
                    {
                        menuManager.coins[13] = true;
                    }
                }
                if (menuManager.coinValue == 2)
                {
                    if (menuManager.coins[15] == false)
                    {
                        menuManager.coins[14] = true;
                    }

                }
                if (menuManager.coinValue == 3)
                {
                    menuManager.coins[15] = true;

                }

                Destroy(gameObject);


                
            }
        }
    }
}

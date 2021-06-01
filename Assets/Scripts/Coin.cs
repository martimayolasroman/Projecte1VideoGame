using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{

    public int coinValue = 1;
    public GameObject CoinEffect;
    Coins_Saved menuManager;

    private AudioSource audioPlayer;
    public AudioClip CoinClip;

    CointCounter CoinCounter;

    private void Start()
    {
        CoinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<CointCounter>();
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Coins_Saved>();
        audioPlayer = GetComponent<AudioSource>();
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


            
            // ScoreManager.instance.changeScore(coinValue);
            // GameObject effectObj = Instantiate(CoinEffect, transform.position, Quaternion.identity);
            if (gameObject.CompareTag("coin1"))
            {
                audioPlayer.clip = CoinClip;
                audioPlayer.Play();
                CointCounter.instance.ChangeScore("coins1");
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyCoin());

            }
            if (gameObject.CompareTag("coin2")) 
                
            {
                audioPlayer.clip = CoinClip;
                audioPlayer.Play();
                CointCounter.instance.ChangeScore("coins2");
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyCoin());

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

                audioPlayer.clip = CoinClip;
                audioPlayer.Play();
                CointCounter.instance.ChangeScore("coins3");
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyCoin());

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


            //   Destroy(effectObj, 5f);
            //Destroy(gameObject);
            //GameObject effectObj = Instantiate(CoinEffect, this.transform.position, Quaternion.identity);
            //CoinEffect.Play();
            //Destroy(CoinEffect, 0.5f);
        }

    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);

    }
}



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        ScoreManager.instance.changeScore(coinValue);
    //        GameObject effectObj = Instantiate(CoinEffect, collision.contacts[0].point, Quaternion.identity);
    //        //CoinEffect.Play();
    //        Destroy(CoinEffect, 0.5f);
    //    }
    //}



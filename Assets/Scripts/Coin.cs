using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{

    public GameObject CoinEffect;
    Coins_Saved menuManager;
    bool ischangedlevel = false;
    private AudioSource audioPlayer;
    public AudioClip CoinClip;

    CointCounter CoinCounter;

    private void Start()
    {
        CoinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<CointCounter>();
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<Coins_Saved>();
        audioPlayer = GetComponent<AudioSource>();
    }

    //private void Update()
    //{


    //    if (SceneManager.GetActiveScene().name == "PrototypLevel")
    //    {
    //        if (ischangedlevel == false)
    //        {
    //            menuManager.coinValue = 0;
    //            ischangedlevel = true;
    //        }

    //    }

    //    if (SceneManager.GetActiveScene().name == "LEVEL2F")
    //    {

    //        if (ischangedlevel == false)
    //        {
    //            menuManager.coinValue = 0;
    //            ischangedlevel = true;
    //        }

    //    }

    //    if (SceneManager.GetActiveScene().name == "Level3")
    //    {

    //        if (ischangedlevel == false)
    //        {
    //            menuManager.coinValue = 0;
    //            ischangedlevel = true;

    //        }



    //    }

    //    if (SceneManager.GetActiveScene().name == "PrototypLevelBoss")
    //    {

    //        if (ischangedlevel == false)
    //        {
    //            menuManager.coinValue = 0;
    //            ischangedlevel = true;
    //        }



    //    }
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "PrototypLevel")
        {

            if (collision.gameObject.CompareTag("Player"))
            {

                if (gameObject.CompareTag("coin1"))
                {
                    CointCounter.instance.ChangeScore("coins1");
                    menuManager.coinValue++;
                }
                if (gameObject.CompareTag("coin2"))
                {
                    CointCounter.instance.ChangeScore("coins2");
                    menuManager.coinValue++;

                }
                if (gameObject.CompareTag("coin3"))
                {
                    CointCounter.instance.ChangeScore("coins3");
                    menuManager.coinValue++;

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
                    menuManager.coinValue++;
                    CointCounter.instance.ChangeScore("coins1");

                }
                if (gameObject.CompareTag("coin2"))
                {

                    CointCounter.instance.ChangeScore("coins2");
                    menuManager.coinValue++;


                }
                if (gameObject.CompareTag("coin3"))
                {

                    CointCounter.instance.ChangeScore("coins3");
                    menuManager.coinValue++;

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
                    menuManager.coinValue++;
                    CointCounter.instance.ChangeScore("coins1");
                    Debug.Log(menuManager.coinValue);
                }
                if (gameObject.CompareTag("coin2"))
                {
                    menuManager.coinValue++;
                    CointCounter.instance.ChangeScore("coins2");
                    Debug.Log(menuManager.coinValue);


                }
                if (gameObject.CompareTag("coin3"))
                {
                    menuManager.coinValue++;
                    CointCounter.instance.ChangeScore("coins3");
                    Debug.Log(menuManager.coinValue);


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
                    menuManager.coinValue++;

                }
                if (gameObject.CompareTag("coin2"))
                {
                    CointCounter.instance.ChangeScore("coins2");
                    menuManager.coinValue++;

                }
                if (gameObject.CompareTag("coin3"))
                {
                    CointCounter.instance.ChangeScore("coins3");
                    menuManager.coinValue++;

                }

                Destroy(gameObject);


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



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinValue = 1;
    public GameObject CoinEffect;
    
    CointCounter CoinCounter;

    private void Start()
    {
        CoinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<CointCounter>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ScoreManager.instance.changeScore(coinValue);
            // GameObject effectObj = Instantiate(CoinEffect, transform.position, Quaternion.identity);
            if (gameObject.CompareTag("coin1"))
            {
                CointCounter.instance.ChangeScore("coins1");
            }
            if (gameObject.CompareTag("coin2"))
            {
                CointCounter.instance.ChangeScore("coins2");
            }
            if (gameObject.CompareTag("coin3"))
            {
                CointCounter.instance.ChangeScore("coins3");
            }

            //   Destroy(effectObj, 5f);
            Destroy(gameObject);
            //GameObject effectObj = Instantiate(CoinEffect, this.transform.position, Quaternion.identity);
            //CoinEffect.Play();
            //Destroy(CoinEffect, 0.5f);
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
}

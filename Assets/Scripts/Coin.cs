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
        Debug.Log("Monedetes");
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
                Debug.Log("Monedetes1");
            }
            if (gameObject.CompareTag("coin2"))
            {
                CointCounter.instance.ChangeScore("coins2");
                Debug.Log("Monedetes2");
            }
            if (gameObject.CompareTag("coin3"))
            {
                CointCounter.instance.ChangeScore("coins3");
                Debug.Log("Monedetes3");
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

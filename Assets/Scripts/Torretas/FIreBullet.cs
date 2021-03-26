using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreBullet : MonoBehaviour
{
    SwitchCharacter sw;
    public float speed;
    [Header("Seconds of bullet life time")]
    public float lifeTime;
    bool dragon;
    private GameObject Player;

    public ParticleSystem destroyEffect;


    private void Start()
    {
       sw = FindObjectOfType<SwitchCharacter>();
        Player = GameObject.FindGameObjectWithTag("Player");
        dragon = sw.dragonn;
    }

    private void Update()
    {
       
        dragon = sw.dragonn;
      
    }

    public void SetUp(Vector2 shootingDir)
    {


        Invoke("DestroyBullet", lifeTime);
        GetComponent<Rigidbody2D>().AddForce(shootingDir.normalized * speed, ForceMode2D.Impulse);
        //FindObjectOfType<AudioManager>().Play("attack");

    }


    void DestroyBullet()
    {
        //Iniciem efecte
        //Instantiate(destroyEffect, transform.position, transform.rotation);
        //Destruim la bala
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
         
         
            if (dragon)//Kknight
            {
                
                Player.GetComponent<Animator>().SetTrigger("isStuned");
                Player.GetComponent<PlayerMovment>().StopPlayer();
            }
            else//Drag
            {
                Player.GetComponent<Animator>().SetTrigger("isStuned");
                Player.GetComponent<Player2Moviment>().StopPlayer();
               
            }
            DestroyBullet();

        }

        if (collision.gameObject.tag == "Ground")
        {

            DestroyBullet();
        }
    }


}

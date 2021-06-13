using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizControl : MonoBehaviour
{
    // Start is called before the first frame update
    SwitchCharacter sw;
    public float speed;
    [Header("Seconds of bullet life time")]
    public float lifeTime;
    bool dragon;
    private GameObject Player;

    public ParticleSystem destroyEffect;
    public int orbeEnergyValue = 2;


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


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (sw.dragonn)
            {
                collision.gameObject.GetComponent<PlayerMovment>().DieP1();
                Destroy(gameObject);

            }
            else
            {
                collision.gameObject.GetComponent<Player2Moviment>().DieP2();
                Destroy(gameObject);
            }

        }

        if (collision.gameObject.tag == "Parry")
        {
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreBullet : MonoBehaviour
{

    public float speed;
    [Header("Seconds of bullet life time")]
    public float lifeTime;


    public ParticleSystem destroyEffect;

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
         
            DestroyBullet();
            
        }

        if (collision.gameObject.tag == "Ground")
        {

            DestroyBullet();
        }
    }


}

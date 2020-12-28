using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootController : MonoBehaviour
{
    public float speed;
   

    [Header("Seconds of bullet life time")]
    public float lifeTime;

    [HideInInspector]
    public Animator anim;
    public Rigidbody2D rb2d;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    public void SetUp(Vector2 shootingDir)
    {
        Invoke("DestroyBullet", lifeTime);
        GetComponent<Rigidbody2D>().AddForce(shootingDir.normalized * speed, ForceMode2D.Impulse);
    }

    void DestroyBullet()
    {
        //Iniciem efecte
        //Els dos el el coroutine
        StartCoroutine(TimingExplosion());
        //Destruim la bala
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            //CAMERA SHAKE

            //collision.gameObject.GetComponent<EnemyGusano>().TakeDamage(damage);


            //KnockBack de l'enemic
            DestroyBullet();

        }
    }

    IEnumerator TimingExplosion()
    {
        anim.SetTrigger("Explosion");
        rb2d.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);

    }
}

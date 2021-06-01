using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallScript : MonoBehaviour
{

    public Sprite[] breakStages;
   
    public float objectHealth;
    
    private Animator destoyedEffect;
    SpriteRenderer mySprite;
    public GameObject ExplosionPS;
    public GameObject WallD;
    public GameObject WallTop;
    
    // Start is called before the first frame update
    void Start()
    {
        destoyedEffect = gameObject.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FireBall")
        {
            GameObject Exp = Instantiate(ExplosionPS, transform.position, Quaternion.identity);
            Exp.GetComponent<ParticleSystem>().Play();
            GameObject Exp1 = Instantiate(ExplosionPS, WallD.transform.position, Quaternion.identity);
            Exp.GetComponent<ParticleSystem>().Play();
            GameObject Exp2 = Instantiate(ExplosionPS, WallTop.transform.position, Quaternion.identity);
            Exp.GetComponent<ParticleSystem>().Play();
            // Instantiate(destoyedEffect, transform.position, Quaternion.identity);
            gameObject.GetComponent<Animator>().SetTrigger("Destroy");

            Invoke("DestroyWall", 0.30f);
           
        }
    }

    void DestroyWall()
    {
        Destroy(gameObject);
        Destroy(WallD);
        Destroy(WallTop);

    }

    

}

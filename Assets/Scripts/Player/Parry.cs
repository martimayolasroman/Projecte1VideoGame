using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{

    public GameObject parry;
    float cooldown;

    [Header("Time of cooldown")]
    public float startCooldown;

    bool active;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Rigidbody2D rb2d;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        parry.SetActive(false);
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            if (active && Input.GetButtonDown("Fire1"))
            {
                //Animació de disparar
                //player.anim.SetTrigger("isAttacking");
                StartCoroutine(Parrying());
                cooldown = startCooldown;
            }
        }
        else
        {
            //Decrementem el cooldown
            cooldown -= Time.deltaTime;
        }
    }

    IEnumerator Parrying()
    {
        anim.SetTrigger("Parry");
        parry.SetActive(true);
        yield return new WaitForSeconds(1f);
        parry.SetActive(false);

    }

}


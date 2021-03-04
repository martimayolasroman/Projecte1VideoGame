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
    public bool isParring;
    JoyButton3 joyButton;
    void Start()
    {
        isParring = false;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        parry.SetActive(false);
        active = true;
        joyButton = FindObjectOfType<JoyButton3>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            if (joyButton.Pressed)
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
        isParring = true;
        yield return new WaitForSeconds(1f);
        parry.SetActive(false);
        isParring = false;

    }

}


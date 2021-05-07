using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
   public GameObject imgageJoy;
    bool isDoingColdown = false;
    PlayerMovment pm;

 

    void Start()
    {
        isParring = false;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        parry.SetActive(false);
        active = true;
        joyButton = FindObjectOfType<JoyButton3>();
        imgageJoy.GetComponent<Image>().fillAmount = 1;
        cooldown = startCooldown;
        pm = FindObjectOfType<PlayerMovment>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown >= startCooldown)
        {
            isDoingColdown = false;

            if (joyButton.Pressed)
            {
                //Animació de disparar
                //player.anim.SetTrigger("isAttacking");
                if (pm.rb.velocity.y == 0)
                {
                    StartCoroutine(Parrying());
                    cooldown = 0;
                }

            }

        }
        else
        {
            //Decrementem el cooldown
            cooldown+= Time.deltaTime;
            if (isDoingColdown)
            {

                imgageJoy.GetComponent<Image>().fillAmount = ((cooldown)/startCooldown);
                isDoingColdown = true;
            }
        }

        if (!isDoingColdown)
        {
            imgageJoy.GetComponent<Image>().fillAmount = 1;

        }

    }

    IEnumerator Parrying()
    {


        anim.SetTrigger("Parry");
        parry.SetActive(true);
        isDoingColdown = true;
        
        imgageJoy.GetComponent<Image>().fillAmount = 0;
        transform.gameObject.tag = "Parry";
        pm.StopPlayer();
        pm.canMove = false;
        isParring = true;
        yield return new WaitForSeconds(1f);
        transform.gameObject.tag = "Player";
        pm.canMove = true;

        parry.SetActive(false);
        isParring = false;



    }

}


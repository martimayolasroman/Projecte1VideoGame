using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    // References to Controlled game objects



    public Vector2 pos;

    public GameObject Personaje1;
    public GameObject Personaje2;
    bool canshift ;
    public bool dragonn ;
    public bool isTransforming;
    protected JoyButton2 joyButton2;




    // Start is called before the first frame update
    void Start()
    {

        Personaje2.SetActive(false);
        dragonn= true;
        canshift = true;
        isTransforming = false;
        joyButton2 = FindObjectOfType<JoyButton2>();


    }

    IEnumerator changeChar(float seconds,bool dragon)
    {
       isTransforming = true;

        yield return new WaitForSeconds(seconds);

        if (dragon == true)
        {
            Personaje1.transform.position = pos;
            Personaje1.SetActive(true);
            Personaje2.SetActive(false);
            canshift = true;


        }

        if (dragon == false)
        {
            Personaje2.transform.position = pos;
            Personaje1.SetActive(false);
            Personaje2.SetActive(true);
            canshift = true;


        }
        isTransforming = false;
    }

    //public void changeChar(bool dragon)
    //{
    //    if (dragon == true)
    //    {
            
    //        Personaje1.transform.position = pos;
    //        Personaje1.SetActive(true);
    //        Personaje2.SetActive(false);

           
    //    }

    //    if (dragon == false)
    //    {
    //       // Personaje2.GetComponent<Animator>().SetBool("isChangew", false);
    //        Personaje2.transform.position = pos;
    //        Personaje1.SetActive(false);
    //        Personaje2.SetActive(true);

    //    }


    //}



    // Update is called once per frame
    void Update()
    {
        //Input
        //Touch touch = Input.GetTouch(0);
        //Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        if (dragonn == true)
        {
           
           
            pos = Personaje2.transform.position;

        }

        else if (dragonn == false)
        {

            
            pos = Personaje1.transform.position;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift)  && canshift ==true || joyButton2.Pressed && canshift == true) 
        {
            canshift = false;
           // changeChar(dragon);

            if (dragonn == true)
            {
                Personaje1.GetComponent<Animator>().SetTrigger("Change");
                StartCoroutine(changeChar(0.6f, false));
                dragonn = false;
            }

            else if (dragonn == false)
            {
                Personaje2.GetComponent<Animator>().SetTrigger("Change");
                StartCoroutine(changeChar(0.5f, true));
                dragonn = true;

            }
            //Personaje1.transform.localScale = new Vector3(1.023534f, 1.127671f, 0.8834544f);
            //Personaje2.transform.localScale = new Vector3(1.293269f, 1.386773f, 1f);

        }
    }
}
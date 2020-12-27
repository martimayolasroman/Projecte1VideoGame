using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    // References to Controlled game objects


    bool dragon;

    public Vector2 pos;

    public GameObject Personaje1;
    public GameObject Personaje2;
    bool canshift ;
    bool dragonn ;





    // Start is called before the first frame update
    void Start()
    {

        Personaje2.SetActive(false);
        dragonn= true;
        canshift = true;

        
    }

   IEnumerator changeChar(float seconds,bool dragon)
    {

        yield return new WaitForSeconds(seconds);

        if (dragon == true)
        {
            Personaje2.GetComponent<Animator>().SetBool("isChangew", false);
            Personaje1.transform.position = pos;
            Personaje1.SetActive(true);
            Personaje2.SetActive(false);
            canshift = true;


        }

        if (dragon == false)
        {
            Personaje1.GetComponent<Animator>().SetBool("isChanging", false);
            Personaje2.transform.position = pos;
            Personaje1.SetActive(false);
            Personaje2.SetActive(true);
            canshift = true;


        }
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
        if (dragonn == true)
        {
           
           
            pos = Personaje2.transform.position;

        }

        else if (dragonn == false)
        {

            
            pos = Personaje1.transform.position;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift)  && canshift ==true) 
        {

            canshift = false;
           // changeChar(dragon);

            if (dragonn == true)
            {
                Personaje1.GetComponent<Animator>().SetBool("isChanging", true);
                StartCoroutine(changeChar(1.4f, false));
                dragonn = false;
            }

            else if (dragonn == false)
            {
                Personaje2.GetComponent<Animator>().SetBool("isChangew", true);
                StartCoroutine(changeChar(0.9f, true));
                dragonn = true;

            }
            Personaje1.transform.localScale = new Vector3(0.7914316f, 0.8131616f, 0.8834544f);
            Personaje2.transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }
}
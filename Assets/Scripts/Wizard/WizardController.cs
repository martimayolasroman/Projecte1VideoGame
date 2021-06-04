using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{

    public GameObject SlowPS;
 
    // Start is called before the first frame update
    public GameObject wiza1;
    public GameObject wiza2;
    public GameObject wiza3;

    [HideInInspector]
    public bool wiza1active = true;
    [HideInInspector]
    public bool wiza2active = false;
    [HideInInspector]
    public bool wiza3active = false;
    [HideInInspector]
    public bool wiz1Right, wiz1Left;
    [HideInInspector]
    public bool wiz2Right, wiz2Left;
    [HideInInspector]
    public bool wiz3Right, wiz3Left;

    [HideInInspector]
    public bool wiz1atac, wiz2atac, wiz3atac = false;

    GameObject player;
    public GameObject player1;
    public GameObject player2;
    SwitchCharacter sw;

    public GameObject clouds, thunder;
    public GameObject positionToElecricAtak;
    public GameObject cameraPos;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sw = FindObjectOfType<SwitchCharacter>();
       

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sw = FindObjectOfType<SwitchCharacter>();


        //activa personatges
        if (wiza1active)
        {
            StartCoroutine(Wizard1Move());
            wiza1active = false;
        }
        if (wiza2active)
        {
            StartCoroutine(Wizard2Move());
            wiza2active = false;

        }
        if (wiza3active)
        {
            StartCoroutine(Wizard3Move());
            wiza3active = false;

        }

        //Movment 
        if (wiz1Right)
        {

                if(player.GetComponent<Rigidbody2D>().velocity.x >= 0 && CamFollowPlayer.instance.transform.position.x - 7 >= wiza1.transform.position.x)
                {

                wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(7, 0, 0);

                 }

        }
        if (wiz1Left)
        {
            wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(15, 100, 100);

        }
        if (wiz2Right)
        {
            if (player.GetComponent<Rigidbody2D>().velocity.x >= 0 && CamFollowPlayer.instance.transform.position.x - 7 >= wiza2.transform.position.x)
            {

                wiza2.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(7, 0, 0);

            }

        }
        if (wiz2Left)
        {
            wiza2.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(15, 100, 100);

        }
        if (wiz3Right)
        {
            if (player.GetComponent<Rigidbody2D>().velocity.x >= 0 && CamFollowPlayer.instance.transform.position.x -7 >= wiza3.transform.position.x)
            {

                wiza3.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(7, 0, 0);

            }

        }
        if (wiz3Left)
        {
            wiza3.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(15,100, 100);

        }

        //Atac

        if (wiz3atac)
        {
            wiz3atac = false;
            StartCoroutine(Wizard3Atak());

        }

        if (wiz1atac)
        {

            wiz1atac = false;
            StartCoroutine(Wizard1Atak());
        }

    }




    IEnumerator Wizard1Move(){

        //Mou dreta       
        wiz1Right = true;
        //Ataca
        wiz1atac = true;
        yield return new WaitForSeconds(5f);
        //Mou esquerra
        wiz1Right = false;
        wiz1Left = true;
        wiz1atac = false;
        yield return new WaitForSeconds(1f);
        wiz1Left = false;
        //wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);
        //Activa2
        wiza2active = true;
        wiza1active = false;

    }
    IEnumerator Wizard2Move()
    {

        //Mou dreta       
      
        wiz2Right = true;
        //Ataca
        wiz2atac = true;
        yield return new WaitForSeconds(5f);
        //Mou esquerra
        wiz2Right = false;
        wiz2Left = true;
        wiz2atac = false;

        yield return new WaitForSeconds(1f);
        wiz2Left = false;
        //wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);
        //Activa2
        wiza3active = true;
        wiza2active = false;

    }
    IEnumerator Wizard3Move()
    {

        //Mou dreta       
       
        wiz3Right = true;
        wiz3atac = true;

        //Ataca

        yield return new WaitForSeconds(5f);
        //Mou esquerra
        wiz3Right = false;
        wiz3Left = true;
        yield return new WaitForSeconds(1f);
        wiz3Left = false;
        //wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);
        //Activa2
        wiza1active = true;
        wiza3active = false;

    }
    IEnumerator Wizard3Atak()
    {
        wiz3atac = false;
        wiza3.GetComponent<Animator>().SetTrigger("Atak");
        if (sw.dragonn)
        {
            
            
            player.GetComponent<PlayerMovment>().speed = 7;
            Instantiate(SlowPS, player2.transform.position, Quaternion.identity);

        }
        else
        {
            player.GetComponent<Player2Moviment>().speed = 7;
            Instantiate(SlowPS, player1.transform.position, Quaternion.identity);


        }
        yield return new WaitForSeconds(4f);

       
            player.GetComponent<PlayerMovment>().speed = 10;
            player.GetComponent<Player2Moviment>().speed = 10;

    }
    IEnumerator Wizard1Atak()
    {
        wiz1atac = false;
        yield return new WaitForSeconds(1f);
        positionToElecricAtak.transform.position = cameraPos.transform.position + new Vector3 (12,0,0);
        clouds.SetActive(true);
        //posa nubols
        wiza1.GetComponent<Animator>().SetTrigger("Atak");
        yield return new WaitForSeconds(1f);
        thunder.SetActive(true);
        //posa rayos
        yield return new WaitForSeconds(2f);
        
        clouds.SetActive(false);
        thunder.SetActive(false);

        //desactiva atac


    }


}

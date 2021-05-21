using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wiza1;
    public GameObject wiza2;
    public GameObject wiza3;

    private bool wiza1active = true;
    private bool wiza2active = false;
    private bool wiza3active = false;

    private bool wiz1Right, wiz1Left;
    private bool wiz2Right, wiz2Left;
    private bool wiz3Right, wiz3Left;

    private bool wiz1atac, wiz2atac, wiz3atac = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

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

            wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(7, 0, 0);

        }
        if (wiz1Left)
        {
            wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(15, 0, 0);

        }
        if (wiz2Right)
        {
            wiza2.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(7, 0, 0);

        }
        if (wiz2Left)
        {
            wiza2.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(15, 0, 0);

        }
        if (wiz3Right)
        {
            wiza3.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(7, 0, 0);

        }
        if (wiz3Left)
        {
            wiza3.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(15, 0, 0);

        }

        //Atac

        if (wiz1atac)
        {

        }

        if (wiz2atac)
        {


        }
        if (wiz3atac)
        {

        }


    }




    IEnumerator Wizard1Move(){

        //Mou dreta       
        wiz1Right = true;
        //Ataca
        wiz3atac = true;
        yield return new WaitForSeconds(5f);
        //Mou esquerra
        wiz1Right = false;
        wiz1Left = true;
        yield return new WaitForSeconds(1f);
        wiz1Left = false;
        //wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);
        //Activa2
        wiza2active = true;
    }
    IEnumerator Wizard2Move()
    {

        //Mou dreta       
      
        wiz2Right = true;
        wiz3atac = true;

        //Ataca

        yield return new WaitForSeconds(5f);
        //Mou esquerra
        wiz2Right = false;
        wiz2Left = true;
        yield return new WaitForSeconds(1f);
        wiz2Left = false;
        //wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);
        //Activa2
        wiza3active = true;
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
    }
}

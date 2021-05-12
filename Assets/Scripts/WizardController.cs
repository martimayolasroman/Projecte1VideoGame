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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        float step = 0.1f * Time.deltaTime; // calculate distance to move

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
          
            wiza1.GetComponent<Rigidbody2D>().MovePosition(wiza1.transform.position* step);

        }
        if (wiz1Left)
        {
            wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);

        }
        if (wiz2Right)
        {

        }
        if (wiz2Left)
        {

        }
        if (wiz3Right)
        {

        }
        if (wiz3Left)
        {

        }


    }

    IEnumerator Wizard1Move(){

        //Mou dreta       
        yield return new WaitForSeconds(2f);
        wiz1Right = true;

        //Ataca

        yield return new WaitForSeconds(5f);
        //Mou esquerra
        wiz1Right = false;
        wiz1Left = true;
        yield return new WaitForSeconds(2f);
        wiz1Left = false;
        //wiza1.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);
        //Activa2
        wiza2active = true;
    }
    IEnumerator Wizard2Move()
    {

        //Mou dreta
        yield return new WaitForSeconds(2f);
 
        //Ataca
        yield return new WaitForSeconds(5f);
        //Mou esquerra
        yield return new WaitForSeconds(2f);
        wiza2.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);

        //Activa2
        wiza3active = true;
    }
    IEnumerator Wizard3Move()
    {

        //Mou dreta

        yield return new WaitForSeconds(2f);
        wiza3.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(7, 0, 0);
        //Ataca

        yield return new WaitForSeconds(5f);
        //Mou esquerra

        yield return new WaitForSeconds(2f);
        wiza3.transform.position = CamFollowPlayer.instance.transform.position - new Vector3(10, 0, 0);
        //Activa2
        wiza1active = true;
    }
}

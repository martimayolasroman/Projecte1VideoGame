using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class SwitchCharacter : MonoBehaviour
{
    // References to Controlled game objects

    private AudioSource audioPlayer;

    public AudioClip TransToDrake;

    public Vector2 pos;

    public GameObject Personaje1;
    public GameObject Personaje2;
    bool canshift ;
    public bool dragonn ;
    public bool isTransforming;
    protected JoyButton2 joyButton2;
    public Sprite dragonnn;
    public Sprite knight;
    public GameObject JoystickChange;
    public Button jumpChangeButton;
    public GameObject runButton;
    public Sprite runK;
    public Sprite runD;
    public Sprite jumpK;
    public Sprite jumpD;
    public GameObject Attak1;
    public GameObject Attak2;
    public GameObject Attak1B;
    public GameObject Attak2B;

    public GameObject BlackFiltre;
   // public Image BlackSwich;
    public EnergyBar energyBarScript;

    // Start is called before the first frame update
    void Start()
    {

        Personaje2.SetActive(false);
        dragonn= true;
        canshift = true;
        isTransforming = false;
        joyButton2 = FindObjectOfType<JoyButton2>();
        Attak1.SetActive(true);
        Attak2.SetActive(false);
        Attak1B.SetActive(true);
        Attak2B.SetActive(false);
        BlackFiltre.GetComponent<Image>();
        audioPlayer = GetComponent<AudioSource>();

    }

    public IEnumerator changeChar(float seconds,bool dragon)
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

        if (!dragonn)
        {
            JoystickChange.GetComponent<Image>().sprite = knight;
            jumpChangeButton.GetComponent<Image>().sprite = jumpD;
            runButton.GetComponent<Image>().sprite = runD;
            Attak1.SetActive(false);
            Attak2.SetActive(true);
            Attak1B.SetActive(false);
            Attak2B.SetActive(true);

        }
        else
        {
            JoystickChange.GetComponent<Image>().sprite = dragonnn;
            jumpChangeButton.GetComponent<Image>().sprite = jumpK;
            runButton.GetComponent<Image>().sprite = runK;
            Attak1.SetActive(true);
            Attak2.SetActive(false);
            Attak1B.SetActive(true);
            Attak2B.SetActive(false);

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
        //Input
        //Touch touch = Input.GetTouch(0);
        //Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        if(energyBarScript.energy == 100)
        {
            BlackFiltre.SetActive(false); 

        }
        if(energyBarScript.energy <=0 && dragonn)
        {
            BlackFiltre.SetActive(true);
        }

        if (dragonn == true)
        {
           
           
            pos = Personaje2.transform.position;

        }

        else if (dragonn == false)
        {

            
            pos = Personaje1.transform.position;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift)  && canshift ==true || joyButton2.Pressed && canshift == true && energyBarScript.energy > 0 || ((Input.GetKeyDown(KeyCode.LeftShift) && dragonn && canshift == true)) || (joyButton2.Pressed && canshift == true && !dragonn)) 
        {
            canshift = false;
            // changeChar(dragon);
            

            if (dragonn == true)
            {
                //audioPlayer.clip = TransToDrake;
               // audioPlayer.Play();
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
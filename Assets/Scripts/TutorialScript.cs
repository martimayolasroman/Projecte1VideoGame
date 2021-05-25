using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{

    private int countTutorial = 0;
    //----TutorialBox1
    public Image MovmentTutorial;
    public Image ArrowTouchPad;
    public Image ArrowJump;
    public Image ArrowParry;
   
    public GameObject SkipButton;
    //----TutorialBox2
    public Image Fire;
    public Image ArrowFire;


    // Start is called before the first frame update
    void Start()
    {
        MovmentTutorial.enabled = false;
        ArrowTouchPad.enabled = false;
        ArrowJump.enabled = false;
        ArrowParry.enabled = false;
        SkipButton.SetActive(false);
        Fire.enabled = false;
        ArrowFire.enabled = false;
}

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tutorial")
        {
            Time.timeScale = 0;
            switch (countTutorial)
            {
                case 0:
                   
                    MovmentTutorial.enabled = true;
                    ArrowTouchPad.enabled = true;
                    ArrowJump.enabled = true;
                    ArrowParry.enabled = true;
                    SkipButton.SetActive(true);
                    countTutorial++;
                    break;
                case 1:
                    Fire.enabled = true;
                    ArrowFire.enabled = true;
                    SkipButton.SetActive(true);
                    countTutorial++;
                    break;
            }
            
        }
    }

    public void Skip()
    {
        Time.timeScale = 1;
        MovmentTutorial.enabled = false;
        ArrowTouchPad.enabled = false;
        ArrowJump.enabled = false;
        ArrowParry.enabled = false;
        SkipButton.SetActive(false);
        Fire.enabled = false;
        ArrowFire.enabled = false;
        



    }
}

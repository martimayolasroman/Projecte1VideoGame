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
    
    public GameObject TB1BB;
    
   
    public GameObject SkipButton;
    //----TutorialBox2
    public Image Fire;
    public Image ArrowFire;
    public GameObject TB2BB;

    //----TutorialBox3

    public Image tutorialBox3;
    public Image ArrowOrb;
    public GameObject TB3BB;

    //----TutorialBox4

    public Image tutorialBox4;
    public Image ArrowTransform;
    public Image ArrowEnerBar;
    public Image ArrowWall;
    public GameObject TB4BB;
    //----TutorialBox5
    public Image tutorialBox5;
    public GameObject TB5BB;

    // Start is called before the first frame update
    void Start()
    {
        SkipButton.SetActive(false);
        //----TutorialBox1
        MovmentTutorial.enabled = false;
        ArrowTouchPad.enabled = false;
        ArrowJump.enabled = false;
        ArrowParry.enabled = false;
        //----TutorialBox2
        Fire.enabled = false;
        ArrowFire.enabled = false;
        //----TutorialBox3
        tutorialBox3.enabled = false;
        ArrowOrb.enabled = false;
        //----TutorialBox4

        tutorialBox4.enabled = false;
        ArrowTransform.enabled = false;
        ArrowEnerBar.enabled = false;
        ArrowWall.enabled = false;

        //----TutorialBox5

        tutorialBox5.enabled = false;


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
                    TB1BB.GetComponent<BoxCollider2D>().enabled = false;
                    countTutorial++;
                    break;
                case 1:
                    Fire.enabled = true;
                    ArrowFire.enabled = true;
                    SkipButton.SetActive(true);
                    TB2BB.GetComponent<BoxCollider2D>().enabled = false;
                    countTutorial++;
                    break;

                case 2:
                    tutorialBox3.enabled = true;
                    ArrowOrb.enabled = true;
                    SkipButton.SetActive(true);
                    TB3BB.GetComponent<BoxCollider2D>().enabled = false;
                    countTutorial++;
                    break;
                case 3:

                    tutorialBox4.enabled = true;
                    ArrowTransform.enabled = true;
                    ArrowEnerBar.enabled = true;
                    ArrowWall.enabled = true;
                    SkipButton.SetActive(true);
                    TB4BB.GetComponent<BoxCollider2D>().enabled = false;
                    countTutorial++;
                    break;

                case 4:
                    tutorialBox5.enabled = true;
                    SkipButton.SetActive(true);
                    TB5BB.GetComponent<BoxCollider2D>().enabled = false;
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
        tutorialBox3.enabled = false;
        ArrowOrb.enabled = false;

        tutorialBox4.enabled = false;
        ArrowTransform.enabled = false;
        ArrowEnerBar.enabled = false;
        ArrowWall.enabled = false;
        tutorialBox5.enabled = false;

    }
}

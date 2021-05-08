using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public bool isactive = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isactive)
            {
                pauseMenu.SetActive(false);
                isactive = false;
                Time.timeScale = 1;

            }
            else
            {
                pauseMenu.SetActive(true);
                isactive = true;
                Time.timeScale = 0;


            }

        }

        
     
    }

    
}

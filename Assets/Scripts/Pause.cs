using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseCont;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void escenaRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;



    }

    public void LEVELSELECTOR()
    {
        SceneManager.LoadScene("LevelSelector");
        Time.timeScale = 1;


    }
    public void MENU()
    {
        SceneManager.LoadScene("MENU");

        Time.timeScale = 1;

    }
    public void Exit()
    {
        Application.Quit();

    }

    public void Resume()
    {

        PauseCont.GetComponent<PauseController>().pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        PauseCont.GetComponent<PauseController>().isactive = false;


    }

    public void Music()
    {
       // music.SwichSonido();

    }
}

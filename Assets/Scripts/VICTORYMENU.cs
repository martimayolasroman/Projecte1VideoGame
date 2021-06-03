using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VICTORYMENU : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victoryMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        victoryMenu.SetActive(false);

    }

    public void LEVELSELECTOR()
    {
        SceneManager.LoadScene("LevelSelector");
        Time.timeScale = 1;
        victoryMenu.SetActive(false);


    }
    public void MENU()
    {
        SceneManager.LoadScene("MENU");
        Time.timeScale = 1;
        victoryMenu.SetActive(false);

    }
    public void Exit()
    {
        Application.Quit();

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSlectorButtons : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {

        

        
    }

    public void Level1()
    {
        SceneManager.LoadScene("PrototypLevel");
    }
    
    public void Level2()
    {
        SceneManager.LoadScene("LEVEL2F");
        Debug.Log("jj");
    }

    public void Level3()
    {

    }

    public void Level4()
    {

    }
}

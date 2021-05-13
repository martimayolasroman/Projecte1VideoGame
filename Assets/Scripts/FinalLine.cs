﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victoryMenu;

    void Start()
    {
        victoryMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            victoryMenu.SetActive(true);
            Time.timeScale =0;

        }
    }
}

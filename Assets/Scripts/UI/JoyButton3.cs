﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton3 : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool Pressed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;

    }
}
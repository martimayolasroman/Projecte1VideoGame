using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class JoyButton2 : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    // Start is called before the first frame update

    [HideInInspector]
    public bool Pressed;

    SwitchCharacter sw;
    public Sprite dragon;
    public Sprite knight;

    void Start()
    {
        sw = FindObjectOfType<SwitchCharacter>();

    }

    // Update is called once per frame
    void Update()
    {

        if (sw.dragonn)
        {
            GetComponent<Image>().sprite = dragon;
        }
        else
        {
            GetComponent<Image>().sprite = knight;

        }

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

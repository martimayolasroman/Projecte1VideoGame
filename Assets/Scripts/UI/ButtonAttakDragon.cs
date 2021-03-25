using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAttakDragon : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    bool canAtack = false;
    [HideInInspector]
    public  Vector2 pos;
    public GameObject joystick;

 
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pressed)
        {
            pos = new Vector2(joystick.GetComponent<Joystick>().Horizontal, joystick.GetComponent<Joystick>().Vertical);

        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        canAtack = true;
        Pressed = false;

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (canAtack)
        {
            Pressed = true;
            StartCoroutine(ColldownCA());
        }
        canAtack = false;
    }
    IEnumerator ColldownCA()

    {
        yield return new WaitForSeconds(0.1f);
        Pressed = false;

    }
}

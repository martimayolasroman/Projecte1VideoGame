//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;


//public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler /*IPointerClickHandler*/
//{
//    // Start is called before the first frame update

//    [HideInInspector]
//    public bool Pressed;

//    SwitchCharacter sw;
//    public Sprite jumpD;
//    bool once;
//    public Sprite jumpK;

//    void Start()
//    {
//        sw = FindObjectOfType<SwitchCharacter>();

//    }

//    // Update is called once per frame
//    void Update()
//    {

//        if (sw.dragonn)
//        {
//            GetComponent<Image>().sprite = jumpK;
//        }
//        else
//        {
//            GetComponent<Image>().sprite = jumpD;

//        }

//    }
//    //public void OnPointerClick(PointerEventData eventData)
//    //{
//    //    Pressed = true;
//    //}
//    public void OnPointerDown(PointerEventData eventData)
//    {
//        //if
//        Pressed = true;
//    }
//    public void OnPointerUp(PointerEventData eventData)
//    {
//        Pressed = false;

//    }
    

//}

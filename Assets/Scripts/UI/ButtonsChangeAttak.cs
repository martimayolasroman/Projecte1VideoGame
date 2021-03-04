using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsChangeAttak : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject Attak1;
    public GameObject Attak2;
    SwitchCharacter sw;

    void Start()
    {
        Attak1.SetActive(true);
        Attak2.SetActive(false);
        sw = FindObjectOfType<SwitchCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sw.dragonn)
        {
            Attak1.SetActive(true);
            Attak2.SetActive(false);

        }
        else
        {
            Attak1.SetActive(false);
            Attak2.SetActive(true);
        }
    }
}

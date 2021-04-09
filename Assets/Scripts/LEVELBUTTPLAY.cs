using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVELBUTTPLAY : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;

    void Start()
    {
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveB1()
    {
        b1.SetActive(true);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);


    }
    public void ActiveB2()
    {

        b2.SetActive(true);
        b1.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);

    }

    public void ActiveB3()
    {

        b3.SetActive(true);
        b2.SetActive(false);
        b1.SetActive(false);
        b4.SetActive(false);

    }

    public void ActiveB4()
    {
        b4.SetActive(true);
        b1.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);
    }
}

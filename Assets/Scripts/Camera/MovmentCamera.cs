using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentCamera : MonoBehaviour
{

    private float movementSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = 2f;
        //get the Input from Vertical axis
        float verticalInput = 1;

        //update the position
        var tmp = transform.position;
        tmp.x += (horizontalInput * movementSpeed * Time.deltaTime);
        transform.position = tmp;
        Debug.Log(tmp);
    }
}


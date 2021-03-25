using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentCamera : MonoBehaviour
{

    private float movementSpeed = 1f;
    int counterSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 1f;
        counterSpeed = 0;
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
        Debug.Log(movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "ChangeSpeed" && counterSpeed == 0)
        {
            movementSpeed = 1.25f;
            StartCoroutine(CanChangeVel());

        }
        if (other.gameObject.tag == "ChangeSpeed" && counterSpeed == 1)
        {
            movementSpeed = 1.5f;
            StartCoroutine(CanChangeVel());
        }


        if (other.gameObject.tag == "ChangeSpeed" && counterSpeed == 2)
        {
            movementSpeed = 1.75f;

        }

    }


    IEnumerator CanChangeVel()
    {

        yield return new WaitForSeconds(3);
        counterSpeed++;


    }
}



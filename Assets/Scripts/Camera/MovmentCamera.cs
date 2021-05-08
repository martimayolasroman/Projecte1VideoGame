using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentCamera : MonoBehaviour
{

    public float movementSpeed = 2f;
    int counterSpeed = 0;
    public bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        //movementSpeed = 1f;
        counterSpeed = 0;
    }

    void Update()
    {


        //get the Input from Horizontal axis
        float horizontalInput = 2f;
        //get the Input from Vertical axis
        float verticalInput = 1;

        //update the position
        if (canMove)
        {
            var tmp = transform.position;
            tmp.x += (horizontalInput * movementSpeed * Time.deltaTime);
            transform.position = tmp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("ChangeSpeed"))// && counterSpeed == 0)
        {
            movementSpeed = 3.5f;
            StartCoroutine(CanChangeVel());

        }
        if (other.CompareTag("ChangeSpeed") && counterSpeed == 1)
        {
            movementSpeed = 4f;
            StartCoroutine(CanChangeVel());
        }


        if (other.CompareTag("ChangeSpeed") && counterSpeed == 2)
        {
            movementSpeed = 4.5f;

        }
    }

   
    IEnumerator CanChangeVel()
    {

        yield return new WaitForSeconds(1);
        counterSpeed++;


    }
}



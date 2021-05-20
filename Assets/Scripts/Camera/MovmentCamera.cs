using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovmentCamera : MonoBehaviour
{

    public float movementSpeed = 2f;
    int counterSpeed = 0;
    public bool canMove = false;
    // Start is called before the first frame update
    public TMP_Text FirstCounter;
    public TMP_Text SecondCounter;
    public TMP_Text ThirdCounter;

    void Start()
    {
        //movementSpeed = 1f;
        counterSpeed = 0;
        FirstCounter.gameObject.SetActive(false);
        SecondCounter.gameObject.SetActive(false);
        ThirdCounter.gameObject.SetActive(false);
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

        if (other.gameObject.CompareTag("ChangeSpeed") && counterSpeed == 0)
        {
            movementSpeed = 3.5f;
            StartCoroutine(CanChangeVel());
            FirstCounter.gameObject.SetActive(true);
            StartCoroutine(TurnOffVelocities());

        }
        if (other.CompareTag("ChangeSpeed") && counterSpeed == 1)
        {
            movementSpeed = 4f;
            StartCoroutine(CanChangeVel());
           SecondCounter.gameObject.SetActive(true);
            StartCoroutine(TurnOffVelocities());
        }


        if (other.CompareTag("ChangeSpeed") && counterSpeed == 2)
        {
            movementSpeed = 4.5f;
           ThirdCounter.gameObject.SetActive(true);
            StartCoroutine(TurnOffVelocities());
        }
    }

   
    IEnumerator CanChangeVel()
    {

        yield return new WaitForSeconds(1);
        counterSpeed++;


    }

    IEnumerator TurnOffVelocities()
    {

        yield return new WaitForSeconds(1);

        FirstCounter.gameObject.SetActive(false);
        SecondCounter.gameObject.SetActive(false);
        ThirdCounter.gameObject.SetActive(false);
        Debug.Log("QUITA BUG");
    }
}



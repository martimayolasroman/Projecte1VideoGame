using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebat : MonoBehaviour
{

    public GameObject Bat;
    public float moveSpeed = -5f;
    
    bool StartMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (StartMove)
        {
            //var temp = Bat.transform.position;
            //Debug.Log(temp);
            //temp.x -= 2 * moveSpeed * Time.deltaTime;
            //transform.position = temp ;
            Bat.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, Bat.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Move Bat");
            StartMove = true;

        }
    }
}

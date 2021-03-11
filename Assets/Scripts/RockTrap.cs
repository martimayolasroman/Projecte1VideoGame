using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap : MonoBehaviour
{



    Animator rockAnim;
   
    // Start is called before the first frame update

    void Start()
    {
        rockAnim = gameObject.GetComponent<Animator>();
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rockAnim.SetTrigger("ThrowRock");
            
        }
    }

   
}

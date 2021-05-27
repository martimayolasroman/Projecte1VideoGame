using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrap : MonoBehaviour
{

    private AudioSource audioPlayer;
    public AudioClip RockClip;

    Animator rockAnim;
   
    // Start is called before the first frame update

    void Start()
    {
        rockAnim = gameObject.GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();

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

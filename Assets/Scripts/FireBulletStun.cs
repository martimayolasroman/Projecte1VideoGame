using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletStun : MonoBehaviour
{
    public GameObject Knight;
    public GameObject Dragon;
    Animator KnightStunAnim;
    Animator DragonStunAnim;
    // Start is called before the first frame update
    void Start()
    {
        KnightStunAnim = Knight.GetComponent<Animator>();
        DragonStunAnim = Knight.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {

            //ResetScene de moment
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            KnightStunAnim.SetBool("isStuned", true);
            DragonStunAnim.SetBool("isStuned", true);
            Debug.Log("Stun");

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatKill : MonoBehaviour
{
    // Start is called before the first frame update
    SwitchCharacter sw;
    bool dragon;
    public int orbeEnergyValue = 4;
    public EnergyBar EnergyBarScript;

    void Start()
    {
        sw = FindObjectOfType<SwitchCharacter>();
        dragon = sw.dragonn;

    }

    // Update is called once per frame
    void Update()
    {

        dragon = sw.dragonn;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (dragon)
            {
                collision.gameObject.GetComponent<PlayerMovment>().DieP1();
                Destroy(gameObject);

            }
            else
            {
                collision.gameObject.GetComponent<Player2Moviment>().DieP2();
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Parry")
        {
            EnergyBarScript.PlusEnergy(orbeEnergyValue);
            Destroy(gameObject);

        }

    }

}

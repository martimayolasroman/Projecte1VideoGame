using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip coinSound, fireBall, jump, drakeTransform, atackCab, colisionWall;

    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        coinSound = Resources.Load<AudioClip>("Coin");
        fireBall = Resources.Load<AudioClip>("fireBall");
        jump = Resources.Load<AudioClip>("Tap2");
        drakeTransform = Resources.Load<AudioClip>("drakeTrans");
        atackCab = Resources.Load<AudioClip>("ESPADA");
        colisionWall = Resources.Load<AudioClip>("Rock");     

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {



    }

    public static void PlaySound(string clip)
    {

        switch (clip)
        {

            case "Coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "fireBall":
                audioSrc.PlayOneShot(fireBall);
                break;
            case "Tap2":
                audioSrc.PlayOneShot(jump);
                break;
            case "drakeTrans":
                audioSrc.PlayOneShot(drakeTransform);
                break;
            case "ESPADA":
                audioSrc.PlayOneShot(atackCab);
                break;
            case "Rock":
                audioSrc.PlayOneShot(colisionWall);
                break;
            default:
                break;

        }
    }
}

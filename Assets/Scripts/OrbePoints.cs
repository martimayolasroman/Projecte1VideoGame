using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbePoints : MonoBehaviour
{
    // Start is called before the first frame update

    public int orbeEnergyValue = 10;
    public EnergyBar EnergyBarScript;
    private AudioSource audioPlayer;
    public AudioClip OrbeClip;

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           // audioPlayer.clip = OrbeClip;
           // audioPlayer.Play();
            EnergyBarScript.PlusEnergy(orbeEnergyValue);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DestroyOrbe());   

        }
    }

    IEnumerator DestroyOrbe()
    {    
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
       
    }
}

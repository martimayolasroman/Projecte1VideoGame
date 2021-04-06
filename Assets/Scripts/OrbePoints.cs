using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbePoints : MonoBehaviour
{
    // Start is called before the first frame update

    public int orbeEnergyValue = 10;
    public EnergyBar EnergyBarScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            EnergyBarScript.PlusEnergy(orbeEnergyValue);
            gameObject.SetActive(false);
        }
    }
}

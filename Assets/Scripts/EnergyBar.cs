using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Text energyText;
    public Image[] EnergyPoints;
    public float maxTime = 10;
    public float timeLeft;
    SwitchCharacter sw;
    bool dragon;


    public float energy, maxEnergy = 10;

   


    // Start is called before the first frame update
    void Start()
    {
        maxTime = 100;
        energy = 0;
        timeLeft = maxTime;
        sw = FindObjectOfType<SwitchCharacter>();
        dragon = sw.dragonn;
    }

    // Update is called once per frame
   
    private void Update()
    {
        // dragon = sw.dragonn;
        //Debug.Log(Time.deltaTime);
       // Debug.Log("dsadf");
        if (energy > maxEnergy) energy = maxEnergy;

        EnergyBarFiller();


        if (!sw.dragonn)
        {
            if (energy > 0)
            {
                energy -= 16*Time.deltaTime;
                

                DecrisBar();

            }
        }
    }

    public void EnergyBarFiller()
    {
        
        for(int i = 0; i < EnergyPoints.Length; i++)
        {
            EnergyPoints[i].enabled = !DisplayEnergyPoints(energy, i);
        }
    }

  

    public void DecrisBar()
    {
       // timeLeft = maxTime;
        //Quant passi temps restar barra.
       // energy =  energy - 0.03f;

        if (energy <= 0)
        {
            energy = 0;
            sw.dragonn = true;
          
           sw.Personaje2.GetComponent<Animator>().SetTrigger("Change");
           sw.StartCoroutine(sw.changeChar(0.5f, true));
           // timeLeft = maxTime;

        }
    }

    public void PlusEnergy(float EnergyPoints)
    {
        if(energy < maxEnergy)
        {
            energy += EnergyPoints;
        }
    }

    bool DisplayEnergyPoints(float _energy,int pointNumber)
    {
        return ((pointNumber * 10) >= _energy);
    }
}

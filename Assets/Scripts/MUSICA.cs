using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MUSICA : MonoBehaviour
{

    public static bool gameP;
    public GameObject SonidoP;

    private AudioSource audioS;
    public Slider VSlider;
    // Start is called before the first frame update
    void Start()
    {
        SonidoP.SetActive(false);
        audioS = GetComponent<AudioSource>();
        VSlider.value = PlayerPrefs.GetFloat("sonidoVolumen", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        audioS.volume = VSlider.value;
    }

    public void SwichSonido()
    {
        if (gameP)
        {
            bntResume();
        }
        else
        {
            bntPause();
        }
    }

    void bntResume()
    {
        SonidoP.SetActive(false);
        Time.timeScale = 1;
        gameP = false;
        PlayerPrefs.SetFloat("sonidoVolumen", audioS.volume);
    }
    void bntPause()
    {
        SonidoP.SetActive(true);
        Time.timeScale = 0;
        gameP = true;
    }
}

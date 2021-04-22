using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuAudioManager : MonoBehaviour
{

    public Text toggleMusic;
    public Sprite newImage;
    public Sprite exImage;
    public Button button;

    private void Start()
    {
        
        if (BgScript.BgInstance.Audio.isPlaying)
        {
            //toggleMusic.text = "OFF";
            button.image.sprite = newImage;
}
        else
        {
            //toggleMusic.text = "ON";
            button.image.sprite = exImage;
        }
    }

    public void MusicToggle()
    {
        if (BgScript.BgInstance.Audio.isPlaying)
        {
            BgScript.BgInstance.Audio.Pause();
            //toggleMusic.text = "ON";
            button.image.sprite = exImage;
        }
        else
        {
            BgScript.BgInstance.Audio.Play();
    //toggleMusic.text = "OFF";
    button.image.sprite = newImage;
}
    }


}

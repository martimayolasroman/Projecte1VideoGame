using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_manager : MonoBehaviour
{

    public AudioSource Audio;

    public AudioClip Click;

    public static SFX_manager sfxInstance;
    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
